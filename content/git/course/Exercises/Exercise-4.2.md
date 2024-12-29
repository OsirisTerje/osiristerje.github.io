# Clean up  -  getting rid of stuff

## **DO 1** Cleaning out branches

A branch is just a pointer, so it doesn't take up any space [you need to be concerned about].  But, it may clutter your view of the repo, and be annoying.

Create a new empty folder.

Point Gitviz to that folder.

Run the batch file Exercise-4.2.cmd

Go through the steps.  Notice the pause steps.  Use GitViz to see what happens for each step

Set up a remote, and push the branches master and fixmore to that remote.

To delete a branch, the command is:

```
git branch -d/-D  branchname
```

-d is the safe option, it will prevent you from deleting a branch that mat not be ready for deletion (like it has not been merged or pushed), meaning it may leave dangling commits if deleted.

-D is a force delete, which will delete any branch regardless of state

We now know that fixmore is connected to a remote.

* Delete all the branches, one by one.  

Note that you can't delete the branch you're standing on.  You may try by checking out that branch and try to delete it.

When trying to delete the dev2 branch you'll get a warning.  Then try to force-delete it.

Now, Gitviz doesn't show any more branches, but run :

```
git branch --all
```

You will see you still have two remote branches left. Or, more correctly tracking branches.

Deleting a tracking branch is the same as unsetting the tracking for a local branch, if that exists.  If it doesn't, you just can delete the tracking branch

Now, delete the one for fixmore

```
git branch -d -r origin/fixmore
```

Use 
```
git branch --all
```
to see the change.

## **DO 2** Cleaning up your history - the branches

Now, we have two commit roads that are sort of annoying.  Is there something we can do to make these become one single line of commits?

If we look at them in the UI (e.g. Fork), we'll see that one branch contains c2 and c3 and the other c5 and c4. We can also see that we should not had merged the fixmore branch, but rebased it instead. 

There is multiple ways of doing this, one way could be:

Regret that you merged, and go one step back.  THat means we need to add a new branch name here.

If we just go back, we will be left with dangling commits, and hard to get back.  So, let us play safe and add some branch names to the two below.  WHy both?  Always hard to say which is which.....and better safe than sorry.

What you do is to notice the two SHAs and add branches to them:
(Note that your SHAs will differ from my below)

```
git branch first 6277a7d
git branch second 9c3f8d1
```

Why didn't we need to do anything with the merge commit?  It will be lost, and that is ok, why?  How do we know?

```
git reset --hard HEAD~1
```
Ok, now it is obvious which is in the master branch and which is in the other.  In my case, the branch named second, so I go there.

```
git switch second
```
and then rebase onto master, and forward merge master

```
git rebase master
git switch master
git merge second
```


## **DO 3**  Cleaning up your history - squashing

We know that rebasing can clean up history and make it more linear.  But, we also know that we sometimes have to do a lot of small commits in order to fix something.  And sometimes those commits doesn't do us much good in the end.  It would be nice to be able to redo them as one single commit.

We could go back to the start, undo all commits and then recommit them, but the easier way is to squash them.

Run the script Exercise-4.2.2.cmd

Now you got a bunch of commits.....

There are multiple ways to do this.  

Let us start with a simple one:

```
git switch master
git merge --squash wow
```

Notice your UI tree in gitviz didn't change.
So do a 
```
git status
```

See ?

Commit this one :-)

Happy ?

Well, I assume you added a commit message :-)

-----------

Ok, let us try another one, but first:

```
git reset --hard HEAD~1
```
Now we're back to square 1!


We will do the same, just slightly different:

```
git merge  --squash wow
git commit
```
Notice no message on the last one, but that means the editor comes up, prefilled with all your commit messages


You still have the commits there, and the branch you merged in as a seperate branch.  No problem getting rid of those, by just deleting that branch and let garbage collection fix the rest.

-------------

But there is yet another way:

```
git reset --hard HEAD~1
```

Now go back to the wow branch:

```
git reset --hard HEAD~6
git merge --squash HEAD@{1}
git commit
```

Now, the wow branch is still there, but all commits are nicely squashed into one, but with all the commit messages preserved. 

------------

Ok, there is even one more.......

### **DO 4** Interactive rebase....

This is a very powerful method, so in this case it is a bit overkill, since the other ones above will do the job nicely.

Go back to have a branch at the top of those 6.

Lets assume it is called whyrebasei

```
git branch whyrebasei 6b1e063
```

Now, run:

```
git rebase -i master
```

Now the editor opens up, just as with the commit messages, but instead of just closing it, now you must edit the file before closing

Replace "pick" on the second and all subsequent to "squash", and then close the file

Now, look at the commit message, it is even nicer than the others....

--------------

### Extra

Check out the other options for using Interactive rebase

Look up [this blogpost](https://hackernoon.com/beginners-guide-to-interactive-rebasing-346a3f9c3a6d) and [this documentation](https://git-scm.com/book/en/v2/Git-Tools-Rewriting-History)





