git switch Experiments
echo C10 > C10.md
echo C11 > C11.md
echo C12 > C12.md
git add *.md
git commit -m"C10-12"
echo C13 > C13.md
git add *.md
git commit -m"C13"
git switch master

