# Cleaning up - Take 5  :  Getting rid of your own inadvertant mess

So you messed up - better clean it up :-)


## **DO 1**

Use the same repo as in 4.5, recreate the same again by running the 'Exercise-4.5cmd'

Look in the folder, and you will see three nice markdown files.

Now run

```
Exercise-4.6.1.cmd
```


Then check the status, and if you like, the content of the files.

```
git status
```

Now, this was bad, and we just want to forget about the whole thing:

Easy:

```
git restore .
```

Run git status again, and also do a 'dir', and you should be fine again

There is another similar way:

Repeat the command file, veriofy the mess is present, but now run:

```
git reset --hard
```

And again, verify all is fine.


## **DO 2**

Now run 

```
Exercise-4.6.2.cmd
```

And when you see the mess using git status, you decide to use 

```
git restore .
```

Except, when checking with git status, you're not quite there:

'git restore .' fixes everything that is in the index, but not untracked files.  And, the rename that happened, ended up with an untracked file, inadvertantly.  

There is also another untracked new file there.

For this single case, you could just delete them, and be fine.  But, if this was multiple files, and way deep down in your folder hierarchy it would not be that fun.

Re-run the Exercise-4.6.2.cmd 

Then try the command below to fix the mess:

```
git clean -xdf
```

Look the command up, and note the purpose of the options 

Verify it fixes the untracked files.

** NOTE **

When you have both modified files (in the index) and untracked, you need to use both commands.

Verify this using both Exercise-4.6.1.cmd and Exercise-4.6.2.cmd at the same time to create the mess.




