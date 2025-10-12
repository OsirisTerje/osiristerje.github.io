---
id: 149816
title: Fixing some Visual Studio 2012 RC install issues
date: 2012-06-05T13:16:38+01:00
author: terje
layout: post
categories:
  - Visual Studio
---
<font size="2"><font color="#ff0000">Updated: June 7th 2012:  Cause for the issues found! Unsupported scenario having TFS 11 Beta side-by-side.  Uninstall TFS 11 Beta before or even after install of VS 2012 RC. </font></font>

  <font size="2">The Visual Studio RC has shown some install issues in some cases, particularly for those who upgrades from VS 11 Beta.  These issues are caused by also having TFS 11 Beta server installed on the same machine.  This is not a supported scenario.  What is good is that if you forget to uninstall TFS Beta 11 first, and get these issues, all that is required is to uninstall TFS 11 Beta, and VS 2012 RC will start working correctly!</font>

  <font size="2"></font>

  <font size="2">I have listed the symptoms known now below, and will update if there are more issues.  Note that a repair will not fix the issue, and a Windows restore and subsequent reinstall may not fix it either.  The fixes below however, cures these issues, but you don’t have to do these now, just <u>uninstall TFS 11 beta!</u></font>

  <font size="2">This [forum post](http://social.msdn.microsoft.com/Forums/en-US/TFSvnext/thread/eafd3f20-2da2-4c5f-81cc-49b4d183f3f1/) is about the same issues.</font>

  <font size="2"></font>

  <font size="2"></font>

## <font size="2">1. The Team Explorer Build node fails</font>

  <font size="2">When you try to access the Team Explorer Build node, you get a System.TypeLoadException error like this:</font>

  <font size="2">*System.TypeLoadException: Could not load type 'Microsoft.TeamFoundation.Common.TfsBackgroundWorkerManager'*</font>

  [![clip_image001](/images/2015/08/GWB-Windows-Live-Writer-Fixing-some-Visual-Studio-RC-install-iss_A826-clip_image001_thumb.png)](http://gwb.blob.core.windows.net/terje/Windows-Live-Writer/Fixing-some-Visual-Studio-RC-install-iss_A826/clip_image001_2.png)

  <font size="2">To solve this do as follows:</font>

  <font size="2">1. Open a command prompt as administrator</font>

  <font size="2">2. Go to your program files directory for VS 2012 and down to  the extension folder like:   C:Program Files (x86)Microsoft Visual Studio 11.0Common7IDECommonExtensionsMicrosoftTeamFoundationTeam Explorer </font>

  <font size="2">3. Run “gacutil –if Microsoft.TeamFoundation.Build.Controls.dll</font>

  [![clip_image002](/images/2015/08/GWB-Windows-Live-Writer-Fixing-some-Visual-Studio-RC-install-iss_A826-clip_image002_thumb.jpg)](http://gwb.blob.core.windows.net/terje/Windows-Live-Writer/Fixing-some-Visual-Studio-RC-install-iss_A826/clip_image002_2.jpg)

## <font size="2">2. Accessing the Process node on Edit Build Definition fails</font>

  <font size="2">When you Edit a build definition and open the Process tab, it starts to load the custom assemblies (if you have any), then it stops before displaying the process parameters, with the messagebox : *Team Foundation Error: Method not found: ‘System.String Microsoft.TeamFoundation.Build.Workflow.ProcessParameterError.get_ParameterValue()’*</font>

  [![image](/images/2015/08/GWB-Windows-Live-Writer-Fixing-some-Visual-Studio-RC-install-iss_A826-image_thumb_2.png)](http://gwb.blob.core.windows.net/terje/Windows-Live-Writer/Fixing-some-Visual-Studio-RC-install-iss_A826/image_6.png)

## <font size="2"></font>

  <font size="2">To solve this do as follows:</font>

  <font size="2">1. Go to C:Program Files (x86)Microsoft Visual Studio 11.0Common7IDEPrivateAssemblies</font>

  <font size="2">2. Run gacutil /if Microsoft.TeamFoundation.Build.Workflow.dll</font>

## <font size="2"></font>

### <font size="2"></font>

#### <font size="2"></font>

##### <font size="2">3. The SQL Editor gives loading error</font>

  <font size="2">When you start up VS 2012 RC you get a loading error message.  The same happens if you try to go from the menu to  SQL/Transact-SQL Editor/New Query.</font>

  <font size="2">The *‘SqlStudio Editor Package’ package did not load correctly*, or  *The ‘SqlStudio Profile Package’ package did not load correctly*, or *The ‘Microsoft.VisualStudio.Data.Tools.SqlLanguageServices.Package’ did not load correctly*.  You might even get all of these.</font>

  [![clip_image001](/images/2015/08/GWB-Windows-Live-Writer-Fixing-some-Visual-Studio-RC-install-iss_A826-clip_image001_thumb.jpg)](http://gwb.blob.core.windows.net/terje/Windows-Live-Writer/Fixing-some-Visual-Studio-RC-install-iss_A826/clip_image001_2.jpg)

  <font size="2">To solve this do as follows:</font>

  <font size="2">1. Open Control Panel/Programs and Features</font>

  <font size="2">2. Locate the “Microsoft SQL Server 2012 Data-Tier App Framework</font>

  <font size="2">    (Note , you might find up to 4 such instances)</font>

  [![clip_image002[5]](/images/2015/08/GWB-Windows-Live-Writer-Fixing-some-Visual-Studio-RC-install-iss_A826-clip_image0025_thumb.jpg)](http://gwb.blob.core.windows.net/terje/Windows-Live-Writer/Fixing-some-Visual-Studio-RC-install-iss_A826/clip_image0025.jpg)

  <font size="2">The ones with version numbers ending in 55 is from the SQL 2012 RC, the ones ending in 60 is from the SQL 2012 RTM.  There are two of each, one for x32 and one for x64.  Which is which no one knows. </font>

  <font size="2">3. Right click each of them, and select Repair.</font>

  <font size="2">(It would be nice if someone with this issue tries only the latest RTM ones, and see if that clears the error, and comment back to this post. I am out of non-functioning VS’s )</font>

  <font size="2">**4.  Errors referring to some extension**</font>

  You get errors referring to some extension that can’t be loaded, or can’t be found.  Check the activity log (see below), and verify there.  If you see yellow collision warnings there, the fix here should solve those too.

  To solve these:

  1. Open a Visual Studio 2012 command prompt

  2.  Run:   devenv /resetsettings

  <font size="2">**How to check for errors using the log**</font>

  <font size="2">Do as follows to get to the activity log for Visual studio 2012 RC</font>

  <font size="2">1. Open a Visual Studio 2012 command prompt</font>

  <font size="2">2. Run:   devenv /log</font>

  <font size="2">This starts up Visual Studio.  </font>

  <font size="2">3. Go to %appdata%/MicrosoftVisualStudio11.0</font>

  [![image](/images/2015/08/GWB-Windows-Live-Writer-Fixing-some-Visual-Studio-RC-install-iss_A826-image_thumb.png)](http://gwb.blob.core.windows.net/terje/Windows-Live-Writer/Fixing-some-Visual-Studio-RC-install-iss_A826/image_2.png)

  <font size="2">4. Double click the file named ActivityLog.xml.  </font>

  <font size="2">It will start up in your browser, and be formatted using the xslt in the same directory. </font>

  <font size="2">5.  Look for items marked in red.  </font>

  <font size="2">Example for Issue 1 :</font>

  [![image](/images/2015/08/GWB-Windows-Live-Writer-Fixing-some-Visual-Studio-RC-install-iss_A826-image_thumb_1.png)](http://gwb.blob.core.windows.net/terje/Windows-Live-Writer/Fixing-some-Visual-Studio-RC-install-iss_A826/image_4.png)
