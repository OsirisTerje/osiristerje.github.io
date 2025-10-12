---
id: 160485
title: Adding a terminal window to Visual Studio 2017
date: 2017-12-03T11:49:00+01:00
author: terje
layout: post
categories:
  - Git
  - Visual Studio
---
Visual Studio 2017 lack a proper internal terminal.&nbsp; The [Command Line extension](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.OpenCommandLine) has been a good substitute, but it opens up in a separate window.&nbsp; If you work with multiple Visual Studio at the same time, you loose track of which command window belongs to which Visual Studio instance. <p>Visual Studio Code has it's own Terminal window built-in, so why not Visual Studio itself?&nbsp; Well, now it is here, a pre-pre tool called Whack Whack (named so because of how you open it).&nbsp;&nbsp; <p>[![image](/images/2017/12/image_thumb.png)](/images/2017/12/image.png) <p>It runs default with Powershell, and if you have installed [Posh-git](https://github.com/dahlbyk/posh-git) with your powershell, it also lights up inside WhackWhack, which is super cool!&nbsp; If you don’t know posh-git, it adds some cool extras to the command prompt for git, like shown above – you see the current branch and the git status straight off the command prompt and tab completes for commands and branches. <p>You can download the [Whack Whack terminal from the Visual Studio marketplace](https://marketplace.visualstudio.com/items?itemName=DanielGriffen.WhackWhackTerminal), and the project is [open sourced at Github](https://github.com/Microsoft/WhackWhackTerminal).

 Scott Hanselman has a nice [blogpost](https://www.hanselman.com/blog/AProperTerminalForVisualStudio.aspx) on WhackWhack here, which also explains some of the background.

 **Trap**:&nbsp; It should by default use the Ctrl+\,Ctrl+\, but that seems to depend on your Windows installation, probably localization.&nbsp; On my mixed Norwegian/English setup, the key press to start it up was Ctrl+|,Ctrl+|. (yes, that key press twice)&nbsp; (Which in fact worked better on my keyboard layout, since those keys are so much closer than Ctrl+\, so it becomes a one hand operation.)&nbsp;

 You can anyway see and change the current shortcut from Tools/Options/Environment/Keyboard.&nbsp;

 [![image](/images/2017/12/image_thumb-1.png)](/images/2017/12/image-1.png)

 You can also start the Terminal window from View/Other Windows/Terminal:

 [![image](/images/2017/12/image_thumb-2.png)](/images/2017/12/image-2.png)
