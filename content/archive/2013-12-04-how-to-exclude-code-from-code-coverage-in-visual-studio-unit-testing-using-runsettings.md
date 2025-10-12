---
id: 154795
title: How to exclude code from Code Coverage in Visual Studio unit testing using runsettings
date: 2013-12-04T21:49:02+01:00
author: terje
layout: post
categories:
  - Code Coverage
  - Unit Testing
  - Visual Studio
---
Download:  [VS2012 Runsettingstemplate](http://visualstudiogallery.msdn.microsoft.com/601bd207-5889-4935-b101-3ebe1f25aafa)   [VS2013 Runsettingstemplate](http://visualstudiogallery.msdn.microsoft.com/704ebd18-7d60-4341-9224-532f73229c74)

  The VS2012/13 unit test feature can generate code coverage results.  It can do so for (nearly) any type of adapter you choose to use, MSTest, CPPTest (managed/native), [XUnit](http://xunit.codeplex.com/) and [NUnit](http://nunit.org) (but not Chutzpah (note 1)).

  Assume you have a project with a set of unit tests included.  For this demonstration I have used multiple different test frameworks just to show that this applies to any of these frameworks.

  You choose to analyze for code coverage:

  [![image](/images/2015/08/GWB-WindowsLiveWriter-HowtoexcludecodefromCodeCoverageinVisual_13AEF-image_thumb.png)](https://gwb.blob.core.windows.net/terje/WindowsLiveWriter/HowtoexcludecodefromCodeCoverageinVisual_13AEF/image_2.png)

  The code under test is this:

  [![image](/images/2015/08/GWB-WindowsLiveWriter-HowtoexcludecodefromCodeCoverageinVisual_13AEF-image_thumb_1.png)](https://gwb.blob.core.windows.net/terje/WindowsLiveWriter/HowtoexcludecodefromCodeCoverageinVisual_13AEF/image_4.png)

  All the tests we have tests the Add method, none tests the Subtract method, so the expected code coverage should be 50%.

  The result we get is this:

  [![image](/images/2015/08/GWB-WindowsLiveWriter-HowtoexcludecodefromCodeCoverageinVisual_13AEF-image_thumb_2.png)](https://gwb.blob.core.windows.net/terje/WindowsLiveWriter/HowtoexcludecodefromCodeCoverageinVisual_13AEF/image_6.png)

  The total code coverage is calculated to 88%.  We also see all the tests, which – not surprisingly – is at 100%.

  Some people find this to be just fine, and want the code coverage to include the tests.  I , for one, are not so keen on this.  I want to see the code coverage of the real production code, and would have expected a result of 50% in this case.

  One can argue in different ways here, but let us assume that you do agree with me – and you want to get this result more correct :-)

  We then need to exclude the tests from the code coverage results, and there are two ways to do this.

  1) Add an ExcludeFromCodeCoverage attribute to the test classes

  2) Add and enable a runsettings file to the solution.

  Option 1) will be tedious to use when the number of tests goes up, so we will go for Option 2).

  After googling “runsettings” you will find [this article](http://msdn.microsoft.com/en-us/library/vstudio/jj159530.aspx), which tells you to copy settings information from that post into an emtpy runsettings file.  That is hard work!  And, if you use those settings, and you use  a 3rd party test adapter you will find more stuff in your test coverage results than you really bargained for.  (In one case I found the testadapters there!) We need to sweeten up this file.

  And, we don’t want to do this manually each time.

  **Solution:  Install the Runsettings solution Item template from here:  **[VS2012 Runsettingstemplate](Runsettings solution Item template from here:  http://visualstudiogallery.msdn.microsoft.com/601bd207-5889-4935-b101-3ebe1f25aafa)   [VS2013 Runsettingstemplate](http://visualstudiogallery.msdn.microsoft.com/704ebd18-7d60-4341-9224-532f73229c74)

  Now, right click your **Solution**, choose Add Item:

  [![image](/images/2015/08/GWB-WindowsLiveWriter-HowtoexcludecodefromCodeCoverageinVisual_13AEF-image_thumb_3.png)](https://gwb.blob.core.windows.net/terje/WindowsLiveWriter/HowtoexcludecodefromCodeCoverageinVisual_13AEF/image_8.png)

  Select the runsettings:

  Your solution will get this added:

  [![SNAGHTML216dc13b](/images/2015/08/GWB-WindowsLiveWriter-HowtoexcludecodefromCodeCoverageinVisual_13AEF-SNAGHTML216dc13b_thumb.png)](https://gwb.blob.core.windows.net/terje/WindowsLiveWriter/HowtoexcludecodefromCodeCoverageinVisual_13AEF/SNAGHTML216dc13b.png)

  Since we have added the default stuff and also the excludes for the unit testing in this, all you now need to do is to enable the use of this from the Test Menu:

  [![image](/images/2015/08/GWB-WindowsLiveWriter-HowtoexcludecodefromCodeCoverageinVisual_13AEF-image_thumb_4.png)](https://gwb.blob.core.windows.net/terje/WindowsLiveWriter/HowtoexcludecodefromCodeCoverageinVisual_13AEF/image_10.png)

  You select the file using the “Select Test Settings File” and then you enable it by ensuring it has been checked.

  Now when we run the Test Coverage we get this very nice result:

  [![image](/images/2015/08/GWB-WindowsLiveWriter-HowtoexcludecodefromCodeCoverageinVisual_13AEF-image_thumb_5.png)](https://gwb.blob.core.windows.net/terje/WindowsLiveWriter/HowtoexcludecodefromCodeCoverageinVisual_13AEF/image_12.png)

  Compared to the results above, it is less clutter, as the irrelevant test code is not included in the results.  The resulting numbers are also more correct, imho.

  ####

  #### Removing test code based on file exclusions

  Most often your test code is placed in projects and assemblies suffixed with “Test”.  You can then use this as an exclusion criteria.  In that case you must open the runsettings file and add that criteria to the list.

  Note, you don’t need to do this if your test files only contains attributed test classes, then the default runsettings file from the extension above will handle them.

  Find  the section in the file named ModulePaths and add the relevant pattern there under the Exclude section.  Note that the patterns are Regular Expressions, and that special characters like ‘.’ and ‘*’may have special meanings. Test the exclusion properly.  See “Regular expressions” in this [MSDN post](http://msdn.microsoft.com/en-us/library/jj159530%28v=vs.110%29.aspx).

  [![image](/images/2015/08/GWB-WindowsLiveWriter-HowtoexcludecodefromCodeCoverageinVisual_13AEF-image_thumb_6.png)](https://gwb.blob.core.windows.net/terje/WindowsLiveWriter/HowtoexcludecodefromCodeCoverageinVisual_13AEF/image_14.png)

  #### Handling special test code

  If you have code in your test project that is not covered by attributes, that code can be excluded by adding the **ExcludeFromCodeCoverageAttribute** to that part of the code, either class or method.  This can f.e. be stub classes or mocking classes, or common test code that does not have any of the other exclusion attributes.

  #### TFS Build

  Note that The TFS Build templates also have a property for setting the runsettingsfile.

  [![image](/images/2015/08/GWB-WindowsLiveWriter-HowtoexcludecodefromCodeCoverageinVisual_13AEF-image_thumb_8.png)](https://gwb.blob.core.windows.net/terje/WindowsLiveWriter/HowtoexcludecodefromCodeCoverageinVisual_13AEF/image_18.png)

  This is the default setup, which means there is no coverage data.  If you select CodeCoverageEnabled( or …ForAspNetApps) then the standard codecoverage will be performed.  If you select a runsettings file, which must have been checked in to the repository, the Type goes to UserSpecified, and the specifications in the selected runsettings file takes effect.

  [![image](/images/2015/08/GWB-WindowsLiveWriter-HowtoexcludecodefromCodeCoverageinVisual_13AEF-image_thumb_9.png)](https://gwb.blob.core.windows.net/terje/WindowsLiveWriter/HowtoexcludecodefromCodeCoverageinVisual_13AEF/image_20.png)

  Note that this don’t apply if you use the MSTest runner, but in TFS 2013, the VSTest runner is the default.

  Note 1:   VS Test runner can’t find code coverage for javascript code, there is no dll’s to analyze, so it doesn’t work for Chutzpah, which handles QUnit andJasmine.
