---
id: 155397
title: 'Fix for the &lsquo;Could not find test executor&rsquo; issue with NUnit, XUnit and Chutzpah when using ReSharper in Visual Studio'
date: 2014-02-09T00:25:00+01:00
author: terje
layout: post
guid: http://terje.wpengine.com/?p=155397
permalink: /fix-for-the-lsquo-could-not-find-test-executor-rsquo-issue-with-nunit-xunit-and-chutzpah-when-using-resharper-in-visual-studio/
dsq_thread_id:
  - "4887710440"
categories:
  - Extensions
  - NUnit
  - Resharper
  - Unit Testing
---
This issue is resolved in the latest ReSharper release, version 8.2.0.2160, [download here](http://www.jetbrains.com/resharper/download/). 

The issue appears when using the Test Explorer to run tests in any of the frameworks mentioned in the title.  The tests are shown in the Test Explorer, but are not executed.  It may look like this:

[![image](http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-Fix-for-the_14BC8-image_thumb_3.png "image")](https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/Fix-for-the_14BC8/image_8.png)

Note:  The tests shown dimmed are NUnit and XUnit tests, which have the issue. The other tests are MSTests, which are not affected. The tests are discovered by the adapter, but not executed.

If you look in the Output window, under Tests, a message there says the message above, like:

[![image](http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-Fix-for-the_14BC8-image_thumb.png "image")](https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/Fix-for-the_14BC8/image_2.png)

[![image](http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-Fix-for-the_14BC8-image_thumb_1.png "image")](https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/Fix-for-the_14BC8/image_4.png)

[![image](http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-Fix-for-the_14BC8-image_thumb_2.png "image")](https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/Fix-for-the_14BC8/image_6.png)

One report of this issue is on the Chutzpah [page](https://chutzpah.codeplex.com/workitem/169).

The issue seems to have surfaced in different circumstances. Some people, including myself, noted the issue when we used the [Nuget adapter for NUnit](http://www.nuget.org/packages/NUnitTestAdapter/), which btw is a brilliant way of adding an adapter – and noted that it worked with the extension adapter but not with the NuGet adapter. With the XUnit and Chutzpah however, the issue appeared with the extension test adapters, so it was obviously not the way the adapters were installed that caused the issue to appear.

The common denominator was always ReSharper.  A similar issue was solved in version 8.0.2, but this seems to be another one coming up. 

The current issue is now solved in a pre-release version of ReSharper, version 23.904,  the latest official version is 23.546.  So note that you need to upgrade to this pre-release version if the issue appears. The 904 version doesn’t seem to have any other “bad” issues, as far as I have seen.

This blogpost will be updated when ReSharper is officially updated.