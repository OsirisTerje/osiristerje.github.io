---
layout: page
---

# Short recipes for different types of branch creation and removal

## Set up local branches for all remote brances

```
git for-each-ref --format='%(refname:strip=3)' refs/remotes | grep -v master | xargs -L 1 git switch
```

## Delete all local branches, but not master

```
git for-each-ref --format='%(refname:strip=2)' refs/heads | grep -v master | xargs git branch -d
```

### Alternative: Delete only local branches that have been merged to master

```
git branch --merged master | grep -v master | xargs git branch -d
```

## Delete all remote tracking branches except master

```
git for-each-ref --format='%(refname:strip=2)' refs/remotes | grep -v master | xargs git branch -rD origin
```

## Delete all remote branches except master

```
git for-each-ref --format='%(refname:strip=2)' refs/remotes | grep -v master | xargs -L 1 git push -d origin 
```

## Delete a subset of local branches

Assume they are arsting with bugs

```
git for-each-ref --format='%(refname:strip=2)' refs/heads/bugs | grep -v master | xargs git branch -d
```

```
```

```
```

```
```

```
```