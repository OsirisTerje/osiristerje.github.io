---
layout: page
---

# Example of a branching/merging/rebasing story

## Developer 1

First change something on the remote branch 'update' twice
```
git pull
```
![1](bms-1.jpg)

Change something on remote branch master and pull again

![2](bms-2.jpg)

Now merge doing a rebase and fast-forward merge on server, and the a pull again

![3](bms-3.jpg)

Another developer (Dev 2) already had a clone of the repo - before the rebase/merge done, and he creates a local branch from origin/update, then add a change there.

![4](bms-4.jpg)

He then tries to push her change up to the server, and is 'rewarded' by this:

![5](bms-5.jpg)

So the server is proteced from the changes, and the developer does not have any force rights, so all he can do is to follow the suggestion and do a pull.

![6](bms-6.jpg)

Observe what happened!  

The 5e0d8ee is rebased into 6dbe74f.  

Let's check the reflog

![7](bms-7.jpg)

Lot's of garbage there now.  Dangling objects.  So, let us get rid of that:

![8](bms-8.jpg)

Looks better now!

![9](bms-9.jpg)

Now he can push the update branch.

![10](bms-10.jpg)

Let us update the local master by merging with origin/master

![11](bms-11.jpg)

And then we do a pull request with a merge commit on the server, and pull that down

![12](bms-12.jpg)
