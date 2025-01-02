---
id: 160571
title: 'How to convert NUnit Assert.AreEqual to fluent  Assert.That syntax easily'
date: 2018-11-03T21:51:11+01:00
author: terje
layout: post
guid: http://hermit.no/?p=160571
permalink: /how-to-convert-nunit-assert-areequal-to-fluent-assert-that-syntax-easily/
catchevolution-sidebarlayout:
  - default
dsq_thread_id:
  - "7017372630"
categories:
  - Code
  - Code Analysis
  - NUnit
  - Roslyn
---
Once upon a time it was declared that an Assert statement should have constraints given as AreEqual and AreNotEqual.  Further it was declared that it should be written in the opposite way of how a developer will think, that is with the expected value first and the actual value last.  Why this was made so, is still unclear.

And then we end up with tons of code like:

<code>Assert.AreEqual("Zulu", zulu.Name);
Assert.AreEqual("Z - Zulu", zulu.Description);
Assert.AreEqual(FlagType.Signal, zulu.Sort);
Assert.AreEqual(0.7, zulu.AspectRatio);</code>

And it is not uncommon to see the two parameters swapped, making the displayed results harder to interpret. 

If we write this with the fluent syntax:

<code>Assert.That(zulu.Name,Is.EqualTo("Zulu");</code>

This is the *new* fluent notation in NUnit (new and new.... it has been around for a very long time now, at least since NUnit 2.4, and that is pretty far back in time). 

But - converting from one to another is not fun.  Doing this manually is a very boring task.  

Enter the <a href="https://github.com/nunit/nunit.analyzers" rel="noopener" target="_blank">NUnit.Analyzers</a>, a new set of Roslyn based analyzers with refactoring.  The project is still in preview, but is still very useful.  
You add it to your solution as a nuget package, like any <a href="https://docs.microsoft.com/en-us/visualstudio/code-quality/roslyn-analyzers-overview?view=vs-2017" rel="noopener" target="_blank">Roslyn analyzer</a>, but instead of grabbing it off NuGet, you get it from the <a href="https://www.myget.org/F/nunit-analyzers/api/v3/index.json" rel="noopener" target="_blank">NUnit preview feed at MyGet</a>. 

When it is installed, it will display green squiggles for the lines above, making it look like:
<a href="http://hermit.no/wp-content/uploads/2018/11/0.jpg"><img src="http://hermit.no/wp-content/uploads/2018/11/0.jpg" alt="" width="1276" height="203" class="alignnone size-full wp-image-160573" /></a>

Going to Show Potential fixes, or just pressing the light bulb.

<a href="http://hermit.no/wp-content/uploads/2018/11/1.jpg"><img src="http://hermit.no/wp-content/uploads/2018/11/1.jpg" alt="" width="687" height="324" class="alignnone size-full wp-image-160574" /></a>

As for any Roslyn warning, it shows you the potential change, and offers you also to fix these for the whole document, the whole project or even the whole solution.
We're in for saving work here, so go all in! 
The result will then be:
<a href="http://hermit.no/wp-content/uploads/2018/11/3.jpg"><img src="http://hermit.no/wp-content/uploads/2018/11/3.jpg" alt="" width="509" height="102" class="alignnone size-full wp-image-160572" /></a>

Which is much more readable test code! 

Currently there are only a few warnings and refactorings present, but enough to already be very valuable.  And, the team is hard at work to add more !
