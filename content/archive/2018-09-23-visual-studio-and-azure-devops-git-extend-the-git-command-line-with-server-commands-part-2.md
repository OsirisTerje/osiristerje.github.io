---
id: 160555
title: 'Visual Studio and Azure DevOps Git:  Extend the git command line with server commands&ndash;Part 2'
date: 2018-09-23T20:05:00+01:00
author: terje
layout: post
guid: http://hermit.no/?p=160555
permalink: /visual-studio-and-azure-devops-git-extend-the-git-command-line-with-server-commands-part-2/
catchevolution-sidebarlayout:
  - default
dsq_thread_id:
  - "6928453180"
categories:
  - Azure Devops
  - Branching
  - Git
  - Pull Requests
  - VSTS
---
The <a href="http://hermit.no/visual-studio-and-vsts-git-extend-the-git-command-line-to-speed-up-your-workflow-part-1/">former post</a> in this series showed how you could add aliases to the git command line, and showed how some simple aliases can simplify your command line work.

This post show how you can extend that to work more actively with the <a href="https://visualstudio.microsoft.com/team-services/" target="_blank" rel="noopener">Azure DevOps (formerly known as VSTS) </a> server hosting your repository. (If you don't have an account here, please consider doing that, it is free for modest individual use!)

You can do all of this from the combination of Visual Studio, and the web browser, but going through all those UI's is like a good friend said: "and after 56 more clicks.....".   Using the command line is just so much faster - but in order to be effective the number of parameters must be cut down to something manageable.  And that is what this is about!
<h2>Background</h2>
When working in a team, it is a good practice to establish a system where each individual developer works in their own task branch. They each push their changes to the server, and then raises a pull request to have this merged in to the master.  I have described the practice in <a href="http://terjesandstrom.github.io/PullRequestsInGit">this post</a>, and you can also read about it <a href="https://docs.microsoft.com/en-us/azure/devops/repos/git/pull-requests?view=vsts&amp;tabs=new-nav">here</a>.

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
<h2>Setting up VSTS CLI</h2>
The first thing you need is the VSTS Client command line interface, and you can <a href="https://docs.microsoft.com/en-us/cli/vsts/overview?view=vsts-cli-latest">read and download it from here</a>.   (<a href="https://aka.ms/vsts-cli-windows-installer">Direct download link</a>)

You then need a Personal Access Token (PAT) for access to the remote server.  Log in to the web portal for your remote VSTS account, and follow the <a href="https://docs.microsoft.com/en-us/azure/devops/organizations/accounts/use-personal-access-tokens-to-authenticate?view=vsts">procedure outlined here</a> to create a PAT.  Copy the PAT token and run the following command:
<pre><span style="font-family: Courier New;">vsts login --token xxxxxxxxxx</span></pre>
Note:  If you work with multiple different Azure DevOps accounts, then you need to add that instance to this command like this:
<pre><span style="font-family: Courier New;">vsts login --token xxxxxxxxxx --instance <a href="https://dev.azure.com/{myorg">https://dev.azure.com/{myorg</a>}</span></pre>
Having done this, we’re ready to start working with the VSTS CLI.
<h2>Adding VSTS commands to the git alias</h2>
Of course you can use the vsts cli directly, but that means writing a lot of stuff which you really don’t need.

In fact, the creators of the VSTS CLI also thought the same, so they included a command to add VSTS CLI to the git alias system!
<pre><span style="font-family: Courier New;">vsts configure --use-git-aliases yes</span></pre>
This command adds two new aliases:

git pr     :    Wraps the vsts code pr command, which controles pull requests

git repo :    Wraps the vsts code repo command, which controls repository

These commands are not normally used alone, but used as building bricks for more streamlined commands, as shown below.

You can read up on the VSTS CLI command set on the <a href="https://docs.microsoft.com/en-us/cli/vsts/overview?view=vsts-cli-latest" target="_blank" rel="noopener">VSTS CLI documentation site</a>.
<h2>Expanding the Git aliases with VSTS CLI commands</h2>
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
Add these to your .gitconfig files as shown in <a href="http://hermit.no/visual-studio-and-vsts-git-extend-the-git-command-line-to-speed-up-your-workflow-part-1/" target="_blank" rel="noopener">the former post</a>.

The commands are based on each other, and in the bottom of that "chain" is the vsts aliases.
<h4>Example of use: Initial</h4>
Let us now see how they work, based on the work flow described above:

First we got to the repo, and check the branch we're in, which is master, and then create the new branch using the aliases from the former post, step (1) to (3).

<a href="http://hermit.no/wp-content/uploads/2018/09/1.jpg"><img class="alignnone wp-image-160557 size-full" src="http://hermit.no/wp-content/uploads/2018/09/1.jpg" alt="Steps to publish a change" width="775" height="718" /></a>

Then we code a bit , (4), and see that we indeed have a change (5).  In step 6 and 7 we add and commit the change.  Here we also can use a git aliases,  like shown below

<a href="http://hermit.no/wp-content/uploads/2018/09/8.jpg"><img class="alignnone size-full wp-image-160564" src="http://hermit.no/wp-content/uploads/2018/09/8.jpg" alt="" width="706" height="89" /></a>

Then we push the change to the remote origin, and set the branch up to track (8).
<h4>Example of use: Creating the pull request</h4>
Now, we're on the new stuff.  We want to create a pull request to merge this on to the master branch.

<a href="http://hermit.no/wp-content/uploads/2018/09/2.jpg"><img class="alignnone size-full wp-image-160558" src="http://hermit.no/wp-content/uploads/2018/09/2.jpg" alt="" width="775" height="158" /></a>

In step (9) we use the prm command,  "Pull Request to Master", and it responds by telling us the pull request id.   We then set the pull request to auto-complete. That means it will automatically be merged when all the requirements set as a branch policy is fulfilled

In (10) using the prc command,"Pull Request autoComplete with the id from the former prm we do this.

To do this in one step, use the prmc command.

Example of use: Reviewing on the web

Now we need to go to the web to do whatever is needed there. Instead of wading through a lot of menues in our Azure DevOps site, we just use the "git web" command, step (11). It takes us directly to the correct pull request list.

<a href="http://hermit.no/wp-content/uploads/2018/09/3.jpg"><img class="alignnone size-full wp-image-160559" src="http://hermit.no/wp-content/uploads/2018/09/3.jpg" alt="" width="830" height="407" /></a>

Clicking (sigh) the pull request, we get to the detailed view for our particular PR.

<a href="http://hermit.no/wp-content/uploads/2018/09/4.jpg"><img class="alignnone size-full wp-image-160560" src="http://hermit.no/wp-content/uploads/2018/09/4.jpg" alt="" width="1009" height="384" /></a>

We see here that it is marked as autocomplete, as we did with the prc command.  Since no one else is around, we just have to complete it ourselves, but in your case I am sure you have a colleague or two to review it for you :-)

When we wait for that review we continue our work, and can just use the command line to check the status of our PR.

We can then either use the prs command "Pull Request Status" (1), which require the PR id as a parameter,  or the prl command (2), which lists all active PR we have, or is assigned to.

<a href="http://hermit.no/wp-content/uploads/2018/09/6.jpg"><img class="alignnone size-full wp-image-160562" src="http://hermit.no/wp-content/uploads/2018/09/6.jpg" alt="" width="642" height="142" /></a>

When approving the PR , it looks like this in the UI.

<a href="http://hermit.no/wp-content/uploads/2018/09/5.jpg"><img class="alignnone size-full wp-image-160561" src="http://hermit.no/wp-content/uploads/2018/09/5.jpg" alt="" width="1027" height="301" /></a>

We can again check the status on the command line, and see it is indeed reported as Completed  using the prs command (1), and the prl (2) list is empty.

<a href="http://hermit.no/wp-content/uploads/2018/09/7.jpg"><img class="alignnone size-full wp-image-160563" src="http://hermit.no/wp-content/uploads/2018/09/7.jpg" alt="" width="611" height="118" /></a>

I have shown this for the most common case where you merge to master.  If you need to set up your PR to another branch you can use the base command:
<pre>git prb  someotherbranch</pre>
If you do that regularly you can just add another alias of your own choice.
<h2>Gist for the aliases</h2>
I have added a <a href="https://gist.github.com/OsirisTerje/e9d06c627405f576e6ebf85e2c09f3c4" target="_blank" rel="noopener">gist here</a>, which contains the aliases I use, included the ones above, and a few more I find useful.  The gist may change :-)
<h2>Creating pull requests for GitHub</h2>
If you're using GitHub, and want the same, or similar, set of commands for that one, you can use <a href="https://github.com/github/hub" target="_blank" rel="noopener">Hub</a>.  It is written in Go, whereas VSTS Client is written in Python - no need to care about that, just fun facts!   <a href="https://andrewlock.net/creating-github-pull-requests-from-the-command-line-with-hub/" target="_blank" rel="noopener">Here is a great blogpost</a> about setting it up and how it works.

Happy coding!

&nbsp;