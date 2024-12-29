# Understanding branching

## Simple branching


### **DO 1**  

Create a new repo

Point Gitviz to it




```
echo C1 >> c1.md
git add *
git commit -m "C1"
```

GitViz:  What is the name of the branch that now just appeared?

Did you explicitly name that branch?

Run git-sizer and note the values:

Now, create a new branch:

```
git switch -c experiment
```
Run git-sizer again

What changed there?

Notice HEAD!  

------

### Note:  What  is HEAD

**HEAD is a special kind of pointer, indicating WHERE YOU ARE with respect to your workspace**

Head points to WHERE you are, by pointing to the commit that is the latest you pull'ed down to your workspace.

You can use HEAD to work down (to the parents) of your current commit.

-------


### **DO 2**  

Run

```
echo C2 >> c2.md
git add *
git commit -m "C2"
echo C3 >> c3.md
git add *
git commit -m "C3"
```

Notice what happened in GitViz with the branch and the head

Go back to master

Either
```
git switch -
```
or
```
git switch master
```

What does the first one mean?

Check your workspace.  What happened ?

```
echo C4 >> c4.md
git add *
git commit -m "C4"
```

Now, your GitViz should show that the two branches have **diverged**.  They have one or more commits each after the common point (C1) where they separated.

We now merge these two together:

```
git merge experiment
```

This automatically created a new merge commit.

What does it contain ?

(Use your graphical tool to look into this commit)


### **DO 3**  Adding a tag

Let us assume you want the release the code at this stage

You can add a release branch here, but it is better to use a tag

```
git tag V1.1
```

Now add another commit:

```
echo C5 >> c5.md
git add *
git commit -m "C5"
```

Now check in GitViz how the branch and tag behaved.

Explain why tags are a good way of marking releases.



-------
#### Extra: Tip or trap

See https://stackoverflow.com/questions/8762601/how-do-i-rename-my-git-master-branch-to-release 

Is this a good idea?

-------

## Analyzing an unknown repository

Unzip the NUnit3TestAdapter.zip into a local folder.  

This repository is a copy of a local repository, and contains both local and remote branches.

### **DO 1**  Branches overview

How many local branches do you see that are not tracked?

How many tracked branches do you see?

How many remote branches that are not tracked do your see?

Write down the procedure for finding these easily.  (Command line only)

### **DO 2** Tags

Locate the tags

What is the similarities between a tag and a branch?
What is the difference between a tag and a branch?

### **DO 3**  Stray cats

Using GitViz:  

1) Can you explain what the dimmed commits are?


----

## **DO 4**  Working in a new repository

Unzip the the archieve Exercise2.1.

Ensure it doesn't have any remote connected.  How do you do that?

View the repo in GitViz

### **DO 5**  Adding branches

Ensure you are on master

Create a set of new branches "Task1", "Task-1","Task_1", "Task 1", "task1"

How many worked ?


Switch to task1  (note: lower case only)
What do you see, and what happened ?

Switch to Task1

Add and commit a file "3.md"
git s
What happened with the   a) branch pointers  b) tag

### **DO 6** Working with tags

Add a tag to Task1, name it e.g. alpha-task-1
Add another tag , name it whatever

Go to the tag "HereIAm"

What was the respone from the command to go there ?
What does it mean?

Add/Commit a new file  

```
echo >> detached.md
git add *
git commit -m"Added detached.md"
```

How does the graph look now ?

If we now go back to task1 branch, what is the response from the git command, and how does the new commit like that?

Now, if you want to keep that commit, how do we go about that?

#### **DO 7** Fixing dangling objects

You can checkout/switch to any commit, based on their SHA.

So, see the SHA of the commit you want to keep, in my case it is b844cf4 (the seven first shown is normally enough).  Then create a branch at that commit.

```
git switch --detach b844cf4
git branch keepthis
git switch keepthis

or for the last two:

git switch -b keepthis

```

There is another command , checkout.   Explain the difference between checkout and switch.

### **DO 8** Overview of your tags

List the tags you have:

```
git tag

or

git tag --list <search params>
```

Run the following:

```
  git tag V1.0
  git tag V2.0
  git tag V3.0
  git tag V3.5
  git tag Issue42
  git tag Issue54
```

Now to only see issue tags:


```
    git tag -l "Issue*"
```

Note:  -l and --list is the same


You realize you don't need the tag named 'whatever', so delete it.

### **DO 9** Remote tags

Now connect this repo with a remote

```
    git switch master
    git push -u origin master
    git switch -c release1
    git tag V1.0
    git push -u origin release1
```    

Check the remote - is the tag there ?

In order to push the tags up to the remote, you need to explicitly push the tags

```
    git push origin V1.0
```

Now, go up to the remote site, and create a new tag there.

Then pull the branch down.

You should now see that the tag is in your repo too.


### Annotated Tags with messages

"*A tag is a pointer, an annotated tag is an object.*"

