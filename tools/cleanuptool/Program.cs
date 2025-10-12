using System.Text.RegularExpressions;
using CleanupTool;

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
var lines = File.ReadAllLines(path).ToList();
string original = string.Join(Environment.NewLine, lines);
var updatedLines = new List<string>(lines);

Console.WriteLine($"Read file: {sw.Elapsed}");

// Remove unwanted frontmatter keys that come from the old WP export (idempotent)
updatedLines = Processor.RemoveUnwantedFrontmatterEntries(updatedLines);

// placeholder map to avoid double-conversion
var placeholders = new Dictionary<string, string>(StringComparer.Ordinal);
int tokenCounter = 0;
Func<string> NextToken = () => $"__T_{tokenCounter++}__";

// 1) Anchor-wrapped images -> placeholders
updatedLines = Processor.ReplaceAnchorWrappedImagesWithPlaceholders(updatedLines, placeholders, NextToken);

// 2) Standalone <img> -> placeholders
updatedLines = Processor.ReplaceImgTagsWithPlaceholders(updatedLines, placeholders, NextToken);

// 2.1) Convert WordPress image blocks <!-- wp:image {..} --> ... <!-- /wp:image -->
updatedLines = Processor.ConvertWpImageBlocks(updatedLines, placeholders, NextToken);

// 2.5) Remove WordPress block comments like <!-- wp:paragraph --> and <!-- /wp:heading -->
updatedLines = Processor.RemoveWordpressBlockComments(updatedLines);

// 2.6) Convert WordPress list blocks <!-- wp:list {..} --> ... <!-- /wp:list --> to markdown lists
updatedLines = Processor.ConvertWpListBlocks(updatedLines);

// 2.7) Convert generic HTML unordered lists (<ul><li>...) to markdown bullets
updatedLines = Processor.ConvertHtmlUnorderedListsToMarkdown(updatedLines);

// 5.1) HTML headings -> Markdown headings/bold
updatedLines = Processor.ConvertHtmlHeadingsToMarkdown(updatedLines);


// 3) Convert simple anchors to markdown (won't touch placeholders)
updatedLines = Processor.ConvertAnchorsToMarkdown(updatedLines);

// 4) Paragraphs
updatedLines = Processor.ConvertParagraphTags(updatedLines);

// 5.15) Ensure headers are surrounded by a single blank line
updatedLines = Processor.EnsureBlankLinesAroundHeaders(updatedLines);


// 5) strong / emphasis
updatedLines = Processor.ConvertStrongAndEmphasis(updatedLines);

// 5.05) Convert lines that are only bold text (hidden headers) into Markdown headers
updatedLines = Processor.ConvertBoldLinesToHeaders(updatedLines);

// 4.5) Convert WordPress <!-- wp:code --> ... <!-- /wp:code --> blocks to fenced code blocks
updatedLines = Processor.ConvertWpCodeBlocksToFenced(updatedLines);



// 6) Normalize code fences and add language heuristics
updatedLines = Processor.NormalizeFencedCodeBlocks(updatedLines);

// 7) Restore placeholders to final markdown
var updated = string.Join(Environment.NewLine, updatedLines);
foreach (var kv in placeholders)
    updated = updated.Replace(kv.Key, kv.Value);
updatedLines = Regex.Split(updated, "\r?\n").ToList();

// 7.5) Fix closing fenced code block qualifiers (e.g. ```text) and ensure exactly one blank line after
updatedLines = Processor.FixClosingFencedCodeBlockEndings(updatedLines);

// 7.6) Ensure image paths that start with "images/..." get a leading slash -> "/images/..."
updatedLines = Processor.EnsureLeadingSlashForImagePaths(updatedLines);

// 7.6) Rewrite hermit.no WP uploads image URLs to local images/ path
updatedLines = Processor.FixHermitImageUrls(updatedLines);

// 8) Normalize blank lines and ensure a blank line after headers (idempotent)
updatedLines = Processor.NormalizeBlankLinesAndHeaderSpacing(updatedLines);

// 9) Final whitespace fixes
updatedLines = Processor.FixTrailingWhitespaceAndNewline(updatedLines);

// Finalize and write
var final = string.Join(Environment.NewLine, updatedLines);
Console.WriteLine($"Processed : {sw.Elapsed}");
if (final != original)
{
    File.WriteAllText(path, final);
    Console.WriteLine($"Updated: {path}");
}
else
{
    Console.WriteLine($"No changes for: {path}");
}
Console.WriteLine($"Finished : {sw.Elapsed}");
