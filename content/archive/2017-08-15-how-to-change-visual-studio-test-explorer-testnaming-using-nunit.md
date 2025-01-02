---
id: 160422
title: How to change test naming in Visual Studio using NUnit
date: 2017-08-15T07:42:03+01:00
author: terje
layout: post
guid: http://hermit.no/?p=160422
permalink: /how-to-change-visual-studio-test-explorer-testnaming-using-nunit/
dsq_thread_id:
  - "6067198589"
catchevolution-sidebarlayout:
  - default
categories:
  - NUnit
  - Testing
  - Visual Studio
---
The Visual Studio Test Explorer user interface have been nearly the same since 2012, with only a few minor updates.  One thing that have annoyed a few people are how the test names are displayed.   The Test Explorer have got a bit of critique on this, but it is not that hardcoded.  It can be tweaked!   With <a href="https://www.nuget.org/packages/NUnit/" target="_blank" rel="noopener">NUnit3</a> and the <a href="https://www.nuget.org/packages/NUnit3TestAdapter/" target="_blank" rel="noopener">NUnit3TestAdapter</a> version 3.8 you can configure this naming yourself, which makes for some interesting possibilities.
<h2>Problem</h2>
The default naming scheme is that the test name is equal to the test method.  You can then group them based on project, outcome, duration, namespace and even class.  The class grouping is pretty nice, and is close to what we want to see, but you can’t combine this with the others.  With only a few tests this is ok, but when the number of tests goes up over the 100’s and even 1000’s it starts to became harder to locate what you want.

The practice of using both the class and the method name combined to express your intent is also pretty common, but the grouping mechanism in Test Explorer makes it hard to get the full benefit of this practice.

Let us take a simple example just for illustration:

<a href="http://hermit.no/wp-content/uploads/2017/08/image.png"><img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border: 0px;" title="image" src="http://hermit.no/wp-content/uploads/2017/08/image_thumb.png" alt="image" width="303" height="171" border="0" /></a>

Here we follow sort of the <a href="https://martinfowler.com/bliki/GivenWhenThen.html" target="_blank" rel="noopener">Given-When-Then</a> pattern,  but it could be anything, it just is one example where the class name can be seen as part of the wanted test name.

It could also so simple that multiple test methods in different classes have the same name. They would come out as equal, but displayed separately, in the Test Explorer but you would not know where they belonged (unless you used the Class grouping).  So you loose context.

It will come out like this:

<a href="http://hermit.no/wp-content/uploads/2017/08/image-1.png"><img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border: 0px;" title="image" src="http://hermit.no/wp-content/uploads/2017/08/image_thumb-1.png" alt="image" width="275" height="150" border="0" /></a>

Just imagine 500 tests like this -  it is not easy to separate them.
<h2>Solution</h2>
Now, NUnit3 has a concept of Test Names, which can be configured, either individually, or globally.  It is done by adding a <a href="https://github.com/nunit/docs/wiki/Template-Based-Test-Naming" target="_blank" rel="noopener">Test Name Template Pattern</a> to the test.

Added to a single test it looks like this:

<a href="http://hermit.no/wp-content/uploads/2017/08/image-2.png"><img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border: 0px;" title="image" src="http://hermit.no/wp-content/uploads/2017/08/image_thumb-2.png" alt="image" width="648" height="235" border="0" /></a>

The default pattern is just “{m}{a}” which means Methodname+Arguments.  When we add the “{c}.” we get the class name in front.   And as seen the Test Explorer now displays the tests with this combination.

This is the basic principle, but we can’t go and change all the tests to enter this pattern.  The next step is therefore to add a runsettings file and enable that.

If you already haven’t, go and download the <a href="https://marketplace.visualstudio.com/items?itemName=OsirisTerje.Runsettings-19151" target="_blank" rel="noopener">item template for the runsettings</a> files.   That done, you can add one out of 3 possible templates for the runsettings.  For this purpose, just choose and add the simplest one, which is the Parallell template.   In the end of the file you find the NUnit settings.  Add the same name template to the DefaultTestNamePattern:

<a href="http://hermit.no/wp-content/uploads/2017/08/image-3.png"><img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border: 0px;" title="image" src="http://hermit.no/wp-content/uploads/2017/08/image_thumb-3.png" alt="image" width="674" height="218" border="0" /></a>

Now, enable choose and enable this runsettings file from the Test/Test Settings/Select Test Settings File, and then it will be selectable.

<a href="http://hermit.no/wp-content/uploads/2017/08/image-4.png"><img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border: 0px;" title="image" src="http://hermit.no/wp-content/uploads/2017/08/image_thumb-4.png" alt="image" width="674" height="219" border="0" /></a>

and voila!  You have proper test naming for all your tests!

<a href="http://hermit.no/wp-content/uploads/2017/08/image-5.png"><img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border: 0px;" title="image" src="http://hermit.no/wp-content/uploads/2017/08/image_thumb-5.png" alt="image" width="674" height="258" border="0" /></a>

Having a runsettings file present is a good thing anyway, because that is also used to control code coverage and a lot of other settings.   Using it to set the test name pattern just solves one more issue, and makes your developer life a little bit easier!

&nbsp;
<h2>Traps</h2>
Now every rose has it's thorn, and in this case even if there is really no big disadvantages, there are just a couple of things you would expect to work, but which unfortunately doesn’t.
<ol>
 	<li>Test Name patterns are ignored by the Live Unit Testing.  This is a known bug in LUT, and you can find one report and the Microsoft answer to it <a href="https://github.com/nunit/nunit3-vs-adapter/issues/375" target="_blank" rel="noopener">here</a>.   If you enable LUT you will both the new name and the old name together, a bit confusing, although only the LUT names will be run.</li>
 	<li>We have also noted that the display names are currently not being used in the VSTest task, neither in version 1.0 nor 2.0.</li>
</ol>