---
id: 160608
title: Moving to SDK-Style projects and package references in Visual Studio, part 1
date: 2019-03-11T21:38:32+01:00
author: terje
layout: post
guid: http://hermit.no/?p=160608
permalink: /moving-to-sdk-style-projects-and-package-references-in-visual-studio-part-1/
catchevolution-sidebarlayout:
  - default
categories:
  - Uncategorized
---
<h1>Background</h1>
With the introduction of .NET core some time back, Visual Studio got two different project systems. Along with this, we also got two different formats for a 'csproj' file.
The new format have a better way of including packages, called PackageReference. This also made its way into the old style format, and greatly simplifies the csproj file with respect to including nuget packages.
<h1><strong>Naming</strong></h1>
These formats have not really had any proper naming, but over time the following names have appeared:

The new format:
<em>SDK-Style</em> format seems to be in favor, although <em>Lightweight </em>format is also used.

The old format:
<em>Traditional </em>format should be the correct naming, but some also just say old-style or legacy format.

The project systems are called 'csproj' for the Traditional format, and CPS (Common Project System) for the new SDK-Style format. The use of the name 'csproj' for the project system is a bit unfortunate. It gets easily mixed up with the project file extension itself. Both the new and the old system uses the same extension naming.
<h1><strong>Why you should migrate</strong></h1>
The new CPS is an improved system, so if you start on new projects, you should use this. It will work with most, but not all project types. This seems to improve all the time though, so over time it should replace the old one.

However, the major issue with the old system, is not the system in itself, but the format. It is a very verbose format, whereas the new system is much more terse. More important is the way packages are included. The name and the version of a single package can be found up to 5 places in the same csproj file.

If you have multiple developers, and you use branching and merging, the risk of doing a faulty merge increases with changes in these files.

<a href="http://hermit.no/wp-content/uploads/2019/03/1.jpg"><img class="alignnone size-full wp-image-160609" src="http://hermit.no/wp-content/uploads/2019/03/1.jpg" alt="" width="1386" height="624" /></a>

This is a simple test project, and the arrows show where the name and the version of the NUnit package are stated. When this file is being merged with merge conflicts, it can be very easy to forget to choose the correct merge.
And, these kinds of errors are not easily resolved by the project or package system, in most cases you need to edit the project file manually to fix.
<h1><strong>How to migrate to package references</strong></h1>
Now the new format does not support all the project types that the old format does, nor is all old package features supported. Otherwise we could just have converted the files and be gone with that.
But there is a way:
The new package references comes from the new project system, but very fortunate for us, it is also implemented in the old project system.
This means we can upgrade the old-style package references to the new style package references, but still keep the old project format for the rest.

In order to convert the project, right click the References (1) node of the project:

<a href="http://hermit.no/wp-content/uploads/2019/03/2.jpg"><img class="alignnone size-full wp-image-160610" src="http://hermit.no/wp-content/uploads/2019/03/2.jpg" alt="" width="474" height="427" /></a>

Choose the Migrate (2) option.

You will then get the dialog below, which tells you if you have any issues. You also see the [possible] transitive dependencies.

<a href="http://hermit.no/wp-content/uploads/2019/03/3.jpg"><img class="alignnone size-full wp-image-160611" src="http://hermit.no/wp-content/uploads/2019/03/3.jpg" alt="" width="621" height="588" /></a>

When this has run, you get a html report if there were any actual issues. If there are, you should go on trying to fix them, but if you can't you should roll back. The old files are placed into a MigrationBackup folder.
To roll back, follow these <a href="https://docs.microsoft.com/en-us/nuget/reference/migrate-packages-config-to-package-reference#how-to-roll-back-to-packagesconfig" target="_blank" rel="noopener">instructions</a>

If all went well, the references will now show the packages with a blue icon.
<a href="http://hermit.no/wp-content/uploads/2019/03/4.jpg"><img class="alignnone size-full wp-image-160612" src="http://hermit.no/wp-content/uploads/2019/03/4.jpg" alt="" width="345" height="281" /></a>

And a look into the migrated csproj file show that we have got rid of a lot of "garbage":

<a href="http://hermit.no/wp-content/uploads/2019/03/5b.jpg"><img class="alignnone size-full wp-image-160614" src="http://hermit.no/wp-content/uploads/2019/03/5b.jpg" alt="" width="774" height="568" /></a>

This looks much better, right ?
<h1><strong>Detailed process and possible issues</strong></h1>
The <a href="https://docs.microsoft.com/en-us/nuget/reference/migrate-packages-config-to-package-reference" target="_blank" rel="noopener">detailed instructions for the migration</a> gives you a complete picture of what is going on here. It also contains <a href="https://docs.microsoft.com/en-us/nuget/reference/migrate-packages-config-to-package-reference#package-compatibility-issues" target="_blank" rel="noopener">information on possible things</a> that may cause problems in a nuget package. One such thing is the use of install.ps1 scripts, which were common some years ago. If you have such packages and they are of your own making, then you should convert the install.ps1 to a target or props file instead . If the package comes from https://nuget.org then you should reach out to the author and ask for an update.
<h1><strong>Summary</strong></h1>
Converting to use package references is a good first step to move your whole project over to the new SDK-Style format. I strongly advise you to take this step first, so that you can mitigate any issues that might arise here first.

In the next part, I will go into some easy ways to move to the SDK-Style format, both manually and using a very nice tool!

Happy coding!