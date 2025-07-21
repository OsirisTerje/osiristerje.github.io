---
layout: post
date: 2020-09-20
categories:
  - git
tags:
  - githubActions
---

# Github Actions released, and some specifics for .Net Framework

## Summary

Github Actions has been released for public use, and announced at the [Github Universe conference](https://githubuniverse.com/) in San Francisco Nov. 13th. And, because Github loves open source - it is fully free for all public repositories!

[Github Actions](https://github.com/features/actions) can be used for automating a series of processes, as it can utilize most of the [events](https://help.github.com/en/actions/automating-your-workflow-with-github-actions/events-that-trigger-workflows) in the github system.  The most typical use will still be to trigger CI/CD builds.  The whole system is yaml based, and it can run on different environments, Linux, Windows and MacOS.

There also is a [marketplace](https://github.com/marketplace?type=actions) where you can find a lot of community contributed actions to be used in your workflow.

You can also find a series of starter workflows which you can use for your first builds.  As they are written in yaml, they are easy to customize to your needs.  A good introduction to yaml can be found [here](https://www.codeproject.com/Articles/1214409/Learn-YAML-in-five-minutes).
When you press New Workflow on the Actions page ((1) in screenshot below), you get a list of proposals, or you can start out blank ((2) in screenshot below)

![](https://github.com/OsirisTerje/osiristerje.github.io/blob/master/images/2019-11-15_10-20-37.jpg)

## Locations of the yaml files

If you add a github action for the first time using the web interface, you will see that the file is placed in the .github/workflows folder.

![](https://github.com/OsirisTerje/osiristerje.github.io/blob/master/images/2019-11-15_16-47-47.jpg)

Note that if want to edit this file locally, you need to have a SSH enabled local repo.  See [Connecting to GitHub with SSH](https://help.github.com/en/github/authenticating-to-github/connecting-to-github-with-ssh)

## Examples of yaml files for some Github Actions

### .Net Core example

We're using a simple test project based on .net core.   The repository is named [ActionExample1](https://github.com/OsirisTerje/ActionExample1)

We start off by using the standard .Net Core starter workflow.  We then modify the file to add unit testing (3) - it is not there by default yet (I have added a PR for that, but not yet approved and merged).  We also change the name to something meaningful (1), including the filename. Just for fun we also change from running on ubuntu to windows (2) .  .Net Core can run on both, so....

![](https://github.com/OsirisTerje/osiristerje.github.io/blob/master/images/2019-11-15_22-44-30.jpg)

As you can see the build file is very small, and easy to understand.

And when it has run, successfully of course, the details look like shown below:

![](https://github.com/OsirisTerje/osiristerje.github.io/blob/master/images/2019-11-15_22-49-05.jpg)

###  Building the NUnit3TestAdapter using powershell and Cake

The build system for the NUnit3TestAdapter is based on a Cake script that is started off by a powershell script. 

To set that build off doesn't require much:

![](https://github.com/OsirisTerje/osiristerje.github.io/blob/master/images/2019-11-15_22-52-28.jpg)

and the results look like:

![](https://github.com/OsirisTerje/osiristerje.github.io/blob/master/images/2019-11-15_22-53-44.jpg)

### Building .Net Framework projects

To build .net framework projects we must check out whether it uses the old legacy project format, or the new SDK based format.  Many projects, or most now, can use the new SDK format.  See [this blogpost](https://hermit.no/moving-to-sdk-style-projects-and-package-references-in-visual-studio-part-2/) for how to convert your project automatically to the new SDK format from the old legacy format.

Using the new SDK project format makes it much simpler to build, because you can then use the dotnet system, which encapsulates all the other stuff you need.  

If you have to stay on the old legacy format, you must use the msbuild system.

I will now show how you do both.

#### First, the SDK format:

The repo with an [SDK format .net project](https://github.com/OsirisTerje/ActionExample2) needs a slightly modified workflow, based on the starter-workflow [Dotnet Core](https://github.com/actions/starter-workflows/blob/master/ci/dotnet-core.yml).

As you can see, the workflow is functionally identical to the .net core workflow above.
We can still use dotnet to build the .net framework project, because it uses the SDK format, and we can test it using dotnet test.

![](https://github.com/OsirisTerje/osiristerje.github.io/blob/master/images/actionexample2yaml.jpg)

And as can be seen, it builds just fine:

![](https://github.com/OsirisTerje/osiristerje.github.io/blob/master/images/2019-11-19_18-17-02.jpg)

#### Then the legacy format

The DotNet Core 'dotnet' tool can not build projects using the old legacy format.  So we then have to resort to good old msbuild. And that also means that running tests are not so simple anymore, so we keep that out for now (until you have moved over to the SDK format, and the problem just disappears).

For this example, I will use the [Example 3](https://github.com/OsirisTerje/ActionExample3) repository.

For such a project, there is no starter workflow available (as of writing Nov 2019), so will start with an empty workflow:

![](https://github.com/OsirisTerje/osiristerje.github.io/blob/master/images/2019-11-19_20-01-50.jpg)

The "empty" is not that empty, so just delete whatever is in the script, and replace with the gist [NetFramework.Legacy.CI](https://gist.github.com/OsirisTerje/f8b5d2252dda2ceaed21787a078ae438). 

Then give it a nice name, and replace YOUR_SOLUTION_NAME in the gist to the correct name and path for your solution.

![](https://github.com/OsirisTerje/osiristerje.github.io/blob/master/images/2019-11-19_20-06-07.jpg)

And running this build gives:

![](https://github.com/OsirisTerje/osiristerje.github.io/blob/master/images/2019-11-19_20-19-05.jpg)

*Credit:  This gist uses actions provided by [Warren Buckley](https://github.com/warrenbuckley)*

Building .Net Framework projects are easy with Github actions, but if you're using the legacy project format, you should first try to [migrate to the new SDK format](http://hermit.no/moving-to-sdk-style-projects-and-package-references-in-visual-studio-part-2/).

