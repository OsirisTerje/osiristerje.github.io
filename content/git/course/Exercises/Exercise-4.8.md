# Exercise 4.8  Your history is crap

You get a suspicion that the history of the repo you have contains unwanted stuff.  It may be because the repo is too big, or  because you say a reference to a bianry file when running git-sizer, or something gets in the way.

## **DO 1** Prepare

Grab the archive binthing.zip

Unzip it into a new folder.  This a repo.

You check the folder that it doesn't contain any suspicious files.

Check the repo that it has a .gitignore file, and that it is recent.

Running

```
dotnet test
```

you verify this is a working program.

Clean the repo again for all temporary files

```
git clean -xdf
```

Run git-sizer -v to see what it says.

Do you notice the dll ?

Does it show in the repo after the clean ?

So, where is this dll?


Create a repo for it on GitHub, and connect your local repo and push everything up.

Verify that you got everything up on Github. 

## **DO 2** Check the repo

You need to find out if the repo contains any history of dll's.

```
git log --all   "**/*.dll"
```

You will be shown a list of all commits that contains dll's.  

For more details:

```
git log --all --full-history  "**/*.dll"
```

#### Tip

If you don't want the paging

```
git --no-pager log --all --full-history  "**/*.dll"
```

Pretty obvious there is a lot of dll's here, so let us clean them out

## **DO 3** Cleaning a repo

We're going to start using a built-in tool called filter-branch.  

So to clean out the repo for dll's do the following:

```
git filter-branch --force --index-filter  "git rm --cached  --ignore-unmatch *.dll"
```

Make sure you take a look at how this looks in GitViz.

Does it look like you expected ?

Run git-sizer -v again, and see if the dll is gone.

Not ?

The reason is that you have a connection to a remote, and the remote tracking branch is hanging on to the old commits.  You have got a new tree with the "cleaned" commits, but that is not enough.

So, remove the remote!!

You still need to clean again, so run the exact same filter-branch command again.

And then check GitViz and git-sizer again.

And run the log command again.

Ok, so, now everything is good, right?

## **DO 4** Cleaning a repo, the much better way

Looking at the git-sizer info, you still see suspicious files there.  And, looking more closely you might see that it is under the obj folder. So, what has happend is that the obj and bin folders have been included in some commits.  

You also remember there was some warning about filter-branch when you ran that the last time, so you decide to go for filter-repo instead.

filter-repo is a tool outside the git projects, but strongly recommended by them, and suggested as a replacement for filter-branch, which is very hard to get right.

You can install filter-repo either using [Scoop](https://scoop.sh/), or you can use Pip if you have Python installed (you should!).  For other alternatives, [read here](https://github.com/newren/git-filter-repo/blob/master/INSTALL.md).

The [manual](https://htmlpreview.github.io/?https://github.com/newren/git-filter-repo/blob/docs/html/git-filter-repo.html) for git-filter-repo is very useful, some good examples can be found [here](https://github.com/newren/git-filter-repo#simple-example-with-comparisons)


Now start by analyzing the repo

```
git filter-repo --analyze
```

The go to the folder (using e.g. code) 

```
code .git/filter-repo/analysis
```

You see all the folders, all the files, extensions etc, and it is easy to understand what needs to be deleted. 

```
git filter-repo --path "obj" --path "bin" --invert-paths
```

Notice the speed!

Run analyze again (you might need to close Code first).  

All gone!


## **DO 5** Handling the remote

Now, I want this cleaned repo up on the remote.

So I reconnect with the remote doing a 
```
git remote add origin <myurl>
```

Then I need to do the real connect, so.... a fetch ??  Or just try to push?   A fetch may bring back the old commits from the remote... so, I'll go for the push

```
git push -u origin master
```

Try this - it will not work....

You need to force it up....  and then... look around, anyone else on that repo?  Have you warned them that you're now going to kill all their work?  Because that is what will happen.

```
git push -u origin master --force
```





