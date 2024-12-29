# Ex. 4.5  Cleaning up - Take 5  Amending


## Amending
Create a new local repo again 

Run Exercise-4.5.cmd

Now, look at the history using your grahical tool (Fork/SourceTree), or simply by using 

```
git log
```
Also, keep GitVIz pointed at this new repo.  It should show a rather nice image.

From the history view, you see that the commit message is not as you like it. 

You can change the message of the last commit by **amending** the commit.

Do:

```
git commit --amend -m"It should have been just C2"
```

Now, look at the history again (refresh view).  All is well.  Then look at GitViz and see what really happened.

Explain!

This is anyway the way you can fix commit messages.  Note it only works on the last commit. 

Run

```
git status
```

Notice there is a file that is untracked.  It should of course have been included.

We can amend the commit once more with this commit, and since we put so much effort into the message, we would like to not repeat that:

```
git add *.md
git commit --amend  --no-edit
```

### Extra 

Assume you would do all in one step, how would you do that?

## Git revert 

Run Exercise-3b.1.cmd again, or reuse the same repo where you installed that earlier

Go to branch Experiments


**Note down the SHA of the current HEAD**

Add/commit  a new file.

Revert the latest commit 

```
git revert HEAD
```

Then do a 

```
git diff HEAD <notedSHA>
```

Any difference?


Then revert a parent commit using the hash key (only 4 chars needed)

```
git revert <SHA>
```

As you can see, you can revert any of your ancestors.

Try to revert some commit that is NOT an ancestor.  It should not work. 






