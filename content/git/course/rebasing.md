---
layout: post
url: "/git/course/"
---

# Rebasing

When you make a new commit, that commit is a child of the former commit in the same branch, its parent.

When you merge two branches, you move the branch pointer forward - and if there is a need for a merge commit, it will be added as a child of its two parents. 

**Rebasing is when you figure out that you don't like your parents, and decide to swap them out for someone else.**

The pointer from a commit to its parent is called the "base".  Rebasing switches that base pointer to another commit parent.

## Technical rebase

Git doesn't do exactly that. What is described above is the functional aspect of what a rebase is.

What it really does is to replay the commit(s) involved onto the the end of the other target parent.  


