---
id: 160621
title: Moving to SDK-Style projects and package references in Visual Studio, part 2
date: 2019-11-04T16:01:13+01:00
author: terje
layout: post
permalink: /moving-to-sdk-style-projects-and-package-references-in-visual-studio-part-2/

categories:
  - Azure DevOps
  - Build
  - Visual Studio
---
<!-- wp:heading {"level":3} -->
<h3>Introduction</h3>
<!-- /wp:heading -->

<!-- wp:paragraph -->
<p>The SDK style projects are the new format that first appeared for .net core, but actually can be used also for nearly any type of projects in the .net world.   The old style, or what we could call legacy style, is a very complex style, and it is not uncommon to be the cause of merging issues, and also can cause all sorts of weird behavior.   Both styles for a C# project has the extension csproj, even if their content is so different.  </p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>Whenever you have a new project, you should go for the SDK style format.  There are a few projects types that still have to use the legacy format, WPF applications being one, but that can also be handled either by going to .net core 3, or by using extensions to handle it.</p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p> The SDK format can also be opened as text in Visual Studio without unloading the project first.  This makes it much more easy to maintain the project file.  </p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>Legacy projects can be converted to the new style project form.  You can do this manually, which I will cover in an upcoming post.  In this post I will show a neat tool which can convert a whole solution, and also have capabilities to optimize the new style.  Even after this conversion there are further optimizations you can do, to trim down the file.</p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>When we build the new project, we will use the dotnet toolset.  You can still build with Visual Studio, but ensuring it will build with dotnet makes it much easier to set up for CI builds.  </p>
<!-- /wp:paragraph -->

<!-- wp:heading {"level":3} -->
<h3>Sample project for conversion</h3>
<!-- /wp:heading -->

<!-- wp:paragraph -->
<p> Below is a sample project containing a small Math class library, and a unit test project for the same.  Both projects run using .net framework 4.7.2, and we want to keep it as a 4.7.2 project, even after conversion to the SDK style.</p>
<!-- /wp:paragraph -->

<!-- wp:image {"id":160645} -->
<figure class="wp-block-image"><img src="http://hermit.no/wp-content/uploads/2019/10/1.jpg" alt="" class="wp-image-160645"/><figcaption>Figure 1</figcaption></figure>
<!-- /wp:image -->

<!-- wp:paragraph -->
<p>The math library use a nuget package, NewtonSoft.Json.  The test project uses the packages NUnit and the NUnit3TestAdapter.  Both are installed using the legacy nuget package format (!).  The new SDK style csproj only supports the new packagereference style package formats, which is very good, but we need to have these converted too. </p>
<!-- /wp:paragraph -->

<!-- wp:heading {"level":3} -->
<h3>The code</h3>
<!-- /wp:heading -->

<!-- wp:paragraph -->
<p>The code below is the unit test for the Math class, where we test two aspects of the Add method. </p>
<!-- /wp:paragraph -->

<!-- wp:image {"id":160646} -->
<figure class="wp-block-image"><img src="http://hermit.no/wp-content/uploads/2019/10/2.jpg" alt="" class="wp-image-160646"/><figcaption>Figure 2</figcaption></figure>
<!-- /wp:image -->

<!-- wp:paragraph -->
<p>The Math class is has only two methods,  Add, and AsJson, the latter just returns a json representation of the last result of the Add method. </p>
<!-- /wp:paragraph -->

<!-- wp:image {"id":160647} -->
<figure class="wp-block-image"><img src="http://hermit.no/wp-content/uploads/2019/10/3.jpg" alt="" class="wp-image-160647"/><figcaption>Figure 3</figcaption></figure>
<!-- /wp:image -->

<!-- wp:paragraph -->
<p>If we try to use 'dotnet build' on this legacy project format projects, it will fail as shown below. Also note that it complains about not finding any packages to restore.  This is because the project are using the old style package system, which is not supported by dotnet restore. </p>
<!-- /wp:paragraph -->

<!-- wp:image {"id":160648} -->
<figure class="wp-block-image"><img src="http://hermit.no/wp-content/uploads/2019/10/4-1024x272.jpg" alt="" class="wp-image-160648"/><figcaption>Figure 4</figcaption></figure>
<!-- /wp:image -->

<!-- wp:heading {"level":3} -->
<h3>Migrating to SDK format automatically</h3>
<!-- /wp:heading -->

<!-- wp:paragraph -->
<p>We first has to install the migration tool. We only need to do this once, since we install it globally.</p>
<!-- /wp:paragraph -->

<!-- wp:code -->
<pre class="wp-block-code"><code>dotnet tool install --global Project2015To2017.Migrate2019.Tool</code></pre>
<!-- /wp:code -->

<!-- wp:image {"id":160623} -->
<figure class="wp-block-image"><img src="http://hermit.no/wp-content/uploads/2019/10/6-1024x79.jpg" alt="" class="wp-image-160623"/><figcaption>Figure 5</figcaption></figure>
<!-- /wp:image -->

<!-- wp:paragraph -->
<p>Then to run it is very simple:</p>
<!-- /wp:paragraph -->

<!-- wp:code -->
<pre class="wp-block-code"><code>dotnet migrate-2019 wizard migrationsample.sln</code></pre>
<!-- /wp:code -->

<!-- wp:paragraph -->
<p>We will run it as a wizard, so there will be a couple of questions under way, among them asking if we want backups.  This can be ok, in order to more quickly see what was changed, but we will anyway delete these backup folders before we commit the conversion. </p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>We also ask it to do whatever optimization it can.  Now, this may or may not be problematic, so if this means your project won't compile afterwards - and you cant figure it out,  you should run again without optimization. </p>
<!-- /wp:paragraph -->

<!-- wp:image {"id":160626} -->
<figure class="wp-block-image"><img src="http://hermit.no/wp-content/uploads/2019/10/9-1024x469.jpg" alt="" class="wp-image-160626"/><figcaption>Figure 6</figcaption></figure>
<!-- /wp:image -->

<!-- wp:paragraph -->
<p>The projects will ask you to be reloaded, but just before you do, the solution will look like below, - note that the packages.config files now are being deleted.</p>
<!-- /wp:paragraph -->

<!-- wp:image {"id":160627} -->
<figure class="wp-block-image"><img src="http://hermit.no/wp-content/uploads/2019/10/10.jpg" alt="" class="wp-image-160627"/><figcaption>Figure 10</figcaption></figure>
<!-- /wp:image -->

<!-- wp:paragraph -->
<p>After reloading, the project looks like below, and we see we still have the package there, but now it will be as a package reference.  We also see the Backup folders - although they are ignored by git (note the icon). </p>
<!-- /wp:paragraph -->

<!-- wp:image {"id":160629} -->
<figure class="wp-block-image"><img src="http://hermit.no/wp-content/uploads/2019/10/12.jpg" alt="" class="wp-image-160629"/><figcaption>Figure 12</figcaption></figure>
<!-- /wp:image -->

<!-- wp:paragraph -->
<p>If we now do a 'dotnet build', we see it builds just fine.  This is a good indication that the conversion was successful.  You will not always be that lucky!</p>
<!-- /wp:paragraph -->

<!-- wp:image {"id":160630} -->
<figure class="wp-block-image"><img src="http://hermit.no/wp-content/uploads/2019/10/13-1024x212.jpg" alt="" class="wp-image-160630"/><figcaption>Figure 13</figcaption></figure>
<!-- /wp:image -->

<!-- wp:heading {"level":3} -->
<h3>Cleaning up further</h3>
<!-- /wp:heading -->

<!-- wp:paragraph -->
<p>With the SDK format, we no longer use the assemblyinfo.cs file.  Whatever we have there can be moved into the csproj file.  The migrator does that work for us, but it leaves stuff it don't understand in an assemblyinfo.cs file.   It now looks like shown below.</p>
<!-- /wp:paragraph -->

<!-- wp:image {"id":160631} -->
<figure class="wp-block-image"><img src="http://hermit.no/wp-content/uploads/2019/10/14-1024x437.jpg" alt="" class="wp-image-160631"/><figcaption>Figure 14</figcaption></figure>
<!-- /wp:image -->

<!-- wp:paragraph -->
<p>As we don't see any need for any of these settings either (you don't use COM, do you?), we can just remove it, meaning deleting the file itself, and also the Properties folder. </p>
<!-- /wp:paragraph -->

<!-- wp:image {"id":160632} -->
<figure class="wp-block-image"><img src="http://hermit.no/wp-content/uploads/2019/10/15.jpg" alt="" class="wp-image-160632"/><figcaption>Figure 15</figcaption></figure>
<!-- /wp:image -->

<!-- wp:paragraph -->
<p>The structure in Figure 15 looks way simpler and better.  We now check that it still compiles, and that tests run. </p>
<!-- /wp:paragraph -->

<!-- wp:image {"id":160634} -->
<figure class="wp-block-image"><img src="http://hermit.no/wp-content/uploads/2019/10/17-1024x572.jpg" alt="" class="wp-image-160634"/><figcaption>Figure 16</figcaption></figure>
<!-- /wp:image -->

<!-- wp:paragraph -->
<p>If we look at the two csproj files, we still see a lot of stuff that actually can just go. </p>
<!-- /wp:paragraph -->

<!-- wp:image {"id":160635} -->
<figure class="wp-block-image"><img src="http://hermit.no/wp-content/uploads/2019/10/18.jpg" alt="" class="wp-image-160635"/><figcaption>Figure 17</figcaption></figure>
<!-- /wp:image -->

<!-- wp:image {"id":160636} -->
<figure class="wp-block-image"><img src="http://hermit.no/wp-content/uploads/2019/10/19.jpg" alt="" class="wp-image-160636"/><figcaption>Figure 18</figcaption></figure>
<!-- /wp:image -->

<!-- wp:paragraph -->
<p>If we take the test project, and look at what we can remove:</p>
<!-- /wp:paragraph -->

<!-- wp:image {"id":160650} -->
<figure class="wp-block-image"><img src="http://hermit.no/wp-content/uploads/2019/11/30-1.jpg" alt="" class="wp-image-160650"/><figcaption>Figure 19</figcaption></figure>
<!-- /wp:image -->

<!-- wp:list {"ordered":true} -->
<ol><li>These are not needed anymore, delete</li><li>Not needed, just delete</li><li>Nope, not needed either</li><li>We have included the test.sdk (line 24), so we can just delete these too</li><li>This output path is the default anyway, no reason to change that, so this line is not needed either, delete. </li><li>These properties may or may not be useful, but for the start we can run with the defaults, so just let us delete these too</li><li>No import needed anymore, just delete</li><li>We don't have anything MSTest here, all is NUnit, so delete these two also.  </li></ol>
<!-- /wp:list -->

<!-- wp:heading {"level":4} -->
<h4>Sidenote on the test.sdk package</h4>
<!-- /wp:heading -->

<!-- wp:paragraph -->
<p>The test.sdk package contains only a few properties.  We removed the properties for test above (point 4 above), and as can be seen the props file contain a property IsTestProject = true, so by including that package we ensure we have the right default properties for a Test project</p>
<!-- /wp:paragraph -->

<!-- wp:image {"id":160637} -->
<figure class="wp-block-image"><img src="http://hermit.no/wp-content/uploads/2019/10/20-1024x604.jpg" alt="" class="wp-image-160637"/><figcaption>Figure 20</figcaption></figure>
<!-- /wp:image -->

<!-- wp:image {"id":160638} -->
<figure class="wp-block-image"><img src="http://hermit.no/wp-content/uploads/2019/10/21-1024x423.jpg" alt="" class="wp-image-160638"/><figcaption>Figure 21</figcaption></figure>
<!-- /wp:image -->

<!-- wp:heading {"level":4} -->
<h4>End result after cleaning</h4>
<!-- /wp:heading -->

<!-- wp:paragraph -->
<p>When we have done the appropriate cleaning, the final SDK style project for the test project will look like Fig. 22 below. </p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>Note that with the SDK format you don't need to include any code files, they are included automatically.  This goes a long way on making the format very slim.  This goes hand in hand with a git source control system, where also all files matters.  If you don't want to include a file, you should just delete it, and if you regret, grab it back from version control.</p>
<!-- /wp:paragraph -->

<!-- wp:image {"id":160651} -->
<figure class="wp-block-image"><img src="https://i2.wp.com/hermit.no/wp-content/uploads/2019/11/31.jpg?fit=678%2C309" alt="" class="wp-image-160651"/><figcaption>Figure 22</figcaption></figure>
<!-- /wp:image -->

<!-- wp:heading {"level":3} -->
<h3>How folders are handled </h3>
<!-- /wp:heading -->

<!-- wp:paragraph -->
<p>The SDK style format can also handle files contained in sub folders, without adding any more stuff into the csproj file. </p>
<!-- /wp:paragraph -->

<!-- wp:image {"id":160642} -->
<figure class="wp-block-image"><img src="http://hermit.no/wp-content/uploads/2019/10/25-1024x334.jpg" alt="" class="wp-image-160642"/><figcaption>Figure 25</figcaption></figure>
<!-- /wp:image -->

<!-- wp:paragraph -->
<p>However, when the migration tool runs, it tends to add some folders here and there.  Normally you can just delete those folders, if they contain any files at all.  Also, if they don't, why would have them there anyway?</p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>If you just add a single folder, it will be included in the format, as shown below.  </p>
<!-- /wp:paragraph -->

<!-- wp:image {"id":160643} -->
<figure class="wp-block-image"><img src="http://hermit.no/wp-content/uploads/2019/10/26-1024x318.jpg" alt="" class="wp-image-160643"/><figcaption>Figure 26</figcaption></figure>
<!-- /wp:image -->

<!-- wp:paragraph -->
<p>But when you add the first file into that folder, the folder is removed automatically from your project file. </p>
<!-- /wp:paragraph -->

<!-- wp:image {"id":160644} -->
<figure class="wp-block-image"><img src="http://hermit.no/wp-content/uploads/2019/10/27-1024x344.jpg" alt="" class="wp-image-160644"/><figcaption>Figure 27</figcaption></figure>
<!-- /wp:image -->

<!-- wp:heading -->
<h2>Conclusion</h2>
<!-- /wp:heading -->

<!-- wp:paragraph -->
<p>The new SDK format is much slimmer and much more easily maintained than the older legacy format.   It saves you time! </p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>The legacy format may contain duplicated information, e.g. using package.config style, and that may cause issues during merging.  The SDK format doesn't have any of those, and thus reduces the likelihood for merge problems.  It saves you time!</p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>When you have a project over in SDK format, you can also build the projects using the new dotnet tooling, even if you use ordinary .net framework projects.  It simplifies your work!</p>
<!-- /wp:paragraph -->
