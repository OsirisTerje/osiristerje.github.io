---
id: 160344
title: Test Data Retention policy added in TFS update 1
date: 2016-04-24T18:32:18+01:00
author: terje
layout: post
categories:
  - Azure DevOps
  - Testing
---
There has been an issue with growing databases due to test data and test attachments not being deleted.&nbsp; I have an earlier [blogpost](http://geekswithblogs.net/terje/archive/2011/11/15/guide-to-reduce-tfs-database-growth-using-the-test-attachment.aspx) ( also [here](http://hermit.no/guide-to-reduce-tfs-database-growth-using-the-test-attachment-cleaner/))&nbsp; on how to fix this, using a tool called Test Attachment Cleaner, and also containing a set of scripts you can run on your server to check on how your database sizes.

 In TFS 2015 update 1 this was fixed by building a data retention policy in to the TFS.&nbsp; This works both for on-premises and for [VSTS](https://www.visualstudio.com/en-us/products/visual-studio-team-services-vs.aspx) instances.

 The retention policy is off by default, but you can enable it by going to the Test tab on the admin page in the WEB UI.&nbsp;

 Press (1) under to go to the admin page)

 [![image](/images/2016/04/image_thumb.png)](/images/2016/04/image.png)

 On the admin page, press 2 (Test tab) to get to the retention policy settings

 [![image](/images/2016/04/image_thumb-1.png)](/images/2016/04/image-1.png)

 You have&nbsp; two groups, one for automated tests and one for manual tests, which can be set independently.

 The retention time is in days, and you can set any number of days, either by selecting from the predefined list, or just by editing in a number there, up to 10000 days.&nbsp; If that is not enough, then it is Never Delete.

 ### Cleaning older databases

 There is no option for cleaning an existing database, which can be handy if you are moving up some data from an earlier version, and there is a not of stuff there.&nbsp; What you do then is to set the retention policy to –1- day, and just wait that single day.&nbsp;
