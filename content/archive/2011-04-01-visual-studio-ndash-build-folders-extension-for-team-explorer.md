---
id: 144658
title: 'Visual Studio&ndash;Build Folders extension for Team Explorer'
date: 2011-04-01T12:05:25+01:00
author: terje
layout: post
categories:
  - none
---
We have just released a free extension for Visual Studio which adds a Builds Explorer with folders to the Team Explorer.

  The extension can be downloaded from [Visual Studio Gallery](http://visualstudiogallery.msdn.microsoft.com/35daa606-4917-43c4-98ab-38632d9dbd45) or just search for Inmeta in Tools/Extension Manager.

  The documentation and issue tracking  can be found at the codeplex site for the project [http://tfsbuildfolders.codeplex.com/](http://tfsbuildfolders.codeplex.com/) and source code is available there.

  [![image](/images/2015/08/GWB-Windows-Live-Writer-41a2ef22be6e_C9E-image_thumb.png)](http://gwb.blob.core.windows.net/terje/Windows-Live-Writer/41a2ef22be6e_C9E/image_2.png)

  The Build explorer is based on using a convention of separators in the build definition names.  See [Brian Harry’s blog](http://blogs.msdn.com/b/bharry/archive/2011/04/01/build-folders.aspx) for  a nice explanation and description of this.

  Lars Nilsson who wrote the code base for this extension has [blogged up](http://larzjoakimnilzzon.blogspot.com/2011/04/inmeta-build-explorer.html) some of the challenges he faced when implementing this.

  The extension have now had 300 downloads in 4 days!  We’ve got very useful feedback, and fixed the issues that came in.

  - It had problems loading more than 100 builds – now it handles 1000 without any sign of stress.
- Some people noted it had problems when the separator token also existed in the team project name, also fixed.
- And some others noted that they couldn’t use a whitespace as a separator!  Something we hadn’t even considered! We fixed that too.

  To us this just shows how useful it is to get community feedback like this.  It is very effective and really appreciated!

  If you want to contribute, post us a message at the codeplex site, and we will add you.  There are always possibilities for improvement.  We’ve added a couple of discussions to get some feedback on things that we have seen.

  The source has also been posted up there, feel free to use it and do your own stuff based on it.  If you do, we would appreciate a comment back ![Smile](/images/2015/08/GWB-Windows-Live-Writer-Visual-StudioBuild-Folders-extension-for_1391E-wlEmoticon-smile_2.png).  Also, if you see issues in the code, tell us, or change it!

## Blogs:

  Nice blog on [Coding4Fun  Channel 9](http://channel9.msdn.com/coding4fun/blog/Long-list-of-Team-Builds-getting-you-down-Wish-you-could-put-them-in-folders-Dont-want-to-wait-for-a) by Greg Duncan

  [Brian Harry has blogged it](http://blogs.msdn.com/b/bharry/archive/2011/04/01/build-folders.aspx).

  [Shai Raiten has blogged it](http://blogs.microsoft.co.il/blogs/shair/archive/2011/04/02/build-folders-for-team-explorer.aspx).

  [Jakob Ehn has blogged it](http://geekswithblogs.net/jakob/archive/2011/04/04/tfs-2010-inmeta-build-explorer.aspx).

  [Lars Nilsson has blogged it](http://larzjoakimnilzzon.blogspot.com/2011/04/inmeta-build-explorer.html).
