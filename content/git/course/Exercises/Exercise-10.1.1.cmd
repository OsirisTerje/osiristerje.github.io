echo C0 > C0.md
git add C0.md
git commit -m"C0"
echo C1 > C1.md
git add C1.md
git commit -m"C1"
git switch -c Experiments
echo C3 > C3.md
git add C3.md
git commit -m"C3"
git switch master
echo C2 > C2.md
git add C2.md
git commit -m"C2"
git switch Experiments
echo C4 > C4.md
git add C4.md
git commit -m"C4"
echo C5 > C5.md
git add C5.md
git commit -m"C5"
echo C6 > C6.md
git add C6.md
git commit -m"C6"