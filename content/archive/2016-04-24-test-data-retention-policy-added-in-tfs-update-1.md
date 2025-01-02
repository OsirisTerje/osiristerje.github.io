---
id: 160344
title: Test Data Retention policy added in TFS update 1
date: 2016-04-24T18:32:18+01:00
author: terje
layout: post
guid: http://hermit.no/?p=160344
permalink: /test-data-retention-policy-added-in-tfs-update-1/
catchevolution-sidebarlayout:
  - default
dsq_thread_id:
  - "4773100170"
categories:
  - Azure DevOps
  - Testing
---
<p>There has been an issue with growing databases due to test data and test attachments not being deleted.&nbsp; I have an earlier <a href="http://geekswithblogs.net/terje/archive/2011/11/15/guide-to-reduce-tfs-database-growth-using-the-test-attachment.aspx" target="_blank">blogpost</a> ( also <a href="http://hermit.no/guide-to-reduce-tfs-database-growth-using-the-test-attachment-cleaner/" target="_blank">here</a>)&nbsp; on how to fix this, using a tool called Test Attachment Cleaner, and also containing a set of scripts you can run on your server to check on how your database sizes. </p> <p>In TFS 2015 update 1 this was fixed by building a data retention policy in to the TFS.&nbsp; This works both for on-premises and for <a href="https://www.visualstudio.com/en-us/products/visual-studio-team-services-vs.aspx" target="_blank">VSTS</a> instances. </p> <p>The retention policy is off by default, but you can enable it by going to the Test tab on the admin page in the WEB UI.&nbsp; </p> <p>Press (1) under to go to the admin page) </p> <p><a href="http://hermit.no/wp-content/uploads/2016/04/image.png"><img title="image" style="border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px" border="0" alt="image" src="http://hermit.no/wp-content/uploads/2016/04/image_thumb.png" width="622" height="115"></a></p> <p>On the admin page, press 2 (Test tab) to get to the retention policy settings</p> <p><a href="http://hermit.no/wp-content/uploads/2016/04/image-1.png"><img title="image" style="border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px" border="0" alt="image" src="http://hermit.no/wp-content/uploads/2016/04/image_thumb-1.png" width="616" height="273"></a></p> <p>You have&nbsp; two groups, one for automated tests and one for manual tests, which can be set independently. </p> <p>The retention time is in days, and you can set any number of days, either by selecting from the predefined list, or just by editing in a number there, up to 10000 days.&nbsp; If that is not enough, then it is Never Delete. </p> <h2>Cleaning older databases</h2> <p>There is no option for cleaning an existing database, which can be handy if you are moving up some data from an earlier version, and there is a not of stuff there.&nbsp; What you do then is to set the retention policy to –1- day, and just wait that single day.&nbsp; </p>