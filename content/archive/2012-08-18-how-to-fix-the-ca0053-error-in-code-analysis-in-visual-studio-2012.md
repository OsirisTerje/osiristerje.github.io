---
id: 150466
title: How to fix the CA0053 error in Code Analysis in Visual Studio 2012
date: 2012-08-18T22:24:27+01:00
author: terje
layout: post
guid: http://terje.wpengine.com/?p=150466
permalink: /how-to-fix-the-ca0053-error-in-code-analysis-in-visual-studio-2012/
dsq_thread_id:
  - "4447935760"
categories:
  - none
---
<h1>Background</h1>  You are opening a solution made in Visual Studio 2010 with VS 2012.  When you run Code Analysis you get a series of CA0053 errors, saying it is unable to load the rule sets from the Visual Studio 2010 directory!

  In the Error window you get an error message saying “Code Analysis detected errors.”

  [![image](http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-How-to-fix-the-CA0053-error-from-Code-An_1129A-image_thumb.png)](http://gwb.blob.core.windows.net/terje/Windows-Live-Writer/How-to-fix-the-CA0053-error-from-Code-An_1129A/image_2.png)

  And in the Code Analysis window you will get the “CA0053 Error running code analysis” with its “Unable to load rule assembly”.

  [![clip_image001](http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-How-to-fix-the-CA0053-error-from-Code-An_1129A-clip_image001_thumb.jpg)](http://gwb.blob.core.windows.net/terje/Windows-Live-Writer/How-to-fix-the-CA0053-error-from-Code-An_1129A/clip_image001_2.jpg)

  This means the project is bound to Visual Studio 2010, where it should have been Visual Studio version independent. The absolute path to the Visual Studio 10 binaries is what causes the problem.

  What has happened was that this certain VS2010 specific information was “inadvertently” introduced in SP1, and it has not been fixed in any later update.

  It does NOT happen if you run in Debug|x86 or Release|x86, but any other configuration you have added will give you this error.

  <h1>**Fixing the error**</h1>  The error must be fixed by changing the project files.  If you have only a few projects in your solution, you can fix them manually.  If you have a lot of projects in your solution, I have uploaded a small tool to help in the process.  After the fix, the projects will work both in VS 2010 and in VS 2012 with no side effects.

  The error seems to be introduced only when a new configuration is created.  Subsequent changes to an existing configuration doesn’t seem to reintroduce the error.  So the fixes below will stay fixed.  Be aware that if anyone adds a new configuration using VS 2010, the error will be introduced again for that new configuration.  Then run the fix again.

  <font color="#ff0000">Update:  It has been reported that also other changes you do (not identified which yet) may revert the change, see for example </font>[this blogpost](http://codemlia.com/blog/post/2012/09/15/code-analysis-ca0053-building-vs-2010-projects-in-vs-2012.aspx)<font color="#ff0000">.</font>

  The bug is fixed in VS2012 however, so if you use VS 2012 to add new configuration, all will be well, and those configurations will be backward compatible with VS 2010.

  <h3>Manual fix</h3>  Open the project file in an editor.

  You do this by right click the project in the solution editor and either choose “Edit Project File” or “Unload Project” followed by “Edit” afterwards.

  Now find all occurrences of the string “**Microsoft Visual Studio 10.0**”

  They should all be in two fields, named &lt;CodeAnalysisRuleDirectories&gt; and &lt;CodeAnalysisRuleSetDirectories&gt;.

  <h6>Alternative 1:  The very safe way</h6>  Replace the content to be as follows:

  &lt;CodeAnalysisRuleDirectories&gt;$(DevEnvDir)....Team ToolsStatic Analysis ToolsFxCopRules&lt;/CodeAnalysisRuleDirectories&gt;

  &lt;CodeAnalysisRuleSetDirectories&gt;$(DevEnvDir)....Team ToolsStatic Analysis ToolsRule Sets&lt;/CodeAnalysisRuleSetDirectories&gt;

  <h6>Alternative 2: Which seems to work</h6>  Simply delete the fields completely.

  It seems to work in the conditions I have tested, but if you should get into a condition where it doesn’t work, go back to alternative 1 for that case.  And please, send me a note, I would like to know.

  (I noted this [blogpost](http://msmvps.com/blogs/alunj/archive/2012/03/04/1806901.aspx) by Alun Jones , where he deleted only the content of the field, that should also work)

  PS:  Why not use Find/Replace:  You can try, but the full content of the fields will differ dependent upon what operating system you run, x86 or x64, and if both have been used, for example because your team’s developers have both, all of these paths will be written into these fields.  That is at least 4 permutations.  A tool is better!



  <h3>Automatic fix using the <font color="#ff0000">[FixCA0053](http://visualstudiogallery.msdn.microsoft.com/471da13b-d415-4a44-a4e9-a8222316b902)</font> tool</h3>  The tool can be downloaded from [Visual Studio Gallery here](http://visualstudiogallery.msdn.microsoft.com/471da13b-d415-4a44-a4e9-a8222316b902).   Place it somewhere easy to find.

  Open a command line window, and go down to the top directory of your project.

  Then simply call the program from there.

  The program will locate all the csproj files from that location and in all subdirectories of that location, and change the fields as in Alternative 1 above.

  The tool will output how many files it fixed, and how many was skipped because the error was not there.

  [![image](http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-How-to-fix-the-CA0053-error-from-Code-An_1129A-image_thumb_1.png)](http://gwb.blob.core.windows.net/terje/Windows-Live-Writer/How-to-fix-the-CA0053-error-from-Code-An_1129A/image_4.png)

  <h3>TIP</h3>  If it tells you it could not write to some files, you have probably forgot to check them out.  To check out ONLY the csproj files (In Solution Explorer it will check out all files, you may not want that), use the Source Control Explorer, go to the location where you want to start, right click and choose Find in Source control/Wildcard.  Enter the Wildcard “*.csproj” and check Recursive.  In the next window coming up, you can select all the files, right click and choose “Check out”.

  <h3>Source code</h3>  The source code can be found at [https://github.com/OsirisTerje/FixCA0053](https://github.com/OsirisTerje/FixCA0053)
