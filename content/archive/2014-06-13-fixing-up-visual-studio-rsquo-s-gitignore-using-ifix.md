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
<p><font size="2"><a href="http://visualstudiogallery.msdn.microsoft.com/b8ba97b0-bb89-4c21-a1e2-53ef335fd9cb" target="_blank">Download tool</a></font></p>  <p><font size="2"><font color="#ff0000">Updated 3.July 2014:  Corrected pattern for NuGet, details in</font> <a href="http://geekswithblogs.net/terje/archive/2014/07/03/gitignorendashhow-to-exclude-nuget-packages-at-any-level-and-make.aspx" target="_blank">this blogpost</a>. (<a href="http://visualstudiogallery.msdn.microsoft.com/b8ba97b0-bb89-4c21-a1e2-53ef335fd9cb" target="_blank">IFix</a> is in progress to be updated too, version 1.1 will have these fixes)</font></p>  <p><font size="2">Is there anything wrong with the built-in Visual Studio gitignore ????</font></p>  <p><font size="2">Yes, there is !  </font></p>  <p><font size="2"></font></p>  <p><font size="2">First, some background:</font></p>  <p><font size="2">When you set up a git repo, it should be small and not contain anything not really needed.  One thing you should not have in your git repo is binary files. </font></p>  <p><font size="2">These binary files may come from two sources, one is the output files, in the bin and obj folders.  If you have a  gitignore file present, which you should always have (!!), these folders are excluded by the standard included file (the one included when you choose Team Explorer/Settings/GitIgnore – Add.)</font></p>  <p><font size="2">The other source are the packages folder coming from your NuGet setup.  You do use NuGet, right ?  Of course you do !  But, that gitignore file doesn’t have any exclude clause for those folders.  You have to add that manually.  (It will very probably be included in some upcoming update or release).  This is one thing that is missing from the built-in gitignore. </font></p>  <p><font size="2">To add those few lines is a no-brainer, you just include this: </font></p>  <pre><font size="2"># NuGet Packages
packages/*
**/packages/*
*.nupkg
# Enable "build/" folder in the NuGet Packages folder since
# NuGet packages use it for MSBuild targets.
# These two line needs to be after the ignore of the build folder
# (and the packages folder if the lines above has been uncommented)
!packages/build/
!**/packages/build/
</font></pre>

<pre><font size="2" face="Verdana">Now, if you are like me, and you probably are, you add git repo’s faster than you can code, and you end up with a bunch of repo’s, and then start to wonder:</font></pre>

<pre><font size="2" face="Verdana">Did I fix up those gitignore files, or did I forget it?</font></pre>

<p><font face="Verdana"><font size="2">The next thing you learn, for example by reading this blog post, is that the “standard” latest Visual Studio gitignore file exist at </font><a title="https://github.com/github/gitignore" href="https://github.com/github/gitignore"><font size="2">https://github.com/github/gitignore</font></a><font size="2">, and you locate it under the file name <a href="https://github.com/github/gitignore/blob/master/VisualStudio.gitignore" target="_blank">VisualStudio.gitignore</a>.  Here you will find all the new stuff, for example, the exclusion of the roslyn ide folders was commited on May 24th.  </font></font></p>

<p><font size="2">So, you think, all is well, Visual Studio will use this file …..     </font></p>

<p><font size="2"><strong>I am very sorry, it won’t</strong>. <img class="wlEmoticon wlEmoticon-surprisedsmile" style="border-top-style: none; border-bottom-style: none; border-right-style: none; border-left-style: none" alt="Surprised smile" src="http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-Fixing-up-Visual-Studios-gitignore_14D3E-wlEmoticon-surprisedsmile_2.png" /> </font></p>

<p><font size="2">Visual Studio comes with a gitignore file that is baked into the release, and that is by this time “very old”.  The one at github is the latest.  </font></p>

<p><font size="2">The included gitignore miss the exclusion of the nuget packages folder, it also miss a lot of new stuff, like the Roslyn stuff. </font></p>

<p><font size="2">So, how do you fix this ?  … note .. while we wait for the next version…</font></p>

<p><font size="2">You can manually update it for every single repo you create, which works, but it does get boring after a few times, doesn’t it ?</font></p>

<p><font size="2"></font></p>

<h1><font size="2">IFix</font></h1>

<p><font size="2">Enter <strong><a href="https://github.com/OsirisTerje/IFix/wiki" target="_blank">IFix</a></strong> ,  install it from <a href="http://visualstudiogallery.msdn.microsoft.com/b8ba97b0-bb89-4c21-a1e2-53ef335fd9cb" target="_blank">here</a>. </font></p>

<p><font size="2">IFix is a command line utility (and the installer adds it to the system path, you might need to reboot), and one of the commands is <strong>gitignore</strong></font></p>

<p><font size="2">If you run it from a directory, it will check and optionally fix all gitignores in all git repo’s in that folder or below.  So, start up by running it from your C:/&lt;user&gt;/source/repos folder. </font></p>

<p><font size="2">To run it in check mode – which will not change anything, just do a check:</font></p>

<p><font size="2"><font face="Courier New"><strong>IFix  gitignore --check</strong></font> </font></p>

<p><font size="2"></font></p>

<p><font size="2">What it will do is to check if the gitignore file is present, and if it is, check if the packages folder has been excluded.  If you want to see those that are ok, add the --verbose command too.  The result may look like this:</font></p>

<p><a href="https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/Fixing-up-Visual-Studios-gitignore_14D3E/SNAGHTMLd9e57a9.png"><img title="SNAGHTMLd9e57a9" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="SNAGHTMLd9e57a9" src="http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-Fixing-up-Visual-Studios-gitignore_14D3E-SNAGHTMLd9e57a9_thumb.png" width="711" height="174" /></a></p>

<p><font size="2"></font></p>

<p><font size="2"><strong>Fixing missing packages</strong></font></p>

<p><font size="2">Let us fix a single repo by adding the missing packages structure,  using </font></p>

<p><font size="2" face="Courier New"><strong>IFix gitignore --fix</strong></font></p>

<p><a href="https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/Fixing-up-Visual-Studios-gitignore_14D3E/image_4.png"><img title="image" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="image" src="http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-Fixing-up-Visual-Studios-gitignore_14D3E-image_thumb_1.png" width="710" height="154" /></a></p>

<p><font size="2"></font></p>

<p><font size="2">We first check, then fix, then check again to verify that the gitignore is correct, and that the “packages/” part has been added.</font></p>

<p><font size="2">If we open up the .gitignore, we see that the block shown below has been added to the end of the .gitignore file.</font></p>

<p><a href="https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/Fixing-up-Visual-Studios-gitignore_14D3E/image_6.png"><img title="image" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="image" src="http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-Fixing-up-Visual-Studios-gitignore_14D3E-image_thumb_2.png" width="221" height="107" /></a></p>

<p> </p>

<p><font size="2"><strong>Comparing and fixing with latest standard Visual Studio gitignore (from github)</strong></font></p>

<p><font size="2">Now, this tells you if you miss the nuget packages folder, but what about the latest gitignore from github ?</font></p>

<p><font size="2">You can check for this too, just add the option –merge (why this is named so will be clear later down)</font></p>

<p><font size="2">So,</font></p>

<p><font size="2">IFix gitignore --check –merge</font></p>

<p><font size="2">The result may come out like this  </font><font size="1">(sorry no colors, not got that far yet here):</font></p>

<p><a href="https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/Fixing-up-Visual-Studios-gitignore_14D3E/image_2.png"><img title="image" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="image" src="http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-Fixing-up-Visual-Studios-gitignore_14D3E-image_thumb.png" width="717" height="117" /></a></p>

<p><font size="2">As you can see, one repo has the latest gitignore (test1), the others are missing either 57 or 150 lines.</font>  </p>

<p><font size="2">IFix has three ways to fix this:</font></p>

<p><font size="2">--add</font></p>

<p><font size="2">--merge</font></p>

<p><font size="2">--replace</font></p>

<p><font size="2">The options work as follows:</font></p>

<p><font size="2"><strong>Add</strong>:  Used to add standard gitignore in the cases where a .gitignore file is missing, and only that, that means it won’t touch other existing gitignores. </font></p>

<p><font size="2"><strong>Merge</strong>: Used to merge in the missing lines from the standard into the gitignore file.  If gitignore file is missing, the whole standard will be added.</font></p>

<p><font size="2"><strong>Replace</strong>: Used to force a complete replacement of the existing gitignore with the standard one. </font></p>

<p><font size="2">The Add and Replace options can be used without Fix, which means they will actually do the action. </font></p>

<p><font size="2">If you combine with --check it will otherwise not touch any files, just do a verification.  So a Merge Check will  tell you if there is any difference between the local gitignore and the standard gitignore, a Compare in effect. </font></p>

<p><font size="2">When you do a Fix Merge it will combine the local gitignore with the standard, and add what is missing to the end of the local gitignore. </font></p>

<p><font size="2">It may mean some things may be doubled up if they are spelled a bit differently.  You might also see some extra comments added, but they do no harm. </font></p>

<p><font size="2"></font></p>

<p><font size="2"><strong>Init new repo with standard gitignore</strong></font></p>

<p><font size="2">One cool thing is that with a new repo, or a repo that is missing its gitignore, you can grab the latest standard just by using either the Add or the Replace command, both will in effect do the same in this case.</font></p>

<p><font size="2">So,</font></p>

<p><font size="2">IFix gitignore --add</font></p>

<p><font size="2">will add it in, as in the complete example below, where we set up a new git repo and add in the latest standard gitignore:</font></p>

<p><a href="https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/Fixing-up-Visual-Studios-gitignore_14D3E/image_8.png"><img title="image" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="image" src="http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-Fixing-up-Visual-Studios-gitignore_14D3E-image_thumb_3.png" width="523" height="333" /></a></p>

<p><font size="2"></font></p>

<p><font size="2"><strong>Notes</strong></font></p>

<p><font size="2">The project is open sourced at <a href="https://github.com/osiristerje/IFix" target="_blank">github</a>, and you can also report issues there.</font></p>
<font size="2" face="Verdana"></font>