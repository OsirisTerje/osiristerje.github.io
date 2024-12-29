---
layout: post
date: 2019-12-06

---

# How to list remotes for multiple git repositories

## Background

When you have been working with git over some time, you end up with a lot of repositories.  Many of them will be connected with your favourite remote site, Azure DevOps, GitHub, Gitlab, BitBucket or something else, and some will be local only.

You will normally have them organized under some common folder.  The state of the repositories will be different.  Some of the folders under this common root may not even be a repository.  And you might have organized them into subfolders, per application or per company or whatever.

Over time it becomes hard to get an overview over all of it.  Not to speak of how to find out where a certain local repo is, when you only know the remote url.  

In my case I have nearly all my local repos under a folder D:\repos.  I got 48 top level folders, and many of those contain multiple repos below.  
I got rather frustrated, and could not find any really suitable tools out there to handle it, so only one thing to do:  Roll your own!

## Listgits coming to help

The tool should preferably be able to run on machines with different operating systems.  It would use git under the hood, and would mostly be a wrapper around that, combined with the ability to scan multiple directories.  It then seemed like a good idea to use Python for this purpose, and package it as a tool.  

Listgit searches through all subfolders, and if it think it must be a git repository, it tries to run git remote -v on that folder, thus showing what remotes that repo is connected to.

If we just run it without any arguments, it will run in default mode, all flags are then false, so everything will be shown.

![](https://github.com/OsirisTerje/osiristerje.github.io/blob/master/images/2019-12-06-21-01-02.png)

The first repo it finds (1) is local repo only, meaning it doesn't have any remotes. 
Then it finds a folder only  (2)

The next repo it finds is a standard one,  (3) is the folder where it is located, and (4) is the remotes it finds for that repo.  Normally there are always these two, one for fetch and one for push.  

Then it finds a couple of more folders  (5)

The repo after that, (6), has two remotes, the origin going to Azure Devops, and a secondary named *github* going to .... right... GitHub.

This is one situation where the tool really helps, quickly giving information like this.

The folder (7) is a subfolder without any repo of its own, so it is marked as *Folder only*.  Below that is the a git repo in the folder marked (8).  Also note that since this is one level down from the top, the whole information block is indented 3 spaces. This is just to make it easier to see the hierarchy.

The repo at (9) have two remotes, but one of them can be seen to be another local repo.  You did know that remotes can also be other local folders, right?

## Options to reduce clutter

For a big folder tree there can be a lot of information, so we need some way to reduce the clutter.  As seen above, there are a bunch of folders with no repos.  

The different options to run it is as shown below:

![](https://github.com/OsirisTerje/osiristerje.github.io/blob/master/images/2019-12-06-19-26-03.png)

If we are just looking for the remotes, we can run with the **--r** option.

```cmd
listgits --r
```

It will remove anything else, like empty folders and also some error messages from non-git folders.

![](https://github.com/OsirisTerje/osiristerje.github.io/blob/master/images/2019-12-06-21-14-14.png)

Now, if we just wanted to see which repos are local only, then we use the **--l** flag:

```cmd
listgits --l
```

![](https://github.com/OsirisTerje/osiristerje.github.io/blob/master/images/2019-12-06-21-15-23.png)

We can also just remove the empty folders, using the **--s** flag

```cmd
listgits --s
```

![](https://github.com/OsirisTerje/osiristerje.github.io/blob/master/images/2019-12-06-21-18-11.png)

And now the indenting is rather useful, since the intermediate folder is not shown.

##  Searching for a remote

Sometimes you have a remote url, and wonder if you already have it cloned.  The remote doesn't know, so the only way to know is to search down in your zillion folders.

You then use the **--f  somestring** option.  The *somestring* can be any part of the remote url.  
Let us say we want to know which repos we have that are connected to the Azure DevOps service.

```cmd
listgits --f dev.azure
```

![](https://github.com/OsirisTerje/osiristerje.github.io/blob/master/images/2019-12-06-21-23-18.png)

or we might want to see which are a wiki repo:

```cmd
listgits --f wiki
```

![](https://github.com/OsirisTerje/osiristerje.github.io/blob/master/images/2019-12-06-21-25-22.png)

And we find one for Github and one for Azure Devops :-)

When we use the search option, it will automatically ensure that local repos and folders only are not shown.  

## Installing the **listgits** tool

The **listgits** tool is a [Python](https://www.python.org/downloads/) application.  It does not have [Python](https://www.python.org/downloads/) embedded, so it is a requirement to have [Python](https://www.python.org/downloads/) already installed on your machine and in your PATH, but who doesn't these days?  The version must be 3.6 or above.

You install it simply by using **[pip](https://www.w3schools.com/python/python_pip.asp)**, the Python package manager, and if you have your python scripts in your program folder, it can be wise to install it into the user.

```cmd
pip install listgits --user
```

The tool will probably be updated often, so for updating it:

```cmd
pip install listgits --user -U
```

## Running on the Linux subsystem for Windows

You need to use the full name of the executable, which is  

```cmd
listgits.exe
```

## Tip

There is another option **--g**.   This will be covered in an upcoming blog post, but you should be able to figure it out!

*Dec 6th, 2019*