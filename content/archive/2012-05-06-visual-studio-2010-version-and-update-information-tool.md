---
id: 149552
title: 'Visual Studio 2010: Version and update information tool'
date: 2012-05-06T23:24:25+01:00
author: terje
layout: post
guid: https://terje.wpengine.com/?p=149552
permalink: /visual-studio-2010-version-and-update-information-tool/
dsq_thread_id:
  - "4943572100"
categories:
  - none
---

[Download from VS Gallery](https://visualstudiogallery.msdn.microsoft.com/bce6cbf1-fb55-4a7d-b39b-8589634d846f)

In my work I meet many developers, tester and project managers, all using Visual Studio. When I ask them if they have updated it to the latest version, there are many who simply don't know. Should you always update? YES, you should. The Visual Studio development teams are continuously making improvements to the product. The question also often comes when we notice that something doesn't quite work the way it should, and we then realize it is caused by not having the latest update. The next issue then comes – how do we find out IF the latest version is installed. That should be trivial, but it isn't.

If you look at the Help/About in Visual Studio, it tells you if you have SP1 or just the RTM version installed. So far so good.

[![SNAGHTML39499e](https://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-Visual-Studio-2010-Version-and-update-i_116FA-SNAGHTML39499e_thumb.png)](https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/Visual-Studio-2010--Version-and-update-i_116FA/SNAGHTML39499e.png)

But to find out if you have the latest update, you need to scroll down (green arrows), and then, what you find is a series of hotfix numbers.

[![image](https://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-Visual-Studio-2010-Version-and-update-i_116FA-image_thumb.png)](https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/Visual-Studio-2010--Version-and-update-i_116FA/image_2.png)

Only SOME of these indicates the correct cumulative updates that have been, five in all for the SP1. And, do you know what IS the latest version – I have a list published [here](https://geekswithblogs.net/terje/archive/2010/12/05/visual-studio-amp-tfs-ndash-list-of-addins-extensions-patches.aspx), but still – it is hard work!

So, enter the **Version and Update Info Tool**. Install it from here: [https://visualstudiogallery.msdn.microsoft.com/bce6cbf1-fb55-4a7d-b39b-8589634d846f](https://visualstudiogallery.msdn.microsoft.com/bce6cbf1-fb55-4a7d-b39b-8589634d846f)

Go to the Visual Studio Help menu, next to the bottom is "Version Info", select it and if everything is as it should be, this is what it should show:

[![SNAGHTML5618a0](https://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-Visual-Studio-2010-Version-and-update-i_116FA-SNAGHTML5618a0_thumb.png)](https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/Visual-Studio-2010--Version-and-update-i_116FA/SNAGHTML5618a0.png)

However, if you are lagging behind in your updates, this might be what you will see then:

[![clip_image002](https://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-Visual-Studio-2010-Version-and-update-i_116FA-clip_image002_thumb.jpg)](https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/Visual-Studio-2010--Version-and-update-i_116FA/clip_image002_2.jpg)

Or, if you have the SP1 but have missed the later updates:

[![clip_image002[5]](https://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-Visual-Studio-2010-Version-and-update-i_116FA-clip_image0025_thumb.jpg)](https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/Visual-Studio-2010--Version-and-update-i_116FA/clip_image0025.jpg)

The tool gives you links to the download sites, and also to information pages for the updates. If you want information on what your current updates is, you have the name there, and if you [go here](https://geekswithblogs.net/terje/archive/2010/12/05/visual-studio-amp-tfs-ndash-list-of-addins-extensions-patches.aspx), at the bottom of that post, the different updates are listed with links to information pages for them.

The principles for updating Visual Studio is to first get it up to SP1. Then you install the latest cumulative update, which is the GRD March 2012. I call this for the CU3, because it is a cumulative update. It is named very strangely at the download site [Visual Studio 2010 SP1 Team Foundation Server 11 Compatibility GDR](https://www.microsoft.com/en-us/download/details.aspx?id=29082), but it is the correct one.

If any new updates for VS 2010 arrives, the Version Info Tool will be updated accordingly.

Be aware that these updates apply to the Visual Studio Client Tools, and that includes the Test Manager.

And if I get enough available time, I will add it to the top level menu or the status bar IF you are outdated. That way you will not need to even check it, it will do that for you. After that, automatic download and update warning would be cool – like it will be in Visual Studio 11.