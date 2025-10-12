---
id: 159183
title: Visual Studio Build fails with MSB4086 after NuGet Update-packages command
date: 2014-09-19T00:38:10+01:00
author: terje
layout: post
categories:
  - NuGet
  - Visual Studio
---
I just got into some strange errors after I had done a NuGet update-packages of some package.  The build of the solution after the update failed with a strange error on some numeric comparison which could not be done:

  [![image](/images/2015/08/GWB-Windows-Live-Writer-Nuget-Update-packages_1464A-image_thumb.png)](https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/Nuget-Update-packages_1464A/image_2.png)

  This one followed by an error list like this:

  [![image](/images/2015/08/GWB-Windows-Live-Writer-Nuget-Update-packages_1464A-image_thumb_1.png)](https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/Nuget-Update-packages_1464A/image_4.png)

  Restarting Visual Studio makes it go away, but it is still a nuisance.

  Since this happened after a NuGet operation I found it useful to mention this to [Xavier Decoster](http://www.xavierdecoster.com/) , the author of the [Pro NuGet book](http://www.amazon.com/Pro-NuGet-Experts-Voice-NET/dp/1430260017), and also one of the founders of the superb [MyGet](http://www.myget.org/) service, and he asked if I might be using [ReSharper](http://www.jetbrains.com/resharper/).  Which I of course could confirm, who doesn’t ?

  It turns of the [issue](http://youtrack.jetbrains.com/issue/RSRP-408376) is caused by ReSharper, and was just recently fixed in an update [8.2.2](http://blog.jetbrains.com/dotnet/2014/09/02/resharper-8-2-2-with-jetbrains-account-support-is-here/) (I had 8.2.1).

  So go [upgrade your ReSharper to 8.2.2](http://www.jetbrains.com/resharper/download/index.html), before you do any Nuget Update-packages commands ![Smile](/images/2015/08/GWB-Windows-Live-Writer-Nuget-Update-packages_1464A-wlEmoticon-smile_2.png)
