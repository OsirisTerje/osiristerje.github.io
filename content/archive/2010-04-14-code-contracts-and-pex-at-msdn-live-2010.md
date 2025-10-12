---
id: 139250
title: Code Contracts and Pex at MSDN Live 2010
date: 2010-04-14T04:58:48+01:00
author: terje
layout: post
guid: http://terje.wpengine.com/?p=139250
permalink: /code-contracts-and-pex-at-msdn-live-2010/
categories:
  - none
---
One of the 6 sessions I and Mikael Nitell is running on [MSDN Live 2010](http://www.microsoft.com/norge/msdn_technet_live/default.aspx) here in Norway is about Code Quality, and part of that session goes through the use of Code Contracts and Pex. Both fantastic tools! They can be used together, but are also completely independent from each other, and each can be used single.

Code Contracts has to be downloaded separately from VS 2010 (works also on VS 2008). Start looking at [Code Contracts on MSDN](http://msdn.microsoft.com/en-us/devlabs/dd491992.aspx). This download is free. Code Contracts originates from the ideas of Bertrand Meyer – Design by Contract, take a look [here](http://en.wikipedia.org/wiki/Design_by_contract).

Pex is found on the MSDN Subscription download, so it requires an active MSDN Subscription. Start to get it from [Pex downloads](http://research.microsoft.com/en-us/projects/pex/downloads.aspx). The current version as of 14.4.10 is 0.9, which works with the 2010 RC. A new version is due this week. Pex is a tool to generate unit tests, and does this very intelligently. Perfect to make tests for legacy code, but also to make sure you get all paths tested. See the [Reference information](http://research.microsoft.com/en-us/um/redmond/projects/pex/wiki/reference%20manual.html) and [project startup information](http://research.microsoft.com/en-us/um/redmond/projects/pex/wiki/Creating%20a%20Pex%20Project%20in%20Visual%20Studio.html).

A nice presentation on how Pex and Code Contracts can work together can be found [here](http://microsoftpdc.com/Sessions/VTL01).