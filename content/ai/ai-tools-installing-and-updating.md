---
title: "AI Tools — Installing and Updating"
date: 2026-07-19
author: terje
layout: post
---

# AI Tools — Installing and Updating

This page covers how to install and update the AI coding tools Claude Code, GitHub Copilot CLI, and Cursor CLI (Agent).

All npm-based tools require **Node.js 22 or later**.

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
