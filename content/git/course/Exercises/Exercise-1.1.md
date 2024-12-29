# Exercise 1.1:  Ensure you're all set up correctly

## Tools

### Check git on command line

You should have git itself installed, and available on command line.

If not [Install Git](https://git-scm.com/downloads)

The Git documentation can be found here:  https://git-scm.com/docs


Open a command prompt, and run:
```
git --version
```
 You should see version 2.25 or higher for Windows, 2.23 or higher for Mac.
 If not, [download it](https://git-scm.com/downloads)

First check your configuration

```
git config user.name
git config user.email
```


If nothing, then configure it with

```
git config --global user.name "Your name"
git config --global user.email "Your email"
```

### Choose an Editor

Choose an editor, preferably one that understands git.

E.g:

Visual Studio Code  (Windows, Mac, Linux) (Any language) 

Install git extensions:  GitLens will be used later, but also anyone else you fancy.

Visual Studio 2019. (Windows) (.net * languages)

Eclipse (Window, Mac, Linux)  (Java ++)

Link for downloading [VSCode](https://code.visualstudio.com/download) 

Install for linux, see https://code.visualstudio.com/docs/setup/linux 



### Choose a graphical client

Using a graphical client helps visualizing git.

Choose one of:
1) [SourceTree (Atlassian)](https://www.sourcetreeapp.com/)  Free
2) [Fork](https://fork.dev/)  Free for evaluation, but seems pretty long
3) [Git Kraken](https://www.gitkraken.com/)  Licensed
4) [Tower](https://www.git-tower.com/)  Licensed
5) gitk  (included with git)

## Learning visualization tool

(Windows only)

Install [Git-Viz](https://github.com/Readify/GitViz/releases/download/1.0.2.0/GItViz-1.0.2.0.zip).  

No installers, just copy to somewhere on disk. Create shortcut on desktop, or add to path.

## Establish a remote

We're using [GitHub](https://github.com) as remote storage.

You need an account on Github.  

If you don't have an account, create a new one.  You have both a Github account identifier and Name.  Imho both should be readable, and not a 'funny' name :-)


## Prerequisites

You have used Git before, so you are familiar with the basic commands:

* git clone
* git add
* git commit
* git pull
* git push
* git fetch

You know how to create repositories on GitHub, and you know how to clone it down.



**DO 1**

Create a remote repository **on your own GitHub account**, named **GitCourseNotes**. 

Initialize it with a readme.md file.  

The readme file should be your kind of table of content.

Use this repo to hold your own course notes as you go.  There is a lot of information, and keeping your own notes will probably be a good idea.


Decide a place on your PC, **a base  folder**, below this all your repositories should be placed.

On my machine, I have a "D:\repos".   

It is wise to keep this base path short.  (The default for VS is to place this under your own user folder, down under Documents and so on, that will in many cases lead to path problems)

Clone this repository to your local machine under the selected folder.  That way it is easier to work on with your local editor.  

**DO 2   Team work**   (NOT FOR ONLINE REMOTE, ONLY FOR LIVE COURSE)

Create a Github organisation for your team.  

*Could be named SEB-Team-A and so on*

Add your team members to the organisation.

Create a Notes repository here, and all team members should clone this repository down.  

**DO 3**

Ensure you have dotnet core , and the .net core 3.1 SDK installed.

Just write  (you can do this anywhere, it is just a check):

```
dotnet
dotnet --list-sdks
```

Check that you have 3.1 in that list.

If not [install .net core 3.1 SDK](https://dotnet.microsoft.com/download).

Create a new local repo,  name it 'TaskSystem':

```
md taskSystem
cd TaskSystem
git init
```

Note:  Make sure you don't create this below another git repo, always start from the basepath.

#### Developer/.Net

use dotnet to create a small code sample:

```
dotnet new nunit
```

####  Developer/Java

Create a small unit test program, using JUnit5.

#### Non-developer

Add a single readme.md file to the repo.
Add some nice storyline text in it.

####  All

#### Devs

Build your program

#### Non-dev

Create a folder named bin.

In that folder, add a new file named   "crap.dll",  it doesn't need to contain anything.  Just a text file that you rename is good enough.

E.g.:

```
echo >> crap.dll
```

#### All

Run the git status command, and note what files are shown.

Go to [gitignore.io](https://gitignore.io) and create a gitignore for your language of choice  (e.g. *csharp* for dotnet). For non-dev, choose *csharp* too. 

Add that to a file named **.gitignore**  (note the **dot** in front)

Run the git status command again, and note again what files are shown.

Explain in your own Notes document what the 'git status' command shows, and what is possibly the effect and purpose of the .gitignore file.

Are you sure your untracked files are what you really want inside your repo ?

What folders and files are not included ?

When sure:  Stage and commit the code/files you have.  


**DO 4**

On your own Github account, create a repo, but don't initialize it !!

Add a remote connection from your own local repo (in the TaskSystem folder) to this new remote repo.

Push the local repo to the remote.

Note down what the different parts of these two commands mean.


#### All

Open the repository in the GitViz tool.  

Note the commit with its hash key, and the "things" pointing to it.

Keep the command window and the GitViz window side-by-side.
Do a change to one of the files in your repo, stage/add and commit that file.

What happened with the "things" ?

How does it look now in GitViz ?

Open the repository with your chosen graphical tool.

What does the history look like ?

Push the repo.

How did it change in GitViz ?



### Note

All repos you create should always have the following files

*  readme.md
*  .gitignore

These should be added before you add anything else.

Make a habit of creating these as your initial commit.


### Extra questions  (given time)

* What is the originator source for .gitignore ?   Give the location.

* How often is gitignore changed ?

* Does it matter if you use a built-in method for getting gitignore?   E.g. Visual Studio when you create a repo from that, or adding one by GitHub.  Try one of these and verify for yourselves

* What is really gitignore.io ?


