Exercise 7.2:  Forms of cloning

Create a new empty repo on github, call it ex72

Go to a non-git folder

```
git clone https://github.com/OsirisTerje/exercise23 exercise23-full
git remote remove origin
git remote add origin <your-url>
```

Then do a shallow clone

```
git clone --depth 1 https://github.com/<your account>/<your repo> exercise23-shallow
```

Check them out and compare them with GitViz




Now try a shallow clone on the 1GB repo from exercise 1.2,  https://github.com/openshift/origin 

Notice the time it takes.  

Check it out with git-sizer 


Go back to the exercise23-shallow

Add another commit to it, and push that up

Notice the GitViz

Notice timing.

Pull the change down to the full repo

Verify it works, and compare with the shallow one

Q:  What is the "grafted" pointer ?


### Extra

Try to make a shallow clone with a history of 3




