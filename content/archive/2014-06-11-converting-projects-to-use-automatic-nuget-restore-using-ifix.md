---
id: 156894
title: Converting projects to use Automatic NuGet restore, using IFix
date: 2014-06-11T22:10:40+01:00
author: terje
layout: post
guid: http://terje.wpengine.com/?p=156894
permalink: /converting-projects-to-use-automatic-nuget-restore-using-ifix/
dsq_thread_id:
  - "4504836863"
categories:
  - IFix
  - NuGet
---
[Download tool](http://visualstudiogallery.msdn.microsoft.com/b8ba97b0-bb89-4c21-a1e2-53ef335fd9cb)

In version 2.7 of NuGet automatic nuget restore was introduced, meaning you no longer need to distort your msbuild project files with nuget target information.   Visual Studio and TFS 2013 build have this enabled by default. 

However, if your project was created before this was introduced, and/or if you have used the “Enable NuGet Package Restore” afterwards, you now have a series of unwanted things in your projects, and a series of project files that have been modified – and – you no longer neither want nor need this !  You might also get into some unwanted issues due to these modifications.  This is a MSBuild modification that was needed only before NuGet 2.7 !

So: **DON’T USE THIS FUNCTION !!!**

[![image](http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-IFix_1349F-image_thumb_2.png "image")](https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/IFix_1349F/image_6.png)

There is an issue [https://nuget.codeplex.com/workitem/4019](https://nuget.codeplex.com/workitem/4019 "https://nuget.codeplex.com/workitem/4019")  on the NuGet project site to get this function removed, renamed or at least moved farther away from the top level (please help vote it up!).  The response seems to be that it WILL BE removed, around version 3.0.

This function does nothing you need after the introduction of NuGet 2.7.  What is also unfortunate is the naming of it – it implies that it is needed, it is not, and what is worse, there is no corresponding function to remove what it does !

So to fix this use the tool named IFix,  - all free of course, and the code is [open source](https://github.com/OsirisTerje/IFix).  Also report issues at:  [https://github.com/OsirisTerje/IFix](https://github.com/OsirisTerje/IFix "https://github.com/OsirisTerje/IFix") 

IFix information
================

**[DOWNLOAD HERE](http://visualstudiogallery.msdn.microsoft.com/b8ba97b0-bb89-4c21-a1e2-53ef335fd9cb)**

This command line tool installs using an MSI, and add itself to the system path. 

If you work in a team, you will probably need to use the  tool multiple times.  Anyone in the team may at any time use the “Enable NuGet Package Restore” function and mess up your project again. 

The IFix program can be run either in a  check mode, where it does not write anything back – it only checks if you have any issues, or in a Fix mode, where it will also perform the necessary fixes for you.

The IFix program is used like this:

**IFix <command> \[-c/--check\] \[-f/--fix\]  \[-v/--verbose\]**

The command in this case is “nugetrestore”. 

It will do a check from the location where it is being called, and run through all subfolders from that location.

So  “IFix nugetrestore  --check” , will do the check ,  and “IFix nugetrestore  --fix”  will perform the changes, **for all files and folders below the current working directory**.

(Note that --check  can be replaced with only –c, and --fix with –f, and so on. )

**BEWARE: When you run the fix option, all solutions to be affected must be closed in Visual Studio !**

**So, if you just want to DO it, then:**

**IFix nugetrestore --check**

to see if you have issues

then

**IFix nugetrestore  --fix**

to fix them.

### How does it work

**IFix nugetrestore**  checks and optionally fixes four issues that the older enabling of nuget restore created.  The issues are related to the MSBuild projess, and are:

1.  Deleting the nuget.targets file.
2.  Deleting the nuget.exe that is located under the .nuget folder
3.  Removing all references to nuget.targets in the solution file
4.  Removing all properties and target imports of nuget.targets inside the csproj files.

IFix will fix these issues in the same sequence.

The first step, removing the nuget.targets file is the most critical one, and all instances of the nuget.targets file within the scope of a solution has to be removed, and in addition it has to be done with the solution closed in Visual Studio.  If Visual Studio finds a nuget.targets file, the csproj files will be automatically messed up again.

This means the removal process above might need to be done multiple times, specially when you’re working with a team, and as long as the solution context menu has the “Enable NuGet Package Restore” function.  Someone on the team might inadvertently use that function at any time.

It can be a good idea to add this check to a checkin policy – if you run TFS standard version control, but that will have no effect if you use TFS Git version control of course.

So, better be prepared to run the IFix check from time to time.

Or, even better, install IFix on your build servers, and add a call to IFix nugetrestore --check in the TFS Build script. 

**How does it look**

As a first example I have run the IFix program from the top of a set of git repositories, so it spans multiple repositories with multiple solutions.

The result from the check option is as follows:

[![SNAGHTML1218b841](http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-IFix_1349F-SNAGHTML1218b841_thumb.png "SNAGHTML1218b841")](https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/IFix_1349F/SNAGHTML1218b841.png)

We see the four red lines, there is one for each of the four checks we talked about in the previous section. The fact that they are red, means we have that particular issue.

The first section (above the first red text line) is the nuget targets section.  Notice  No.1, it says it has found no paths to copy.  What IFix does here is to check if there are any defined paths to other nuget galleries.  If there are, then those are copied over to the nuget.config file, where is where it should be in version 2.7 and above.   No.2 says it has found the particular nuget.targets file,  No.3  states it HAS found some other nuget galleries defines in the targets file, which then it would like to copy to the config.file.

No.4 is the section for nuget.exe files, and list those it has found, and which it would like to delete.

No 5 states it has found a reference to nuget.targets in the solution file.  This reference comes from the fact that the .nuget folder is a solution folder, and the items within are described in the solution file.

It then checks the csproj files, and as can be seen from the last red line, it ha found issues in 96 out of 198 csproj files.  There are two possible issues in a csproj files.  No.6 is the first one, and the most common and most important one, an “Import project” section.  This is the section that calls the nuget.targets files.  No.7 is another issue, which seems to sometimes be there, sometimes not, it is a RestorePackages property, which also should go away.

Now, if we run the IFix nugetrestore –fix command, and then the check again after that, the result is:

[![image](http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-IFix_1349F-image_thumb.png "image")](https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/IFix_1349F/image_3.png)

All green !