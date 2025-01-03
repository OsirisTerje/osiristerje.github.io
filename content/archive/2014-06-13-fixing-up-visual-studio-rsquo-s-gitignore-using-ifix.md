---
id: 156924
title: 'Fixing up Visual Studio&rsquo;s gitignore , using IFix'
date: 2014-06-13T17:59:29+01:00
author: terje
layout: post
guid: http://terje.wpengine.com/?p=156924
permalink: /fixing-up-visual-studio-rsquo-s-gitignore-using-ifix/
dsq_thread_id:
  - "4354276919"
categories:
  - Extensions
  - Git
  - IFix
  - NuGet
---
[Download tool](http://visualstudiogallery.msdn.microsoft.com/b8ba97b0-bb89-4c21-a1e2-53ef335fd9cb)

Updated 3.July 2014:  Corrected pattern for NuGet, details in [this blogpost](http://geekswithblogs.net/terje/archive/2014/07/03/gitignorendashhow-to-exclude-nuget-packages-at-any-level-and-make.aspx). ([IFix](http://visualstudiogallery.msdn.microsoft.com/b8ba97b0-bb89-4c21-a1e2-53ef335fd9cb) is in progress to be updated too, version 1.1 will have these fixes)

Is there anything wrong with the built-in Visual Studio gitignore ????

Yes, there is ! 

First, some background:

When you set up a git repo, it should be small and not contain anything not really needed.  One thing you should not have in your git repo is binary files.

These binary files may come from two sources, one is the output files, in the bin and obj folders.  If you have a  gitignore file present, which you should always have (!!), these folders are excluded by the standard included file (the one included when you choose Team Explorer/Settings/GitIgnore – Add.)

The other source are the packages folder coming from your NuGet setup.  You do use NuGet, right ?  Of course you do !  But, that gitignore file doesn’t have any exclude clause for those folders.  You have to add that manually.  (It will very probably be included in some upcoming update or release).  This is one thing that is missing from the built-in gitignore.

To add those few lines is a no-brainer, you just include this:

\# NuGet Packages
packages/\*
\*\*/packages/\*
\*.nupkg
# Enable "build/" folder in the NuGet Packages folder since
# NuGet packages use it for MSBuild targets.
# These two line needs to be after the ignore of the build folder
# (and the packages folder if the lines above has been uncommented)
!packages/build/
!\*\*/packages/build/

Now, if you are like me, and you probably are, you add git repo’s faster than you can code, and you end up with a bunch of repo’s, and then start to wonder:

Did I fix up those gitignore files, or did I forget it?

The next thing you learn, for example by reading this blog post, is that the “standard” latest Visual Studio gitignore file exist at [https://github.com/github/gitignore](https://github.com/github/gitignore "https://github.com/github/gitignore"), and you locate it under the file name [VisualStudio.gitignore](https://github.com/github/gitignore/blob/master/VisualStudio.gitignore).  Here you will find all the new stuff, for example, the exclusion of the roslyn ide folders was commited on May 24th. 

So, you think, all is well, Visual Studio will use this file …..    

**I am very sorry, it won’t**. ![Surprised smile](http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-Fixing-up-Visual-Studios-gitignore_14D3E-wlEmoticon-surprisedsmile_2.png) 

Visual Studio comes with a gitignore file that is baked into the release, and that is by this time “very old”.  The one at github is the latest. 

The included gitignore miss the exclusion of the nuget packages folder, it also miss a lot of new stuff, like the Roslyn stuff.

So, how do you fix this ?  … note .. while we wait for the next version…

You can manually update it for every single repo you create, which works, but it does get boring after a few times, doesn’t it ?

IFix
====

Enter **[IFix](https://github.com/OsirisTerje/IFix/wiki)** ,  install it from [here](http://visualstudiogallery.msdn.microsoft.com/b8ba97b0-bb89-4c21-a1e2-53ef335fd9cb).

IFix is a command line utility (and the installer adds it to the system path, you might need to reboot), and one of the commands is **gitignore**

If you run it from a directory, it will check and optionally fix all gitignores in all git repo’s in that folder or below.  So, start up by running it from your C:/<user>/source/repos folder.

To run it in check mode – which will not change anything, just do a check:

**IFix  gitignore --check**

What it will do is to check if the gitignore file is present, and if it is, check if the packages folder has been excluded.  If you want to see those that are ok, add the --verbose command too.  The result may look like this:

[![SNAGHTMLd9e57a9](http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-Fixing-up-Visual-Studios-gitignore_14D3E-SNAGHTMLd9e57a9_thumb.png "SNAGHTMLd9e57a9")](https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/Fixing-up-Visual-Studios-gitignore_14D3E/SNAGHTMLd9e57a9.png)

**Fixing missing packages**

Let us fix a single repo by adding the missing packages structure,  using

**IFix gitignore --fix**

[![image](http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-Fixing-up-Visual-Studios-gitignore_14D3E-image_thumb_1.png "image")](https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/Fixing-up-Visual-Studios-gitignore_14D3E/image_4.png)

We first check, then fix, then check again to verify that the gitignore is correct, and that the “packages/” part has been added.

If we open up the .gitignore, we see that the block shown below has been added to the end of the .gitignore file.

[![image](http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-Fixing-up-Visual-Studios-gitignore_14D3E-image_thumb_2.png "image")](https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/Fixing-up-Visual-Studios-gitignore_14D3E/image_6.png)

**Comparing and fixing with latest standard Visual Studio gitignore (from github)**

Now, this tells you if you miss the nuget packages folder, but what about the latest gitignore from github ?

You can check for this too, just add the option –merge (why this is named so will be clear later down)

So,

IFix gitignore --check –merge

The result may come out like this  (sorry no colors, not got that far yet here):

[![image](http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-Fixing-up-Visual-Studios-gitignore_14D3E-image_thumb.png "image")](https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/Fixing-up-Visual-Studios-gitignore_14D3E/image_2.png)

As you can see, one repo has the latest gitignore (test1), the others are missing either 57 or 150 lines. 

IFix has three ways to fix this:

\--add

\--merge

\--replace

The options work as follows:

**Add**:  Used to add standard gitignore in the cases where a .gitignore file is missing, and only that, that means it won’t touch other existing gitignores.

**Merge**: Used to merge in the missing lines from the standard into the gitignore file.  If gitignore file is missing, the whole standard will be added.

**Replace**: Used to force a complete replacement of the existing gitignore with the standard one.

The Add and Replace options can be used without Fix, which means they will actually do the action.

If you combine with --check it will otherwise not touch any files, just do a verification.  So a Merge Check will  tell you if there is any difference between the local gitignore and the standard gitignore, a Compare in effect.

When you do a Fix Merge it will combine the local gitignore with the standard, and add what is missing to the end of the local gitignore.

It may mean some things may be doubled up if they are spelled a bit differently.  You might also see some extra comments added, but they do no harm.

**Init new repo with standard gitignore**

One cool thing is that with a new repo, or a repo that is missing its gitignore, you can grab the latest standard just by using either the Add or the Replace command, both will in effect do the same in this case.

So,

IFix gitignore --add

will add it in, as in the complete example below, where we set up a new git repo and add in the latest standard gitignore:

[![image](http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-Fixing-up-Visual-Studios-gitignore_14D3E-image_thumb_3.png "image")](https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/Fixing-up-Visual-Studios-gitignore_14D3E/image_8.png)

**Notes**

The project is open sourced at [github](https://github.com/osiristerje/IFix), and you can also report issues there.