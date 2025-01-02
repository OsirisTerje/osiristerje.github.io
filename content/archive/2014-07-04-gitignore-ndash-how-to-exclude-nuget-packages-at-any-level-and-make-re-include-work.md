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
<p>The .gitignore file contains rules for what files and folders to exclude from git source control.  When you use NuGet you don’t want the binaries retrieved by NuGet to be included into your git repository.  The binaries (and other files) from a NuGet package is downloaded into a folder named packages by default.   You need to add some rules to the gitignore file to exclude this folder from the repository. </p>  <p>Visual Studio comes with a standard gitignore file.  Althought this file contains a Nuget section, it is unfortunately commented out  (VS 2013 Update 2), so you manually have to fix this, or use the <a href="http://visualstudiogallery.msdn.microsoft.com/b8ba97b0-bb89-4c21-a1e2-53ef335fd9cb" target="_blank">IFix</a> utility.  (<a href="http://geekswithblogs.net/terje/archive/2014/06/13/fixing-up-visual-studiorsquos-gitignore--using-ifix.aspx" target="_blank">Blogpost here</a>). </p>  <p>The latest <a href="https://github.com/github/gitignore/raw/master/VisualStudio.gitignore" target="_blank">Visual Studio gitignore file</a> can be found on the <a href="https://github.com/github/gitignore" target="_blank">github gitignore repository</a>.  IFix can also download this file for you. (Visual Studio does not)</p>  <p><font color="#ff0000">Updated 8.Jul. 2014</font>:  <em>This file now has the option 3 below, which works for git version 2.0.1, if you have a lower version, use IFix to add in Option 4 if you require top level exclusion. </em></p>  <p><em>Also updated this post with a  simple decision table, see bottom of the post</em>. </p>  <p><strong></strong></p>  <h1><strong>Where does VS place the packages folder</strong> </h1>  <p>VS (with nuget) will by default create a packages directory at the <strong>first project directory level</strong>, which is one down referred to the gitignore file (given you say no solutiondirectory when you create the project/solution).  Any subsequent projects created will use the packages folder of the first created project. </p>  <p>If you choose to create the project (and solution) <strong>with</strong> a solution directory, the package folder will be placed within that directory and each project will be below that.</p>  <p>In no case is the packages folder placed at the root level of the repo, where the standard gitignore file will be placed.</p>  <p>Some developers however, prefer to have the packages folder at the root level, and simply “move” it there, by editing the Repository path in the nuget.config file, see the <a href="http://docs.nuget.org/docs/reference/nuget-config-settings" target="_blank">docs</a>, sot he pattern need to cover that too.  </p>  <p><strong></strong></p>  <h1><strong>What is to be excluded and re-included</strong></h1>  <p>Normally you want to exclude everything in the packages folder, but there are two typical re-includes, MSBuild build files - those are placed in a subfolder named “build” under the packages folder (you might need this if you do native C++ packages, otherwise probably not), and a file named repositories.config.  The latter is normally regenerated, so you shouldn’t really need to store it in source control, but some developers prefer to do so.</p>  <p>To demonstrate how this works, I have set up a project with package folders at both top level and a sublevel, and with build folder and a repositories.config file to be re-included.</p>  <p><a href="https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/GitIgnore_14795/image_4.png"><img title="image" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="image" src="http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-GitIgnore_14795-image_thumb_1.png" width="291" height="393" /></a></p>  <p>1 and 2 are the packages folders.  3 is a nuget package we want to be excluded, 4 is some text files that we also want to be excluded, whereas the build folders and their content and the repositories.config files are to be included.</p>  <p> </p>  <h1><strong>The different possible patterns for exclusion</strong></h1>  <h3><strong>Option 1:  The VS included gitignore</strong></h3>  <p>The section looks like this:</p>  <pre class="xml" name="code"># NuGet Packages Directory
## TODO: If you have NuGet Package Restore enabled, uncomment the next line
#packages/</pre>

<p>As mentioned above, you must uncomment the last line here.  </p>

<p><font face="Courier New">packages/</font></p>

<p>This exclusion will work for a package folder at any level, but it will not accept any re-includes.  If you try to add any re-includes, they will simply be ignored. </p>

<p>If we add a re-inclusion for the build folder, the result will be as shown below (I use VS to show this, but the “git status” command will show the same) :</p>

<p><a href="https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/GitIgnore_14795/image_2.png"><img title="image" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="image" src="http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-GitIgnore_14795-image_thumb.png" width="699" height="166" /></a></p>

<p>The packages folders are excluded, blue arrow, the build folders are reincluded, red arrow, and thus should appear, but they don’t.  </p>

<p><strong>Conclusion:  This pattern only works if you don’t want to re-include anything.</strong></p>

<p> </p>

<h3><strong>Option 2: The current github gitignore file, using “packages/*” as pattern</strong></h3>

<p>The pattern looks like this, with re-includes:</p>

<pre class="xml" name="code"># NuGet Packages
packages/*
*.nupkg
## TODO: If the tool you use requires repositories.config
## uncomment the next line
!packages/repositories.config

# Enable "build/" folder in the NuGet Packages folder since
# NuGet packages use it for MSBuild targets.
# This line needs to be after the ignore of the build folder
# (and the packages folder if the lines above for that has been uncommented)
!/packages/build/</pre>

<p>What happens now is this:</p>

<p><a href="https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/GitIgnore_14795/image_6.png"><img title="image" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="image" src="http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-GitIgnore_14795-image_thumb_2.png" width="609" height="261" /></a></p>

<p>The exclusion and re-includes are as shown by the blue arrows.  The root level package folder is fine, green arrow, the build folder stays, the repositories.config stays, and the text files we had there are excluded.  BUT – the sub level folder – red arrow – is not fine at all, the build folder is ignored (because there are an exclusion for build higher up in the gitignore file), the NUnit package lib are present, and should have been excluded. </p>

<p><strong>Conclusion:  This pattern only works for top level package folders, which are not a default of Visual Studio. </strong></p>

<p><strong></strong></p>

<h3><strong>Option 3:  A pattern for subfolders that accept re-includes</strong></h3>

<p>If we add a pattern  **/ ahead of the other patterns it will work on subfolders, like </p>

<p><font face="Courier New">**/packages/*</font></p>

<p>it will cover any sub folders like option 1, and will accept re-includes, like option 2.</p>

<p>However, alone, this will NOT cover any top level folders, if you have version 1.9.4 of Git or lower.</p>

<p><a href="https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/GitIgnore_14795/image_8.png"><img title="image" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="image" src="http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-GitIgnore_14795-image_thumb_3.png" width="600" height="237" /></a></p>

<p>We add the **/ to the three clauses, and we see that the sub folders are ok, green arrow, but the top level is now wrong. </p>

<p>However, note that if you use Visual Studio with the default locations of the package folder, this pattern will work. </p>

<p><strong>Conclusion:  This pattern only works for sub level package folders, but will not work on a top level folder, which a developer may choose to use. </strong></p>

<p><strong>This has been fixed in version 2.0.1 of Git, but the current Windows version – which are always lagging – is 1.9.4, which still has this error.</strong></p>

<p> </p>

<h3>Option 4: A combined pattern to cover both top level and subfolders</h3>

<p>If we combine Option 2 and Option 3 we will cover all options here, the resulting clauses are then </p>

<pre class="xml" name="code"># NuGet Packages
**/packages/*
packages/*
*.nupkg
## TODO: If the tool you use requires repositories.config
## uncomment the next line
!**/packages/repositories.config
!packages/repositories.config

# Enable "build/" folder in the NuGet Packages folder since
# NuGet packages use it for MSBuild targets.
# This line needs to be after the ignore of the build folder
# (and the packages folder if the lines above for that has been uncommented)
!**/packages/build/
!packages/build/</pre>

<p>And the results are:</p>

<p><a href="https://gwb.blob.core.windows.net/terje/Windows-Live-Writer/GitIgnore_14795/image_10.png"><img title="image" style="border-left-width: 0px; border-right-width: 0px; background-image: none; border-bottom-width: 0px; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-top-width: 0px" border="0" alt="image" src="http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-GitIgnore_14795-image_thumb_4.png" width="614" height="240" /></a></p>

<p>All is green !</p>

<p> </p>

<p><strong>Conclusion:  This pattern works at any level of package folders, and works with re-includes at any level  but will not work on a top level folder.</strong></p>

<p><strong></strong></p>

<p><em>Note 1:  The “**/” syntax is new from version 1.8.2 of git.</em> </p>

<p><em>Note 2: A pull request for the github gitignore is here <a title="https://github.com/github/gitignore/pull/1131" href="https://github.com/github/gitignore/pull/1131">https://github.com/github/gitignore/pull/1131</a> .  <font color="#ff0000">Update:  Merged July 7th 2014.</font></em></p>

<p><em>Note 3: IFix will be updated to option 3/4 in version 1.1, it will choose correct option based on your git version. </em></p>

<p><em></em></p>

<h3><em>What exclusion pattern to choose</em></h3>

<p>A simple decision table:</p>

<table cellspacing="0" cellpadding="2" width="378" border="1"><tbody>
    <tr>
      <td valign="top" width="81"> </td>

      <td valign="top" width="90"> </td>

      <td valign="top" width="103">Git version &gt;= 2.0.1</td>

      <td valign="top" width="102">&lt;2.0.1 
        <br />(Current for Windows is 1.9.4)</td>
    </tr>

    <tr>
      <td valign="top" width="82">Have top level package </td>

      <td valign="top" width="91">No reincludes</td>

      <td valign="top" width="104">a) **/packages/*
        <br />b) packages/ 

        <br /></td>

      <td valign="top" width="103">packages/
        <br /></td>
    </tr>

    <tr>
      <td valign="top" width="82">Have top level package </td>

      <td valign="top" width="91">Have reincludes</td>

      <td valign="top" width="104">**/packages/*</td>

      <td valign="top" width="104">**/packages/* 
        <br />packages/*</td>
    </tr>

    <tr>
      <td valign="top" width="82">Have sub folder packages </td>

      <td valign="top" width="91">No reincludes</td>

      <td valign="top" width="104">a) **/packages/*
        <br />b) packages/</td>

      <td valign="top" width="104">a) **/packages/*
        <br />b) packages/

        <br /></td>
    </tr>

    <tr>
      <td valign="top" width="82">Have sub folder packages </td>

      <td valign="top" width="91">Have recincludes</td>

      <td valign="top" width="104">**/packages/*</td>

      <td valign="top" width="104">**/packages/* 
        <br /></td>
    </tr>
  </tbody></table>

<p><em></em></p>

<p>a):  Preferred  b): Optional</p>

<p> </p>

<p>Current (July 8th 2014) defaults:</p>

<p>Gitignore from github:  **/package/*</p>

<p>Gitignore from VS default:  package/</p>