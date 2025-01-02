---
id: 160543
title: 'VSIX based Test Adapters to be deprecated in Visual Studio for C# and Visual Basic to speed up testing'
date: 2018-07-08T13:16:14+01:00
author: terje
layout: post
guid: http://hermit.no/?p=160543
permalink: /vsix-based-test-adapters-to-be-deprecated-in-visual-studio-for-c-and-visual-basic-to-speed-up-testing/
catchevolution-sidebarlayout:
  - default
dsq_thread_id:
  - "6780608636"
categories:
  - NUnit
  - Unit Testing
  - Visual Studio
---
Test Adapters come in two flavors, VSIX based and Nuget based. The VSIX based are installed as extensions to Visual Studio and therefore will apply to all solutions you load, The Nuget based adapter packages must be installed at least into one project in your solution and will only work for that solution.

All versions of Visual Studio have supported both flavors, but from <strong>Visual Studio 2017 Update 15.8 (Preview 4) the VSIX based adapters for C# and Visual Basic will be deprecated</strong>.

Also, you will need to install the nuget test adapter package into <strong>all</strong> test projects. See below for details.

One of the reasons for this, is that you can gain a significant speed increase especially when you execute just a few tests out of many. Since test execution speed is very essential to a good development flow this should be greatly appreciated.

Note 1: VSIX will still be supported and enabled by default, but to gain the performance boost, you should switch. Moving forward, at first you must "opt out" of using VSIX - if installed, but one should expect it to move towards "opt in" or completely being removed in an even later version. So with "deprecated" it means they will still be supported.  In the longer term, the "supporting" will be taken out, but there is no time frame for that now.  You'll however be wise to start moving over sooner than later.

Note 2: VSIX for all other languages, like C++, JavaScript, Python and others, will still be fully supported.  This change will only apply to C# and Visual Basic projects.

<strong>Actions you should take</strong>
You should start to add the <a href="https://www.nuget.org/packages/NUnit3TestAdapter/" target="_blank" rel="noopener">NUnit3 Nuget TestAdapter</a> (or if you're still on NUnit2 use the <a href="https://www.nuget.org/packages/NUnit3TestAdapter/" target="_blank" rel="noopener">NUnit2 TestAdapter</a>) to at least one project in each solution you have.

And then you <strong>should</strong> uninstall your VSIX adapter.

By uninstalling the VSIX adapter you will
1) More easily see which solutions are still missing the test adapter package
2) Avoid having the VSIX adapter taking precedence over the nuget adapter, because that is what happens currently when you have both. With the VSIX installed, you don't see if the nuget adapter is actually working. (Note: This applies "pre-change", see below)

The same procedure applies if you use any other VSIX based adapter where there exist a matching Nuget based adapter.  If you're using MSTest 1 VSIX, then you can switch to the MSTest 2 nuget based  adapter.

<strong>[Important!]  Installing the adapter package into all projects</strong>
When you install the test adapter package, you choose to install it just into one project, but in upcoming Visual Studio versions you <strong>must</strong> <strong>install the adapter into all test projects you have.  </strong>Adding it to a single project only will no longer work.

This will also enable the optimisations making the adapter loading faster if they are present in the binary output folder.

With the new project format this is much easier (read: faster) to change than with the old format, since it is just a copy/paste operation into the csproj file,  see <a href="http://hermit.no/net-core-setup/" target="_blank" rel="noopener">this post</a> for an example.  The csproj file can be accessed through the context menu Edit XXXX.csproj without having to unload the project. With the old format the most easy way is to go through the Tools/Nuget Package Manager/Manage NuGet Packages for Solution dialogue.

<strong>Performance improvements</strong>

The new feature with the adapter in each binary test folder, will make the adapter loading faster.  How much faster will depend on how many tests you have, and how many you select to run.  It is expected to have most effect when you have many tests but just execute a few.  Time will tell :-)

<strong>But I am not ready to do this </strong>
Don't worry!  Deprecation don't mean "not supported".  There will be a fallback option in Visual Studio which will start out by being enabled by default, and it will then use the old mechanism to search for and load adapters.

[caption id="attachment_160544" align="alignnone" width="1403"]<a href="http://hermit.no/wp-content/uploads/2018/06/2018-06-24_22-09-50.jpg"><img class="wp-image-160544 size-full" src="http://hermit.no/wp-content/uploads/2018/06/2018-06-24_22-09-50.jpg" alt="Suggested options dialog for handling test adapters" width="1403" height="835" /></a> Suggested options dialog for handling test adapters[/caption]

In the first versions the full feature will be Opt In, although if you have the adapters correctly placed you will get the benefit.  At some time later, it will be changed to Opt Out.  (No time frame about when that change will happen has been published)
The suggested options dialog is shown below (from ref.1 below):

At first, both (1) and (2) will be checked.

Checkbox (1) enables feature.  If a test adapter is found in the given location, it will be used, and there will be no further search.

Checkbox (2) enables the fallback option.   With this unchecked the test will not be run if there is no test adapter.

Note:   The full precedence of the VSIX will not happen when you have these options enabled.  The options as shown above will cause the test system to choose the optimal adapter where found.

<strong>When will this change appear</strong>

This feature will probably start to appear in the 15.8 update to VS2017, and can be seen in (<em>currently upcoming per July 7th 2018</em>)  Preview 4.  This should not adversely affect any existing projects, but will allow you to take advantage of it simply by having nuget test adapters in all test projects.  The defaults will be set so that everything will continue to work as they do today.

Keep track here:

<strong>What about the command line</strong>
There will be new command line options to control the behavior, see <a href="https://github.com/Microsoft/vstest-docs/blob/master/RFCs/0022-User-Specified-TestAdapter-Lookup.md">Ref.2</a> for details.
Since build servers works by using the command line, either directly or through the VSTS/TFS test task, the latter will need to change to adopt the new behavior, it will only be a question of time before the default is changing here too.  Since there will be a version update of the VSTest task to enable this, using the older version should keep you "safe" if you have VSIX adapters installed on all your build servers.

<strong>References</strong>

1.<a href="https://github.com/nunit/nunit3-vs-adapter/issues/518">NUnit3 Test Adapter issue raised by MS</a>
2.<a href="https://github.com/Microsoft/vstest-docs/blob/master/RFCs/0022-User-Specified-TestAdapter-Lookup.md">Documentation for the new test behaviour</a>
3.<a href="https://docs.microsoft.com/en-gb/visualstudio/releasenotes/vs2017-Preview-relnotes#testadapterextension">Release note comment for the feature for VS 2017 Update 15.8 Preview 4</a>
&nbsp;