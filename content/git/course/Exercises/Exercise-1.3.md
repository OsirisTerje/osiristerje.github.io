# Exercise 1.3

## Git states


Init a new repo

Create two new files

```
echo C1 >> c1.md
echo C2 >> c2.md
git status 
git status -s
```

The *git status* gives a detailed status, while *git status -s* gives a short notation, with letters in the two first columns stating the states.  The first column is the Stageing area status, the second column is the workspace status

The following symbols are used:

|Symbol|Placement|Meaning|
|---|---|---|
|??||Untracked files|
|A|Col 1|New file added|
|M|Col 2|Modified in workspace|
|M|Col 1|Modified and staged|
|MM||Modified, staged and modified again in workspace|

Commit the file, check the status

Modify the file, and check status

Now, remove the file:

### Method 1

```
del c1.md
```

What is the status?

### Method 2

```
git rm c2.md
```

What is the status now?

What is the benefit of the latter?

## A second look at git storage

Use the same repo as above

Run git sizer

Note the numbers given

Then add another file, add and commit it.

Note the numbers now, and which incremented.

Copy the file , add it and commit again.

Note the numbers now, and which changed and not.

What is the conclusion from this?

## More git status

Create a new repo, get some code in there, and run it

```
git init testrepo  && cd testrepo
```

Add a .gitignore file (from [gitignore.io]())

```
git add * && git commit -m"gitignore"
dotnet new nunit
dotnet build
```

Now run
```
git status --ignore
```

Notice what you see ?

