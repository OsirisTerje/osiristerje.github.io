# CleanupTool

A tiny .NET 6 console tool to apply conservative Markdown cleanup transformations to files under `content/**`.

Usage:

```powershell
cd tools
dotnet run --project CleanupTool.csproj -- <path-to-markdown-file>
```

Each transform is implemented as a separate method in `Program.cs` and is intentionally conservative. The tool edits files in-place; no backups are created (use git to manage backups/review).

Transforms implemented (one method per change):
- ConvertEscapedXmlToFencedXml
- LabelWindowsCmdFences
- ConvertAnchorWrappedImages
- ConvertImgTagsToMarkdown
- ConvertAnchorsToMarkdown
- ConvertParagraphTags
- ConvertStrongAndEmphasis
- NormalizeFencedCodeBlocks
- FixTrailingWhitespaceAndNewline

Notes:
- The tool is intended for small, reviewable batches. It will not attempt to convert complex HTML (tables, nested spans) and will leave them as-is for manual review.
- If you want me to run a batch of files now, say how many and I'll proceed.