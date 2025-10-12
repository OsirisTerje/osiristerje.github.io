using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CleanupTool
{
    public partial class Processor
    {

        // --- Methods ---

        #region methods

        // --- Line-based wrappers (join -> call existing string methods -> split) ---
        public static List<string> RemoveUnwantedFrontmatterEntries(List<string> lines)
        {
            var text = string.Join(Environment.NewLine, lines);
            var outText = RemoveUnwantedFrontmatterEntries(text);
            return Regex.Split(outText, @"\r?\n").ToList();
        }

        public static List<string> ReplaceAnchorWrappedImagesWithPlaceholders(List<string> lines, Dictionary<string, string> placeholders, Func<string> tokenFactory)
        {
            var text = string.Join(Environment.NewLine, lines);
            var outText = ReplaceAnchorWrappedImagesWithPlaceholders(text, placeholders, tokenFactory);
            return Regex.Split(outText, @"\r?\n").ToList();
        }

        public static List<string> ReplaceImgTagsWithPlaceholders(List<string> lines, Dictionary<string, string> placeholders, Func<string> tokenFactory)
        {
            var text = string.Join(Environment.NewLine, lines);
            var outText = ReplaceImgTagsWithPlaceholders(text, placeholders, tokenFactory);
            return Regex.Split(outText, @"\r?\n").ToList();
        }

        public static List<string> ConvertWpImageBlocks(List<string> lines, Dictionary<string, string> placeholders, Func<string> tokenFactory)
        {
            var text = string.Join(Environment.NewLine, lines);
            var outText = ConvertWpImageBlocks(text, placeholders, tokenFactory);
            return Regex.Split(outText, @"\r?\n").ToList();
        }

        public static List<string> RemoveWordpressBlockComments(List<string> lines)
        {
            var text = string.Join(Environment.NewLine, lines);
            var outText = RemoveWordpressBlockComments(text);
            return Regex.Split(outText, @"\r?\n").ToList();
        }

        public static List<string> ConvertWpListBlocks(List<string> lines)
        {
            var text = string.Join(Environment.NewLine, lines);
            var outText = ConvertWpListBlocks(text);
            return Regex.Split(outText, @"\r?\n").ToList();
        }

        public static List<string> ConvertHtmlUnorderedListsToMarkdown(List<string> lines)
        {
            var text = string.Join(Environment.NewLine, lines);
            var outText = ConvertHtmlUnorderedListsToMarkdown(text);
            return Regex.Split(outText, @"\r?\n").ToList();
        }

        public static List<string> ConvertHtmlHeadingsToMarkdown(List<string> lines)
        {
            var text = string.Join(Environment.NewLine, lines);
            var outText = ConvertHtmlHeadingsToMarkdown(text);
            return Regex.Split(outText, @"\r?\n").ToList();
        }

        public static List<string> ConvertAnchorsToMarkdown(List<string> lines)
        {
            var text = string.Join(Environment.NewLine, lines);
            var outText = ConvertAnchorsToMarkdown(text);
            return Regex.Split(outText, @"\r?\n").ToList();
        }

        public static List<string> ConvertParagraphTags(List<string> lines)
        {
            var text = string.Join(Environment.NewLine, lines);
            var outText = ConvertParagraphTags(text);
            return Regex.Split(outText, @"\r?\n").ToList();
        }

        public static List<string> EnsureBlankLinesAroundHeaders(List<string> lines)
        {
            var text = string.Join(Environment.NewLine, lines);
            var outText = EnsureBlankLinesAroundHeaders(text);
            return Regex.Split(outText, @"\r?\n").ToList();
        }

        public static List<string> ConvertStrongAndEmphasis(List<string> lines)
        {
            var text = string.Join(Environment.NewLine, lines);
            var outText = ConvertStrongAndEmphasis(text);
            return Regex.Split(outText, @"\r?\n").ToList();
        }

        public static List<string> ConvertBoldLinesToHeaders(List<string> lines)
        {
            var text = string.Join(Environment.NewLine, lines);
            var outText = ConvertBoldLinesToHeaders(text);
            return Regex.Split(outText, @"\r?\n").ToList();
        }

        public static List<string> ConvertWpCodeBlocksToFenced(List<string> lines)
        {
            var text = string.Join(Environment.NewLine, lines);
            var outText = ConvertWpCodeBlocksToFenced(text);
            return Regex.Split(outText, @"\r?\n").ToList();
        }

        public static List<string> NormalizeFencedCodeBlocks(List<string> lines)
        {
            // Normalize shorthand label 'cs' -> 'csharp' on a per-line basis
            for (int li = 0; li < lines.Count; li++)
            {
                if (Regex.IsMatch(lines[li] ?? string.Empty, @"(?im)^```[ \t]*cs[ \t]*$"))
                    lines[li] = "```csharp";
            }

            var outLines = new List<string>();
            int i = 0;
            int totalFences = 0;
            int unlabeled = 0;

            while (i < lines.Count)
            {
                var line = lines[i] ?? string.Empty;
                var trimmed = line.Trim();

                // Opening fence with no language label (```) only
                if (trimmed.StartsWith("```") && Regex.IsMatch(trimmed, @"^```\s*$"))
                {
                    totalFences++;
                    int j = i + 1;
                    var bodyLines = new List<string>();
                    bool foundClose = false;

                    while (j < lines.Count)
                    {
                        var l = lines[j] ?? string.Empty;
                        int fencePos = l.IndexOf("```");
                        if (fencePos >= 0)
                        {
                            var before = l.Substring(0, fencePos);
                            if (!string.IsNullOrEmpty(before)) bodyLines.Add(before);
                            foundClose = true;
                            break;
                        }
                        bodyLines.Add(l);
                        j++;
                    }

                    var body = string.Join(Environment.NewLine, bodyLines);
                    var lang = InferLanguageFromCode(body);
                    unlabeled++;

                    outLines.Add("```" + lang);
                    if (bodyLines[0]==string.Empty)
                        bodyLines.RemoveAt(0);
                    outLines.AddRange(bodyLines);

                    if (foundClose)
                    {
                        outLines.Add("```");
                        i = j + 1;
                        continue;
                    }
                    else
                    {
                        i = j;
                        continue;
                    }
                }

                outLines.Add(line);
                i++;
            }

            Console.WriteLine($"NormalizeFencedCodeBlocks: found fences={totalFences}, unlabeled={unlabeled}");
            return outLines;
        }

        public static List<string> FixClosingFencedCodeBlockEndings(List<string> lines)
        {
            var outLines = new List<string>();
            bool inBlock = false;

            for (int i = 0; i < lines.Count; i++)
            {
                var line = lines[i] ?? string.Empty;
                var trimmedStart = line.TrimStart();

                if (trimmedStart.StartsWith("```"))
                {
                    // If we're not currently in a code block, this is an opening fence. Preserve as-is and enter block.
                    if (!inBlock)
                    {
                        inBlock = true;
                        outLines.Add(line);
                        continue;
                    }

                    // We're in a block, so this fence is a closing fence.
                    var trimmed = line.Trim();
                    if (trimmed.Length > 3 && !trimmed.Equals("```"))
                    {
                        // normalize closing fence to exactly ``` (drop qualifier)
                        outLines.Add("```");

                        // collapse any existing blank lines after the fence to a single blank line if there is further content
                        int k = i + 1;
                        bool hadBlank = false;
                        while (k < lines.Count && string.IsNullOrWhiteSpace(lines[k]))
                        {
                            hadBlank = true;
                            k++;
                        }

                        // If there were blank lines after the closing fence, preserve exactly one.
                        if (hadBlank)
                        {
                            outLines.Add(string.Empty);
                        }

                        // advance the loop to the last skipped index (k-1). The for-loop will increment to k.
                        i = Math.Max(i, k - 1);
                        inBlock = false;
                        continue;
                    }

                    // Normal closing fence (```), preserve and exit block
                    inBlock = false;
                    outLines.Add(line);
                    continue;
                }

                outLines.Add(line);
            }

            return outLines;
        }

        public static List<string> EnsureLeadingSlashForImagePaths(List<string> lines)
        {
            var text = string.Join(Environment.NewLine, lines);
            var outText = EnsureLeadingSlashForImagePaths(text);
            return Regex.Split(outText, @"\r?\n").ToList();
        }

        public static List<string> FixHermitImageUrls(List<string> lines)
        {
            var text = string.Join(Environment.NewLine, lines);
            var outText = FixHermitImageUrls(text);
            return Regex.Split(outText, @"\r?\n").ToList();
        }

        public static List<string> NormalizeBlankLinesAndHeaderSpacing(List<string> lines)
        {
            var text = string.Join(Environment.NewLine, lines);
            var outText = NormalizeBlankLinesAndHeaderSpacing(text);
            return Regex.Split(outText, @"\r?\n").ToList();
        }

        public static List<string> FixTrailingWhitespaceAndNewline(List<string> lines)
        {
            var text = string.Join(Environment.NewLine, lines);
            var outText = FixTrailingWhitespaceAndNewline(text);
            return Regex.Split(outText, @"\r?\n").ToList();
        }


        public static string ReplaceAnchorWrappedImagesWithPlaceholders(string text, Dictionary<string, string> placeholders, Func<string> tokenFactory)
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

        public static string ReplaceImgTagsWithPlaceholders(string text, Dictionary<string, string> placeholders, Func<string> tokenFactory)
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

        public static string ConvertAnchorsToMarkdown(string text)
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

        public static string StripTags(string html)
        {
            return MyRegex11().Replace(html, string.Empty).Replace("\r\n", " ").Replace("\n", " ").Trim();
        }

        public static string ConvertParagraphTags(string text)
        {
            var regex = MyRegex12();
            return regex.Replace(text, m =>
            {
                var inner = m.Groups["inner"].Value.Trim();
                return inner + "\n\n";
            });
        }

        public static string ConvertStrongAndEmphasis(string text)
        {
            text = MyRegex().Replace(text, "**$1**");
            text = MyRegex1().Replace(text, "*$1*");
            return text;
        }

        public static string EnsureBlankLinesAroundHeaders(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;

            var lines = Regex.Split(text, @"\r?\n");
            var sb = new StringBuilder();
            bool inFence = false;

            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                var trimmed = line ?? string.Empty;

                // Toggle fence state
                if (trimmed.TrimStart().StartsWith("```"))
                {
                    inFence = !inFence;
                    sb.AppendLine(line);
                    continue;
                }

                if (inFence)
                {
                    sb.AppendLine(line);
                    continue;
                }

                // Detect ATX markdown headers (#) or bold alternative headers (**text**)
                if (Regex.IsMatch(trimmed, @"^\s*#{1,6}\s") || Regex.IsMatch(trimmed, @"^\s*\*\*.*\*\*\s*$"))
                {
                    // Ensure previous line is blank
                    if (sb.Length > 0)
                    {
                        var outSoFar = sb.ToString();
                        if (!outSoFar.EndsWith(Environment.NewLine + Environment.NewLine))
                        {
                            // ensure exactly one blank line before
                            sb.AppendLine();
                        }
                    }

                    sb.AppendLine(trimmed);

                    // Ensure next line is blank (lookahead)
                    if (i + 1 < lines.Length && !string.IsNullOrWhiteSpace(lines[i + 1]))
                    {
                        sb.AppendLine();
                    }

                    continue;
                }

                sb.AppendLine(line);
            }

            return sb.ToString();
        }

        public static string ConvertHtmlHeadingsToMarkdown(string text)
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
                    var sb = new StringBuilder();
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
                        1 => $"\n\n## {stripped}\n\n",
                        2 => $"\n\n### {stripped}\n\n",
                        3 => $"\n\n#### {stripped}\n\n",
                        _ => $"\n\n**{stripped}**\n\n",
                    };
                    text = string.Concat(text.AsSpan(0, start), replacement, text.AsSpan(end + closeTag.Length));
                    searchPos = start + replacement.Length;
                }
            }

            return text;
        }

        // string-based NormalizeFencedCodeBlocks removed; use the List<string> overload instead.

        public static string FixClosingFencedCodeBlockEndings(string text)
        {
            // Replace closing fences that include a qualifier (e.g. ```text) with a plain ``` and ensure exactly one blank line after.
            // We'll process lines and normalize any line that begins with ``` followed by non-space characters (closing fences sometimes get an extra qualifier).
            var lines = Regex.Split(text, "\r?\n");
            var sb = new StringBuilder();
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

        public static string ConvertWpCodeBlocksToFenced(string text)
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

        public static string EnsureLeadingSlashForImagePaths(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;

            // Markdown links/images: ](images/...  and ![alt](images/...)
            text = Regex.Replace(text, @"\]\(\s*images[\\/]", "](/images/", RegexOptions.IgnoreCase);
            text = Regex.Replace(text, @"!\[([^\]]*)\]\(\s*images[\\/]", "![$1](/images/", RegexOptions.IgnoreCase);

            // HTML img src attributes with double or single quotes
            text = Regex.Replace(text, @"src\s*=\s*""\s*images[\\/]", "src=\"/images/", RegexOptions.IgnoreCase);
            text = Regex.Replace(text, @"src\s*=\s*'\s*images[\\/]", "src='/images/", RegexOptions.IgnoreCase);

            return text;
        }

        public static string FixHermitImageUrls(string text)
        {
            // Convert absolute hermit.no upload URLs to local images/ path
            // e.g. http://hermit.no/wp-content/uploads/2019/10/1.jpg -> /images/2019/10/1.jpg
            // Match either direct hermit.no URLs or proxy-prefixed like i2.wp.com/hermit.no
            var rx = new Regex(@"https?://(?:i\d+\.wp\.com/)?hermit\.no/wp-content/uploads/(?<rest>\S+)", RegexOptions.IgnoreCase);
            return rx.Replace(text, m =>
            {
                var rest = m.Groups["rest"].Value.TrimStart('/');
                return "/images/" + rest;
            });
        }



        public static string ConvertWpImageBlocks(string text, Dictionary<string, string> placeholders, Func<string> tokenFactory)
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

        public static string ConvertWpListBlocks(string text)
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

                var sb = new StringBuilder();
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

        public static string ConvertHtmlUnorderedListsToMarkdown(string text)
        {
            // Convert simple <ul>...</ul> blocks to markdown bullets. This is conservative and
            // does not attempt to fully handle nested lists with different levels.
            var rx = new Regex(@"<ul\b[^>]*>(?<body>.*?)</ul>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            return rx.Replace(text, m =>
            {
                var body = m.Groups["body"].Value;
                var lis = Regex.Matches(body, "<li\\b[^>]*>(?<inner>.*?)</li>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                if (lis.Count == 0) return string.Empty;

                var sb = new StringBuilder();
                foreach (Match li in lis)
                {
                    var inner = li.Groups["inner"].Value;
                    // Strip any inner tags, but preserve basic inline formatting
                    var cleaned = Regex.Replace(inner, "<\\/?p\\b[^>]*>", "", RegexOptions.IgnoreCase);
                    cleaned = Regex.Replace(cleaned, "<.*?>", "", RegexOptions.Singleline).Trim();
                    if (string.IsNullOrEmpty(cleaned)) continue;
                    sb.AppendLine($"- {cleaned}");
                }

                sb.AppendLine();
                return sb.ToString();
            });
        }

        public static string ConvertBoldLinesToHeaders(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;

            var lines = Regex.Split(text, @"\r?\n");
            var sb = new StringBuilder();
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                var trimmed = line?.Trim() ?? string.Empty;

                if (string.IsNullOrEmpty(trimmed))
                {
                    sb.AppendLine(line);
                    continue;
                }

                // Match pure bold lines: **text** or <strong>text</strong> or <b>text</b>
                var m1 = Regex.Match(trimmed, @"^\*\*(?<t>.+?)\*\*$");
                var m2 = Regex.Match(trimmed, @"^<strong\b[^>]*>(?<t>.*?)</strong>$", RegexOptions.IgnoreCase);
                var m3 = Regex.Match(trimmed, @"^<b\b[^>]*>(?<t>.*?)</b>$", RegexOptions.IgnoreCase);

                string? inner = null;
                if (m1.Success) inner = m1.Groups["t"].Value.Trim();
                else if (m2.Success) inner = Regex.Replace(m2.Groups["t"].Value, "<.*?>", "").Trim();
                else if (m3.Success) inner = Regex.Replace(m3.Groups["t"].Value, "<.*?>", "").Trim();

                if (!string.IsNullOrEmpty(inner))
                {
                    // Determine header level based on nearest previous header in output (level+1)
                    int targetLevel = 2; // default
                    var outSoFar = sb.ToString();
                    if (!string.IsNullOrEmpty(outSoFar))
                    {
                        // Find last non-blank line
                        var outLines = Regex.Split(outSoFar, @"\r?\n");
                        for (int j = outLines.Length - 1; j >= 0; j--)
                        {
                            var ol = outLines[j]?.Trim();
                            if (string.IsNullOrEmpty(ol)) continue;
                            var hm = Regex.Match(ol, @"^(#+)\s+");
                            if (hm.Success)
                            {
                                int prevLevel = hm.Groups[1].Value.Length;
                                targetLevel = Math.Min(prevLevel + 1, 6);
                            }
                            break;
                        }
                    }

                    // Ensure blank line before
                    sb.AppendLine();
                    sb.AppendLine(new string('#', targetLevel) + " " + inner);
                    sb.AppendLine();
                    continue;
                }

                sb.AppendLine(line);
            }

            return sb.ToString();
        }

        public static string RemoveWordpressBlockComments(string text)
        {
            // Remove WordPress block comment markers inserted by the editor, e.g.
            // <!-- wp:paragraph -->, <!-- /wp:heading -->, <!-- wp:heading {"level":3} -->
            // We target paragraph and heading blocks for levels 1-4 and their closing markers.
            var pattern = new Regex(@"<!--\s*/?wp:(?:paragraph|heading)(?:\s*\{.*?\})?\s*-->", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            return pattern.Replace(text, "");
        }

        public static string InferLanguageFromCode(string body)
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

        public static string FixTrailingWhitespaceAndNewline(string text)
        {
            text = MyRegex5().Replace(text, "$1");
            text = text.TrimEnd('\r', '\n') + Environment.NewLine;
            return text;
        }

        public static string NormalizeBlankLinesAndHeaderSpacing(string text)
        {
            var lines = Regex.Split(text, @"\r?\n");
            var outLines = new List<string>();
            bool inFence = false;

            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i] ?? string.Empty;
                var trimmed = line.TrimEnd();

                // fence toggling
                if (trimmed.TrimStart().StartsWith("```"))
                {
                    inFence = !inFence;
                    outLines.Add(trimmed);
                    continue;
                }

                if (inFence)
                {
                    outLines.Add(line);
                    continue;
                }

                // collapse multiple blank lines
                if (string.IsNullOrWhiteSpace(line))
                {
                    if (outLines.Count == 0 || string.IsNullOrWhiteSpace(outLines.Last()))
                        continue; // skip additional blanks
                    outLines.Add(string.Empty);
                    continue;
                }

                // normal non-blank line
                outLines.Add(trimmed);

                // if this line is an ATX header, ensure a blank line follows
                if (trimmed.TrimStart().StartsWith("#"))
                {
                    if (i + 1 < lines.Length && !string.IsNullOrWhiteSpace(lines[i + 1]))
                    {
                        outLines.Add(string.Empty);
                    }
                }
            }

            // normalize endings
            return string.Join(Environment.NewLine, outLines);
        }

        static string? CaptureAttribute(string? attrs, string name)
        {
            if (string.IsNullOrEmpty(attrs)) return null;
            var m = Regex.Match(attrs, $@"\b{name}\s*=\s*""(?<v>[^""]*)""", RegexOptions.IgnoreCase);
            return m.Success ? m.Groups["v"].Value : null;
        }

        public static string RemoveUnwantedFrontmatterEntries(string text)
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
        #endregion


    }

    #region Regexes

    partial class Processor
    {
        [GeneratedRegex(@"<(?:strong|b)\b[^>]*>(.*?)</(?:strong|b)>", RegexOptions.IgnoreCase | RegexOptions.Singleline, "en-US")]
        private static partial Regex MyRegex();
    }

    partial class Processor
    {
        [GeneratedRegex(@"<(?:em|i)\b[^>]*>(.*?)</(?:em|i)>", RegexOptions.IgnoreCase | RegexOptions.Singleline, "en-US")]
        private static partial Regex MyRegex1();
    }

    partial class Processor
    {
        [GeneratedRegex(@"^\s*(PS |PS>|C:\\|C:\s*>)", RegexOptions.IgnoreCase | RegexOptions.Multiline, "en-US")]
        private static partial Regex MyRegex2();
    }

    partial class Processor
    {
        [GeneratedRegex("\\b(msbuild|nuget|dotnet|git|devenv|pip|python)\\b", RegexOptions.IgnoreCase, "en-US")]
        private static partial Regex MyRegex3();
    }

    partial class Processor
    {
        [GeneratedRegex(@"\b(using|namespace|class|struct|interface|public|private|protected|internal|void|int|string|bool|decimal|Task<|async|await|Console\.Write|var)\b", RegexOptions.IgnoreCase, "en-US")]
        private static partial Regex MyRegex4();
    }

    partial class Processor
    {
        [GeneratedRegex(@"[ \t]+(\r?$)", RegexOptions.Multiline)]
        private static partial Regex MyRegex5();
    }

    partial class Processor
    {
        [GeneratedRegex("^(---\r?\n.*?\r?\n---\r?\n)", RegexOptions.Singleline)]
        private static partial Regex MyRegex6();
    }

    partial class Processor
    {
        [GeneratedRegex("\r?\n{2,}")]
        private static partial Regex MyRegex7();
    }

    partial class Processor
    {
        [GeneratedRegex(@"<a\b[^>]*?href\s*=\s*""(?<href>[^""]+)""[^>]*>\s*<img\b(?<imgattrs>[^>]*)>\s*</a>", RegexOptions.IgnoreCase | RegexOptions.Singleline, "en-US")]
        private static partial Regex MyRegex8();
    }

    partial class Processor
    {
        [GeneratedRegex(@"<img\b(?<imgattrs>[^>]*)>", RegexOptions.IgnoreCase | RegexOptions.Singleline, "en-US")]
        private static partial Regex MyRegex9();
    }

    partial class Processor
    {
        [GeneratedRegex(@"<a\b[^>]*?href\s*=\s*""(?<href>[^""]+)""[^>]*>(?<text>.*?)</a>", RegexOptions.IgnoreCase | RegexOptions.Singleline, "en-US")]
        private static partial Regex MyRegex10();
    }

    partial class Processor
    {
        [GeneratedRegex("<.*?>", RegexOptions.Singleline)]
        private static partial Regex MyRegex11();
    }

    partial class Processor
    {
        [GeneratedRegex(@"<p\b[^>]*>(?<inner>.*?)</p>", RegexOptions.IgnoreCase | RegexOptions.Singleline, "en-US")]
        private static partial Regex MyRegex12();
    }
    #endregion
}
