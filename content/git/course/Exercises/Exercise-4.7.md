# Ex 4.7 Cleaning up - Take 7  :  So you pushed....

If you have pushed you can't [should not] rewrite local history any more.
If you then see one of your commits are wrong, you can revert it.


## **DO 1**

Use the repo from 4.6.  We will assume it is a repo that has a remote.

(Keep GitViz up!)

Run the following commands:

```
echo C4 > c4mismatch.md
git add *
git commit -m"c4"
```

If this was local only we could have got rid of this using git reset, but since it is pushed, we can't. That would rewrite history.

You now have 4 files in the workspace, and all are committed.

Now run:

```
git revert HEAD --no-edit
```

What happens if you don't use --no-edit ?


## **DO 2 - (Perhaps Extra) **

Set up a real remote for the repo

Now repeat adding the C4 as above

Push the repo to the remote

The we see we want to amend the message, so we run the commit amend command:

```
git commit --amend -m"It should have been just C2" 
```

Now look at how this is in GitViz.

And then we push it.

Didn't work ?  

Ok, follow the advice then....

And then we got a not so nice history.....

How does this look?





