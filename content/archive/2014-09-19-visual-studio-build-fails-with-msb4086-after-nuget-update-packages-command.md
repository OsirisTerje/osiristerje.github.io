---
id: 159183
title: Visual Studio Build fails with MSB4086 after NuGet Update-packages command
date: 2014-09-19T00:38:10+01:00
author: terje
layout: post
guid: http://terje.wpengine.com/?p=159183
permalink: /visual-studio-build-fails-with-msb4086-after-nuget-update-packages-command/
dsq_thread_id:
  - "4153883167"
categories:
  - NuGet
  - Visual Studio
---
<p>I just got into some strange errors after I had done a NuGet update-packages of some package.  The build of the solution after the update failed with a strange error on some numeric comparison which could not be done:</p>  <p><a href="https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/Nuget-Update-packages_1464A/image_2.png"><img title="image" style="border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px" border="0" alt="image" src="http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-Nuget-Update-packages_1464A-image_thumb.png" width="444" height="171" /></a></p>  <p>This one followed by an error list like this:</p>  <p><a href="https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/Nuget-Update-packages_1464A/image_4.png"><img title="image" style="border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px" border="0" alt="image" src="http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-Nuget-Update-packages_1464A-image_thumb_1.png" width="654" height="173" /></a></p>  <p>Restarting Visual Studio makes it go away, but it is still a nuisance. </p>  <p>Since this happened after a NuGet operation I found it useful to mention this to <a href="http://www.xavierdecoster.com/" target="_blank">Xavier Decoster</a> , the author of the <a href="http://www.amazon.com/Pro-NuGet-Experts-Voice-NET/dp/1430260017" target="_blank">Pro NuGet book</a>, and also one of the founders of the superb <a href="http://www.myget.org/" target="_blank">MyGet</a> service, and he asked if I might be using <a href="http://www.jetbrains.com/resharper/" target="_blank">ReSharper</a>.  Which I of course could confirm, who doesn’t ?</p>  <p>It turns of the <a href="http://youtrack.jetbrains.com/issue/RSRP-408376" target="_blank">issue</a> is caused by ReSharper, and was just recently fixed in an update <a href="http://blog.jetbrains.com/dotnet/2014/09/02/resharper-8-2-2-with-jetbrains-account-support-is-here/" target="_blank">8.2.2</a> (I had 8.2.1).  </p>  <p> </p>  <p>So go <a href="http://www.jetbrains.com/resharper/download/index.html" target="_blank">upgrade your ReSharper to 8.2.2</a>, before you do any Nuget Update-packages commands <img class="wlEmoticon wlEmoticon-smile" style="border-top-style: none; border-bottom-style: none; border-right-style: none; border-left-style: none" alt="Smile" src="http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-Nuget-Update-packages_1464A-wlEmoticon-smile_2.png" /></p>