---
layout: page
---

# Configurations for Diff and merge tools


## Possible diff/merge tools

Default is vimdiff.

Some alternatives that are understood by git

* KDiff3
* BeyondCompare

These have to be installed, and available in the path.  

Run
```
git mergetool --tool-help
```
to see a complete list of supported tools.

An alternative that must be fully configured:

* Visual Studio (vsdiffmerge)

An alternative that has built in support

* Visual Studio Code

See [information here.](https://code.visualstudio.com/docs/editor/versioncontrol#_merge-conflicts)

Note: Get to this by using the Source Control tool, select the file(s) shown under "Merge Changes".

But in order to fire it up from the command line, it has to be added to the global config too.



## Specific instructions for configuration

### Setting up KDiff3

See [instructions](https://docs.kde.org/trunk5/en/extragear-utils/kdiff3/git.html)

Copy the section shown into the global git config

### Setting up BeyondCompare

See [instructions here](https://www.scootersoftware.com/support.php?zz=kb_vcs), and go down to the Git for Windows section

Copy the section shown into the global git config

### Setting up vsdiffmerge (Visual Studio)

Add the following to the global git config file, just check the path to your installation of Visual Studio.

Find that path
```
where vsdiffmerge.exe >> vsd.txt
```
Copy the content of vsd.txt into the :your path to vsdiffmerge: below.

Note that you might need to escape the \, and possibly the " too.  
Also, Visual Studio may be very slow to open it, and I have often experienced it hangs too, depending on versions.

It is much easier to just start VS in that folder, it will then automatically pick up the merge conflict.

```
[diff]
  tool = vsdiffmerge
[merge]
   tool = vsdiffmerge

[difftool]
  prompt = false
[mergetool]
   prompt = false

[difftool "vsdiffmerge"]
  cmd = '"your path to vsdiffmerge"' "$LOCAL" "$REMOTE" //t
  keepBackup = false
  trustexitcode = true

[mergetool "vsdiffmerge"]
   cmd = '"your path to vsdiffmerge"' "$REMOTE" "$LOCAL" "$BASE" "$MERGED" //m
   keepBackup = false
   trustexitcode = true
```




### Setting up Visual Studio Code

Setting up just the  merge tool sections:

```
[merge]
        tool = vscode
[mergetool "vscode"]
        cmd = code --wait $MERGED
        keepBackup = false
        trustexitcode = true
```


## Running the tool

Looking at the section above for Visual Studio, the upper two configs sets the default diff/merge tool to use.  The rest sets how those tools are to be used.

We can then choose to run with a specific tool, or we can run with the default one.

Running with a default tool:

```
git mergetool
```

or choose a specific tool:

```
git mergetool --tool=vscode
```




