---
id: 135691
title: Branched history working in Visual Studio 2010 using TFS Server 2008
date: 2009-10-24T16:59:05+01:00
author: terje
layout: post
categories:
  - Uncategorized
---
Visual Studio 2010 (beta 2) can be connected to an existing TFS 2008 Server.  Much of the new great stuff is then not available, quite naturally.  But I was quite positively surprised that some stuff I had not expected to work in fact did.  Which of course means it’s client stuff more than server stuff. Anyway, here comes:

History across branches:  You can now see the history of a versioned item even it started it’s life in another branch, and even if you are connected to a TFS 2008 server.

[![Branched history screenshot](/images/2015/08/GWB-WindowsLiveWriter-BranchedHistory_5775-image_thumb.png)](http://gwb.blob.core.windows.net/terje/WindowsLiveWriter/BranchedHistory_5775/image.png)

You can see that this item started out in a Development (Feature) branch, changeset 33008, but in changeset 34502 it was merged into the Main.

If you use branched history you will probably also want to change your workspace mappings so the branch is mapped into a folder location that more closely matches the real folder structure of the branch. This makes it easier to navigate between branches when sharing a workspace between branches. For example, you may map the root of the branch into a folder with the same name as the branch. You do this by editing your workspace mappings and changing the server path mapping to the appropriate branch path.

When working with branched history you'll often want to use a workspace that contains mappings for only one branch.
