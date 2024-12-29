---
id: 135691
title: Branched history working in Visual Studio 2010 using TFS Server 2008
date: 2009-10-24T16:59:05+01:00
author: terje
layout: post
guid: http://terje.wpengine.com/?p=135691
permalink: /branched-history-working-in-visual-studio-2010-using-tfs-server-2008/
dsq_thread_id:
  - "5105999313"
categories:
  - Uncategorized
---
<p>Visual Studio 2010 (beta 2) can be connected to an existing TFS 2008 Server.  Much of the new great stuff is then not available, quite naturally.  But I was quite positively surprised that some stuff I had not expected to work in fact did.  Which of course means it’s client stuff more than server stuff. Anyway, here comes:</p>  <p>History across branches:  You can now see the history of a versioned item even it started it’s life in another branch, and even if you are connected to a TFS 2008 server.</p>  <p><a href="http://gwb.blob.core.windows.net/terje/WindowsLiveWriter/BranchedhistoryworkinginVisualStudio2010_14334/History_2.jpg"><img style="border-bottom: 0px; border-left: 0px; display: inline; border-top: 0px; border-right: 0px" title="History" border="0" alt="History" src="http://hermit.no/wp-content/uploads/2015/08/GWB-WindowsLiveWriter-BranchedhistoryworkinginVisualStudio2010_14334-History_thumb.jpg" width="516" height="147" /></a> </p>  <p>You can see that this item started out in a Development (Feature) branch, changeset 33008, but in changeset 34502 it was merged into the Main.  </p>