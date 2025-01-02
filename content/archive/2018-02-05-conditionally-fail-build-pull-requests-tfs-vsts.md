---
id: 160520
title: How to conditionally fail a build in a pull requests with TFS/VSTS
date: 2018-02-05T18:31:17+01:00
author: terje
layout: post
guid: http://hermit.no/?p=160520
permalink: /conditionally-fail-build-pull-requests-tfs-vsts/
catchevolution-sidebarlayout:
  - default
dsq_thread_id:
  - "6460311064"
categories:
  - Azure DevOps
  - Branching
  - Build
  - Pull Requests
  - Testing
  - Unit Testing
  - VSTS
---
When your TFS/VSTS CI build is also used for a pull request, you often want to enable more checks before you let this go into the master (or any target) branch, and fail the build if these raise warnings.

It can be extra tests you want to run, code quality checks,  process checks, and  you might want to block the pull request if you have warnings from these.

Setting a single test task to fail could be done, but that only works well if you have a single step, with multiple tasks you will have build stops for one and every step, so it also reduces the error reporting granularity.  And, it is nice to be able to see what is an absolutely blocker, red, and what is quality issues, yellow.

You can achieve this by adding a standard command line task that <strong>fails</strong> given these conditions.  It is very easy to set up.

In the build shown below, there are seven tasks that may give rise to warnings (green checkmarks).  Note that some are ordinary unit tests, the tests are also split into pure L0 class based unit tests, and L1 integration tests, see these <a href="https://blogs.msdn.microsoft.com/bharry/2017/06/28/testing-in-a-cloud-delivery-cadence/" target="_blank" rel="noopener">two</a> <a href="https://www.visualstudio.com/learn/shift-left-make-testing-fast-reliable/" target="_blank" rel="noopener">posts</a>.  There are also checks that verify that we have more than a set number of tests, and finally a<a href="https://marketplace.visualstudio.com/items?itemName=alanwales.resharper-code-analysis" target="_blank" rel="noopener"> Resharper code quality check task</a>.  They are checked using the red circled command line task below them.

<a href="http://hermit.no/wp-content/uploads/2018/02/conditionallyfails-1.jpg"><img class="alignnone wp-image-160521 size-full" src="http://hermit.no/wp-content/uploads/2018/02/conditionallyfails-1.jpg" alt="Build task setup for conditional fail" width="1740" height="824" /></a>
<ol>
 	<li>Give it a good name like: "If above is partially succeeded, and we have a PR , then fail"</li>
 	<li>Use the command "echo"</li>
 	<li>The arguments are "1&gt;&amp;2".  This mean we redirect the standard output to the error output</li>
 	<li>Set to fail on Standard Error.</li>
 	<li>Set to custom conditions</li>
 	<li>Set to: and(eq(variables['Agent.JobStatus'], 'SucceededWithIssues'), eq(variables['Build.Reason'], 'PullRequest'))</li>
</ol>
Reusing a CI build in a pull request saves you an extra build.  The PR build which you enable in the Pull Request policy, runs on the merged code of your branch and the target branch, normally the master.  It makes a lot of sense to make this build stricter than the ordinary CI build.  Note in the build definition above that the L1 tests are also conditionals, they only run for a pull request started build. The L1 tests are normally slower than the L0, and it makes sense to only use them as an extra quality step.

<strong>Tip 1:</strong> Note that everything above where you place the command line will be affected, anything below will not be affected.

<strong>Tip 2</strong>: This has to be used in the build definition proper, it doesn't work in a <a href="https://docs.microsoft.com/en-gb/vsts/build-release/concepts/library/task-groups" target="_blank" rel="noopener">task group</a>, due to the custom conditional which is not available in task groups.

<strong>Tip 3:</strong> Examples of other useful conditions, and the condition syntax can  be found in <a href="https://docs.microsoft.com/en-us/vsts/build-release/concepts/process/conditions" target="_blank" rel="noopener">this msdn article</a>