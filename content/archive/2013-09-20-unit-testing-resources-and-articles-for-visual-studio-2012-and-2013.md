---
id: 154091
title: Unit testing resources and articles for Visual Studio 2012 and 2013
date: 2013-09-20T17:55:59+01:00
author: terje
layout: post
categories:
  - Azure DevOps
  - Extensions
  - Unit Testing
  - Visual Studio
  - VSTS
---
The last year I have written three blog posts for the [Microsoft MSDN ALM blog](http://blogs.msdn.com/b/visualstudioalm/) on unit testing. The posts focused on the new test explorer with its abilities to run tests in multiple frameworks, and utilizing traits to filter what to run, both in Visual Studio and on TFS Build.  I covered the adapters for [NUnit](http://nunit.org/), [XUnit](http://xunit.codeplex.com/) and [Chutzpah](http://chutzpah.codeplex.com/).

  [How to manage unit tests in Visual Studio 2012 Update 1 : Part 1–Using Traits in the Unit Test Explorer](http://blogs.msdn.com/b/visualstudioalm/archive/2012/11/09/how-to-manage-unit-tests-in-visual-studio-2012-update-1-part-1-using-traits-in-the-unit-test-explorer.aspx)

  [Part 2–Using Traits with different test frameworks in the Unit Test Explorer](http://blogs.msdn.com/b/visualstudioalm/archive/2012/11/20/part-2-using-traits-with-different-test-frameworks-in-the-unit-test-explorer.aspx)

  [Part 3: Unit testing with Traits and code coverage in Visual Studio 2012 using the TFS Build – and the new NuGet adapter approach](http://blogs.msdn.com/b/visualstudioalm/archive/2013/06/11/part-3-unit-testing-with-traits-and-code-coverage-in-visual-studio-2012-using-the-tfs-build-and-the-new-nuget-adapter-approach.aspx)

  The adapters can be installed either into Visual Studio using a Visual Studio Extension, or added to your solution using an adapter delivered through NuGet. At the time of writing only NUnit offers the NuGet adapter. The advantage of using a NuGet based adapter is that it follows the solution, so it will just work for any developer regardless of that developer has installed the adapter or not.  It will also work directly on a TFS server, either on-premise or the TF Service.

  If you use non-NuGet adapter, the content of the adapter must be added to the TFS Server custom build activities folder. This is described in Part 3 (above). Grab a [readymade zip](https://launchpad.net/nunit-vs-adapter) with this content.

  Part 3 also describes how to get the NUnit NuGet adapters – there are two variants – and how to choose between them.

  [NuGet](http://nuget.org) Quick Access: Search for “NUnit TestAdapter”.   Note:  You need only one per solution

  Setting up NuGet correctly in your solution is described in this [NuGet Setup Inmeta Knowledge Article](https://github.com/Inmeta/Knowledge/wiki/NuGet-Setup)

  If you choose to go the extensions road, they are found at

  [NUnit Test Adapter Extension](http://visualstudiogallery.msdn.microsoft.com/6ab922d0-21c0-4f06-ab5f-4ecd1fe7175d)

  [XUnit Test Adapter Extension](https://visualstudiogallery.msdn.microsoft.com/463c5987-f82b-46c8-a97e-b1cde42b9099)

  [Chutzpah Test Adapter Extension](http://visualstudiogallery.msdn.microsoft.com/f8741f04-bae4-4900-81c7-7c9bfb9ed1fe) (covering [QUnit](http://docs.jquery.com/QUnit) and [Jasmine](http://pivotal.github.com/jasmine/) for Javascript testing)

  Some other useful articles

  [Visual Studio 2012 RC – What’s new in Unit Testing](http://blogs.msdn.com/b/visualstudioalm/archive/2012/06/18/visual-studio-2012-rc-what-s-new-in-unit-testing.aspx)

  [Windows Phone Unit Tests in Visual Studio 2012 Update 2](http://blogs.msdn.com/b/visualstudioalm/archive/2013/01/31/windows-phone-unit-tests-in-visual-studio-2012-update-2.aspx)

  [Visual Studio Unit Test Generator v1 “lands”](http://blogs.msdn.com/b/visualstudioalm/archive/2013/08/27/visual-studio-unit-test-generator-v1-lands.aspx)

  [What's New in Visual Studio 11 Beta Unit Testing](http://blogs.msdn.com/b/visualstudioalm/archive/2012/03/08/what-s-new-in-visual-studio-11-beta-unit-testing.aspx)

  [Visual Studio 11 Beta - Unit Testing Plugins List](http://blogs.msdn.com/b/visualstudioalm/archive/2012/03/02/visual-studio-11-beta-unit-testing-plugins-list.aspx)

  or [search for more here](http://social.msdn.microsoft.com/Search/en-US?query=unit%20testing&amp;beta=0&amp;rn=Visual+Studio+ALM+%2b+Team+Foundation+Server+Blog&amp;rq=site:blogs.msdn.com/b/visualstudioalm/&amp;ac=5).
