# Demo 2.5

## 1

```cmd
git init
echo c1 > c1.md
git add *
git commit -m"c1"
```

## 2

```cmd
git switch -c work
```

## 3

```cmd
echo cc >> c1.md
git add *
git commit -m"c1"

```

## 4

```cmd
git switch master
git merge work
git switch work

```

Go back to 3

Alternative:

Do #3 5 times,  then do #4
