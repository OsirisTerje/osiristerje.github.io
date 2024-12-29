# Demo 2.5 


## 1
```
git init
echo c1 > c1.md
git add *
git commit -m"c1"
```

## 2
```
git switch -c work
```

## 3
```
echo cc >> c1.md
git add *
git commit -m"c1"

```

## 4
```
git switch master
git merge work
git switch work

```

Go back to 3

Alternative:

Do #3 5 times,  then do #4

