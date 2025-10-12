---
id: 140620
title: 'Team Foundation Server &#8211; Test Center and Visual Studio build list management'
date: 2010-06-26T13:59:24+01:00
author: terje
layout: post
guid: http://terje.wpengine.com/?p=140620
permalink: /team-foundation-server-test-center-and-visual-studio-build-list-management/
dsq_thread_id:
  - "6134132793"
categories:
  - Uncategorized
---
One of the great things with the Team Foundation server 2010 is the integration between the different parts. In this blog post, I’ll go through the connection between a Test Plan and the Build System.

A Test Plan should be connected to the builds being done in order to reap the most benefits from the system. The test plan can be connected to the builds through the Properties page on the test plan you are working with, or you can connect it when you start a test run, by choosing "Run with options". The builds should also be properly set up, as shown below.

First, let us start with the Test Plan. When you choose a build to connect to, you get a list of candidates. These candidates are based on the settings given on for each test plan, on its Properties page.

Select the Properties tab for the test plan you are working on. Locate the section named Builds: The candidates are filtered based on the settings given here.

Choose the build definition matching the builds you are using for your test. This will normally be a special manual build, a kind of production build or test build. See here for some definitions of these terms: [defining the build set](http://geekswithblogs.net/terje/archive/2009/02/04/defining-the-build-set.aspx)

Also, choose an appropriate Build Quality, like for example "Ready for initial test". This requires you to set the corresponding build quality, which is done either on the build page itself or on the build list.

Ok, done that – go back to the Test Plan Properties. The next thing to do is to connect the test plan with the build to use for this test run. Go back to the Builds section there.

Choose Modify on the Build in use. You get to the Assign Build page, and it should now look like this: Sometimes, the Available build doesn’t come up with anything, then do a Refresh, and it should be there (little green refresh button to the far right). Press Assign to Plan to set this to the build of your choosing.

You can, as mentioned above, set the build to use when you choose to run your test. Then choose the Run with options and selecting it gives you the opportunity to, among a few things more, set the current build.

A Snag and a Trick:

The list of builds to choose from can get rather long. In order to keep this down, the system for selecting builds gives you only the unassigned builds in the list. Earlier builds are not shown. This is not quite clear in the system, so it is worth mentioning, and sometimes one really has to go back and retest an earlier build.

In any kind of branch, ALWAYS use a Check-in Build (for the Developer). It gives early warning if anything is going wrong.

Always use a QA Build (running daily/nightly at least) on your Development and Main branches, to ensure you have the right code quality, code coverage etc. I say None/Optional on the Release branch, meaning if you do a lot of code changes there, it might be wise to run it also on the release branch, otherwise there should be no need.

Deployment to production build should ONLY be done from the Release branch. Never ever from any of the other.