---
id: 135706
title: On branches and builds in Team Foundation Server
date: 2009-10-25T16:49:19+01:00
author: terje
layout: post
guid: http://terje.wpengine.com/?p=135706
permalink: /on-branches-and-builds-in-team-foundation-server/
dsq_thread_id:
  - "4780186454"
categories:
  - none
---
<p>On codeplex the VSTS Rangers have published the <a href="http://tfsbranchingguideii.codeplex.com/">Branching Guidance II</a> (yes, a while ago, but still very true).  The basic idea there is the separation between 3 major branches,  the Main (or trunk), the Development and the Release branch.  One can elaborate on these and use multiple Development branches, and also a tree of release branches, but the basic principle can be summed up with these three.</p>
<p><a href="http://gwb.blob.core.windows.net/terje/WindowsLiveWriter/OnbranchesandbuildsinTeamFoundationServe_132C8/image_2.png"><img title="image" border="0" alt="image" width="590" height="190" style="border-bottom: 0px; border-left: 0px; display: inline; border-top: 0px; border-right: 0px" src="http://hermit.no/wp-content/uploads/2015/08/GWB-WindowsLiveWriter-OnbranchesandbuildsinTeamFoundationServe_132C8-image_thumb.png" /></a></p>
<p> </p>
<p>Now, if we look at the different sets of build types we have, see <a title="http://geekswithblogs.net/terje/archive/2009/02/04/defining-the-build-set.aspx" href="http://geekswithblogs.net/terje/archive/2009/02/04/defining-the-build-set.aspx">http://geekswithblogs.net/terje/archive/2009/02/04/defining-the-build-set.aspx</a> for details, and combine this information with the branching model above, we can see what types of builds should be set up for each branch.  I’ve used the terms None, Mandatory and Optional to indicate the relationships.</p>
<table border="0" cellspacing="0" cellpadding="2" width="610">
    <tbody>
        <tr>
            <td valign="top" width="168"><strong>Builds    Branches</strong></td>
            <td valign="top" width="162"><strong>Development</strong></td>
            <td valign="top" width="144"><strong>Main</strong></td>
            <td valign="top" width="134"><strong>Release</strong></td>
        </tr>
        <tr>
            <td valign="top" width="180"><strong>Developer (CI build)</strong></td>
            <td valign="top" width="170">Mandatory</td>
            <td valign="top" width="150">Mandatory</td>
            <td valign="top" width="139">Mandatory</td>
        </tr>
        <tr>
            <td valign="top" width="183"><strong>QA build</strong></td>
            <td valign="top" width="173">Mandatory</td>
            <td valign="top" width="151">Mandatory</td>
            <td valign="top" width="141">None/Optional</td>
        </tr>
        <tr>
            <td valign="top" width="184"><strong>Deployment to Test</strong></td>
            <td valign="top" width="174">Optional</td>
            <td valign="top" width="151">None</td>
            <td valign="top" width="142">Mandatory</td>
        </tr>
        <tr>
            <td valign="top" width="183"><strong>Deployment to Production</strong></td>
            <td valign="top" width="175">None</td>
            <td valign="top" width="150">None</td>
            <td valign="top" width="143">Mandatory</td>
        </tr>
    </tbody>
</table>
<p>Some comments may be needed:</p>
<p>In any kind of branch, ALWAYS use a Check-in Build (for the Developer). It gives early warning if anything is going wrong.</p>
<p>Always use a QA Build (running daily/nightly at least) on your Development and Main branches, to ensure you have the right code quality, code coverage etc.  I say None/Optional on the Release branch, meaning if you do a lot of code changes there, it might be wise to run it also on the release branch, otherwise there should be no need.</p>
<p>Decide from where you want to release to your Test Systems.  You could choose any of the child branches, depending on how you want to ensure your quality.  If you’re making a large development effort, you need to go through a Quality Gate before you do a Reverse Integration back to main, then you should deploy to test from your Development branch. But you always need to test before release, so a deployment to Test should be done from the release branch.  A test on the development branch does only ensure the quality of the RI to main, you still need to do the Test on the release branch.</p>
<p>Deployment to production build should ONLY be done from the Release branch. Never ever from any of the other.</p>