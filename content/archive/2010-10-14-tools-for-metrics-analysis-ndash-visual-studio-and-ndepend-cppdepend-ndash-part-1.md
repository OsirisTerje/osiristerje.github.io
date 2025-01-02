---
id: 142292
title: 'Tools for Metrics analysis &ndash; Visual Studio and NDepend / CppDepend &ndash; part 1'
date: 2010-10-14T10:07:10+01:00
author: terje
layout: post
guid: http://terje.wpengine.com/?p=142292
permalink: /tools-for-metrics-analysis-ndash-visual-studio-and-ndepend-cppdepend-ndash-part-1/
dsq_thread_id:
  - "5580896201"
categories:
  - Code Analysis
  - Extensions
  - Visual Studio
---
<p><strong>Introduction</strong></p>
<p>Recently I have been involved in some projects to improve the software quality of their code base.  These code bases have been rather large, and in some cases consisting of both managed code, C# and C++, and Native code in C++. The reasons for improving the code base comes from a realization of the relationship between non-optimal coding practices and runtime incidents.  Runtime incidents can be anything from exceptions, out of memory conditions to functionality simply not working at all – some times with no apparent reason or messages appearing.</p>
<p>In order to analyze this codebase one has to use tools, and one set of tools I like to use is Metrics tools.  They give you a quick overview of where you can concentrate your efforts. There is never enough time to improve all the code. One has to choose one’s battles.  Further, letting the developers start to use such tools themselves increases the awareness of coding with respect to code quality.</p>
<p>For managed code the fastest and easiest tool is the Visual Studio built-in metrics.  This tool have a few metrics which are easy to use, easy understandable and works well for a quick and dirty overview of the code.  In order to see what code to fix one should be aware of the limits.  The tool’s internal limits are not very usable, so I blogged up earlier some more <a target="_blank" href="http://geekswithblogs.net/terje/archive/2008/11/25/code-metrics---suggestions-for-appropriate-limits.aspx">usable limits here</a>.</p>
<p>At one point one needs more power for doing metrics, to be able to drill more into the code, and this is where a tool like <a target="_blank" href="http://www.ndepend.com/">NDepend</a> comes in.  I’ve used this tool now for quite some time, and like it better and better.  It has a steeper learning curve than the build-in metrics, but is far more powerful. In fact, it takes metrics analysis to another level – because you can even make your own metric queries based on their Code Query Language.  It also has a bunch of useful metrics, just the <a target="_blank" href="http://www.ndepend.com/Metrics.aspx">documentation of these</a> are valuable in itself.</p>
<p>NDepend integrates into Visual Studio – works for all versions now – and with this you can easily move from methods and types the metrics has identified, and double-click to go straight to the code in question.</p>
<p>NDepend mixes the concept of metrics with Static Code Analysis, and in fact does a series of metrics which are more like the Static Code Analysis rules. What it does in addition is to make a count of the violations, making it easier to see which are the most bothersome.</p>
<p>One thing is pure code analysis, another thing is dependency analysis, which can be done on several levels, from assembly, through namespaces and down to classes and types.</p>
<p>The NDepend analyses C# code, whereas the companion package CppDepend analyses C++ code, and does so both for managed code and for native code. The principle behind these two are similar, and even if some of the more specific metrics differs, most of the stuff is equal.</p>
<p>I will in a series of posts walk through different aspects of code analysis and metrics using both the internal tools, including Static Code Analysis and using the NDepend package. Stay tuned !</p>