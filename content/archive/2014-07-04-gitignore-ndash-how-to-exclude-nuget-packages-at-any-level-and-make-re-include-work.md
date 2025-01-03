---
id: 157276
title: 'GitIgnore&ndash;How to exclude Nuget packages at any level, and make re-include work'
date: 2014-07-04T00:06:15+01:00
author: terje
layout: post
guid: http://terje.wpengine.com/?p=157276
permalink: /gitignore-ndash-how-to-exclude-nuget-packages-at-any-level-and-make-re-include-work/
dsq_thread_id:
  - "4153885136"
categories:
  - Git
  - NuGet
---
The .gitignore file contains rules for what files and folders to exclude from git source control.  When you use NuGet you don’t want the binaries retrieved by NuGet to be included into your git repository.  The binaries (and other files) from a NuGet package is downloaded into a folder named packages by default.   You need to add some rules to the gitignore file to exclude this folder from the repository.

Visual Studio comes with a standard gitignore file.  Althought this file contains a Nuget section, it is unfortunately commented out  (VS 2013 Update 2), so you manually have to fix this, or use the [IFix](http://visualstudiogallery.msdn.microsoft.com/b8ba97b0-bb89-4c21-a1e2-53ef335fd9cb) utility.  ([Blogpost here](http://geekswithblogs.net/terje/archive/2014/06/13/fixing-up-visual-studiorsquos-gitignore--using-ifix.aspx)).

The latest [Visual Studio gitignore file](https://github.com/github/gitignore/raw/master/VisualStudio.gitignore) can be found on the [github gitignore repository](https://github.com/github/gitignore).  IFix can also download this file for you. (Visual Studio does not)

Updated 8.Jul. 2014:  _This file now has the option 3 below, which works for git version 2.0.1, if you have a lower version, use IFix to add in Option 4 if you require top level exclusion._

_Also updated this post with a  simple decision table, see bottom of the post_.

**Where does VS place the packages folder** 
============================================

VS (with nuget) will by default create a packages directory at the **first project directory level**, which is one down referred to the gitignore file (given you say no solutiondirectory when you create the project/solution).  Any subsequent projects created will use the packages folder of the first created project.

If you choose to create the project (and solution) **with** a solution directory, the package folder will be placed within that directory and each project will be below that.

In no case is the packages folder placed at the root level of the repo, where the standard gitignore file will be placed.

Some developers however, prefer to have the packages folder at the root level, and simply “move” it there, by editing the Repository path in the nuget.config file, see the [docs](http://docs.nuget.org/docs/reference/nuget-config-settings), sot he pattern need to cover that too. 

**What is to be excluded and re-included**
==========================================

Normally you want to exclude everything in the packages folder, but there are two typical re-includes, MSBuild build files - those are placed in a subfolder named “build” under the packages folder (you might need this if you do native C++ packages, otherwise probably not), and a file named repositories.config.  The latter is normally regenerated, so you shouldn’t really need to store it in source control, but some developers prefer to do so.

To demonstrate how this works, I have set up a project with package folders at both top level and a sublevel, and with build folder and a repositories.config file to be re-included.

[![image](http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-GitIgnore_14795-image_thumb_1.png "image")](https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/GitIgnore_14795/image_4.png)

1 and 2 are the packages folders.  3 is a nuget package we want to be excluded, 4 is some text files that we also want to be excluded, whereas the build folders and their content and the repositories.config files are to be included.

**The different possible patterns for exclusion**
=================================================

### **Option 1:  The VS included gitignore**

The section looks like this:

\# NuGet Packages Directory
## TODO: If you have NuGet Package Restore enabled, uncomment the next line
#packages/

As mentioned above, you must uncomment the last line here. 

packages/

This exclusion will work for a package folder at any level, but it will not accept any re-includes.  If you try to add any re-includes, they will simply be ignored.

If we add a re-inclusion for the build folder, the result will be as shown below (I use VS to show this, but the “git status” command will show the same) :

[![image](http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-GitIgnore_14795-image_thumb.png "image")](https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/GitIgnore_14795/image_2.png)

The packages folders are excluded, blue arrow, the build folders are reincluded, red arrow, and thus should appear, but they don’t. 

**Conclusion:  This pattern only works if you don’t want to re-include anything.**

### **Option 2: The current github gitignore file, using “packages/\*” as pattern**

The pattern looks like this, with re-includes:

\# NuGet Packages
packages/\*
\*.nupkg
## TODO: If the tool you use requires repositories.config
## uncomment the next line
!packages/repositories.config

# Enable "build/" folder in the NuGet Packages folder since
# NuGet packages use it for MSBuild targets.
# This line needs to be after the ignore of the build folder
# (and the packages folder if the lines above for that has been uncommented)
!/packages/build/

What happens now is this:

[![image](http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-GitIgnore_14795-image_thumb_2.png "image")](https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/GitIgnore_14795/image_6.png)

The exclusion and re-includes are as shown by the blue arrows.  The root level package folder is fine, green arrow, the build folder stays, the repositories.config stays, and the text files we had there are excluded.  BUT – the sub level folder – red arrow – is not fine at all, the build folder is ignored (because there are an exclusion for build higher up in the gitignore file), the NUnit package lib are present, and should have been excluded.

**Conclusion:  This pattern only works for top level package folders, which are not a default of Visual Studio.**

### **Option 3:  A pattern for subfolders that accept re-includes**

If we add a pattern  \*\*/ ahead of the other patterns it will work on subfolders, like

\*\*/packages/\*

it will cover any sub folders like option 1, and will accept re-includes, like option 2.

However, alone, this will NOT cover any top level folders, if you have version 1.9.4 of Git or lower.

[![image](http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-GitIgnore_14795-image_thumb_3.png "image")](https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/GitIgnore_14795/image_8.png)

We add the \*\*/ to the three clauses, and we see that the sub folders are ok, green arrow, but the top level is now wrong.

However, note that if you use Visual Studio with the default locations of the package folder, this pattern will work.

**Conclusion:  This pattern only works for sub level package folders, but will not work on a top level folder, which a developer may choose to use.**

**This has been fixed in version 2.0.1 of Git, but the current Windows version – which are always lagging – is 1.9.4, which still has this error.**

### Option 4: A combined pattern to cover both top level and subfolders

If we combine Option 2 and Option 3 we will cover all options here, the resulting clauses are then

\# NuGet Packages
\*\*/packages/\*
packages/\*
\*.nupkg
## TODO: If the tool you use requires repositories.config
## uncomment the next line
!\*\*/packages/repositories.config
!packages/repositories.config

# Enable "build/" folder in the NuGet Packages folder since
# NuGet packages use it for MSBuild targets.
# This line needs to be after the ignore of the build folder
# (and the packages folder if the lines above for that has been uncommented)
!\*\*/packages/build/
!packages/build/

And the results are:

[![image](http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-GitIgnore_14795-image_thumb_4.png "image")](https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/GitIgnore_14795/image_10.png)

All is green !

**Conclusion:  This pattern works at any level of package folders, and works with re-includes at any level  but will not work on a top level folder.**

_Note 1:  The “\*\*/” syntax is new from version 1.8.2 of git._

_Note 2: A pull request for the github gitignore is here [https://github.com/github/gitignore/pull/1131](https://github.com/github/gitignore/pull/1131 "https://github.com/github/gitignore/pull/1131") .  Update:  Merged July 7th 2014._

_Note 3: IFix will be updated to option 3/4 in version 1.1, it will choose correct option based on your git version._

### _What exclusion pattern to choose_

A simple decision table:

 

 

Git version >= 2.0.1

<2.0.1  
(Current for Windows is 1.9.4)

Have top level package

No reincludes

a) \*\*/packages/\*  
b) packages/  

packages/  

Have top level package

Have reincludes

\*\*/packages/\*

\*\*/packages/\*  
packages/\*

Have sub folder packages

No reincludes

a) \*\*/packages/\*  
b) packages/

a) \*\*/packages/\*  
b) packages/  

Have sub folder packages

Have recincludes

\*\*/packages/\*

\*\*/packages/\*  

a):  Preferred  b): Optional

Current (July 8th 2014) defaults:

Gitignore from github:  \*\*/package/\*

Gitignore from VS default:  package/