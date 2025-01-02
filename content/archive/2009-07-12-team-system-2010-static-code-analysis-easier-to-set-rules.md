---
id: 133435
title: 'Team System 2010:  Static Code Analysis, easier to set rules'
date: 2009-07-12T12:41:01+01:00
author: terje
layout: post
guid: http://terje.wpengine.com/?p=133435
permalink: /team-system-2010-static-code-analysis-easier-to-set-rules/
categories:
  - none
---
<p>In Visual Studio the settings for static analysis is done on the project property page, a tab called Code Analysis. You can set which code analysis rules you want to be active.  The default in Visual Studio 2008 is to use all.   If you run with this default setting you will generate a lot of "noise", since there are a large set of rules.  You need to create a set containing the rules you and your team find are suitable for your organization and project.  This set you have to apply to every C# project in your solution.  In Visual Studio 2008 there is no easy way to do this.  At Osiris we made an Addin to Visual Studio to ease this.  We defined the set in a separate file, and used the Addin to apply that to all projects in a solution. </p>
<p>With Visual Studio 2010 this will be more easy, because in 2010 you can define sets of rules.  It comes with a default list of sets.   You can also define your own sets, based on any of the others. </p>
<p><a href="http://gwb.blob.core.windows.net/terje/WindowsLiveWriter/TeamSystem2010StaticCodeAnalysis_5770/image_2.png"><img style="BORDER-RIGHT-WIDTH: 0px; BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px" border="0" alt="Code Analysis page" width="559" height="351" src="http://hermit.no/wp-content/uploads/2015/08/GWB-WindowsLiveWriter-TeamSystem2010StaticCodeAnalysis_5770-image_thumb.png" /></a> </p>
<p> </p>
<p>To make your own rule set, just open any of the default ones, make any changes you like to it, and save it under a suitable name.  A rule set file is created, which can be checked in together with the other files of the project.  This file [rule set] can now be used by any other project you have.  So you only need to define it once.</p>
<p> </p>
<p><a href="http://gwb.blob.core.windows.net/terje/WindowsLiveWriter/TeamSystem2010StaticCodeAnalysis_5770/image_4.png"><img style="BORDER-RIGHT-WIDTH: 0px; BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px" border="0" alt="image" width="560" height="408" src="http://hermit.no/wp-content/uploads/2015/08/GWB-WindowsLiveWriter-TeamSystem2010StaticCodeAnalysis_5770-image_thumb_1.png" /></a> </p>
<p>You still have to select it for all the projects in the solution, but this has been made easier by having solution properties, where Code Analysis is one of these setting pages:</p>
<p><a href="http://gwb.blob.core.windows.net/terje/WindowsLiveWriter/TeamSystem2010StaticCodeAnalysis_5770/image_6.png"><img style="BORDER-RIGHT-WIDTH: 0px; BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px" border="0" alt="image" width="565" height="397" src="http://hermit.no/wp-content/uploads/2015/08/GWB-WindowsLiveWriter-TeamSystem2010StaticCodeAnalysis_5770-image_thumb_2.png" /></a> </p>
<p>It's then easy to select the rule set you want for all projects within your solution.</p>