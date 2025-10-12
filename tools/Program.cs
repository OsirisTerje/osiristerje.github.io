using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

// Idempotent cleanup tool implementing conservative transformations.
// Usage: dotnet run -- <path-to-markdown-file>

if (args.Length == 0)
{
    Console.WriteLine("Usage: CleanupTool <file.md>");
    return;
}

var path = args[0];
if (!File.Exists(path))
{
    Console.WriteLine($"File not found: {path}");
    return;
}

string original = File.ReadAllText(path);
string updated = original;

// placeholder map to avoid double-conversion
var placeholders = new Dictionary<string, string>(StringComparer.Ordinal);
int tokenCounter = 0;
Func<string> NextToken = () => $"__T_{tokenCounter++}__";

// 1) Anchor-wrapped images -> placeholders
updated = ReplaceAnchorWrappedImagesWithPlaceholders(updated, placeholders, NextToken);

// 2) Standalone <img> -> placeholders
updated = ReplaceImgTagsWithPlaceholders(updated, placeholders, NextToken);

// 3) Convert simple anchors to markdown (won't touch placeholders)
updated = ConvertAnchorsToMarkdown(updated);

// 4) Paragraphs
updated = ConvertParagraphTags(updated);

// 5) strong / emphasis
updated = ConvertStrongAndEmphasis(updated);

// 6) Normalize code fences and add language heuristics
updated = NormalizeFencedCodeBlocks(updated);

// 7) Restore placeholders to final markdown
foreach (var kv in placeholders)
    updated = updated.Replace(kv.Key, kv.Value);

// 8) Final whitespace fixes
updated = FixTrailingWhitespaceAndNewline(updated);

if (updated != original)
{
    File.WriteAllText(path, updated);
    Console.WriteLine($"Updated: {path}");
}
else
{
    Console.WriteLine($"No changes for: {path}");
}


// --- Methods ---

static string ReplaceAnchorWrappedImagesWithPlaceholders(string text, Dictionary<string, string> placeholders, Func<string> tokenFactory)
{
    var regex = new Regex(@"<a\b[^>]*?href\s*=\s*""(?<href>[^""]+)""[^>]*>\s*<img\b(?<imgattrs>[^>]*)>\s*</a>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
    return regex.Replace(text, m =>
    {
        var href = m.Groups["href"].Value.Trim();
        var imgattrs = m.Groups["imgattrs"].Value;
        var src = CaptureAttribute(imgattrs, "src") ?? string.Empty;
        var alt = CaptureAttribute(imgattrs, "alt") ?? CaptureAttribute(imgattrs, "title") ?? Path.GetFileName(src) ?? "image";
        var md = $"[![{alt}]({src})]({href})";
        var token = tokenFactory();
        placeholders[token] = md;
        return token;
    });
}

static string ReplaceImgTagsWithPlaceholders(string text, Dictionary<string, string> placeholders, Func<string> tokenFactory)
{
    var regex = new Regex(@"<img\b(?<imgattrs>[^>]*)>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
    return regex.Replace(text, m =>
    {
        var imgattrs = m.Groups["imgattrs"].Value;
        var src = CaptureAttribute(imgattrs, "src") ?? string.Empty;
        var alt = CaptureAttribute(imgattrs, "alt") ?? CaptureAttribute(imgattrs, "title") ?? Path.GetFileName(src) ?? "image";
        var md = $"![{alt}]({src})";
        var token = tokenFactory();
        placeholders[token] = md;
        return token;
    });
}

static string ConvertAnchorsToMarkdown(string text)
{
    var regex = new Regex(@"<a\b[^>]*?href\s*=\s*""(?<href>[^""]+)""[^>]*>(?<text>.*?)</a>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
    return regex.Replace(text, m =>
    {
        var href = m.Groups["href"].Value.Trim();
        var inner = StripTags(m.Groups["text"].Value).Trim();
        if (string.IsNullOrEmpty(inner)) inner = href;
        return $"[{inner}]({href})";
    });
}

static string StripTags(string html)
{
    return Regex.Replace(html, "<.*?>", string.Empty, RegexOptions.Singleline).Replace("\r\n", " ").Replace("\n", " ").Trim();
}

static string ConvertParagraphTags(string text)
{
    var regex = new Regex(@"<p\b[^>]*>(?<inner>.*?)</p>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
    return regex.Replace(text, m =>
    {
        var inner = m.Groups["inner"].Value.Trim();
        return inner + "\n\n";
    });
}

static string ConvertStrongAndEmphasis(string text)
{
    text = Regex.Replace(text, @"<(?:strong|b)\b[^>]*>(.*?)</(?:strong|b)>", "**$1**", RegexOptions.IgnoreCase | RegexOptions.Singleline);
    text = Regex.Replace(text, @"<(?:em|i)\b[^>]*>(.*?)</(?:em|i)>", "*$1*", RegexOptions.IgnoreCase | RegexOptions.Singleline);
    return text;
}

static string NormalizeFencedCodeBlocks(string text)
{
    // Match unlabeled fences (``` followed by newline) and infer language
    var pattern = new Regex(@"(?m)^```[ \t]*\r?\n(?<body>.*?)(?=\r?\n```)", RegexOptions.Singleline);
    return pattern.Replace(text, m =>
    {
        var body = m.Groups["body"].Value;
        var lang = InferLanguageFromCode(body);
        return $"```{lang}\n{body}";
    });
}

static string InferLanguageFromCode(string body)
{
    var sample = body.Length > 1000 ? body.Substring(0, 1000) : body;
    if (Regex.IsMatch(sample, @"^\s*(PS |PS>|C:\\|C:\s*>)", RegexOptions.IgnoreCase | RegexOptions.Multiline) ||
        Regex.IsMatch(sample, @"\b(msbuild|nuget|dotnet|git|devenv)\b", RegexOptions.IgnoreCase))
        return "cmd";
    if (sample.Contains("<") && sample.Contains(">"))
        return "xml";
    return "text";
}

static string FixTrailingWhitespaceAndNewline(string text)
{
    text = Regex.Replace(text, @"[ \t]+(\r?$)", "$1", RegexOptions.Multiline);
    text = text.TrimEnd('\r', '\n') + Environment.NewLine;
    return text;
}

static string? CaptureAttribute(string? attrs, string name)
{
    if (string.IsNullOrEmpty(attrs)) return null;
    var m = Regex.Match(attrs, $@"\b{name}\s*=\s*""(?<v>[^""]*)""", RegexOptions.IgnoreCase);
    return m.Success ? m.Groups["v"].Value : null;
}
