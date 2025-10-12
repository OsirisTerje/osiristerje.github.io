---
id: 160571
title: 'How to convert NUnit Assert.AreEqual to fluent  Assert.That syntax easily'
date: 2018-11-03T21:51:11+01:00
author: terje
layout: post
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

Enter the [NUnit.Analyzers](https://github.com/nunit/nunit.analyzers), a new set of Roslyn based analyzers with refactoring.  The project is still in preview, but is still very useful.
You add it to your solution as a nuget package, like any [Roslyn analyzer](https://docs.microsoft.com/en-us/visualstudio/code-quality/roslyn-analyzers-overview?view=vs-2017), but instead of grabbing it off NuGet, you get it from the [NUnit preview feed at MyGet](https://www.myget.org/F/nunit-analyzers/api/v3/index.json).

When it is installed, it will display green squiggles for the lines above, making it look like:
[![](/images/2018/11/0.jpg)](/images/2018/11/0.jpg)

Going to Show Potential fixes, or just pressing the light bulb.

[![](/images/2018/11/1.jpg)](/images/2018/11/1.jpg)

As for any Roslyn warning, it shows you the potential change, and offers you also to fix these for the whole document, the whole project or even the whole solution.
We're in for saving work here, so go all in!
The result will then be:
[![](/images/2018/11/3.jpg)](/images/2018/11/3.jpg)

Which is much more readable test code!

Currently there are only a few warnings and refactorings present, but enough to already be very valuable.  And, the team is hard at work to add more !
