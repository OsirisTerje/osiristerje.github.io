# Exercise 6.1 :  Configurations

## Checking your configuration

Drop down to any git repository

List your complete configuration by

```
git config -l
```
You possibly got quite a long list, remember it has three levels, so you can filter it by that:

```
git config --system -l
```

```
git config --global -l
```

```
git config --local -l
```

## Some configs to be aware of

### Check that you have set the editor for git

Verify that the editor is being called, by doing :

```cmd
git config --global --edit
```

Is the expected editor opened?

Create a new repo (using git init), or use an existing scrap one.

Then do:

```cmd
echo abc > abc.md
git add abc.md
git commit -e
```

What lines are not included ?

What happens if you just close the editor window with nothing added ?

### Check that you're using the credential manager

```
git config credential.helper
```

The response should be 

```
manager
```

### Check that you're ignoring case and have autocrlf on

```
git config core.ignorecase
```

The response should be 'true'

Likewise, check that core.autocrlf is true

#### Tip and trap

Can be wise to check that you have core.longpaths true too.

If not, you can set it by:

```
git config core.longpaths true
```

But...  where was it really written ?

How do you check where it was written?

Now, write it into the global location!

#### Tip 2  Removing a wrongly set config key

Assume you set this in the wrong place, you get rid of that key by:

```
git config --system --unset core.longpaths
```

### Set up access to unix tools

Check if you have 'grep' installed:

```
where grep
```

If not, then run :

```
where git
```

You will get a response that says something like

```
C:\Program Files\Git\cmd\git.exe
```

Pick out the path above the cmd, add **usr/bin** to that, and add the complete path to your environment PATH.

(You can check in explorer that you have a valid path)
On my machine it was:

```
C:\Program Files\Git\usr\bin
```

Verify again that you have 'grep' working.


### Set up merge and diff tools

You need good 3-way merge tools to handle merging.  The built-in is doable, but it is easier to use  more full blown tool.

Visual Studio is a good tool, but also tools like KDiff3.

If you have Visual Studio, setting it up is as easy as using the Visual Studio Git Settings page.  

#### For Visual Studio users

Go to the Git Settings hub, select the Global settings, and enable the diff tool and merge tool for VS.

Go back to the command line:

Run
```
git config -l | grep merge
```

Go to [DiffMergeTools](https://github.com/OsirisTerje/osiristerje.github.io/blob/master/Git/Course/DeepDives/Section6/DiffMergeTools.md) for further instructions on setting this up for different scenarios.  Pick the one that suits you!

