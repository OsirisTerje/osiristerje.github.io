@echo off
REM Run CleanupTool on every Markdown file under the repository's content\\ folder.
REM Usage: open a Command Prompt, cd to the repo root (where this script lives), then run this script.

SETLOCAL
SET PROJECT=tools\CleanupTool.csproj

dotnet build "%PROJECT%"

echo Running CleanupTool for all files under content\

rem The following loop finds all .md files under the content folder (recursively)
rem and runs the cleanup tool once per file. It prints the file being processed.
for /f "delims=" %%F in ('dir /b /s "content\*.md"') do (
  echo ------------------------------------------------------------
  echo Processing: "%%~fF"
  dotnet run --no-restore --no-build --project "%PROJECT%" -- "%%~fF"
)

echo All done.
ENDLOCAL
