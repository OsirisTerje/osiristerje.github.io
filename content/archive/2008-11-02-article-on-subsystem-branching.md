---
id: 126491
title: Article on Subsystem branching
date: 2008-11-02T06:38:26+01:00
author: terje
layout: post
categories:
  - none
---

I did an article on Subsystem branching (http://geekswithblogs.net/terje/archive/2008/11/02/handling-subsystem-branching.aspx) as a result of a post on the Microsoft forums regarding this.

Further, at the PDC 2008 conference now, [Grant Holliday](http://blogs.msdn.com/granth/) made me aware of the [TFS Dependency Replicator](http://www.codeplex.com/tfsdepreplicator), which also is a way to solve the problem. It corresponds to the solution I named Solution 3B, however, it's not using the branch/merge facilities, so the TFS itself is not "aware" of the file copied. Anyway, a great tool!

The article is as follows:

This article came out of a post on the Microsoft forums concerning how to handle team builds of subsystems. The post can be found [here](http://social.msdn.microsoft.com/forums/en-US/tfsbuild/thread/5a017a4b-4617-4339-af18-3077c77abb20/), look up the original post to see the problem in detail. Some of the problems the original poster got, concerned build reports which included work items belonging to other subprojects, but the problem go further than that. By not having a proper structure for your source code, you run the risk of build problems when you try to set up team build.

The problem concerns how to arrange your source code and build structure in these cases. There are several options, as outlined below. Which one to choose depends on your particular situation.

In the original problem, each subsystem resided in separate team projects. For this discussion, the subsystem may or may not be located separately.

For the sake of the discussion: Assume the existence of a Common framework project, and two other projects named Project1 and Project2 which uses this common framework. You want to build these as separate build projects, so to get as high isolation between them as possible.

There is guidelines for this on codeplex, see [TFS Guide release](http://www.codeplex.com/TFSGuide/Release/ProjectReleases.aspx?ReleaseId=6280) but I feel the guidelines there on source code structure is somewhat lacking, although not in any way wrong, but I would like to add from my own experience, take this for what is it - good intentions.

##### Solution 1: Multiple build workspacemappings

**Choose this if:**

Your projects are small,
common is small,
your teams are small,
or the same team works on all projects including common,
and/or 'common' is not very stable, meaning it's as likely to change as your projects.

**Setup:**

Keep your source structure exactly as you have outlined. Move (if they are not already there, by default they should) your solution files (sln) down to each project, this is essential. Use project references between each project and common, exactly as you have outlined. Ignore the warning from Visual Studio you may get above referring above your root. You know what you're doing.

In the workspacemapping of your build (See Edit Build, 'Workspace'), make two mappings, one goes to Project1, and the other goes to Common. Do the same for Project2. If you now change something in Project1, and on that checkin associates this with a workitem, both the workitem and the changeset will only show up in the build report for Project1, and nothing will show in the build report for Project2.

**Advantages:** Simple to do
**Disadvantages:** A developer may not always get the latest source down, if they are unaware of the dependency on Common. If Common is a very long path-way away from your project, more levels than what you have shown above, this problem is much more likely to happen, in that case go to solution 2 or 3.

##### Solution 2: Source code branching

**Choose this if:**

Your projects are a bit larger,
a separate team is or has been working with Common
you need isolation between projects, meaning Project2 will not be bothered by requests from Project1 to change something in Common.
You have a more complex source code structure.

**Setup:**

Change your source code structure below Project1 and Project2 to include a branch FROM Common. that is, make it look like:

Source

    Common
    Project1
        CommonBranched
    Project2
        CommonBranched

Then of course create the branches from Common to the two respective CommonBranched. It is probably wise in this setup to have a separate solution for Common alone, and its own CI build to make sure it is correct before merging changes over to the Branches. The solutions for Project1 and Project2 should be as described in solution 1, no changes there. Note that one would normally not do any changes in the source in the CommonBranches, one could of course, but that would create a merging issue later when one merges new or updated code from the Common trunk.

**Advantages:**

Provides better separation between the projects and common
A developer will always get a buildable solution if he takes get latest from the Project node.
**Disadvantages:**

Every change in Common must be merged over to the branches. This will give an extra step in the process. For a small 'enterprise' this overhead may not be justified, for a lager one, it may be an advantage - due to the fact that this provides isolation and awareness of changes.
Possible changes to the branched source could make them non-mergeable at a later time.

##### Solution 3: Binary deployment branching:

**Choose this if:**

You have (a/many) large project(s)
Your common framework is rather stable,
Your common framework is used in many other projects, and you would not take the risk that someone at those projects made changes to the source that would make them non-mergeable at a later time.

**Setup:**

Change the source code structure as follows:

Source

    Common
           Deploy
    Project1
           CommonBranched  (or Libs or References)
    Project2
           CommonBranched (or Libs or References)

In addition to the CI build for Common, you should make what I would call a public build, which you build every time you want a new "release". This build should have an extra step, f.e. using the AfterEndToEndIteration target, that it should check in the resulting 'dll' and 'pdb' file into the Deploy folder. (Use the ***NO_CI*** trick on that checkin to avoid triggering the CI build again.) This build btw, should not be triggered nor scheduled. You trigger this build manually whenever you need a  new release of the Common library.
Now, when that is done, branch the Deploy folders, which mean that you in fact branch the binaries, into the CommonBranched folders.

**Advantages:**

The teams working on Project1 and Project2 can't mess up the source code. IF they want a change they must post a workitem to the Common team, and wait for a new release. . This is a good thing!
Good isolation (as in Solution 2), and the framework is very nicely controlled, but in addition, no possibility for a source code problem with the Common source code branched into the projects.

**Disadvantages:**

The build scripts must be modified
Binaries must be checked in (not a problem IMHO).

Versioning should be introduced in the build process (not described in this post), may further complicate the build script

**Advantage in disadvantage:**

When the build script changes have been done, the process is smooooottth .

##### Solution 3B : Binary deployment with immediate merge

This is similar to solution 3 above, except that instead of doing a manual merge operation, you let the build system perform this for you. This will effectively chain the system builds. If Common is built, all other projects that depends on this will also be build. The advantage of this approach is that if you have a large total system, a change in any of the upper level projects will be faster to build, since the lower levels already have been built.

Regardless of which solution above you prefer to implement, your problem with workitems will be solved. All three solutions will provide the necessary isolation.

See this [http://geekswithblogs.net/jakob/archive/2009/03/05/implementing-dependency-replication-with-tfs-team-build.aspx](http://geekswithblogs.net/jakob/archive/2009/03/05/implementing-dependency-replication-with-tfs-team-build.aspx) for details on implementing these strategies for TFS.
