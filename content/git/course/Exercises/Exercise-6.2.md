# Exercise 6.2   Aliasing

Git support creating shortcuts for its commands, known as aliases.

Aliases are best put into the Global section, or even System section if you have multiple users on the same machine. 

## **DO 1**  Shortcuts

Open up the global section in your editor:

```
git config --global -e
```

Check that there is no `[alias]` section already

If not, add a new such section

Now, let us look at some possible nice shortcuts.  I prefer very short single letter or just a few letters abbreviations as my shortcuts.  YMMV, so find out first what suits yourself.

You use git status a lot, so I would like to just use git s as a shortcut for that.  This is a simple abbreviation.

Also, I often go to main, so I would like to shorten that one done, so instead of writing  git switch main,  I'll just write git m
I also often like to check all my branches, so bl for git branch --all sounds good.

```
[alias]
    s = !git status
    m = !git switch main
    bl = !git branch --all
```

Usage:

```
    git s
    git m
    git bl
```

## **DO 2**  Shortcuts with parameters

When at this, having to write all the stuff for creating a new branch and going to it....  It is called `switch`'ing, so lets make the shortcut  'sw' to mean ``go to a branch` and `swc` to mean `create a new branch and go to it`

```alias
    sw = !git switch
    swc = !git switch -c
```

Wait ....  now how do you use this ?

```
    git swc mybranch
```

You can add parameters to your shortcuts, they are just being expanded to the full command, so if you make them so that the parameters comes naturally, they will stay very simple.


## **DO 3**  Chained calls

One thing that also annoys me, is when I want to push a non-tracked branch to the remote.  In order to do that, I need to know the name of the branch I am on.  Then I can use that when pushing, and call that 'git pub' (short for publish)

```
   branchname = !git rev-parse --abbrev-ref HEAD
   pub = !git push -u origin $(git branchname)
```

Find one of the repos you have that is connected to your github account.

Create a new branch there, and test the 'git pub' alias

## **DO 4**  Removing dangling objects

Earlier we have seen how we can remove dangling objects.  We needed to call two git commands, with a set of arguments.  No way we can remember those.  So way better to make an alias for that. 

Since the word clean is taken, and this is for the repo, I'll go for rclean (repoclean).  Note, I could also make a command, and then a shortcut for that, having both.  What about repoclean as the command, and rc as the shortcut ?

```
   repoclean = !git reflog expire --expire-unreachable=now --all &&  git gc --prune=now
   rc = !git repoclean
```

## **DO 5**  Functional:  Going to the web

Another thing that is annoying, is to always look for the remote, fire up the browser, and going to that remote repo.  Too much work.  And, the repo already know the remote url, so...

Lets first find the url of the origin remote:
```
    url = !git config --get remote.origin.url 
```
Then we start our favourite browser, in this case Microsoft Edge, using the function syntax for git aliases:

```alias
    execurl = "!f() { exec start msedge \"$@\"; } ; f"
```

Note here that we also use the upcoming parameter.  We need now to have the parameter $@ inside our alias, not only tucked to the end.

And finally we combine the two above

```alias
    web = !git execurl $(git url)
```

Now running

```alias
    git web
```

brings up Microsoft Edge and takes it to the remote site. It takes us to the front page of the site.  If you want to go any particular sub-part of that, you need to extend the command above.

## **DO 5**  Functional: Gitignore

One thing that was pretty annoying when creating new repos, was all the single steps we needed to do. We can use the same technique as above to start fixing those too:

We got the gitignore file from https://gitignore.io , and we had to specify the name we needed it for, like VisualStudio.  
It turns out gitignore.io has an api just under there, which we can use.

This function call the gitignore.io api using curl, with the selected language as a parameter

```
    ignore =  "!f() { curl -L -s https://www.gitignore.io/api/$@ ;}; f"
```

We then add one specific for Visual Studio (or C#), and appends that to the .gitignore file !   We also add one for Python

```
    ignorevs = !git ignore visualstudio >> .gitignore
    ignorepy = !git ignore python >> .gitignore
```

We're using the appending pipe to ensure we never overwrite anything in the .gitignore, but always just appends to it.

Check these out on your repo, and see that it all works.  It is very easy to forget something in these aliases.

## More information (than you might need)

The aliasing system is a small shell system, and is very unix like.

We used only the simple form for parameters above

A function **f** is defined as **f(){ };**

Parameters can be used as positional parameters too, like ${1}.  They can also have default parameters, using the dash:  ${1-No Idea}

Variables can be defined inside the function:

```alias
!f() { msg = ${1}; echo $msg;}; f
```

Otherwise, see a [good source for more information on aliases](https://git.wiki.kernel.org/index.php/Aliases)

## Extra

Think about other things that are hard to do or annoying on the command line, and figure out how you can make an alias for them.