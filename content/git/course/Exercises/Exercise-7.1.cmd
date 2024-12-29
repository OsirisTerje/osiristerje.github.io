git init repo7.1A
git init --bare 71Aserver
git init --bare 71Bserver
cd repo7.1A
echo C1 > c1.md
git add *
git commit -m"C1"
echo C2 > c2.md
git add *
git commit -m"C2"
echo C3 > c3.md
git add *
git commit -m"C3" 
git remote add origin ../71Aserver
git push -u origin master
cd ..
git clone 71Aserver repo7.1B
cd repo7.1B
git remote add second ../71Bserver
git switch -c masterb
echo C4 > c4.md
git add *
git commit -m"C4"
git push -u second masterb:master
cd ..
cd repo7.1A
echo C5 > c5.md
git add *
git commit -m"C5"
git push
git switch -c fix
git reset --hard HEAD~2
git push -u origin fix
echo C6 > c6.md
git add *
git commit -m"C6"
git push





