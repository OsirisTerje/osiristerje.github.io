---
layout: post
date: 2020-09-20
url: "/git/course/"
---

# Removing history from a git repo

If your repository contains files you want to remove, such as files accidentally committed before setting up a proper .gitignore, sensitive information, or unnecessary clutter, you can clean it up effectively.

Even if you've deleted these files from your branch, they remain in the repository's history. The following commands will help you completely remove them from all history.

Keep in mind that after pushing these changes to your remote repository, anyone else using the repo will need to delete their existing clones and perform a fresh clone to access the cleaned version.

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




