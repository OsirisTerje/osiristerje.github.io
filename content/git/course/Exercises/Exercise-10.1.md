# Exercise 10.1


## Cherrypicking

### **DO 1**

Create a new repo

Run Exercise-10.1.1.cmd

Look in Gitviz, and Graph tool

Find the commit SHA for the one containg C4

We want this over to the master branch, and we dont want the C3 nor the C5 there, so we will cherrypick the C4

Ensure you are on master

```
git cherry-pick <YourSHA>
```

Verify that these are the files now present in the workspace, and that the status is unmodified on all

### **DO 2**

Now run Exercise-10.1.2.cmd

See in your graph tool, and find the SHA of the commit containing the files C10-C12

Now, we want **only** the file C11 from that commit


```
git cherry-pick <YourSHA> --no-commit 

or

git cherry-pick <YourSHA> -n 
```

What happened ?

------

So you now need to work on these files.

What are the states of the files?   Are they staged ?

You need to unstage the files you don't want to commit.

Alt. 1
```
git restore --staged C10.md C12.md
```


Alt. 2
```
git reset HEAD C10.md
git reset HEAD C12.md
```

Then clean out the workspace for any untracked files (those you just unstaged)

```
git clean -f
```

Then commit the staged file, the ones you wanted to keep.

```
git commit -m"cherrypicked C11.md"
```

## Comments on cherrypicking

If you cherrypick a commit that has the same file as the target branch, you may get a merge conflict.  You have to resolve that before proceeding.
(This was what I missed during the last hectic demo.  If I only had done 'code a.md' at that point I could have resolved the conflict and proceeded.)

The first issue I got however, said :
```
d:\repos\gitcourse\whatever>git cherry-pick f9fd --no-commit
error: commit f9fd8fd5e56f662b497dbcc75185ebc21dddcaee is a merge but no -m option was given.
fatal: cherry-pick failed
```
That was because the f9fd actually **WAS** a merge commit (just as the error message said...). That means it has TWO parents, and the cherry-picking algorithm could not figure out which parent to choose for its diff work.   The -m option tells which parent to use, like ``` -m 1``` selects the first parent. 

See [image in comment here](https://github.com/sebgroup/Git_Course/issues/8#issuecomment-635407691)

To figure out which parent number matches which commit you do a :

```
d:\repos\gitcourse\whatever>git show f9fd
commit f9fd8fd5e56f662b497dbcc75185ebc21dddcaee
Merge: ce28970 168a2fb
Author: Terje Sandstr<C3><B8>m <terje@hermit.no>
Date:   Tue Mar 10 18:31:23 2020 +0100

```
In the 3rd line you see the two parent commits.  They are numbered from left as 1 and upwards.

A last advice on this:  Cherry-picking is picking apart commits and trees. Use it only when you must, and never as a daily practice.  Ordinary merges and rebases are better
choices. 

