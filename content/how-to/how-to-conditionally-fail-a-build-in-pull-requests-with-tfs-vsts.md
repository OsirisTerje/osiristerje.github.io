---
id: 160518
title: How to conditionally fail a build in Pull Requests with TFS/VSTS
date: 2019-05-28T09:37:03+01:00
author: terje
layout: post
guid: http://hermit.no/?page_id=160518

---
When you have a build that is used for CI also covering pull requests (PR), you often want to enable more checks before you let this go into the master (or any target) branch. It can be extra tests you want to run, or, you might want to block the PR if you have warnings, e.g. from tests.

Setting a single test task to fail could be done, but that only works well if you have a single step, with multiple you can have build stops for one and every step, so it also reduces the error reporting granularity.&nbsp; And, it is nice to be able to see what is an absolutely blocker, red, and what is quality issues, yellow.

You can achieve this by adding a standard command line task that fails given these conditions.

In the build shown below, there are seven tasks that may give rise to warnings (green checkmarks).&nbsp; They are checked using the red circled command line task below them.

<a href="http://hermit.no/wp-content/uploads/2018/02/conditionallyfails.jpg"><img class="alignnone size-full wp-image-160519" src="http://hermit.no/wp-content/uploads/2018/02/conditionallyfails.jpg" alt="" width="1740" height="824"></a>

<ol>
    <li>Give it a good name like: "If above is partially succeeded, and we have a PR , then fail"</li>
    <li>Use the command "echo"</li>
    <li>The arguments are "1&gt;&amp;2".&nbsp; This mean we redirect the standard output to the error output</li>
    <li>Set to fail on Standard Error.</li>
    <li>Set to custom conditions</li>
    <li>Set to:&nbsp;and(eq(variables['Agent.JobStatus'], 'SucceededWithIssues'), eq(variables['Build.Reason'], 'PullRequest'))</li>
</ol>

The color of the build will then be red, not yellow, but that is how the Azure Pipelines work, so - at least it will block your build and then your Pull Requests too.

## YAML
If you need a yml snippet for this, the above was converted by [Edward Bordin](https://github.com/ed-alertedh) - see [this issue comment](https://github.com/microsoft/azure-pipelines-tasks/issues/1268#issuecomment-430501012), into the following:

```yml
- script: 'echo 1>&2'
  failOnStderr: true
  displayName: 'If above is partially succeeded, then fail'
  condition: eq(variables['Agent.JobStatus'], 'SucceededWithIssues')
```



&nbsp;
