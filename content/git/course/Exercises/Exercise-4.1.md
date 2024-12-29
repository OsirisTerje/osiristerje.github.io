# Clean up - fixing just noise


## Remote branches

### **DO 1**   Remove local copies of remote deleted branches

Create a new repo Exercise41, locally and on the server, add a commit to it, and push it to the server.

Then create branches  a,b,c and d.

Push each of these branches to the server

Run 
```
git branch -l  --no-color
```

Then go to the server, and delete the branch b

Locally, go back to master, 

Fetch the remote repo:
```
git fetch
```
and run the branch list command again

Is the remote branch 'b' still present?  

Now run :
```
git fetch --prune
```

Is the remote branch 'b' still present? 

Is it a good idea to let the local repo "know" about a remote branch that is no longer there?

Can we make this setting the default, and why?


### **DO 2**  Prune branches

Run the following command

```
git config --global fetch.prune true
```

Go to server and delete branch 'c'

Check the branch list, and verify that the tracking branch for 'c' is still present.

Ensure you're on master

```
git pull
```

You should get a message that the tracking branch 'c' was deleted-

Verify using the branch list

Why does git pull remove the tracking branch?

### **DO 3**  Cleaning up dangling and orphan objects

Git will regularly clean up such objects, e.g. doing a garbage collection.  However, you may want to clean it up yourself.

Use Gitviz to find one of your repos that have dangling or orphaned objects. These objects are showed as dimmed objects in Gitviz. They are not visible in any of the other UI tools. 

You can list them though, doing:

```
git fsck

or

git fsck --unreachable
```

There are two steps to this process, one is to get rid of all refs that points to the objects, then to get rid of the objects themselves.



```
git reflog expire --expire-unreachable=now --all
git gc --prune=now
```

Rerun the checks above, and also check Gitviz

**Trap 1**

If you have remote branches that have not been pruned, and they point to commits, they will be **ref'ed** and then not be regarded as dangling.  So prune your remotes first.

**Trap 2**

Tags are easy to forget.
If you have any tags that references the commits, then they will not be regarded as dangling.  Remove the tags first.















