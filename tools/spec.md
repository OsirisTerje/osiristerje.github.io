# Content cleanup specification

Location: `tools/spec.md`

Purpose: Define the conservative, repository-wide Markdown/HTML cleanup tasks to apply to files under `content/**`. These are low-risk automated edits to make the site content more idiomatic Markdown and reduce escaped XML/HTML noise. Complex HTML (tables, heavily styled blocks) will be flagged for manual review and not auto-converted.

## Summary of changes (high level)

1. Label Windows command-line fences with `cmd` when clearly Windows/cmd content.
2. Convert escaped XML (`&lt;` / `&gt;`) and XML-like fragments into fenced code blocks of type `xml`.
3. Replace inline HTML with Markdown equivalents where safe:
   - `<a href="...">text</a>` -> `[text](url)`
   - anchor-wrapped images: `<a href="..."><img ...></a>` -> `[![alt](img-url)](href)` or `![alt](img-url)` if not a link
   - `<img src="..." alt="...">` -> `![alt](url)` (preserve alt when available)
   - `<p>...</p>` -> plain Markdown paragraph (strip tags)
   - `<strong>` / `<b>` -> `**text**`
   - `<em>` / `<i>` -> `*text*`
   - `<pre><code class="...">...</code></pre>` -> fenced code block using class (or inferred language)
   - `<ul>/<ol>/<li>` -> Markdown lists (`- ` or `1. `)
   - `<h1>..</h1>` .. `<h6>..</h6>` -> Markdown headings (`# ..`..`###### ..`)
4. Normalize fenced code blocks:
   - Ensure closing fences exist.
   - Add language identifiers when the content clearly matches a language (e.g., `xml`, `cmd`, `powershell`, `bash`, `csharp`). Only add labels when confident to avoid mislabeling.
5. Remove or simplify common HTML attributes that don't translate to Markdown (e.g., `target="_blank"`) — remove attribute but keep the link.
6. Preserve or flag content that is risky to auto-convert:
   - HTML tables (`<table>`) — do not auto-convert; flag for manual review.
   - Complex / styled `<pre>` blocks (with inline styles) — flag.
   - Nested `<span>` / `<font>` styling — flag or unwrap to plain text; prefer flagging.
7. Small hygiene fixes where safe:
   - Ensure single trailing newline at end of file.
   - Remove trailing spaces.
   - Fix obvious emphasis-used-as-heading by converting to a real heading when unambiguous.
8. Add alt text to images when it is obvious (file name or surrounding caption); otherwise flag for manual inspection.

## Examples (before -> after)

- Code fence label (cmd):

Before:
````
```
C:\> tf get
C:\> msbuild MySolution.sln
```
````

After:
````
```cmd
C:\> tf get
C:\> msbuild MySolution.sln
```
````

- Escaped XML (paragraphs) -> fenced xml:

Before:

<p>&lt;CodeAnalysisRuleDirectories&gt;$(DevEnvDir)...&lt;/CodeAnalysisRuleDirectories&gt;</p>

After:

```xml
<CodeAnalysisRuleDirectories>$(DevEnvDir)...</CodeAnalysisRuleDirectories>
```

- Anchor -> Markdown link:

Before: `<a href="http://example.com">Example</a>`

After: `[Example](http://example.com)`

- Anchor-wrapped image:

Before: `<a href="/post"><img src="/img.png" alt="x"></a>`

After: `[![x](/img.png)](/post)`

## Contract (inputs, outputs, error modes, success criteria)

- Inputs: Files under `content/**` (Markdown files that may contain inline HTML, escaped XML, unlabeled code fences).
- Outputs: Updated Markdown files with conservative transformations applied, and a short machine-readable log (optional) of files changed and linter warnings remaining.
- Error modes: File changed concurrently (re-read before applying), ambiguous markup (defer/flag), binary or non-markdown files (do not touch).
- Success criteria: No syntax breakages (Markdown files still render as Markdown), no accidental removal of meaningful text, and a reduction in inline-escaped XML cases and unlabeled Windows command fences. Each changed file should have a diff-only change that is human-reviewable.

## Edge cases / heuristics

- Detecting command-line content to label `cmd`:
  - Consider lines starting with `C:\`, `PS C:\`, `tf `, `msbuild`, `nuget`, `choco`, `git `, `dotnet `, `bcdedit`, or Windows prompt `>` patterns.
  - If single-line shell commands that look Unix-like (e.g., `ls`, `./configure`) do not get `cmd`; infer `bash`/`sh` only when clear.
- Escaped XML embedded in HTML attributes or mixed with HTML should be flagged, not auto-converted.
- If a fenced block already has a language, do not change it.
- If a `<a>` tag contains inline HTML (e.g., `<a><strong>...</strong></a>`), convert inner HTML first then the anchor.
- For images without `alt`, try to infer from nearby caption or file name; otherwise flag.
- Files currently being edited by the user: re-read and skip if modified since the read step.

## Implementation approach

- Per-file, small, conservative edits (read file -> compute replacements -> write file). No large multi-file destructive scripts.
- Batch size: ~10 files per batch (safe, reviewable). After each batch, run the linter and record warnings.
- Before editing a file, re-read it to ensure the edit context still matches.
- Maintain a changelog (git commits with focused messages) and optionally a file `tools/cleanup-log.md` summarizing changes per commit.
- Flagging: When content is ambiguous or risky, insert an HTML comment marker at the top of the file such as `<!-- TODO: manual-html-review -->` (only if the file contains flagged constructs), or append a TODO list to `tools/manual-review.md` with file path and reason.

## Verification / tests

- Minimal smoke checks after each batch:
  - Run a repository search for remaining `&lt;` / `&gt;` occurrences to make sure most obvious cases were converted.
  - Run `Select-String` (PowerShell) or similar to detect `<p>` tags left in `content/**`.
  - Optionally run the markdown linter used in prior runs and record MD033/MD047/MD009/MD036 counts.

Suggested commands (PowerShell):

```powershell
# list files with escaped entities
Select-String -Path "content\**\*.md" -Pattern "&lt;|&gt;" -SimpleMatch | Select-Object Path,LineNumber,Line

# list files still containing <p> tags
Select-String -Path "content\**\*.md" -Pattern "<p>" -SimpleMatch | Select-Object Path,LineNumber

# check git status and create a commit after review
git status --porcelain
git add -p
git commit -m "content: conservative markdown cleanup (escaped-xml, simple html -> md, label cmd fences)"
```

## Priority / rollout plan

1. High priority (auto-convert): escaped XML -> fenced xml; unlabeled Windows command fences -> add `cmd` where clear; simple `<p>`, `<a>`, `<img>`, `<strong>` conversions.
2. Medium (auto or semi-auto): simple lists, headings, `<pre><code>` normalization.
3. Low / manual: tables, nested spans, `<font>`, heavy inline styles, complex pre/code with mixed markup.

Batch cadence: run multiple batches until no high-priority patterns remain or until a manual review is requested.

## Output artifacts

- `tools/spec.md` (this file) — specification and checklist.
- (Optional) `tools/manual-review.md` — generated list of files needing human attention.
- (Optional) `tools/cleanup-log.md` — changelog of edits applied.

## Notes & constraints

- Respect the user's active file(s): do not modify `content/posts/2009-07-08-mapping-use-cases-to-code.md` or any other file currently open in the editor unless explicitly allowed.
- Conservative policy: when in doubt, flag for manual review rather than change.
- Keep commits small and self-contained for easy review.

---

If you want, I can now:
- Create `tools/manual-review.md` and scan the repository for flagged files and populate it, or
- Start the first batch of automated edits (I will process up to 10 files, re-read them before editing, and report changes).

Which would you like next?