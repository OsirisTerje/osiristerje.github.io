---
layout: post
date: 2020-09-20
url: "/git/course/"
---

# Removing history from a git repo

When you have something in your repo that you want to get rid of.

This can happen if you commit before you had the proper .gitignore there, or you committed security info you should not have, or just got a lot of rubbish in there.  

Even if you have removed them from your branch, they will still exist in history, so these commands will remove the files from all history.

It also means, that once you have pushed this up to the cloud storage, then everyone else will have to do a new clone (and remove their old clones first) to get the new cleaned repo.

## Introducing `git-filter-repo`

[Manual](https://htmlpreview.github.io/?https://github.com/newren/git-filter-repo/blob/docs/html/git-filter-repo.html)

Requirement:  You need Python installed, or use it from a container.  But everyone have Python installed, right?

Also see [Andrew Locks post](https://andrewlock.net/rewriting-git-history-simply-with-git-filter-repo/)

### Installing `git-filter-repo`

```cmd
pip install --user git-filter-repo
```

## Using `git-filter-repo`

### Removing a file

```cmd
git filter-repo --path <file> --invert-paths
```

### Removing a folder with all content

```cmd
git filter-repo --path <folder> --invert-paths
```

Docs says you can use wildcards, but it doesn't seem to work if they are placed lower in the tree.

Example: `--path */bin/*` will not work, but `--path */bin` will.




