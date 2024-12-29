# Cleaning up, take 1, Getting the history linear



## Rebasing with origin

Clone down [this repo](https://github.com/OsirisTerje/exercise43)

Open up Gitviz and Fork (or whatever tool you use)

Ensure you are on master

You can see one commit in master and one in Whatever, children of the original starting commit.  The branches have diverged.

* Merge in the branch Whatever

As you can see, you now have a new merge commit.  We want to get rid of this and get a **linear history**.

We can do that doing a rebase on origin/master, which points to the previous commit from the remote repo.

```
git rebase origin/master
```

Notice you now have a new commit for master, the merged commit is left dangling, so it will be garbage collected later some time.

If you look at the comment for this commit, and the last one on the Whatever branch, you see they are the same.

#### Note

We did a rebase with origin/master in this case.  You can actually rebase on anything that might solve your problem with a non-linear history.




