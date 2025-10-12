---
id: 160549
title: 'Visual Studio and VSTS Git: Extend the git command line to speed up your workflow&ndash;Part 1'
date: 2018-08-25T11:13:56+01:00
author: terje
layout: post
categories:
  - Git
  - Visual Studio
---
The most basic Git commands are built into the Visual Studio Team Explorer.&nbsp;&nbsp; The Team Explorer will cover your basic needs, but once you get beyond that, you will need to drop down to the command line.&nbsp;&nbsp;&nbsp; The commands are more explicit there, and you have more options, but you will soon tire of having to repeat the same basic commands again and again.&nbsp; Enter the Git aliases – and you can easily make your most used commands so much more short and effective.&nbsp;

 #### What is a Git alias

 A Git alias is a short name for a more complex command which you can add to your git configuration.&nbsp; You can do this either by command, or by editing the git config file directly.&nbsp; A git alias can build on another other git alias, so you can start out simple and extend them as you like.&nbsp; Note that you’re sort of creating your own command language here, so decide how much you want, and consider if you will be able to remember the aliases when you’re going to use them.

 To add it by command, look up the [syntax and usage here](https://git-scm.com/book/en/v2/Git-Basics-Git-Aliases), but for what we’re doing now, adding a bunch of these, it is easier to edit the config file itself.

 #### Deciding upon a syntax

 I prefer very short commands, preferably single letter commands.&nbsp; That limits the range a bit, so I let commands build up from single or double letters to multiple letters as they get more complex.&nbsp; It is pretty common to start out with double letter commands.&nbsp; In some cases that can even be necessary since the terms they’re covering might start with the same letter, like checkout and commit.

 There also are some conventions that are becoming more common, and it certainly doesn’t harm to try to follow these. I you just [google “git aliases](http://lmgtfy.com/?q=git+aliases)” you will find a bunch of posts on this.

 You don’t need to base your commands on the existing command syntax,&nbsp; feel free to make the syntax match your thinking.

 &nbsp;

 #### The basic set of aliases

 The following list of aliases is a good starting point:

 <table cellspacing="0" cellpadding="2" width="400" border="1"> <tbody> <tr> <td valign="top" width="127">**Alias**</td> <td valign="top" width="146">**git command**</td> <td valign="top" width="126">**Comment**</td></tr> <tr> <td valign="top" width="127"><font size="1">a</font></td> <td valign="top" width="146"><font size="1">aliases</font></td> <td valign="top" width="126"><font size="1">Lets you get a list of defined aliases</font></td></tr> <tr> <td valign="top" width="127"><font size="1">b&nbsp; &lt;name&gt;</font></td> <td valign="top" width="146"><font size="1">checkout –b &lt;name&gt;</font></td> <td valign="top" width="126"><font size="1">Create a branch, plus we jump to it</font></td></tr> <tr> <td valign="top" width="127">br &lt;name&gt;</td> <td valign="top" width="146">checkout –b origin/&lt;name&gt;</td> <td valign="top" width="126">Create a local branch of a remote branch </td></tr> <tr> <td valign="top" width="127"><font size="1">s</font></td> <td valign="top" width="146"><font size="1">status</font></td> <td valign="top" width="126"><font size="1">Status stating current branch and files changed and staged</font></td></tr> <tr> <td valign="top" width="127"><font size="1">m</font></td> <td valign="top" width="146"><font size="1">checkout master</font></td> <td valign="top" width="126"><font size="1">Quick way to go to master branch, since that is a very common operation</font></td></tr> <tr> <td valign="top" width="127"><font size="1">p</font></td> <td valign="top" width="146"><font size="1">push</font></td> <td valign="top" width="126"><font size="1">Push to remote</font></td></tr> <tr> <td valign="top" width="127"><font size="1">co &lt;name&gt;</font></td> <td valign="top" width="146"><font size="1">checkout&nbsp; &lt;name&gt;</font></td> <td valign="top" width="126"><font size="1">Go to named branch </font></td></tr> <tr> <td valign="top" width="127">ci &lt;comment&gt;</td> <td valign="top" width="146">add *&nbsp; + commit -m</td> <td valign="top" width="126">Add and commit in one op. Equal to VS commit operation.&nbsp; Add comment in “some comment”</td></tr> <tr> <td valign="top" width="127"><font size="1">pub</font></td> <td valign="top" width="146"><font size="1">See below</font></td> <td valign="top" width="126"><font size="1">Publish local branch to remote</font></td></tr> <tr> <td valign="top" width="127">rm</td> <td valign="top" width="146">rebase master</td> <td valign="top" width="126">Rebase your branch on master, a very common operation</td></tr></tbody></table> #### A common usage scenario using&nbsp; ‘git pub’

 When you work within a team, branches is the saving grace to avoid trouble.&nbsp; So each developer creates his/her own work or task branch, and merges/rebases that to the common team branch – which may be a distinct branch or simply the master.

 The typical workflow will then be:

 <ol> <li>Create a new branch and go to that branch</li> <li>Code whatever it is</li> <li>Stage the changes by doing a git add *</li> <li>Commit the changes</li> <li>Push the changes to the remote, but also remember to create the remote branch and set up tracking&nbsp; (git push -u origin &lt;yourBranchName&gt;) </li> <li>Go to master, and start over</li></ol> Doing that with git commands is a lot of typing, but with the aliases it becomes so much easier as shown below:

 [![image](/images/2018/08/image_thumb.png)](/images/2018/08/image.png)

 #### Modifying the git configuration file

 The git configuration file can be found in your default user folder,&nbsp; named something like c:\users\yourname\.gitconfig

 Go to it using :&nbsp; cd %userprofile%&nbsp; (or just %userprofile% in Explorer)

 The file is named&nbsp;&nbsp;&nbsp;&nbsp; .gitconfig&nbsp;&nbsp;&nbsp; (note it starts with a dot!)

 If the file has a section named Alias you can add lines to that, if not, add the Alias section at the bottom, so it looks like:

<pre class="xml" name="code">[alias]
    a = !git config --get-regexp alias
    b = !git checkout -b
    br = !git checkout -b origin/
    s = !git status
    m = !git checkout master
    p = !git push
    co = !git checkout
    ci = !git add * &amp;&amp; git commit -m
    rm = !git rebase master
    rom = !git rebase origin master
    branchname = !git rev-parse --abbrev-ref HEAD
    pub = !git push -u origin $(git branchname)

&nbsp;

</pre>
*Part 2 :&nbsp; Adding in commands to access VSTS remote.&nbsp;&nbsp;&nbsp; Coming soon*
