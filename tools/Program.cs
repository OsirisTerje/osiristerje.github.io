using System.Text.RegularExpressions;

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
var sw = new System.Diagnostics.Stopwatch();
sw.Start();
string original = File.ReadAllText(path);
string updated = original;

Console.WriteLine($"Read file: {sw.Elapsed}");

// Remove unwanted frontmatter keys that come from the old WP export (idempotent)
updated = RemoveUnwantedFrontmatterEntries(updated);

// placeholder map to avoid double-conversion
var placeholders = new Dictionary<string, string>(StringComparer.Ordinal);
int tokenCounter = 0;
Func<string> NextToken = () => $"__T_{tokenCounter++}__";

// 1) Anchor-wrapped images -> placeholders
updated = ReplaceAnchorWrappedImagesWithPlaceholders(updated, placeholders, NextToken);

// 2) Standalone <img> -> placeholders
updated = ReplaceImgTagsWithPlaceholders(updated, placeholders, NextToken);

// 2.1) Convert WordPress image blocks <!-- wp:image {..} --> ... <!-- /wp:image -->
updated = ConvertWpImageBlocks(updated, placeholders, NextToken);

// 2.5) Remove WordPress block comments like <!-- wp:paragraph --> and <!-- /wp:heading -->
updated = RemoveWordpressBlockComments(updated);

// 2.6) Convert WordPress list blocks <!-- wp:list {..} --> ... <!-- /wp:list --> to markdown lists
updated = ConvertWpListBlocks(updated);

// 5.1) HTML headings -> Markdown headings/bold
updated = ConvertHtmlHeadingsToMarkdown(updated);

// 3) Convert simple anchors to markdown (won't touch placeholders)
updated = ConvertAnchorsToMarkdown(updated);

// 4) Paragraphs
updated = ConvertParagraphTags(updated);

// 5) strong / emphasis
updated = ConvertStrongAndEmphasis(updated);

// 4.5) Convert WordPress <!-- wp:code --> ... <!-- /wp:code --> blocks to fenced code blocks
updated = ConvertWpCodeBlocksToFenced(updated);



// 6) Normalize code fences and add language heuristics
updated = NormalizeFencedCodeBlocks(updated);

// 7) Restore placeholders to final markdown
foreach (var kv in placeholders)
    updated = updated.Replace(kv.Key, kv.Value);

// 7.5) Fix closing fenced code block qualifiers (e.g. ```text) and ensure exactly one blank line after
updated = FixClosingFencedCodeBlockEndings(updated);

// 7.6) Ensure image paths that start with "images/..." get a leading slash -> "/images/..."
updated = EnsureLeadingSlashForImagePaths(updated);

// 7.6) Rewrite hermit.no WP uploads image URLs to local images/ path
updated = FixHermitImageUrls(updated);

// 8) Normalize blank lines and ensure a blank line after headers (idempotent)
updated = NormalizeBlankLinesAndHeaderSpacing(updated);

// 9) Final whitespace fixes
updated = FixTrailingWhitespaceAndNewline(updated);

Console.WriteLine($"Processed : {sw.Elapsed}");
if (updated != original)
{
    File.WriteAllText(path, updated);
    Console.WriteLine($"Updated: {path}");
}
else
{
    Console.WriteLine($"No changes for: {path}");
}
Console.WriteLine($"Finished : {sw.Elapsed}");

// --- Methods ---

static string ReplaceAnchorWrappedImagesWithPlaceholders(string text, Dictionary<string, string> placeholders, Func<string> tokenFactory)
{
    var regex = MyRegex8();
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
    var regex = MyRegex9();
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
    var regex = MyRegex10();
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
    return MyRegex11().Replace(html, string.Empty).Replace("\r\n", " ").Replace("\n", " ").Trim();
}

static string ConvertParagraphTags(string text)
{
    var regex = MyRegex12();
    return regex.Replace(text, m =>
    {
        var inner = m.Groups["inner"].Value.Trim();
        return inner + "\n\n";
    });
}

static string ConvertStrongAndEmphasis(string text)
{
    text = MyRegex().Replace(text, "**$1**");
    text = MyRegex1().Replace(text, "*$1*");
    return text;
}

static string ConvertHtmlHeadingsToMarkdown(string text)
{
    // We'll scan for literal opening tags <h1 ...> to </h1> without using complex regex.
    for (int level = 1; level <= 6; level++)
    {
        string openPrefix = $"<h{level}";
        string closeTag = $"</h{level}>";
        int searchPos = 0;
        while (true)
        {
            int start = text.IndexOf(openPrefix, searchPos, StringComparison.OrdinalIgnoreCase);
            if (start == -1) break;
            // find end of opening tag '>'
            int openEnd = text.IndexOf('>', start);
            if (openEnd == -1) break;
            int innerStart = openEnd + 1;
            int end = text.IndexOf(closeTag, innerStart, StringComparison.OrdinalIgnoreCase);
            if (end == -1)
            {
                searchPos = openEnd + 1;
                continue;
            }

            string inner = text.Substring(innerStart, end - innerStart);
            // strip inner HTML tags
            var sb = new System.Text.StringBuilder();
            bool inTag = false;
            foreach (char c in inner)
            {
                if (c == '<') { inTag = true; continue; }
                if (c == '>') { inTag = false; continue; }
                if (!inTag) sb.Append(c);
            }
            string stripped = sb.ToString().Trim();

            // strip common surrounding emphasis markers
            if (stripped.StartsWith("**") && stripped.EndsWith("**") && stripped.Length > 4)
                stripped = stripped.Substring(2, stripped.Length - 4).Trim();
            else if (stripped.StartsWith("__") && stripped.EndsWith("__") && stripped.Length > 4)
                stripped = stripped.Substring(2, stripped.Length - 4).Trim();
            else if (stripped.StartsWith("*") && stripped.EndsWith("*") && stripped.Length > 2)
                stripped = stripped.Substring(1, stripped.Length - 2).Trim();
            else if (stripped.StartsWith("_") && stripped.EndsWith("_") && stripped.Length > 2)
                stripped = stripped.Substring(1, stripped.Length - 2).Trim();
            string replacement = level switch
            {
                1 => $"## {stripped}\n\n",
                2 => $"### {stripped}\n\n",
                3 => $"#### {stripped}\n\n",
                _ => $"**{stripped}**\n\n",
            };
            text = string.Concat(text.AsSpan(0, start), replacement, text.AsSpan(end + closeTag.Length));
            searchPos = start + replacement.Length;
        }
    }

    return text;
}

static string NormalizeFencedCodeBlocks(string text)
{
    // Normalize shorthand label 'cs' -> 'csharp' (preserve other explicit labels).
    text = Regex.Replace(text, @"(?im)^```[ \t]*cs[ \t]*\r?\n", "```csharp\n");

    // Add language to unlabeled fenced code blocks where we can infer one.
    var pattern = new Regex(@"(?m)^```[ \t]*\r?\n(?<body>.*?)(?=\r?\n```)", RegexOptions.Singleline);
    return pattern.Replace(text, m =>
    {
        var body = m.Groups["body"].Value;
        var lang = InferLanguageFromCode(body);
        return $"```{lang}\n{body}";
    });
}

static string FixClosingFencedCodeBlockEndings(string text)
{
    // Replace closing fences that include a qualifier (e.g. ```text) with a plain ``` and ensure exactly one blank line after.
    // We'll process lines and normalize any line that begins with ``` followed by non-space characters (closing fences sometimes get an extra qualifier).
    var lines = Regex.Split(text, "\r?\n");
    var sb = new System.Text.StringBuilder();
    for (int i = 0; i < lines.Length; i++)
    {
        var line = lines[i];
        if (line.TrimStart().StartsWith("```"))
        {
            // If this is a closing fence with extra qualifier (e.g. ```text), normalize to ```
            var trimmed = line.Trim();
            if (trimmed.Length > 3 && !trimmed.Equals("```"))
            {
                sb.AppendLine("```");
                // ensure exactly one blank line after the fence
                if (i + 1 < lines.Length)
                {
                    // skip any following blank lines
                    int j = i + 1;
                    while (j < lines.Length && string.IsNullOrWhiteSpace(lines[j])) j++;
                    sb.AppendLine();
                    i = j - 1;
                    continue;
                }
            }
        }
        sb.AppendLine(line);
    }

    return sb.ToString();
}

static string EnsureLeadingSlashForImagePaths(string text)
{
    if (string.IsNullOrEmpty(text)) return text;

    // Markdown links/images: ](images/...  and ![alt](images/...
    text = Regex.Replace(text, @"\]\(\s*images[\\/]", "](/images/", RegexOptions.IgnoreCase);
    text = Regex.Replace(text, @"!\[([^\]]*)\]\(\s*images[\\/]", "![$1](/images/", RegexOptions.IgnoreCase);

    // HTML img src attributes with double or single quotes
    text = Regex.Replace(text, @"src\s*=\s*""\s*images[\\/]", "src=\"/images/", RegexOptions.IgnoreCase);
    text = Regex.Replace(text, @"src\s*=\s*'\s*images[\\/]", "src='/images/", RegexOptions.IgnoreCase);

    return text;
}

static string FixHermitImageUrls(string text)
{
    // Convert absolute hermit.no upload URLs to local images/ path
    // e.g. http://hermit.no/wp-content/uploads/2019/10/1.jpg -> images/2019/10/1.jpg
    // Match either direct hermit.no URLs or proxy-prefixed like i2.wp.com/hermit.no
    var rx = new Regex(@"https?://(?:i\d+\.wp\.com/)?hermit\.no/wp-content/uploads/(?<rest>\S+)", RegexOptions.IgnoreCase);
    return rx.Replace(text, m =>
    {
        var rest = m.Groups["rest"].Value.TrimStart('/');
        return "/images/" + rest;
    });
}

static string ConvertWpCodeBlocksToFenced(string text)
{
    // Match <!-- wp:code --> (optionally with JSON attributes) then any content, then <!-- /wp:code -->
    var rx = new Regex(@"<!--\s*wp:code(?:\s*\{(?<json>.*?)\})?\s*-->(?<body>.*?)<!--\s*/wp:code\s*-->", RegexOptions.IgnoreCase | RegexOptions.Singleline);
    return rx.Replace(text, m =>
    {
        var json = m.Groups["json"].Value;
        var body = m.Groups["body"].Value;

        // Strip surrounding <pre> and <code> tags if present
        body = Regex.Replace(body, "</?(pre|code)\\b[^>]*>", "", RegexOptions.IgnoreCase);

        // Decode HTML entities to get real characters (e.g. &lt; &gt;)
        try { body = System.Net.WebUtility.HtmlDecode(body); } catch { }

        // Trim leading/trailing whitespace and ensure a trailing newline
        body = body.Trim('\r', '\n');

        // Attempt to extract a language from the JSON attributes, e.g. {"language":"csharp"}
        string lang = string.Empty;
        if (!string.IsNullOrEmpty(json))
        {
            var mlang = Regex.Match(json, "\"language\"\\s*:\\s*\\\"(?<l>[^\\\"]+)\\\"", RegexOptions.IgnoreCase);
            if (mlang.Success) lang = mlang.Groups["l"].Value.Trim();
        }

        if (!string.IsNullOrEmpty(lang))
            return $"```{lang}\n{body}\n```\n\n";
        else
            return $"```\n{body}\n```\n\n";
    });
}

static string ConvertWpImageBlocks(string text, Dictionary<string, string> placeholders, Func<string> tokenFactory)
{
    // Matches <!-- wp:image {json} --> ... <!-- /wp:image --> blocks
    var rx = new Regex(@"<!--\s*wp:image(?:\s*\{(?<json>.*?)\})?\s*-->(?<body>.*?)<!--\s*/wp:image\s*-->", RegexOptions.IgnoreCase | RegexOptions.Singleline);
    return rx.Replace(text, m =>
    {
        var body = m.Groups["body"].Value;

        // First, try to find an existing placeholder token inside the block
        var tokenMatch = Regex.Match(body, "__T_\\d+__");
        string mdImage = string.Empty;
        if (tokenMatch.Success)
        {
            var existingToken = tokenMatch.Value;
            if (placeholders.TryGetValue(existingToken, out var existingMd))
            {
                mdImage = existingMd.TrimEnd();
            }
        }

        // If no placeholder found, try to parse an <img> tag directly
        if (string.IsNullOrEmpty(mdImage))
        {
            var imgMatch = Regex.Match(body, "<img\\b(?<imgattrs>[^>]*)>", RegexOptions.IgnoreCase);
            if (imgMatch.Success)
            {
                var imgattrs = imgMatch.Groups["imgattrs"].Value;
                var src = CaptureAttribute(imgattrs, "src") ?? string.Empty;
                var alt = CaptureAttribute(imgattrs, "alt") ?? CaptureAttribute(imgattrs, "title") ?? Path.GetFileName(src) ?? "image";
                mdImage = $"![{alt}]({src})";
            }
        }

        // Look for figcaption content
        var figcapMatch = Regex.Match(body, "<figcaption\\b[^>]*>(?<cap>.*?)</figcaption>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
        string captionLine = string.Empty;
        if (figcapMatch.Success)
        {
            var cap = Regex.Replace(figcapMatch.Groups["cap"].Value, "<.*?>", "", RegexOptions.Singleline).Trim();
            if (!string.IsNullOrEmpty(cap))
                captionLine = cap;
        }

        if (!string.IsNullOrEmpty(mdImage))
        {
            var token = tokenFactory();
            var combined = mdImage;
            if (!string.IsNullOrEmpty(captionLine)) combined += "\n\n" + captionLine;
            // ensure trailing blank line
            combined = combined.TrimEnd() + "\n\n";
            placeholders[token] = combined;
            return token;
        }

        // fallback: remove the block entirely
        return string.Empty;
    });
}

static string ConvertWpListBlocks(string text)
{
    // Match wp:list blocks, capture JSON attributes (to determine ordered) and the inner HTML
    var rx = new Regex(@"<!--\s*wp:list(?:\s*\{(?<json>.*?)\})?\s*-->(?<body>.*?)<!--\s*/wp:list\s*-->", RegexOptions.IgnoreCase | RegexOptions.Singleline);
    return rx.Replace(text, m =>
    {
        var json = m.Groups["json"].Value;
        var body = m.Groups["body"].Value;

        bool ordered = false;
        if (!string.IsNullOrEmpty(json))
        {
            var mo = Regex.Match(json, "\\\"ordered\\\"\\s*:\\s*(true|false)", RegexOptions.IgnoreCase);
            if (mo.Success) ordered = mo.Groups[1].Value.Equals("true", StringComparison.OrdinalIgnoreCase);
        }

        // Find all <li>...</li> items
        var lis = Regex.Matches(body, "<li\\b[^>]*>(?<inner>.*?)</li>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
        if (lis.Count == 0) return string.Empty;

        var sb = new System.Text.StringBuilder();
        int index = 1;
        foreach (Match li in lis)
        {
            var inner = li.Groups["inner"].Value;
            // strip tags inside li and trim
            var textItem = Regex.Replace(inner, "<.*?>", "", RegexOptions.Singleline).Trim();
            if (ordered)
                sb.AppendLine($"{index}. {textItem}");
            else
                sb.AppendLine($"- {textItem}");
            index++;
        }

        sb.AppendLine();
        return sb.ToString();
    });
}

static string RemoveWordpressBlockComments(string text)
{
    // Remove WordPress block comment markers inserted by the editor, e.g.
    // <!-- wp:paragraph -->, <!-- /wp:heading -->, <!-- wp:heading {"level":3} -->
    // We target paragraph and heading blocks for levels 1-4 and their closing markers.
    var pattern = new Regex(@"<!--\s*/?wp:(?:paragraph|heading)(?:\s*\{.*?\})?\s*-->", RegexOptions.IgnoreCase | RegexOptions.Singleline);
    return pattern.Replace(text, "");
}

static string InferLanguageFromCode(string body)
{
    var sample = body.Length > 1000 ? body.Substring(0, 1000) : body;
    // Heuristics to infer language for unlabeled fenced code blocks.
    // Prefer C# when nothing else matches (project is a C# focused repo and requirement)
    if (MyRegex4().IsMatch(sample))
        return "csharp";

    // PowerShell / command-line heuristics
    if (MyRegex2().IsMatch(sample) ||
        MyRegex3().IsMatch(sample))
        return "cmd";

    // XML/HTML-like content
    if (sample.Contains("<") && sample.Contains(">"))
        return "xml";

    // Default language when nothing matches: C# (per repository convention / user preference)
    return "csharp";
}

static string FixTrailingWhitespaceAndNewline(string text)
{
    text = MyRegex5().Replace(text, "$1");
    text = text.TrimEnd('\r', '\n') + Environment.NewLine;
    return text;
}

static string NormalizeBlankLinesAndHeaderSpacing(string text)
{
    // Work line-by-line, but avoid modifying content inside fenced code blocks (```).
    var lines = Regex.Split(text, "\r?\n");
    var sb = new System.Text.StringBuilder();
    bool inFence = false;
    bool prevBlank = false;

    for (int i = 0; i < lines.Length; i++)
    {
        var line = lines[i];
        var trimmedLine = line ?? string.Empty;

        // detect fence start/end (lines that start with ```)
        if (trimmedLine.TrimStart().StartsWith("```"))
        {
            // toggle fence state and write the fence line
            inFence = !inFence;
            sb.AppendLine(trimmedLine);
            prevBlank = false;
            continue;
        }

        if (inFence)
        {
            // inside a fenced block, preserve exact content
            sb.AppendLine(trimmedLine);
            prevBlank = false;
            continue;
        }

        if (string.IsNullOrWhiteSpace(trimmedLine))
        {
            // collapse multiple blank lines into a single blank line
            if (!prevBlank)
            {
                sb.AppendLine();
                prevBlank = true;
            }
            continue;
        }

        // Non-blank line outside fences: write it
        sb.AppendLine(trimmedLine);
        prevBlank = false;

        // If this is a Markdown ATX header (starts with #), ensure a blank line follows when the next
        // line exists and is not already blank.
        var startsWithHash = trimmedLine.TrimStart().StartsWith("#");
        if (startsWithHash)
        {
            if (i + 1 < lines.Length && !string.IsNullOrWhiteSpace(lines[i + 1]))
            {
                // add a single blank line if not already present
                sb.AppendLine();
                prevBlank = true;
            }
        }
    }

    var output = sb.ToString();
    // normalize final line endings and trailing newline will be ensured later
    return output.Replace("\r\n", "\n").Replace("\n", Environment.NewLine);
}

static string? CaptureAttribute(string? attrs, string name)
{
    if (string.IsNullOrEmpty(attrs)) return null;
    var m = Regex.Match(attrs, $@"\b{name}\s*=\s*""(?<v>[^""]*)""", RegexOptions.IgnoreCase);
    return m.Success ? m.Groups["v"].Value : null;
}

static string RemoveUnwantedFrontmatterEntries(string text)
{
    // We operate only inside the top frontmatter block (between --- and ---)
    var fmMatch = MyRegex6().Match(text);
    if (!fmMatch.Success) return text;

    var fm = fmMatch.Groups[1].Value;
    // Keys to remove (match key: and any following indented lines)
    var keys = new[] { "guid", "permalink", "catchevolution-sidebarlayout", "dsq_thread_id" };

    foreach (var key in keys)
    {
        // Remove lines starting with key: and any immediately following indented lines (e.g. - "123")
        fm = Regex.Replace(fm, $@"^{Regex.Escape(key)}\s*:\s*.*(?:\r?\n(?:\s+-\s*.*|\s+.*))*", "", RegexOptions.IgnoreCase | RegexOptions.Multiline);
    }

    // Collapse multiple blank lines inside frontmatter to a single blank line
    fm = MyRegex7().Replace(fm, "\r\n");

    return fmMatch.Result(fm) + text.Substring(fmMatch.Length);
}

partial class Program
{
    [GeneratedRegex(@"<(?:strong|b)\b[^>]*>(.*?)</(?:strong|b)>", RegexOptions.IgnoreCase | RegexOptions.Singleline, "en-US")]
    private static partial Regex MyRegex();
}

partial class Program
{
    [GeneratedRegex(@"<(?:em|i)\b[^>]*>(.*?)</(?:em|i)>", RegexOptions.IgnoreCase | RegexOptions.Singleline, "en-US")]
    private static partial Regex MyRegex1();
}

partial class Program
{
    [GeneratedRegex(@"^\s*(PS |PS>|C:\\|C:\s*>)", RegexOptions.IgnoreCase | RegexOptions.Multiline, "en-US")]
    private static partial Regex MyRegex2();
}

partial class Program
{
    [GeneratedRegex("\\b(msbuild|nuget|dotnet|git|devenv)\\b", RegexOptions.IgnoreCase, "en-US")]
    private static partial Regex MyRegex3();
}

partial class Program
{
    [GeneratedRegex(@"\b(using|namespace|class|struct|interface|public|private|protected|internal|void|int|string|bool|decimal|Task<|async|await|Console\.Write|var)\b", RegexOptions.IgnoreCase, "en-US")]
    private static partial Regex MyRegex4();
}

partial class Program
{
    [GeneratedRegex(@"[ \t]+(\r?$)", RegexOptions.Multiline)]
    private static partial Regex MyRegex5();
}

partial class Program
{
    [GeneratedRegex("^(---\r?\n.*?\r?\n---\r?\n)", RegexOptions.Singleline)]
    private static partial Regex MyRegex6();
}

partial class Program
{
    [GeneratedRegex("\r?\n{2,}")]
    private static partial Regex MyRegex7();
}

partial class Program
{
    [GeneratedRegex(@"<a\b[^>]*?href\s*=\s*""(?<href>[^""]+)""[^>]*>\s*<img\b(?<imgattrs>[^>]*)>\s*</a>", RegexOptions.IgnoreCase | RegexOptions.Singleline, "en-US")]
    private static partial Regex MyRegex8();
}

partial class Program
{
    [GeneratedRegex(@"<img\b(?<imgattrs>[^>]*)>", RegexOptions.IgnoreCase | RegexOptions.Singleline, "en-US")]
    private static partial Regex MyRegex9();
}

partial class Program
{
    [GeneratedRegex(@"<a\b[^>]*?href\s*=\s*""(?<href>[^""]+)""[^>]*>(?<text>.*?)</a>", RegexOptions.IgnoreCase | RegexOptions.Singleline, "en-US")]
    private static partial Regex MyRegex10();
}

partial class Program
{
    [GeneratedRegex("<.*?>", RegexOptions.Singleline)]
    private static partial Regex MyRegex11();
}

partial class Program
{
    [GeneratedRegex(@"<p\b[^>]*>(?<inner>.*?)</p>", RegexOptions.IgnoreCase | RegexOptions.Singleline, "en-US")]
    private static partial Regex MyRegex12();
}