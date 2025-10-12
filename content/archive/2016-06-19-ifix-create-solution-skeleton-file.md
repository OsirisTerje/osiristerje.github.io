---
id: 160374
title: 'IFIX:  Create Solution Skeleton File'
date: 2016-06-19T12:14:51+01:00
author: terje
layout: post
categories:
  - Git
  - IFix
  - Visual Studio
---
**Download**:&nbsp; [IFix 1.7](http://visualstudiogallery.msdn.microsoft.com/b8ba97b0-bb89-4c21-a1e2-53ef335fd9cb)

 When I start creating a new solution I normally want this in its own git repository, and I catch myself adding the same stuff over and over again.&nbsp;&nbsp; And, I often get the folder structures wrong,&nbsp; I seem to never get the hang of when and where Visual Studio creates a folder for the solution, why the solution ends up at the same place as the first csproj file, and I often end up moving things around to get it the way I want it.

 The structure I prefer is to have the solution file at the root of the repository, and I want the standard .gitignore and .gitattributes files there, and also a readme.md.&nbsp; The readme.md should contain information for the next developer (or myself a few months down the road).&nbsp; The .gitignore should be the standard latest .gitignore from the [github repository](https://github.com/github/gitignore) (no, not the one coming with Visual Studio, that one is older), and I want these files added as solution items to my solution.

 Further, I want a default runsettings file there, which includes the settings for [running tests in parallel.](https://blogs.msdn.microsoft.com/visualstudioalm/2016/02/08/parallel-and-context-sensitive-test-execution-with-visual-studio-2015-update-1/)&nbsp; I know I can download the [item templates](https://visualstudiogallery.msdn.microsoft.com/1cc3863b-f15f-4107-bb05-3586fd65540b) for that, or copy the content from somewhere on the web, but why not do this the easy way.

 It should look something like this:

 [![image](/images/2016/06/image_thumb-1.png)](/images/2016/06/image-1.png)

 And opening the solution in Visual Studio should then show something like this:

 [![image](/images/2016/06/image_thumb-2.png)](/images/2016/06/image-2.png)

 The .gitignore and .gitattributes are also available from the git settings menu in the Team Explorer, but I always find it faster and more visible to see them in the solution, and – they do absolutely no harm being there.

 When you add projects to the solution now, they will add themselves nicely as subfolders, exactly the way it should be.

 #### How to

 Using the command line to do things are very fast, so instead of&nbsp; doing this from Visual Studio (where there are multiple ways of doing this, all with slightly different results), I added this as a separate command to the [IFix](http://visualstudiogallery.msdn.microsoft.com/b8ba97b0-bb89-4c21-a1e2-53ef335fd9cb) program,&nbsp; in version 1.7.&nbsp; Using the command line have the added benefit of giving you even more control over how your file and folder structure ends up.&nbsp;

 The commands to create the repository and the&nbsp; solution file is:

 [![image](/images/2016/06/image_thumb-3.png)](/images/2016/06/image-3.png)

 1) Create the folder for the repository

 2) Create the git repository:&nbsp;&nbsp; git init

 3) Create the solution file:&nbsp;&nbsp; IFix createsln fantasticApp –f

 #### IFix syntax

 The syntax for creating the solution using IFix is:

 IFix&nbsp; createsln&nbsp; &lt;your solution name&gt;&nbsp; -f

 The solution name don’t need to include the “.sln”, that is added automatically.

 If you want a completely blank solution,&nbsp; you can add the option –blank, and the skeleton will not contain any files.
