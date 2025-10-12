---
id: 160555
title: 'Visual Studio and Azure DevOps Git:  Extend the git command line with server commands&ndash;Part 2'
date: 2018-09-23T20:05:00+01:00
author: terje
layout: post
categories:
  - Azure Devops
  - Branching
  - Git
  - Pull Requests
  - VSTS
---
The [former post](http://hermit.no/visual-studio-and-vsts-git-extend-the-git-command-line-to-speed-up-your-workflow-part-1/) in this series showed how you could add aliases to the git command line, and showed how some simple aliases can simplify your command line work.

This post show how you can extend that to work more actively with the [Azure DevOps (formerly known as VSTS)](https://visualstudio.microsoft.com/team-services/) server hosting your repository. (If you don't have an account here, please consider doing that, it is free for modest individual use!)

You can do all of this from the combination of Visual Studio, and the web browser, but going through all those UI's is like a good friend said: "and after 56 more clicks.....".   Using the command line is just so much faster - but in order to be effective the number of parameters must be cut down to something manageable.  And that is what this is about!

### Background

When working in a team, it is a good practice to establish a system where each individual developer works in their own task branch. They each push their changes to the server, and then raises a pull request to have this merged in to the master.  I have described the practice in [this post](http://terjesandstrom.github.io/PullRequestsInGit), and you can also read about it [here](https://docs.microsoft.com/en-us/azure/devops/repos/git/pull-requests?view=vsts&amp;tabs=new-nav).

The workflow you do when working with a pull request is something like the following (YMMV):

1. Create a new branch and go to (checkout) that branch

2. Do your code changes, add and commit the changes

3. Push the commit to the remote server, and create the remote branch at the same time

4. Raise a pull request

5. Optionally set it to autocomplete

6. Go to the web site for the server to follow the [build] process or do whatever you need to do

there

7. Go back to the master branch and prepare for the next task to do.

The points 1-3 + 7 can be done quickly with the aliases made in the last post. But step 4-6 need some extra, and here it comes !

### Setting up VSTS CLI

The first thing you need is the VSTS Client command line interface, and you can [read and download it from here](https://docs.microsoft.com/en-us/cli/vsts/overview?view=vsts-cli-latest).   ([Direct download link](https://aka.ms/vsts-cli-windows-installer))

You then need a Personal Access Token (PAT) for access to the remote server.  Log in to the web portal for your remote VSTS account, and follow the [procedure outlined here](https://docs.microsoft.com/en-us/azure/devops/organizations/accounts/use-personal-access-tokens-to-authenticate?view=vsts) to create a PAT.  Copy the PAT token and run the following command:
<pre><span style="font-family: Courier New;">vsts login --token xxxxxxxxxx</span></pre>
Note:  If you work with multiple different Azure DevOps accounts, then you need to add that instance to this command like this:
<pre><span style="font-family: Courier New;">vsts login --token xxxxxxxxxx --instance [https://dev.azure.com/{myorg](https://dev.azure.com/{myorg)}</span></pre>
Having done this, we’re ready to start working with the VSTS CLI.

### Adding VSTS commands to the git alias

Of course you can use the vsts cli directly, but that means writing a lot of stuff which you really don’t need.

In fact, the creators of the VSTS CLI also thought the same, so they included a command to add VSTS CLI to the git alias system!
<pre><span style="font-family: Courier New;">vsts configure --use-git-aliases yes</span></pre>
This command adds two new aliases:

git pr     :    Wraps the vsts code pr command, which controles pull requests

git repo :    Wraps the vsts code repo command, which controls repository

These commands are not normally used alone, but used as building bricks for more streamlined commands, as shown below.

You can read up on the VSTS CLI command set on the [VSTS CLI documentation site](https://docs.microsoft.com/en-us/cli/vsts/overview?view=vsts-cli-latest).

### Expanding the Git aliases with VSTS CLI commands

Based on the git aliases commands above, we add the following shorter alias commands listed below, and also a couple more to make things even more easy:
<div>
<pre>    prb = !git pr create --target-branch
    prm = !git prb master --query pullRequestId
    prmc = !git prm --auto-complete
    prl = !git pr list -output table
    prc = !git pr update --query status --auto-complete on --id
    url = !git config --get remote.origin.url
    execurl = "!f() { exec start chrome \"$@/pullrequests?_a=mine\"; } ; f"
    web = !git execurl $(git url)
    prs = !git ps show --query status  --id</pre>
</div>
Add these to your .gitconfig files as shown in [the former post](http://hermit.no/visual-studio-and-vsts-git-extend-the-git-command-line-to-speed-up-your-workflow-part-1/).

The commands are based on each other, and in the bottom of that "chain" is the vsts aliases.

## Example of use: Initial

Let us now see how they work, based on the work flow described above:

First we got to the repo, and check the branch we're in, which is master, and then create the new branch using the aliases from the former post, step (1) to (3).

[![Steps to publish a change](/images/2018/09/1.jpg)](/images/2018/09/1.jpg)

Then we code a bit , (4), and see that we indeed have a change (5).  In step 6 and 7 we add and commit the change.  Here we also can use a git aliases,  like shown below

[![](/images/2018/09/8.jpg)](/images/2018/09/8.jpg)

Then we push the change to the remote origin, and set the branch up to track (8).

## Example of use: Creating the pull request

Now, we're on the new stuff.  We want to create a pull request to merge this on to the master branch.

[![](/images/2018/09/2.jpg)](/images/2018/09/2.jpg)

In step (9) we use the prm command,  "Pull Request to Master", and it responds by telling us the pull request id.   We then set the pull request to auto-complete. That means it will automatically be merged when all the requirements set as a branch policy is fulfilled

In (10) using the prc command,"Pull Request autoComplete with the id from the former prm we do this.

To do this in one step, use the prmc command.

Example of use: Reviewing on the web

Now we need to go to the web to do whatever is needed there. Instead of wading through a lot of menues in our Azure DevOps site, we just use the "git web" command, step (11). It takes us directly to the correct pull request list.

[![](/images/2018/09/3.jpg)](/images/2018/09/3.jpg)

Clicking (sigh) the pull request, we get to the detailed view for our particular PR.

[![](/images/2018/09/4.jpg)](/images/2018/09/4.jpg)

We see here that it is marked as autocomplete, as we did with the prc command.  Since no one else is around, we just have to complete it ourselves, but in your case I am sure you have a colleague or two to review it for you :-)

When we wait for that review we continue our work, and can just use the command line to check the status of our PR.

We can then either use the prs command "Pull Request Status" (1), which require the PR id as a parameter,  or the prl command (2), which lists all active PR we have, or is assigned to.

[![](/images/2018/09/6.jpg)](/images/2018/09/6.jpg)

When approving the PR , it looks like this in the UI.

[![](/images/2018/09/5.jpg)](/images/2018/09/5.jpg)

We can again check the status on the command line, and see it is indeed reported as Completed  using the prs command (1), and the prl (2) list is empty.

[![](/images/2018/09/7.jpg)](/images/2018/09/7.jpg)

I have shown this for the most common case where you merge to master.  If you need to set up your PR to another branch you can use the base command:
<pre>git prb  someotherbranch</pre>
If you do that regularly you can just add another alias of your own choice.

### Gist for the aliases

I have added a [gist here](https://gist.github.com/OsirisTerje/e9d06c627405f576e6ebf85e2c09f3c4), which contains the aliases I use, included the ones above, and a few more I find useful.  The gist may change :-)

### Creating pull requests for GitHub

If you're using GitHub, and want the same, or similar, set of commands for that one, you can use [Hub](https://github.com/github/hub).  It is written in Go, whereas VSTS Client is written in Python - no need to care about that, just fun facts!   [Here is a great blogpost](https://andrewlock.net/creating-github-pull-requests-from-the-command-line-with-hub/) about setting it up and how it works.

Happy coding!

&nbsp;
