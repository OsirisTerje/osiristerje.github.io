---
id: 160485
title: Adding a terminal window to Visual Studio 2017
date: 2017-12-03T11:49:00+01:00
author: terje
layout: post
guid: http://hermit.no/?p=160485
permalink: /adding-a-terminal-window-to-visual-studio-2017/
dsq_thread_id:
  - "6326136414"
categories:
  - Git
  - Visual Studio
---
<p>Visual Studio 2017 lack a proper internal terminal.&nbsp; The <a href="https://marketplace.visualstudio.com/items?itemName=MadsKristensen.OpenCommandLine" target="_blank">Command Line extension</a> has been a good substitute, but it opens up in a separate window.&nbsp; If you work with multiple Visual Studio at the same time, you loose track of which command window belongs to which Visual Studio instance. <p>Visual Studio Code has it's own Terminal window built-in, so why not Visual Studio itself?&nbsp; Well, now it is here, a pre-pre tool called Whack Whack (named so because of how you open it).&nbsp;&nbsp; <p><a href="http://hermit.no/wp-content/uploads/2017/12/image.png"><img title="image" style="border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px" border="0" alt="image" src="http://hermit.no/wp-content/uploads/2017/12/image_thumb.png" width="542" height="284"></a> <p>It runs default with Powershell, and if you have installed <a href="https://github.com/dahlbyk/posh-git" target="_blank">Posh-git</a> with your powershell, it also lights up inside WhackWhack, which is super cool!&nbsp; If you don’t know posh-git, it adds some cool extras to the command prompt for git, like shown above – you see the current branch and the git status straight off the command prompt and tab completes for commands and branches. <p>You can download the <a href="https://marketplace.visualstudio.com/items?itemName=DanielGriffen.WhackWhackTerminal" target="_blank">Whack Whack terminal from the Visual Studio marketplace</a>, and the project is <a href="https://github.com/Microsoft/WhackWhackTerminal" target="_blank">open sourced at Github</a>.</p> <p>Scott Hanselman has a nice <a href="https://www.hanselman.com/blog/AProperTerminalForVisualStudio.aspx" target="_blank">blogpost</a> on WhackWhack here, which also explains some of the background.</p> <p><strong>Trap</strong>:&nbsp; It should by default use the Ctrl+\,Ctrl+\, but that seems to depend on your Windows installation, probably localization.&nbsp; On my mixed Norwegian/English setup, the key press to start it up was Ctrl+|,Ctrl+|. (yes, that key press twice)&nbsp; (Which in fact worked better on my keyboard layout, since those keys are so much closer than Ctrl+\, so it becomes a one hand operation.)&nbsp; </p> <p>You can anyway see and change the current shortcut from Tools/Options/Environment/Keyboard.&nbsp; </p> <p><a href="http://hermit.no/wp-content/uploads/2017/12/image-1.png"><img title="image" style="border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px" border="0" alt="image" src="http://hermit.no/wp-content/uploads/2017/12/image_thumb-1.png" width="563" height="252"></a></p> <p>You can also start the Terminal window from View/Other Windows/Terminal:</p> <p><a href="http://hermit.no/wp-content/uploads/2017/12/image-2.png"><img title="image" style="border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px" border="0" alt="image" src="http://hermit.no/wp-content/uploads/2017/12/image_thumb-2.png" width="461" height="533"></a></p>