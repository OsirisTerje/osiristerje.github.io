---
id: 160385
title: How to control the selection of test runner in TFS/VSTS, making it work with x86/x64 selected targets
date: 2016-08-21T21:27:06+01:00
author: terje
layout: post
guid: http://hermit.no/?p=160385
permalink: /how-to-control-the-selection-of-test-runner-in-tfsvsts-making-it-work-with-x86x64-selected-targets/
dsq_thread_id:
  - "5083735483"
categories:
  - Azure DevOps
  - Unit Testing
  - Visual Studio
  - VSTS
---
<p>When you do test runs with the Test Explorer in Visual Studio, you can select to use either a x86 or a x64 test runner.&nbsp; Now, if you select to create an AnyCPU target for that component, it will not matter which one you choose, but if you select a target x86 or x64, the selected test runner has to match the selected target.&nbsp; Otherwise no tests will be visible in the Test Explorer.&nbsp; </p> <p>You do this selection from the Test menu,&nbsp;&nbsp; Test Settings/Default Processor Architecture, and select appropriately x86 or x64.</p> <p><a href="http://hermit.no/wp-content/uploads/2016/08/image.png"><img title="image" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="image" src="http://hermit.no/wp-content/uploads/2016/08/image_thumb.png" width="428" height="174"></a></p> <p>Now, this is good for Visual Studio, but when you try to execute your tests in TFS (or VSTS), using the default vNext build template with the Visual Studio Test activity, no tests shows up, even if it looks like you have specified it to run using the correct build platform (x86 or x64)</p> <p><a href="http://hermit.no/wp-content/uploads/2016/08/clip_image002.jpg"><img title="clip_image002" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="clip_image002" src="http://hermit.no/wp-content/uploads/2016/08/clip_image002_thumb.jpg" width="572" height="367"></a></p> <p><a href="http://hermit.no/wp-content/uploads/2016/08/clip_image0027.jpg"><img title="clip_image002[7]" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="clip_image002[7]" src="http://hermit.no/wp-content/uploads/2016/08/clip_image0027_thumb.jpg" width="569" height="287"></a></p> <p>If you look closer, you see that it is only the reporting that is set, not the execution, and there is NO place for setting it.&nbsp; </p> <p>The way to solve this is to include a <strong>runsettings</strong> file, with the appropriate setting, and check it in with your source.&nbsp;&nbsp; Now, including a runsettings file may come with some other issues, like how is it supposed to look, values to set and so on.&nbsp; To make this easier, use a ready made template:</p> <p>1)&nbsp; I have an item template at the Visual Studio Gallery with <a href="https://visualstudiogallery.msdn.microsoft.com/1cc3863b-f15f-4107-bb05-3586fd65540b" target="_blank">three different templates for runsettings</a>.&nbsp; Install this and you will see 3 new items when you do a Add new item to your solution. On the VSG site there are also links to more information on these templates.</p> <p>2) We need to modify the item a bit, so if you don’t require code coverage, and you don’t want to delete a lot of stuff that might get in your way,&nbsp; use the simplest one which is the Parallel one.</p> <p>Select Add new item from the context menu on the Solution node in the solution explorer:</p> <p><a href="http://hermit.no/wp-content/uploads/2016/08/image-1.png"><img title="image" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="image" src="http://hermit.no/wp-content/uploads/2016/08/image_thumb-1.png" width="466" height="115"></a></p> <p>I named the file target.runsettings, and it looks like this OOB:</p><pre style="border-top-style: none; overflow: visible; max-width: none; font-family: ; background: white; border-bottom-style: none; color: ; padding-bottom: 0px; padding-top: 0px; border-right-style: none; padding-left: 0px; border-left-style: none; line-height: normal; padding-right: 0px"><font face="Consolas"><span style="color: "><font color="#0000ff"><font style="font-size: 9.8pt">&lt;?</font></font></span><font style="font-size: 9.8pt"><span style="color: "><font color="#a31515">xml</font></span><span style="color: "><font color="#0000ff">&nbsp;</font></span><span style="color: "><font color="#ff0000">version</font></span><span style="color: "><font color="#0000ff">=</font></span><font color="#000000">"</font><span style="color: "><font color="#0000ff">1.0</font></span><font color="#000000">"</font><span style="color: "><font color="#0000ff">&nbsp;</font></span><span style="color: "><font color="#ff0000">encoding</font></span><span style="color: "><font color="#0000ff">=</font></span><font color="#000000">"</font><span style="color: "><font color="#0000ff">utf-8</font></span><font color="#000000">"</font><span style="color: "><font color="#0000ff">?&gt;</font></span>
<span style="color: "><font color="#0000ff">&lt;</font></span><span style="color: "><font color="#a31515">RunSettings</font></span><span style="color: "><font color="#0000ff">&gt;</font></span>
<span style="color: "><font color="#0000ff">&nbsp; &lt;</font></span><span style="color: "><font color="#a31515">RunConfiguration</font></span><span style="color: "><font color="#0000ff">&gt;</font></span>
<span style="color: "><font color="#0000ff">&nbsp;&nbsp;&nbsp; &lt;!--</font></span><span style="color: "><font color="#008000"> 0 = As many processes as possible, limited by number of cores on machine, 1 = Sequential (1 process), 2-&gt; Given number of processes up to limit by number of cores on machine</font></span><span style="color: "><font color="#0000ff">--&gt;</font></span>
<span style="color: "><font color="#0000ff">&nbsp;&nbsp;&nbsp; &lt;</font></span><span style="color: "><font color="#a31515">MaxCpuCount</font></span><span style="color: "><font color="#0000ff">&gt;</font></span><font color="#000000">0</font><span style="color: "><font color="#0000ff">&lt;/</font></span><span style="color: "><font color="#a31515">MaxCpuCount</font></span><span style="color: "><font color="#0000ff">&gt;</font></span>
<span style="color: "><font color="#0000ff">&nbsp; &lt;/</font></span><span style="color: "><font color="#a31515">RunConfiguration</font></span><span style="color: "><font color="#0000ff">&gt;</font></span>
<span style="color: "><font color="#0000ff">&lt;/</font></span><span style="color: "><font color="#a31515">RunSettings</font></span></font><span style="color: "><font style="font-size: 9.8pt" color="#0000ff">&gt;</font></span></font></pre>
<p>Now, just add the setting for the execution engine to this one, and set the parallel to 1, if you want to have it run sequentially – which should be the default for server builds.&nbsp;&nbsp; It should then look like this, given you run in x64 (otherwise set it to x86)</p><pre style="border-top-style: none; overflow: visible; max-width: none; font-family: ; background: white; border-bottom-style: none; color: ; padding-bottom: 0px; padding-top: 0px; border-right-style: none; padding-left: 0px; border-left-style: none; line-height: normal; padding-right: 0px"><font face="Consolas"><span style="color: "><font color="#0000ff"><font style="font-size: 9.8pt">&lt;?</font></font></span><font style="font-size: 9.8pt"><span style="color: "><font color="#a31515">xml</font></span><span style="color: "><font color="#0000ff">&nbsp;</font></span><span style="color: "><font color="#ff0000">version</font></span><span style="color: "><font color="#0000ff">=</font></span><font color="#000000">"</font><span style="color: "><font color="#0000ff">1.0</font></span><font color="#000000">"</font><span style="color: "><font color="#0000ff">&nbsp;</font></span><span style="color: "><font color="#ff0000">encoding</font></span><span style="color: "><font color="#0000ff">=</font></span><font color="#000000">"</font><span style="color: "><font color="#0000ff">utf-8</font></span><font color="#000000">"</font><span style="color: "><font color="#0000ff">?&gt;</font></span>
<span style="color: "><font color="#0000ff">&lt;</font></span><span style="color: "><font color="#a31515">RunSettings</font></span><span style="color: "><font color="#0000ff">&gt;</font></span>
<span style="color: "><font color="#0000ff">&nbsp; &lt;</font></span><span style="color: "><font color="#a31515">RunConfiguration</font></span><span style="color: "><font color="#0000ff">&gt;</font></span>
<span style="color: "><font color="#0000ff">&nbsp;&nbsp;&nbsp; &lt;!--</font></span><span style="color: "><font color="#008000"> [x86] | x64&nbsp; </font></span><span style="color: "><font color="#0000ff">--&gt;</font></span>
<span style="color: "><font color="#0000ff">&nbsp;&nbsp;&nbsp; &lt;</font></span><span style="color: "><font color="#a31515">TargetPlatform</font></span><span style="color: "><font color="#0000ff">&gt;</font></span><font color="#000000">x64</font><span style="color: "><font color="#0000ff">&lt;/</font></span><span style="color: "><font color="#a31515">TargetPlatform</font></span><span style="color: "><font color="#0000ff">&gt;</font></span>
<span style="color: "><font color="#0000ff">&nbsp;&nbsp;&nbsp; &lt;!--</font></span><span style="color: "><font color="#008000"> 0 = As many processes as possible, limited by number of cores on machine, 1 = Sequential (1 process), 2-&gt; Given number of processes up to limit by number of cores on machine</font></span><span style="color: "><font color="#0000ff">--&gt;</font></span>
<span style="color: "><font color="#0000ff">&nbsp;&nbsp;&nbsp; &lt;</font></span><span style="color: "><font color="#a31515">MaxCpuCount</font></span><span style="color: "><font color="#0000ff">&gt;</font></span><font color="#000000">1</font><span style="color: "><font color="#0000ff">&lt;/</font></span><span style="color: "><font color="#a31515">MaxCpuCount</font></span><span style="color: "><font color="#0000ff">&gt;</font></span>
<span style="color: "><font color="#0000ff">&nbsp; &lt;/</font></span><span style="color: "><font color="#a31515">RunConfiguration</font></span><span style="color: "><font color="#0000ff">&gt;</font></span>
<span style="color: "><font color="#0000ff">&lt;/</font></span><span style="color: "><font color="#a31515">RunSettings</font></span></font><span style="color: "><font style="font-size: 9.8pt" color="#0000ff">&gt;</font></span></font></pre>
<p>Now go back to your Build Definition and add the runsettings file there under Execution Options:</p>
<p><a href="http://hermit.no/wp-content/uploads/2016/08/image-2.png"><img title="image" style="border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px" border="0" alt="image" src="http://hermit.no/wp-content/uploads/2016/08/image_thumb-2.png" width="667" height="310"></a></p>
<p>Note that you can give the path both as a server path – which works well with TFS Old VC, or as a relative path from your defined root, defined either by your source mappings or from the root of your git repository.&nbsp; </p>
<p>&nbsp;</p>
<h4>Trap:</h4>
<p>When you upgrade your Visual Studio, the item templates may disappear.&nbsp; They are still there, but to get them visible again you must delete your MEF cache.&nbsp; For executables you get a loading error, but for item templates – they just go missing:&nbsp; Easy way to fix that:&nbsp; See <a title="http://hermit.no/how-to-fix-visual-studio-loading-errors-using-ifix/" href="http://hermit.no/how-to-fix-visual-studio-loading-errors-using-ifix/">http://hermit.no/how-to-fix-visual-studio-loading-errors-using-ifix/</a></p>