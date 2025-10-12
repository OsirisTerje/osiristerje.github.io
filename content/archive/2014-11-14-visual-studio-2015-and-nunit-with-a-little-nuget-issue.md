---
id: 160201
title: Visual Studio 2015 and NUnit, with a little NuGet issue
date: 2014-11-14T14:20:52+01:00
author: terje
layout: post
pl-settings:
  - 'a:2:{s:4:"live";a:0:{}s:5:"draft";a:0:{}}'
pl-draft:
  - ""
categories:
  - NuGet
  - NUnit
---
<font size="2" face="Segoe UI">**NUGET**</font>

  <font size="2" face="Segoe UI">The current version 1.2 of the NuGet adapters for NUnit works with the VS 2015 Preview (and earlier CTPs).  </font>

  <font size="2" face="Segoe UI">You can find them here:  </font>[http://www.nuget.org/packages/NUnitTestAdapter/](http://www.nuget.org/packages/NUnitTestAdapter/)<font size="2" face="Segoe UI">  and with framework: </font>[http://www.nuget.org/packages/NUnitTestAdapter.WithFramework/](http://www.nuget.org/packages/NUnitTestAdapter.WithFramework/)

  <font size="2" face="Segoe UI">Add one of these to your solution and it works without having the VSIX installed, both for VS2015 and for TFS build, including VSO build.  Note that you only need to add one of these to one of your projects in the solution.  </font>

  <font size="2" face="Segoe UI">The use of these NuGet based adapters is preferred since they don’t require any developer to install anything on his own machine, and also make it easier to run on TFS build. </font>

  <font size="2" face="Segoe UI">I prefer to install them by opening the NuGet console, and choosing a relevant project, just one of the test projects, it doesn’t matter which one.</font>

  [![image](/images/2015/08/GWB-Windows-Live-Writer-07fa34ba10da_A1B0-image_thumb_1.png)](https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/07fa34ba10da_A1B0/image_4.png)

  <font size="2" face="Segoe UI"></font>

  <font size="2" face="Segoe UI">Choosing (1), the console, takes you into the screen below:</font>

  [![image](/images/2015/08/GWB-Windows-Live-Writer-07fa34ba10da_A1B0-image_thumb_3.png)](https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/07fa34ba10da_A1B0/image_8.png)

  *NOTE:  If you do get the yellow line warning, and you don’t have it in the cache, you must use option 2 below.  This is a bug somewhere in the console, since this work from the Manager shown below.  There are different workarounds on the net, but none seems to work consistently.*

  <font size="2" face="Segoe UI">In my case it worked because I had it in my local cache.</font>

  <font size="2" face="Segoe UI"></font>

  <font size="2" face="Segoe UI">Choosing (2), the manager, takes you into the new NuGet dialog below:</font>

  [![image](/images/2015/08/GWB-Windows-Live-Writer-07fa34ba10da_A1B0-image_thumb_2.png)](https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/07fa34ba10da_A1B0/image_6.png)

  <font size="2" face="Segoe UI"></font>

  <font size="2" face="Segoe UI">And then writing some tests and verifying it works in Visual Studio  2015</font>

 [![image](/images/2015/08/GWB-Windows-Live-Writer-07fa34ba10da_A1B0-image_thumb_6.png)](https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/07fa34ba10da_A1B0/image_14.png)  <font size="2" face="Segoe UI"></font>

  <font size="2" face="Segoe UI"></font>

  <font size="2" face="Segoe UI">****</font>

  <font size="2" face="Segoe UI">using NUnit parameterized tests – isn't that cool !</font>

  <font size="2" face="Segoe UI">****</font>

  <font size="2" face="Segoe UI">**VSIX**</font>

  <font size="2" face="Segoe UI">The VSIX must be enabled for 2015, and we will update it pretty soon - but you can grab a debug preview at </font>[https://bintray.com/nunit/NUnitAdapter/NUnitAdapter/1.2.0.1/view](https://bintray.com/nunit/NUnitAdapter/NUnitAdapter/1.2.0.1/view)

  <font size="2" face="Segoe UI">(This VSIX will be updated when a newer production version appears.)</font>

  <font size="2" face="Segoe UI">There is also  no real code changes here, so it should work fine, but we have not run it through all the testing yet.  If you find anything, please report it at </font>[https://github.com/nunit/nunit-vs-adapter/issues](https://github.com/nunit/nunit-vs-adapter/issues)<font size="2" face="Segoe UI"> .  That really helps us. </font>

  <font size="2" face="Segoe UI">Note that the same VSIX also works with all previous Visual Studio versions, after VS 2012.</font>

  <font size="2" face="Segoe UI"></font>

  <font size="2" face="Segoe UI">**ASP.NET 5**</font>

  <font size="2" face="Segoe UI">These adapters works with the standard .Net 4.5 projects, but they will NOT work with the new ASP.Net 5 projects, they require a K-runner, and we have not finished that yet.   I will update this post when it is ready. </font>
