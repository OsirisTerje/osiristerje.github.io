---
layout: post
date: 2020-09-20

---



# Git Config

## Git Configurations

There are 3 common levels for the git configurations, and two more that are not so common and very rarely used.

The best way to find them, is to use the editor, and run commands like e.g. `git config --edit --global` to open the global config file in the editor. The same for the other configurations.  The editor will open the file in the correct location.

Locations below are for Windows.  For Linux, the locations are different, but you find them the same way.

Notice that the names of the config files differs for the different levels.

|Configuration|Location|Command|Comment|
|---|---|---|---|
|System|E.g. `C:\Program Files\Git\etc\gitconfig`|`git config --system --edit`|Applies to all users on the system and all their repos. Will be created and written when git is installed with the options you chose at that time. It is rarely modified afterwards, but if you work with multiple users on your machine, it can replace the use of the global.|
|Global|E.g. `%userprofile%\.gitconfig`|`git config --global --edit`|Applies to all repos for the current user. Created at first pull/push. Very commonly used.|
|Local|`.git/config` in the repo|`git config --edit`|Applies to the current repo only. Created when you first edit it. Used when you need to override something in a particular repo.|

There are also two more, but they are very rarely used.
|Configuration|Location|Command|Comment|
|---|---|---|---|
|Worktree|`.git/config.worktree` in the repo|`git config --edit --worktree`|Applies to the current repo only. Created when you first edit it. Very rarely used.|
|File based|`C:\ProgramData\Git\config`|`git config --edit --file "C:\ProgramData\Git\config"`|Applies to all repos for the current user. Very rarely used.|

The `worktree` configuration is used when you have multiple worktrees for the same repo. It require the `extensions.worktreeConfig` to be present in the local configuration. It is not used very often.

## Precendence and how to figure out why your config doesn't work

The configurations are read in the order above, and the last one read will override the previous ones.

This may cause you to wonder why your config doesn't work after you have changed it.  You will always write to a specific level, and if that particular setting have an override in a higher level, then your change will have no effect.  

The best way to figure it out, is to run `git config --show-origin <your config value>` to see where it is read from. The format should be like `section.name`.  If you don't know the section, you can use `git config --list --show-origin` to see all the settings and where they are read from.

If you just want to see the actual value of a given config value, you can use `git config <your config value>`.

Example:

```cmd
git config --show-origin user.name 
```

will give you something like:

```cmd
file:C:/Users/TerjeSandstrom/.gitconfig Terje Sandstrom
```

Using the table above, you see that this file is the global config file for user Terje Sandstrom.

## Exercises and more detailed information

[Exercise 6.1](https://github.com/OsirisTerje/osiristerje.github.io/blob/master/Git/Course/Exercises/Exercise-6.1.md)

[Exercise 6.2](https://github.com/OsirisTerje/osiristerje.github.io/blob/master/Git/Course/Exercises/Exercise-6.2.md)

[Setting up diff and merge tools](https://github.com/OsirisTerje/osiristerje.github.io/blob/master/Git/Course/DeepDives/Section6/DiffMergeTools.md)



## Other Links

[Official Git Config reference documentation](https://git-scm.com/docs/git-config)

[Official Git tutorial book](https://git-scm.com/book/en/v2/Customizing-Git-Git-Configuration)

**Tip**:  You can get help locally by running `git config --help`.  
(P.S. This way of getting help applies to all git commands.)