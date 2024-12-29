git init
echo >> c1.md
git add *
git commit -m"c1"
pause
git switch -c fix
pause
echo >> c2.md
git add *
git commit -m"c2"
pause
git switch -c fixmore
pause
echo >> c3.md
git add *
git commit -m"c3"
pause
git switch master
pause
git switch -c dev1
pause
echo >> c4.md
git add *
git commit -m"c4"
pause
git switch master
echo >> c5.md
git add *
git commit -m"c5"
pause
git switch dev1
git branch dev2
pause
git rebase master
git switch master
git merge dev1
pause
git merge fixmore


