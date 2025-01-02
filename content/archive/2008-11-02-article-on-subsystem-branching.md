---
id: 126491
title: Article on Subsystem branching
date: 2008-11-02T06:38:26+01:00
author: terje
layout: post
guid: http://terje.wpengine.com/?p=126491
permalink: /article-on-subsystem-branching/
categories:
  - none
---
<p>I did an article on Subsystem branching (<a title="http://geekswithblogs.net/terje/archive/2008/11/02/handling-subsystem-branching.aspx" href="http://geekswithblogs.net/terje/archive/2008/11/02/handling-subsystem-branching.aspx">http://geekswithblogs.net/terje/archive/2008/11/02/handling-subsystem-branching.aspx</a>) as a result of a post on the Microsoft forums regarding this.</p>
<p>Further, at the PDC 2008 conference now, <a href="http://blogs.msdn.com/granth/">Grant Holliday</a> made me aware of the <a href="http://www.codeplex.com/tfsdepreplicator">TFS Dependency Replicator</a>, which also is a way to solve the problem. It corresponds to the solution I named Solution 3B, however, it's not using the branch/merge facilities, so the TFS itself is not "aware" of the file copied. Anyway, a great tool !</p>
<p>The article is as follows:</p>
<p>This article came out of a post on the Microsoft forums concerning how to handle team builds of subsystems.  The post can be found <a href="http://social.msdn.microsoft.com/forums/en-US/tfsbuild/thread/5a017a4b-4617-4339-af18-3077c77abb20/"><strong>here</strong></a>, look up the original post to see the problem in detail.  Some of the problems the original poster got, concerned build reports which included work items belonging to other subprojects, but the problem go further than that.  By not having a proper structure for your source code, you run the risk of build problems when you try to set up team build.</p>
<p>The problem concerns how to arrange your source code and build structure in these cases. There are several options, as outlined below.  Which one to choose depends on your particular situation. </p>
<p>In the original problem, each subsystem resided in separate team projects. For this discussion, the subssystem may or may not be located separately.  </p>
<p>For the sake of the discussion: Assume the existence of a Common framework project, and two other projects named Project1 and Project2 which uses this common framework. You want to build these as separate build projects, so to get as high isolation between them as possible.</p>
<p>There is guidelines for this on codeplex, see <a href="http://www.codeplex.com/TFSGuide/Release/ProjectReleases.aspx?ReleaseId=6280">http://www.codeplex.com/TFSGuide/Release/ProjectReleases.aspx?ReleaseId=6280</a> but I feel the guidelines there on source code structure is somewhat lacking, although not in any way wrong, but I would like to add from my own experience, take this for what is it - good intentions  .</p>
<p><br />
A)  A decision to use one or multiple TFS Projects should be based on other criteria, like teams, rights management, etc,  and not on the problem you have. </p>
<p>B) The reason you get the behavior you describe first, is that both your builds "points", so to speak, at the level above your projects, that is the node called 'source'.  It is this that determines what is shown in the build report.  And no, you should not change anything in the build report. At this level, you probably have two solutions, one called Project1 and one called Project2, or if you have the solutions down at the level of the Project1 and Project2, you have still your workspace for the build at the level of the 'source'.  <br />
So in order to get the behavior you want, you have some options.  Which to choose depends a bit on the size of your projects, including common, and the stability of the 'common' framework, your team sizes, how much isolation between them you want etc etc.  <br />
I'll outline these options below:</p>
<h5>S<strong>olution 1: Multiple build workspacemappings</strong></h5>
<p><strong>Choose this if:</strong> <br />
Your projects are small, <br />
common is small, <br />
your teams are small, <br />
or the same team works on all projects including common, <br />
and/or 'common' is not very stable, meaning it's as likely to change as your projects.</p>
<p><strong>Setup</strong>:  <br />
Keep your source structure exactly as you have outlined.  <br />
Move (if they are not already there, by default they should) your solution files (sln) down to each project, this is essential.  <br />
Use project references between each project and common, exactly as you have outlines. Ignore the warning from Visual Studio you may get above referring above your root. You know what you're doing. <br />
Now the change from what you have today:  <br />
In the workspacemapping of your build (See Edit Build, 'Workspace'), make -2- mappings, one goes to Project1, and the other goes to Common. <br />
Do the same for Project2. <br />
          If you now change something in Project1, and on that checkin associates this with a workitem,both the workitem and the changeset will only show up in the build report for Project1, and  nothing will show in the build report for Project2.</p>
<p><strong>Advantages</strong>:  Simple to do <br />
<strong>Disadvantages</strong>: A developer may not always get the latest source down, if they are unaware of the dependency on Common. If Common is a very long path-way away from your project, more levels than what you have shown above, this problem is much more likely to happen, in that case got to solution 2 or 3.</p>
<h5>Solution 2.  Source code branching: </h5>
<p><strong>Choose this if:</strong> <br />
Your projects are a bit larger, <br />
a separate team is or has been working with Common <br />
you need isolation between projects, meaning Project2 will not be bothered by requests from Project1 to change something in Common. <br />
You have a more complex source code structure.</p>
<p><strong>Setup</strong>: <br />
Change your source code structure below Project1 and Project2 to include a branch FROM Common. that is, make it look like:</p>
<p>Source <br />
     Common <br />
     Project1 <br />
         CommonBranched <br />
     Project2 <br />
         CommonBranched <br />
Then of course create the branches from Common to the two respective CommonBranched. <br />
It is probably wise in this setup to have a separate solution for Common alone, and its own CI build to make sure it is correct before merging changes over to the Branches. <br />
The solutions for Project1 and Project2 should be as described in solution 1, no changes there. <br />
Note that one would normally not do any changes in the source in the CommonBranches, one could of course, but that would create a merging issue later when one merges new or updated code from the Common trunk. <br />
<strong>Advantages</strong>:  <br />
Provides better separation between the projects and common <br />
A developer will always get a buildable solution if he takes get latest from the Project node. <br />
<strong>Disadvantages</strong>: <br />
Every change in Common must be merged over to the branches.  This will give an extra step in the process.  For a small 'enterprise' this overhead may not be justified, for a lager one, it may be an advantage - due to the fact that this provides isolation and awareness of changes. <br />
Possible changes to the branched source could make them non-mergeable at a later time.</p>
<h5>Solution 3:  Binary deployment branching:</h5>
<p><strong>Choose this if:</strong> <br />
You have (a/many) large project(s) <br />
Your common framework is rather stable, <br />
Your common framework is used in many other projects, and you would not take the risk that someone at those projects made changes to the source that would make them non-mergeable at a later time. <br />
 </p>
<p><strong>Setup</strong>: <br />
Change the source code structure as follows: <br />
Source <br />
    Common <br />
           Deploy <br />
    Project1 <br />
           CommonBranched  (or Libs or References) <br />
    Project2 <br />
           CommonBranched (or Libs or References) <br />
In addition to the CI build for Common, you should make what I would call a public build, which you build every time you want a new "release". This build should have an extra step, f.e. using the AfterEndToEndIteration target,  that it should check in the resulting 'dll' and 'pdb' file into the Deploy folder.  (Use the ***NO_CI*** trick on that checkin to avoid triggering the CI build again.)  This build btw, should not be triggered nor scheduled.  You trigger this build manually whenever you need a  new release of the Common library. <br />
Now, when that is done, branch the Deploy folders, which mean that you in fact branch the binaries, into the CommonBranched folders.  <br />
<strong>Advantages</strong>: <br />
The teams working on Project1 and Project2 can't mess up the source code. IF they want a change they must post a workitem to the Common team, and wait for a new release.  . This is a good thing ! <br />
Good isolation (as in Solution 2), and the framework is very nicely controlled, but in addition, no possibility for a source code problem with the Common source code branched into the projects. <br />
 </p>
<p><strong>Disadvantages</strong>: <br />
The build scripts must be modified <br />
Binaries must be checked in (not a problem IMHO).</p>
<p>Versioning should be introduced in the build process (not described in this post), may further complicate the build script</p>
<p><strong>Advantage in disadvantage</strong>:  <br />
When the build script changes have been done, the process is smooooottth  .</p>
<h5>Solution 3B : Binary deployment with immediate merge</h5>
<p>This is similar to solution 3 above, except that instead of doing a manual merge operation, you let the build system perform this for you.  This will effectively chain the system builds.  If Common is built, all other projects that depends on this will also be build.  The advantage of this approach is that if you have a large total system, a change in any of the upper level projects will be faster to build, since the lower levels already have been built.</p>
<p>Regardless of which solution above you prefer to implement, your problem with workitems will be solved.  All three solutions will provide the necessary isolation.</p>
<p> See this <a href="http://geekswithblogs.net/jakob/archive/2009/03/05/implementing-dependency-replication-with-tfs-team-build.aspx">http://geekswithblogs.net/jakob/archive/2009/03/05/implementing-dependency-replication-with-tfs-team-build.aspx</a> for details on implementing these strategies for TFS.</p>