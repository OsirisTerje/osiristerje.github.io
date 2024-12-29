---
layout: post
---

# Setting up Visual Studio Code

## C# extension

Add the standard C# extension

## Solution extension

Add the [solution extension](https://marketplace.visualstudio.com/items?itemName=fernandoescolar.vscode-solution-explorer)

This goes together with organizing your code with a parent folder, called solution root, and then having each C# project in a corresponding subfolder.  Add these projects to your solution using the solution extension.

## Debugger

The C# debugger comes with the standard C# extension

Set up the debugger as shown in [this post](https://github.com/OmniSharp/omnisharp-vscode/blob/master/debugger.md)

 If debugger won't start, and saying things like *Omnisharp server not running*, then run the command (from the command palette) *Omniserver restart* and then *Generate assets for debug*.

 When generating assets, you have to select for which project to do this. Thus, you might need to do this multiple times, if you have multiple runnable projects.  Note that classlibs are not runnable by themselves.

 