---
id: 160596
title: How to find the best gitignore for Visual Studio and Azure DevOps
date: 2019-02-04T12:34:26+01:00
author: terje
layout: post
guid: http://hermit.no/?p=160596
permalink: /how-to-find-the-best-gitignore-for-visual-studio-and-azure-devops/
catchevolution-sidebarlayout:
  - default
categories:
  - Azure DevOps
  - Git
  - Visual Studio
---
This post came about as a result of a an interesting question raised by my good friend <a href="https://www.scrum.org/richard-hundhausen">Richard Hundhausen</a> in <a href="http://accentient.com/">Accentient</a>.  It turned out into some very interesting observations, and a few ways of handling this. 

## Background

When you're starting up a new git repository for a Visual Studio project, you need a .gitignore file that matches.  The gitignore file ensures that working files and folders that are not to go into source control are kept out.  As Visual Studio and its extensions are growing, this list of files and folders are increasing.  You need to have a gitignore file that at least matches the version of Visual Studio you're using.
Most developers notice files that they don't think should be in source control, and exclude those (and then adds them to the gitignore file they have), but in many cases they don't even know what that file is for, and it is inadvertently added in.  Normally not causing any problem locally for that single developer, but then it may fail for the next developer down the line, or it may fail during CI builds.
So it is much better to get the correct and full gitignore file when you start up your project.  Less work later!
And what could possibly go wrong?

<!--more-->

## The multiple ways of creating a gitignore file

a) Start by creating a new Visual Studio project, either VS 2017 or VS 2019, select to add it to source control.  You then get a .gitignore file from Visual Studio
b) Start by creating a new Azure DevOps git repository, and select to add a gitignore file.  (You can also do the same if you create a new GitHub repository, it has the same functionality)
c) Copy the raw gitignore file from github/gitignore repository

Let us have a look at the results of this:

<a href="http://hermit.no/wp-content/uploads/2019/02/GI-1.jpg"><img src="http://hermit.no/wp-content/uploads/2019/02/GI-1.jpg" alt="" width="1146" height="470" class="alignnone size-full wp-image-160597" /></a>

This is rather disappointing, right?
The ones from Visual Studio 2017 and 2019 are equal (no 3 and 4 above)  - which is good - but they are quite a bit less than the originator (no 1 above) from github.  
The one from Azure Devops (no 2 above) is better off, but still not quite there.  
And yes, the differences are significant.

The screen shots below are from comparison with between the Visual Studio and the originator, originator on the left side. 
<a href="http://hermit.no/wp-content/uploads/2019/02/GI-2.jpg"><img src="http://hermit.no/wp-content/uploads/2019/02/GI-2.jpg" alt="" width="1625" height="1021" class="alignnone size-full wp-image-160598" /></a>

<a href="http://hermit.no/wp-content/uploads/2019/02/GI-3.jpg"><img src="http://hermit.no/wp-content/uploads/2019/02/GI-3.jpg" alt="" width="1932" height="1560" class="alignnone size-full wp-image-160599" /></a>


The reasons for these being "off", is that the tools don't download from the originator source, but maintain their own copy. And this copy is not updated regularly.  

This means that you must either update the gitignore file yourself, and ensure it is sufficient, or even better, just use another tool to get it down.  Fortunately that is not so hard. 

## Gitignore locations

The gitignore file is given as an option, or a result, in several different places. The issue is that very few of these are really updated to the latest.  We'll have a look at that, but first - there IS an originating site, holding the one and only true gitignore file.
The site is at [https://github.com/github/gitignore](https://github.com/github/gitignore).  Whenever someone need to add something to the file, they can raise a pull request here, and the maintainers ensures that it is properly checked and then merged in.  This is what allows for a lot of 3rd party suppliers to add to this file and keep it properly updated.
If you wonder why it is placed here, and not at some Visual Studio site, it is because there are a lot of other gitignore files, for a ton of other tools, also kept at the same repository.  

There has been complaints on this site not accepting Pull Requests too easily, the maintainers may be a bit restrictive - and that may be for good reasons too.  Anyway, this has led to a separate repository being created, at [https://github.com/dvcs/gitignore](https://github.com/dvcs/gitignore).  This site is actively beeing synced from the previous site, but adds more gitignore types for different 3rd party tools, and may also extend the existing ones through patching.  Details of <a href="https://blog.joeblau.com/gitignore-io-template-fork" rel="noopener" target="_blank">this has been documented</a> by one of the originators of this system.

What is also interesting by this system, is that they expose a website, [gitignore.io](https://www.gitignore.io/), and a corresponding REST Api for accessing this.  

Currently (January 2019), the Visual Studio gitignore file and the one from gitignore.io are identical.  

## Tools for downloading gitignore

1. First option you have is to simply copy the raw content from the originator source, using this <a href="https://raw.githubusercontent.com/github/gitignore/master/VisualStudio.gitignore" rel="noopener" target="_blank">link</a>. 
2. Second option you have is to simply copy the raw content from the gitignore.io site, using this <a href="https://www.gitignore.io/api/visualstudio" rel="noopener" target="_blank">link</a>. 
3. Third option is to install the <a href="https://marketplace.visualstudio.com/items?itemName=OsirisTerje.IFix" rel="noopener" target="_blank">IFix </a>command line tool, and use the command 
```
IFix gitignore -r -f
```
to get a fresh latest copy down.  Alternatively, if you already have one, using 
```
IFix -m -f
```
to merge your own existing gitignore with the latest from the originator source.
Using IFix to merge is a pretty good way of handling existing ones, as you may have entered ignores that you want to keep, but still need to update. 
4. Fourth option is to use the gitignore.io REST Api

We're going to look a bit more at using the REST Api.  There is a tool called cUrl which is perfect for accessing a url, and also for calling a REST Api.  It's use is <a href="https://www.gitignore.io/docs" rel="noopener" target="_blank">documented </a>by the gitignore.io people.

We can add the curl command with it's parameters as a git alias, like I have shown in two earlier <a href="http://hermit.no/visual-studio-and-vsts-git-extend-the-git-command-line-to-speed-up-your-workflow-part-1/" rel="noopener" target="_blank">blogposts</a> (and <a href="http://hermit.no/visual-studio-and-azure-devops-git-extend-the-git-command-line-with-server-commands-part-2/" rel="noopener" target="_blank">second one here</a>).  

So, add the following lineinto your git config file:

```
ignore = "!gi() { curl -L -s https://www.gitignore.io/api/$@ ;}; gi"
```

You can then add a gitignore file doing:

```
git ignore visualstudio > .gitignore
```

And of course you can simplify this further by adding the following alias:

```
ignorevs = !git ignore visualstudio > .gitignore
```

 Then all you need to write is as shown below:

<a href="http://hermit.no/wp-content/uploads/2019/02/GI-4.jpg"><img src="http://hermit.no/wp-content/uploads/2019/02/GI-4.jpg" alt="" width="705" height="333" class="alignnone size-full wp-image-160600" /></a>

And for being able to update it, you can add the following IFix command as another alias to your gitconfig

```
updategitignore = "!f() { exec ifix gitignore -m -f;}; f"
```

resulting in the following when there is an update available

<a href="http://hermit.no/wp-content/uploads/2019/02/GI-5.jpg"><img src="http://hermit.no/wp-content/uploads/2019/02/GI-5.jpg" alt="" width="697" height="144" class="alignnone size-full wp-image-160601" /></a>


