---
id: 129178
title: Defining the build set
date: 2009-02-04T00:54:12+01:00
author: terje
layout: post
guid: http://terje.wpengine.com/?p=129178
permalink: /defining-the-build-set/
dsq_thread_id:
  - "5169459059"
categories:
  - none
---
<p>A <strong>build set</strong> is a set of builds running on the same solution or set of solutions, catering for different aspects of the Continuous Integration process.  Why a set of builds ?  Because one size doesn't fit all.  Something you want to run quickly and others you want to cover a lot of stuff.  This can be divided into a set of aspects.</p>
<p>The aspects can be divided into three major parts:</p>
<ol>
    <li><strong>Developer aspect</strong>.  A continuous build running normally at each check in to ensure that the code the developer checks in is sound and working.  Normally this build is run at each check in of code. Depending on the size of the code, and thus the total build time, and the number of developers on the team, there is some different types to choose from. </li>
    <li><strong>Quality assurance aspect</strong>.  A build running at regular interval, nightly might be wise, intended to ensure that the total quality of the code is satisfactory.  This build will take longer time, and you do as much as possible in order to cover the different types of quality you want to check.  Normally you would also put code documentation into this build.</li>
    <li><strong>Deployment aspect</strong>.  This type of build is also called Public builds or release builds.  They build a complete installable package, and would normally also deploy and install the package onto a test system. They have at least two different parts, or paths. One is to run it against a test system, the other is to create the public release package, which we often call Production.  It would normally be dependent upon a correct Build Quality. If a build has not been given a correct build quality it should not be possible to run a Deployment build.</li>
</ol>
<p> </p>
<p><strong>Scheduling</strong></p>
<p>The scheduling of the different aspects may vary, depending on the total build time, but given a reasonable size, a set can be as outlined in this table:</p>
<table border="1" cellspacing="0" cellpadding="2" width="708">
    <tbody>
        <tr>
            <td valign="top" width="279"><strong><font size="3">Aspect</font></strong></td>
            <td valign="top" width="427"><strong>Scheduling options</strong></td>
        </tr>
        <tr>
            <td valign="top" width="304">Developer</td>
            <td valign="top" width="446">Each check in, accumulated or gated</td>
        </tr>
        <tr>
            <td valign="top" width="312">Quality assurance</td>
            <td valign="top" width="449">Nightly</td>
        </tr>
        <tr>
            <td valign="top" width="316">Deployment/Test</td>
            <td valign="top" width="447">Nightly (preferred), or manually triggered,</td>
        </tr>
        <tr>
            <td valign="top" width="319">Deployment/Production</td>
            <td valign="top" width="445">Manually triggered</td>
        </tr>
    </tbody>
</table>
<p> </p>
<p><strong>Content of builds</strong></p>
<p>The content of each build also has a certain dependency on the total build time. When the build time increases one must cut off some of the functionality. The table below shows the different tasks to be done for each aspect, the tasks marked with (x) is typically cut-off tasks.</p>
<table border="1" cellspacing="0" cellpadding="2" width="710">
    <tbody>
        <tr>
            <td valign="top" width="305"><strong>Task</strong></td>
            <td valign="top" width="135" align="center"><strong>Developer</strong></td>
            <td valign="top" width="120" align="center"><strong>Quality </strong></td>
            <td valign="top" width="148" align="center"><strong>Deployment</strong></td>
        </tr>
        <tr>
            <td valign="top" width="300">Gets and compiles the source</td>
            <td valign="top" width="136" align="center">X</td>
            <td valign="top" width="121" align="center">X</td>
            <td valign="top" width="149" align="center">X</td>
        </tr>
        <tr>
            <td valign="top" width="297">Runs unit tests per class</td>
            <td valign="top" width="137" align="center">X</td>
            <td valign="top" width="122" align="center">X</td>
            <td valign="top" width="150" align="center">X</td>
        </tr>
        <tr>
            <td valign="top" width="296">Runs automatic functional tests</td>
            <td valign="top" width="138" align="center">(X)</td>
            <td valign="top" width="122" align="center">X</td>
            <td valign="top" width="150" align="center">(X)</td>
        </tr>
        <tr>
            <td valign="top" width="296">Calculates code coverage</td>
            <td valign="top" width="139" align="center"> </td>
            <td valign="top" width="122" align="center">X</td>
            <td valign="top" width="150" align="center"> </td>
        </tr>
        <tr>
            <td valign="top" width="295">Static code analysis</td>
            <td valign="top" width="140" align="center"> </td>
            <td valign="top" width="122" align="center">X</td>
            <td valign="top" width="150" align="center"> </td>
        </tr>
        <tr>
            <td valign="top" width="295">Calculates code metrics</td>
            <td valign="top" width="140" align="center"> </td>
            <td valign="top" width="122" align="center">X</td>
            <td valign="top" width="150" align="center"> </td>
        </tr>
        <tr>
            <td valign="top" width="294">Generates code documentation</td>
            <td valign="top" width="140" align="center"> </td>
            <td valign="top" width="122" align="center">(X)</td>
            <td valign="top" width="150" align="center">X</td>
        </tr>
        <tr>
            <td valign="top" width="294">Generates version numbers</td>
            <td valign="top" width="140" align="center"> </td>
            <td valign="top" width="122" align="center"> </td>
            <td valign="top" width="150" align="center">X</td>
        </tr>
        <tr>
            <td valign="top" width="294">Creates installation program (msi)</td>
            <td valign="top" width="140" align="center"> </td>
            <td valign="top" width="122" align="center"> </td>
            <td valign="top" width="150" align="center">X</td>
        </tr>
        <tr>
            <td valign="top" width="294">Stores result in a release repository</td>
            <td valign="top" width="140" align="center"> </td>
            <td valign="top" width="122" align="center"> </td>
            <td valign="top" width="151" align="center">X</td>
        </tr>
        <tr>
            <td valign="top" width="294">Deploy onto a test server</td>
            <td valign="top" width="140" align="center"> </td>
            <td valign="top" width="122" align="center"> </td>
            <td valign="top" width="151" align="center">X</td>
        </tr>
    </tbody>
</table>
<p> </p>
<p><strong>Notes about some of the tasks</strong></p>
<p>The Unit testing framework in Team System can be used for both class based unit tests, by which I mean testing of one class at a time, possibly using a mocking system to isolate the class from its dependencies, and for functional automatic testing.  The latter comes by many names, but it means testing of a set of functionality, in some cases including a database round-trip.  This type of testing is much more complex than ordinary class based testing, but is more alike to end-user testing, and thus easier for testing groups to specify.</p>
<p>A manual test in an early iteration will often be converted into an automatic functional test in a latter iteration.  This type of tests may take significantly longer time to execute, especially if a database is involved, which has to be created from scratch for each run.</p>
<p>Code metrics can not be run using TFS 2008, but will hopefully be included in TFS 2010. Third party products may of course be used.</p>
<p>A Release Repository is a specialized storage for public releases, often also test releases are stored there. It contains the msi files, and is linked to the workitems and changesets included in a build. The task moves the results off the drop folder of the build server and into the release repository together with other relevant information. It is used for easy access to the final results, normally accessed through a web system.  Using a release repository makes it possible to integrate the TFS build system with a release and download system.  Osiris Data (the company I'm working at) is in the process of finalizing and releasing such a system for the TFS 2010. A pilot will be available for the TFS 2008 also.</p>
<p>Deployment onto a test server can be implemented either through a push or a pull strategy. Which to choose depends on the security models in effect at your site. </p>
<p>Generation of version numbers should include both the assemblyinfo.cs files, and the msi files.  It should also include both the total version number and the version name of the release.</p>
<p> </p>
<p><strong>The build set</strong> </p>
<p>Each build in a build set has a set of tasks, settings and properties in common, among them the solution (or code) to build. The TFS 2008 has no concept of build sets.  Having a folder to group a set of builds would be a way to organize these things. That is on my wish list for 2010.  The use of templates in the new build system for the 2010 may be a way of solving the commonality problem. The best would however be for the TFS to include the build set as a recognizable term in the build system.</p>