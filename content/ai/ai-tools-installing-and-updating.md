---
title: "AI Tools — Installing and Updating"
date: 2026-07-19
author: terje
layout: post
---

# AI Tools — Installing and Updating

This page covers how to install and update the AI coding tools Claude Code, GitHub Copilot CLI, OpenAI Codex CLI, and Cursor CLI (Agent).

All npm-based tools require **Node.js 22 or later**.

**Quick links:** [Current Version](#current-version) · [Installing](#installing) · [Updating](#updating) · [Checking Usage](#checking-usage)

---

## Current Version

```cmd
claude --version
copilot --version
codex --version
agent --version
```

---

## Installing

### Claude Code

Claude Code is Anthropic's official CLI. Install it globally via npm:

```bash
npm install -g @anthropic-ai/claude-code
```

On first run it will open a browser window and ask you to authenticate with your Anthropic account.

### GitHub Copilot CLI

GitHub Copilot CLI brings Copilot assistance to the terminal. Install it globally via npm:

```bash
npm install -g @github/copilot
```

On first launch, run `/login` and follow the prompts to authenticate with your GitHub account.

As an alternative, if you have the GitHub CLI (`gh`) installed, you can also install and run it through that:

```bash
gh copilot
```

### OpenAI Codex CLI

OpenAI Codex CLI is a terminal-native coding agent. Install it globally via npm:

```bash
npm install -g @openai/codex
```

> **Note:** Use `@openai/codex`, not `codex` — the unscoped `codex` package on npm is an unrelated 2012 project.

### Cursor CLI (Agent)

Cursor CLI runs the Cursor agent headlessly from the terminal. It is installed via a shell script, not npm:

```bash
curl https://cursor.com/install -fsSL | bash
```

> **Note:** On Windows, set up WSL (Windows Subsystem for Linux) before running this command, as the tooling assumes a Unix-like environment.

After installation the primary command is `agent`. The older `cursor-agent` alias still works.

---

## Updating

### Claude Code

```bash
npm update -g @anthropic-ai/claude-code
```

> **Note:** Claude Code's updater often needs to run an install script as part of the update. If you hit a prompt or failure related to that, use the full form instead:
>
> ```bash
> npm install -g @anthropic-ai/claude-code@latest --allow-scripts=@anthropic-ai/claude-code
> ```
>
> To avoid typing this every time, allow the script once and go back to the short form:
>
> ```bash
> npm config set allow-scripts=@anthropic-ai/claude-code --location=user
> ```

### GitHub Copilot CLI

```bash
npm update -g @github/copilot
```

### OpenAI Codex CLI

```bash
npm update -g @openai/codex
```

### Cursor CLI (Agent)

Re-run the install script — it will replace the existing installation with the latest version:

```bash
curl https://cursor.com/install -fsSL | bash
```

---

## Checking Usage

Each tool has both a web dashboard and an in-CLI command for checking how much of your monthly quota remains.

| Tool                 | Web dashboard                                                              | In-CLI check                                                    |
| --------------------- | --------------------------------------------------------------------------- | ------------------------------------------------------------------ |
| Claude Code           | [claude.ai/settings/usage](https://claude.ai/settings/usage)               | `/usage` (plan limits, 5-hour + weekly rate-limit status), `/status` |
| GitHub Copilot CLI     | [github.com/settings/copilot](https://github.com/settings/copilot) → Billing & Licensing → Usage by product → Copilot | `/usage` (current session's consumption)                        |
| OpenAI Codex CLI       | [chatgpt.com/codex/pricing](https://chatgpt.com/codex/pricing/)            | `/status` (remaining tokens for the 5-hour and weekly windows)   |
| Cursor CLI (Agent)     | [cursor.com/settings](https://cursor.com/settings)                        | —                                                                 |

> **Note:** For Claude Code and Codex CLI, the in-CLI `/status` (or `/usage`) command is more reliable than the web dashboard for seeing where you stand right now — the dashboards tend to show historical totals and can lag by a few minutes. GitHub Copilot's premium request usage resets on the 1st of each month at 00:00 UTC. Cursor's usage dashboard has been reported to render blank for some users — a known issue, not misconfiguration on your end.
