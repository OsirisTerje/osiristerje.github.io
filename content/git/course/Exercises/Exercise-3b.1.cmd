echo C0 > C0.md
git add C0.md
git commit -m"C0"
echo C1 > C1.md
git add C1.md
git commit -m"C1"
git tag YouStartedHere
git switch -c Experiments
echo C3 > C3.md
git add C3.md
git commit -m"C3"
git switch master
echo C2 > C2.md
git add C2.md
git commit -m"C2"
git tag SomeOneAddedThis
git switch Experiments
git tag YourExperiment
