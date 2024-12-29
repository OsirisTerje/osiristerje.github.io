# Exercise 2.4 - Other branch types, or temporary branches

## Simple stashing

You can reuse one of the former repos, or just create a new repo, add a first commit like:

```
echo C1 > C1.md
git add *
git commit -m"C1"
```

Stay on master

```
echo stuff > stuff.md
echo otherstuff >> C1.md
```

*"Boss comes screaming into the room, demanding you do a hotfix right away"*

Now stash your work, no time for finding out if you can add it to your branch or not, just get rid of this, so that you can switch branches.

Run git status and see first, keep a watch on GitViz too.

Then

```
git stash
```

What happened ?

What did **not** happen ?

Since you have untracked files, you need to state that explicitly.  Stash with no options doesn't stash untracked files. 

```
git stash -u
```

Notice how this looks in GitViz

And also take a look how it is in your graphical tool.  (Fork is particularly interesting....)

What changed between your first and second stash ?

How does your workspace look like now?

## Stash is a stack

Run
```
git stash list
```

You should now see that you have two stashes there.  To get things out again, you do one of 3 things:

* Just apply the latest stash.
* Retrieve the latest stash, at the same time remove it from the stach stack
* Retrieve a given stash, by number

First

Run
```
git stash apply
```

You got back an untracked file, and nothing else changed.

Now delete the file ....

As you still have the stash in the stack, you can retrieve it again.

This time use

Run
```
git stash pop
```

Notice the change in GitViz


## Inspect a stash

Do 

```
echo C1234 >> c1.md
git stash
```

No you can see what this stash is about by:

```
git stash show
```

This gives  list of the changes,  for more details:

```
git stash show -p
```

## Use different branches

### **DO 2**

Create a  new branch , name it 'ex'
Now, stage and commit the changes you have in now

You now remember that you  forgot the next stash.  But no problem, you can pop into any branch.

```
git stash pop
```

Did that work as expected ?

How does it look in GitViz?

Now run the commands below:

```
echo C12 >> c1.md
git stash
```

Now, let us assume you want to work on this change (stash), but in a branch for itself.

```
git stash branch st1
```

What happened ?

Ensure the changes are committed.


### **DO 2**

Now go back to master

```
echo C12 >> c1.md
git stash
```

Go back to the ex branch

```
git stash branch st2
```

Now what happened this time?


### **DO 3**


Do 

```
echo C12 >> c1.md
git stash
echo C13 >> c1.md
git stash
echo C14 >> c1.md
git stash
```

Use git stash list to see the 3 stashes you have.

Now, let us assume you want to work on all of these changes, but in a branch for each one.

List out the stashes.  You decide to start with the middle one.

To get that one out of the list, run:

```
git stash branch s1 stash@{1}
```

This way of referring to a particular stash can also be used when pop'ing, or apply'ing:

```
git stash pop stash@{2}
```


## Cleaning up

When you see you don't need the stashes anymore, or a particular stash, you can drop or clear them out

Do 

```
echo C12 >> c1.md
git stash
echo C13 >> c1.md
git stash
echo C14 >> c1.md
git stash
git stash list
```

Now, you can drop one of these:

```
git stash drop stash@{2}
git stash list
```

Check GitViz !

Or you can get rid of them all:

```
git stash clear
git stash list
```





