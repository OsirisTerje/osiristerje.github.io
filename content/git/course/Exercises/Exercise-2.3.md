# Branching conventions

If you choose to have a complex branching structure, you can create some order into these.

Reuse on of your earlier repos,  e.g. Exercise 2.1 repo

Assume you have multiple teams with many developers working on this, and you need to create a bunch of release branches, bunch of task branches, and you have a lots of bugs that needs to be handled, so you want to keep them as seperate branches too.

This will create a a mess, and you need to get some structure into this.

All the developers are using modern GUI tools like VS or  VSC.

Create the following sets of branches:

Release branches

* releases/release1.1
* releases/release1.2
* releases/release2.0
* releases/hotfixes/hotfix1.1.1
* releases/hotfixes/hotfix1.1.1
* tasks/issue450
* tasks/issue450
* tasks/issue450
* bugs/issue16
* bugs/issue24
* bugs/issue42

### VSC

Open up VSC, and go to Gitlens, and under Repositories you will see your branches.
Notice how they are displayed.

### Fork

See under Branches

### Visual Studio

Team Explorer, see under Branches

What has happened with the display of the branches?

### Github

Now push this to a remote repository on Github.

Push **all** the branches at the same time!   How do you do that?

Does Github honor the branch convention?

## Good branch naming conventions

* Use only english characters
* You can use dashes and dots
* Commas are allowed, but hey, does it look weird.....
* Casing:  Remember the learning from the 2.1 exercise
