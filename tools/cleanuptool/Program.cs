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
string original = File.ReadAllText(path);
string updated = original;

Console.WriteLine($"Read file: {sw.Elapsed}");

// Remove unwanted frontmatter keys that come from the old WP export (idempotent)
updated = Processor.RemoveUnwantedFrontmatterEntries(updated);

// placeholder map to avoid double-conversion
var placeholders = new Dictionary<string, string>(StringComparer.Ordinal);
int tokenCounter = 0;
Func<string> NextToken = () => $"__T_{tokenCounter++}__";

// 1) Anchor-wrapped images -> placeholders
updated = Processor.ReplaceAnchorWrappedImagesWithPlaceholders(updated, placeholders, NextToken);

// 2) Standalone <img> -> placeholders
updated = Processor.ReplaceImgTagsWithPlaceholders(updated, placeholders, NextToken);

// 2.1) Convert WordPress image blocks <!-- wp:image {..} --> ... <!-- /wp:image -->
updated = Processor.ConvertWpImageBlocks(updated, placeholders, NextToken);

// 2.5) Remove WordPress block comments like <!-- wp:paragraph --> and <!-- /wp:heading -->
updated = Processor.RemoveWordpressBlockComments(updated);

// 2.6) Convert WordPress list blocks <!-- wp:list {..} --> ... <!-- /wp:list --> to markdown lists
updated = Processor.ConvertWpListBlocks(updated);

// 2.7) Convert generic HTML unordered lists (<ul><li>...) to markdown bullets
updated = Processor.ConvertHtmlUnorderedListsToMarkdown(updated);

// 5.1) HTML headings -> Markdown headings/bold
updated = Processor.ConvertHtmlHeadingsToMarkdown(updated);


// 3) Convert simple anchors to markdown (won't touch placeholders)
updated = Processor.ConvertAnchorsToMarkdown(updated);

// 4) Paragraphs
updated = Processor.ConvertParagraphTags(updated);

// 5.15) Ensure headers are surrounded by a single blank line
updated = Processor.EnsureBlankLinesAroundHeaders(updated);


// 5) strong / emphasis
updated = Processor.ConvertStrongAndEmphasis(updated);

// 5.05) Convert lines that are only bold text (hidden headers) into Markdown headers
updated = Processor.ConvertBoldLinesToHeaders(updated);

// 4.5) Convert WordPress <!-- wp:code --> ... <!-- /wp:code --> blocks to fenced code blocks
updated = Processor.ConvertWpCodeBlocksToFenced(updated);



// 6) Normalize code fences and add language heuristics
updated = Processor.NormalizeFencedCodeBlocks(updated);

// 7) Restore placeholders to final markdown
foreach (var kv in placeholders)
    updated = updated.Replace(kv.Key, kv.Value);

// 7.5) Fix closing fenced code block qualifiers (e.g. ```text) and ensure exactly one blank line after
updated = Processor.FixClosingFencedCodeBlockEndings(updated);

// 7.6) Ensure image paths that start with "images/..." get a leading slash -> "/images/..."
updated = Processor.EnsureLeadingSlashForImagePaths(updated);

// 7.6) Rewrite hermit.no WP uploads image URLs to local images/ path
updated = Processor.FixHermitImageUrls(updated);

// 8) Normalize blank lines and ensure a blank line after headers (idempotent)
updated = Processor.NormalizeBlankLinesAndHeaderSpacing(updated);

// 9) Final whitespace fixes
updated = Processor.FixTrailingWhitespaceAndNewline(updated);

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
