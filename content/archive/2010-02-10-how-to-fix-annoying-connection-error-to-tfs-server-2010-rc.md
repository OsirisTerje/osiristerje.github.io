---
id: 137911
title: How to fix annoying connection error to TFS server 2010 RC
date: 2010-02-10T12:50:22+01:00
author: terje
layout: post
guid: http://terje.wpengine.com/?p=137911
permalink: /how-to-fix-annoying-connection-error-to-tfs-server-2010-rc/
categories:
  - none
---
This issue has popped up for some after having upgraded from Team System Beta 2 to RC. You have remembered to uninstall everything (as Jakob points out here: [http://geekswithblogs.net/jakob/archive/2010/02/09/reember-to-uninstall-all-beta-2-stuff-before-upgrading-to.aspx](http://geekswithblogs.net/jakob/archive/2010/02/09/reember-to-uninstall-all-beta-2-stuff-before-upgrading-to.aspx)) but you still get the following error box:

[![tfs1](http://hermit.no/wp-content/uploads/2015/08/GWB-WindowsLiveWriter-HowtofixannoyingconnectionerrortoTFSserv_106B9-tfs1_thumb.png)](http://gwb.blob.core.windows.net/terje/WindowsLiveWriter/HowtofixannoyingconnectionerrortoTFSserv_106B9/tfs1_2.png)

saying **Could not load type 'Microsoft.TeamFoundation.Client.TeamFoundationServerBase' from assembly 'Microsoft.TeamFoundation.Client, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'.**

At the same time, you see Power Tools functions are still there in Visual Studio, but no Power Tool appears in the Add/Remove programs. This is some freak happening when uninstalling the beta Power Tools.

The solution, as first suggested and tried by [Mathias Olausson](http://msmvps.com/blogs/molausson/), is to simply install the beta 2 Power Tools again, and uninstall them again. That seems to solve the problem.