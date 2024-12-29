# Exercise 1.2 - Remotes, sizing

### Install a tool

Install  [git sizer](https://github.com/github/git-sizer/releases) following [these instructions](https://github.com/github/git-sizer#getting-started)

Also check [this blogpost](https://github.blog/2018-03-05-measuring-the-many-sizes-of-a-git-repository/)


### Why should repos be small and what does it mean


Start cloning [this repo](https://github.com/torvalds/linux).

If too big, try:

cloning [this repo](https://github.com/openshift/origin).

Still too much?

The try [this](https://github.com/microsoft/vscode), you will manage it!


Run 

```
git-sizer  --verbose
```

How does it look?   Size,  structure ?

Open it up with your favourite UI tool, how does that work ?

Look at Blobs/Total size.  How does that compare to Explorer's size of the repo ?

What is the size of the workspace folder (inluding its .git folder) ?   What does it tell you?

Now try to clone [this](https://github.com/nunit/nunit3-vs-adapter.git)

Repeat sizing it.  

Do the same with [this one](https://github.com/microsoft/vscode-python)

What types of files seems to be bothering these, with respect to sizes?

#### Extra

Install the Github size extension (link at the bottom), to see the size before you start a download




## Remotes

### Decide on https or ssh

You can use either https or ssh connections to github.  What you use is a preference things, and you can also mix and match these.

To set up with SSH, ensure you have it installed - otherwise add it from Apps & Features, named OpenSSH client.

If you don't have any, create a new SSH key, and add it to your github profile.

```
ssh-keygen
```

Insert it (from id_rsa.pub) into your "Profile/SSH and GPG keys" section on Github.

If you use https, you don't need to do anything mroe than cloning.

Note that the format for cloning is different between https and ssh.  

```
git clone git@github.com:OsirisTerje/exercise12.git

or

git clone https://github.com/OsirisTerje/exercise12.git

```

More [info here](https://help.github.com/en/github/authenticating-to-github/connecting-to-github-with-ssh)

--------------

## Creating repositories

### Method 1

Create a local repo, name it whatever you like

```
git init
or
git init mywhatever
```

Commit a new file to it

```
echo  # Fun stuff  >> readme.md
git add *
git commit -m"initial"
```

Then connect your local repo with a new remote :

Create a repo named 'exercise12' on your Github account, **without adding any files to it**.

Notice the second block, "push an existing repository from the command line"


```
git remote add origin https://github.com/<youraccountname>/exercise12.git
git push -u origin master
```

Why is the remote named 'origin' ?

What does the -u mean ?

How does this look on GitHub ?  (Notice the readme)

What is the connection between a local name of repo, and the name of the remote ?

#### Find out

How can you remove the remote?


### Method 2

Create a new repo on github, initialize it with a readme.md file, and clone this down.

Run

```
git remote -v
```

How does it look compared to Method 1?


### Note

All repos you create should always have the following files

*  readme.md
*  .gitignore

These should be added before you add anything else.

Make a habit of creating these as your initial commit.

### Tip

If you want to know the size of a github repo, install [this Chrome Extension](https://chrome.google.com/webstore/detail/github-repository-size/apnjnioapinblneaedefcnopcjepgkci/related?ref=producthunt)

### Further reading

https://git-scm.com/book/en/v2/Git-Internals-Git-Objects


