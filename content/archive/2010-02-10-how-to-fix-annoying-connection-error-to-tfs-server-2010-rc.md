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
<p>This issue has popped up for some after having upgraded from Team System Beta 2 to RC.  You have remembered to uninstall everything (as Jakob points out here: <a title="http://geekswithblogs.net/jakob/archive/2010/02/09/reember-to-uninstall-all-beta-2-stuff-before-upgrading-to.aspx" href="http://geekswithblogs.net/jakob/archive/2010/02/09/reember-to-uninstall-all-beta-2-stuff-before-upgrading-to.aspx">http://geekswithblogs.net/jakob/archive/2010/02/09/reember-to-uninstall-all-beta-2-stuff-before-upgrading-to.aspx</a> but you still get the following error box:</p>  <p><a href="http://gwb.blob.core.windows.net/terje/WindowsLiveWriter/HowtofixannoyingconnectionerrortoTFSserv_106B9/tfs1_2.png"><img style="border-right-width: 0px; display: inline; border-top-width: 0px; border-bottom-width: 0px; border-left-width: 0px" title="tfs1" border="0" alt="tfs1" src="http://hermit.no/wp-content/uploads/2015/08/GWB-WindowsLiveWriter-HowtofixannoyingconnectionerrortoTFSserv_106B9-tfs1_thumb.png" width="244" height="115" /></a></p>  <p>saying <strong>Could not load type 'Microsoft.TeamFoundation.Client.TeamFoundationServerBase' from assembly 'Microsoft.TeamFoundation.Client, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'.</strong></p>  <p>At the same time, you see Power Tools functions are still there in Visual Studio, but no Power Tool appears in the Add/Remove programs.  This is some freak happening when uninstalling the beta Power Tools.</p>  <p>The solution, as first suggested and tried by <a href="http://msmvps.com/blogs/molausson/">Mathias Olausson</a>, is to simply install the beta 2 Power Tools again, and uninstall them again. That seems to solve the problem. </p>