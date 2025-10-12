---
id: 160621
title: Moving to SDK-Style projects and package references in Visual Studio, part 2
date: 2019-11-04T16:01:13+01:00
author: terje
layout: post
---

#### Introduction

The SDK style projects are the new format that first appeared for .net core, but actually can be used also for nearly any type of projects in the .net world.   The old style, or what we could call legacy style, is a very complex style, and it is not uncommon to be the cause of merging issues, and also can cause all sorts of weird behavior.   Both styles for a C# project has the extension csproj, even if their content is so different.

Whenever you have a new project, you should go for the SDK style format.  There are a few projects types that still have to use the legacy format, WPF applications being one, but that can also be handled either by going to .net core 3, or by using extensions to handle it.

The SDK format can also be opened as text in Visual Studio without unloading the project first.  This makes it much more easy to maintain the project file.

Legacy projects can be converted to the new style project form.  You can do this manually, which I will cover in an upcoming post.  In this post I will show a neat tool which can convert a whole solution, and also have capabilities to optimize the new style.  Even after this conversion there are further optimizations you can do, to trim down the file.

When we build the new project, we will use the dotnet toolset.  You can still build with Visual Studio, but ensuring it will build with dotnet makes it much easier to set up for CI builds.

#### Sample project for conversion

Below is a sample project containing a small Math class library, and a unit test project for the same.  Both projects run using .net framework 4.7.2, and we want to keep it as a 4.7.2 project, even after conversion to the SDK style.

![](/images/2019/10/1.jpg)

Figure 1

The math library use a nuget package, NewtonSoft.Json.  The test project uses the packages NUnit and the NUnit3TestAdapter.  Both are installed using the legacy nuget package format (!).  The new SDK style csproj only supports the new packagereference style package formats, which is very good, but we need to have these converted too.

#### The code

The code below is the unit test for the Math class, where we test two aspects of the Add method.

![](/images/2019/10/2.jpg)

Figure 2

The Math class is has only two methods,  Add, and AsJson, the latter just returns a json representation of the last result of the Add method.

![](/images/2019/10/3.jpg)

Figure 3

If we try to use 'dotnet build' on this legacy project format projects, it will fail as shown below. Also note that it complains about not finding any packages to restore.  This is because the project are using the old style package system, which is not supported by dotnet restore.

![](/images/2019/10/4-1024x272.jpg)

Figure 4

#### Migrating to SDK format automatically

We first has to install the migration tool. We only need to do this once, since we install it globally.

```cmd
dotnet tool install --global Project2015To2017.Migrate2019.Tool
```
![](/images/2019/10/6-1024x79.jpg)

Figure 5

Then to run it is very simple:

```
dotnet migrate-2019 wizard migrationsample.sln
```
We will run it as a wizard, so there will be a couple of questions under way, among them asking if we want backups.  This can be ok, in order to more quickly see what was changed, but we will anyway delete these backup folders before we commit the conversion.

We also ask it to do whatever optimization it can.  Now, this may or may not be problematic, so if this means your project won't compile afterwards - and you cant figure it out,  you should run again without optimization.

![](/images/2019/10/9-1024x469.jpg)

Figure 6

The projects will ask you to be reloaded, but just before you do, the solution will look like below, - note that the packages.config files now are being deleted.

![](/images/2019/10/10.jpg)

Figure 10

After reloading, the project looks like below, and we see we still have the package there, but now it will be as a package reference.  We also see the Backup folders - although they are ignored by git (note the icon).

![](/images/2019/10/12.jpg)

Figure 12

If we now do a 'dotnet build', we see it builds just fine.  This is a good indication that the conversion was successful.  You will not always be that lucky!

![](/images/2019/10/13-1024x212.jpg)

Figure 13

#### Cleaning up further

With the SDK format, we no longer use the assemblyinfo.cs file.  Whatever we have there can be moved into the csproj file.  The migrator does that work for us, but it leaves stuff it don't understand in an assemblyinfo.cs file.   It now looks like shown below.

![](/images/2019/10/14-1024x437.jpg)

Figure 14

As we don't see any need for any of these settings either (you don't use COM, do you?), we can just remove it, meaning deleting the file itself, and also the Properties folder.

![](/images/2019/10/15.jpg)

Figure 15

The structure in Figure 15 looks way simpler and better.  We now check that it still compiles, and that tests run.

![](/images/2019/10/17-1024x572.jpg)

Figure 16

If we look at the two csproj files, we still see a lot of stuff that actually can just go.

![](/images/2019/10/18.jpg)

Figure 17

![](/images/2019/10/19.jpg)

Figure 18

If we take the test project, and look at what we can remove:

![](/images/2019/11/30-1.jpg)

Figure 19

1. These are not needed anymore, delete
2. Not needed, just delete
3. Nope, not needed either
4. We have included the test.sdk (line 24), so we can just delete these too
5. This output path is the default anyway, no reason to change that, so this line is not needed either, delete.
6. These properties may or may not be useful, but for the start we can run with the defaults, so just let us delete these too
7. No import needed anymore, just delete
8. We don't have anything MSTest here, all is NUnit, so delete these two also.

## Sidenote on the test.sdk package

The test.sdk package contains only a few properties.  We removed the properties for test above (point 4 above), and as can be seen the props file contain a property IsTestProject = true, so by including that package we ensure we have the right default properties for a Test project

![](/images/2019/10/20-1024x604.jpg)

Figure 20

![](/images/2019/10/21-1024x423.jpg)

Figure 21

## End result after cleaning

When we have done the appropriate cleaning, the final SDK style project for the test project will look like Fig. 22 below.

Note that with the SDK format you don't need to include any code files, they are included automatically.  This goes a long way on making the format very slim.  This goes hand in hand with a git source control system, where also all files matters.  If you don't want to include a file, you should just delete it, and if you regret, grab it back from version control.

![](/images/2019/11/31.jpg?fit=678%2C309)

Figure 22

#### How folders are handled

The SDK style format can also handle files contained in sub folders, without adding any more stuff into the csproj file.

![](/images/2019/10/25-1024x334.jpg)

Figure 25

However, when the migration tool runs, it tends to add some folders here and there.  Normally you can just delete those folders, if they contain any files at all.  Also, if they don't, why would have them there anyway?

If you just add a single folder, it will be included in the format, as shown below.

![](/images/2019/10/26-1024x318.jpg)

Figure 26

But when you add the first file into that folder, the folder is removed automatically from your project file.

![](/images/2019/10/27-1024x344.jpg)

Figure 27

### Conclusion

The new SDK format is much slimmer and much more easily maintained than the older legacy format.   It saves you time!

The legacy format may contain duplicated information, e.g. using package.config style, and that may cause issues during merging.  The SDK format doesn't have any of those, and thus reduces the likelihood for merge problems.  It saves you time!

When you have a project over in SDK format, you can also build the projects using the new dotnet tooling, even if you use ordinary .net framework projects.  It simplifies your work!
