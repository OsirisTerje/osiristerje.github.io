---
title: 'How to convert NUnit Assert.AreEqual to fluent  Assert.That syntax easily'
date: 2018-11-03T22:44:25+01:00
author: terje
layout: post
categories:
 - nunit
 - howto
---

Once upon a time it was declared that an Assert statement should have constraints given as AreEqual and AreNotEqual.  
Further it was declared that it should be written in the opposite way of how a developer will think, that is with the expected value first and the actual value last.  
Why this was made so, is still unknown.

But we end up with tons of code like:

```cs
Assert.AreEqual("Zulu", zulu.Name);
Assert.AreEqual("Z - Zulu", zulu.Description);
Assert.AreEqual(FlagType.Signal, zulu.Sort);
Assert.AreEqual(0.7, zulu.AspectRatio);
```

And it is not uncommon to see the two parameters swapped, making the displayed results harder to interpret. 

If we write this with the fluent syntax:

```cs
Assert.That(zulu.Name,Is.EqualTo("Zulu");
```

This is the *new* fluent notation in NUnit (new and new.... it has been around for a very long time now, at least since NUnit 2.4, and that is pretty far back in time). 

But - converting from one to another is not fun.  Doing this manually is a very boring task.  

Enter the [NUnit.Analyzers](https://github.com/nunit/nunit.analyzers), a new set of Roslyn based analyzers with refactoring.  

<!--more-->

If you created your NUnit project using Visual Studio *Add New Project* and selected *NUnit*, or you used the command line with `dotnet new nunit`, you will already have the analyzer present.
If not, you can add it to your solution as a nuget package, like any [Roslyn analyzer](https://docs.microsoft.com/en-us/visualstudio/code-quality/roslyn-analyzers-overview).

When it is installed, it will display green squiggles for the lines above, making it look like:

![](/images/nunit/0.jpg)

Going to Show Potential fixes, or just pressing the light bulb.

![](/images/nunit/1.jpg)

As for any Roslyn warning, it shows you the potential change, and offers you also to fix these for the whole document, the whole project or even the whole solution.
We're in for saving work here, so go all in! 
The result will then be:

![](/images/nunit/3.jpg)

Which is much more readable test code! 


