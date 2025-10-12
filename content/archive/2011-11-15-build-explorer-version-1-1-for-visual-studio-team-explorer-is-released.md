---
id: 147712
title: Build Explorer version 1.1 for Visual Studio Team Explorer is released
date: 2011-11-15T21:02:30+01:00
author: terje
layout: post
categories:
  - Uncategorized
---
Our free extension to Visual Studio , the folder based Build Explorer Version 1.1 has now been released, and uploaded to the [Visual Studio Gallery](http://visualstudiogallery.msdn.microsoft.com/35daa606-4917-43c4-98ab-38632d9dbd45) and [Codeplex](http://tfsbuildfolders.codeplex.com/). We have collected up a few changes and some bugs, as follows:

  Changes:

  <ul>   <li>Queue Default Builds can now be optionally fully enabled, fully disabled or enabled just for leaf nodes (=disabled for folders).  If you got a large number of builds it was pretty scary to be able to launch all of them with just one click.  However, it is nice to avoid having the dialog box up when you want to just run off a single build.  That’s the reasoning between the 3rd choice here. </li>    <li>Auto fill-in of the builds at start up and refresh  This was a request that came up a lot, and which was also irritating to us.  When the Team Project is opened, the Build explorer will start by itself and fill up it’s tree. So you don’t need to click the node anymore.      <ul>       <li>There was also quite a bit of flashing when the tree filled up, this has been reduced to just a single top level fill before it collapses the node. </li>        <li>The speed of the buildup of the tree has also been increased. </li>     </ul>   </li>    <li>The “All Build Definitions” node is now shown on top of the list </li>    <li>Login box appeared in certain cross domain situations. This was a fix for the TF30063 authentication problem we had in the beginning.  Hopefully the new code has that fixed properly so that both the login box and the TF30063 are gone forever.  Our testing so far seems to indicate it works.  If anyone gets a real problem here there are two workarounds: 1) Turn off the auto refresh to reduce the issue. If this doesn’t fix it, then 2) please reinstall the former version (go to the [codeplex download site](http://tfsbuildfolders.codeplex.com/releases/view/66182) if you don’t have it anymore)  Write a comment to this blog post with a description of what happens, and I will send a temporary fix asap. </li> </ul>  Bug fixes:

  <ul>   <li>The folder name matching was case sensitive, so “Application.CI” and “application.CI” created two different folders.  </li>    <li>View all builds not shown for leaf odes, and view builds didn’t work in all cases.  There was some inconsistencies here which have been fixed. </li>    <li>Partly fixed:  The context menu to queue a new build for disabled builds should be removed, but that was a difficult one, and is still on the list, but the command will not do anything for a disabled build. </li>    <li>Using the Queue Default Builds on a folder, and if it had some disabled builds below an error box appeared and ruined the whole experience. </li> </ul>  As a result of these fixes there has been introduced some new options, as shown below:

  [![image](/images/2015/08/GWB-Windows-Live-Writer-Build-Explorer-update-released_F166-image_thumb.png)](http://gwb.blob.core.windows.net/terje/Windows-Live-Writer/Build-Explorer-update-released_F166/image_2.png)

  The two first settings, the Separator symbol and the options for how to handle Queuing of default builds are set per Team Project, and is stored in the TFS source control under the BuildProcessTemplates folder, with the name Inmeta.VisualStudio.BuildExplorer.Settings.xml

  The next two settings need some explanations.  They handle the behavior for the auto update of the build folders.  First, these are stored in the local registry per user, at the key HKEY_CURRENT_USER/SoftwareInmetaBuildExplorer.

  The first option Use Timed Refresh at Startup, if turned off, you will need to click the node as it is done in Version 1.0.

  The second option is a timed value, the time after the Build explorer node is created and until the scanning of the Build folders start.  It is assumed that this is enough, and the tests so far indicates this.  If you have very many builds and you see that the explorer don’t get them all, try to increase this value, and of course, notify me of your case, either here or on the Visual Gallery site.
