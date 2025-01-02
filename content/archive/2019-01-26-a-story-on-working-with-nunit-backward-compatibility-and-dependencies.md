---
id: 160583
title: A story on working with NUnit backward compatibility, and dependencies
date: 2019-01-26T20:18:27+01:00
author: terje
layout: post
guid: http://hermit.no/?p=160583
permalink: /a-story-on-working-with-nunit-backward-compatibility-and-dependencies/
catchevolution-sidebarlayout:
  - default
dsq_thread_id:
  - "7190695027"
categories:
  - Dependencies
  - Extensions
  - NuGet
  - NUnit
---
NUnit as a project has a tradition of keeping backwards compatibility.  It ensures that even if you stay on a earlier version of Visual Studio, .net FrameWork, or whatever it is, NUnit should continue to work even with upgrades of NUnit.  
So also for the NUnitAdapter.  It  should work on any version of Visual Studio after the 2012 version.  We have managed to maintain that.
However, over time it has become harder and harder to verify the compatibility. Microsoft has increased their release pace, and the number of versions and variations of Visual Studio has subsequently increased tremendously over the last years. We have not found an easy way to test all the possible variations, so have had to do a set of minimum tests, then respond quickly when someone raises an issue.  Fortunately, there have not been many of those.  We rely to a large degree on peer reviews using pull requests, which have weeded out most of these issues.

We could automate all the tests using a set of virtual machines and script up some test procedures to handle installs and process. Let us try to do it manually first.  What can possibly go wrong ?

<strong>Testing the extension</strong>

When we were working on the 3.13 release, I added a <a href="https://github.com/nunit/nunit3-vs-adapter/pull/591" rel="noopener" target="_blank">Pull Request</a> with some changes to ensure the VSIX version of the adapter would work with the upcoming Visual Studio 2019. <a href="https://github.com/rprouse" rel="noopener" target="_blank">Rob </a>noticed that we had something in there that might affect earlier versions (and also found some automated updates that was wrong, so much fun with those things).  I then accessed a machine with VS 2013 to check out the VSIX version there.  Should be a 3 minute job, right?

I just created a new Class Library project, standard .net framework 4.5, and added a nice little test class like this:

<a href="http://hermit.no/wp-content/uploads/2019/01/jan19-8.png"><img src="http://hermit.no/wp-content/uploads/2019/01/jan19-8.png" alt="" width="376" height="393" class="alignnone size-full wp-image-160592" /></a>

And then I used the Manage NuGet packages for Solution to get the NUnit package in, which I assumed should be a no-brainer, but was rewarded by this nice "Operation failed" message:

<a href="http://hermit.no/wp-content/uploads/2019/01/Jan19-2.png"><img src="http://hermit.no/wp-content/uploads/2019/01/Jan19-2.png" alt="" width="1002" height="554" class="alignnone size-full wp-image-160588" /></a>

Now what is this ????

Standard library ??  I don't have any of that in here ?

So something else must be going on.  What I always do when things go wrong like this, is to (except googling it) trying to use the console instead.  
Doing that gave me this:

<a href="http://hermit.no/wp-content/uploads/2019/01/Jan19-6.png"><img src="http://hermit.no/wp-content/uploads/2019/01/Jan19-6.png" alt="" width="1050" height="147" class="alignnone size-full wp-image-160590" /></a>

Well, obviously something is wrong with the Nuget version, now the question is WHICH Nuget are we talking about. There are multiple components involved, and version numbers are not always what they seem to be.  So let us check on the proper console :

<a href="http://hermit.no/wp-content/uploads/2019/01/Jan19-5.png"><img src="http://hermit.no/wp-content/uploads/2019/01/Jan19-5.png" alt="" width="566" height="82" class="alignnone size-full wp-image-160586" /></a>

This comes up with the proper NuGet version numbers. although a bit outdated too (current version today Jan 2019 is 4.9.2) - it should not cause this problem, so only possible thing for the above is that this must be the Visual Studio built-in NuGet manager extension. If we check for that, we find it has an update, and the version numbers match the error message.  
Back on safe ground!

But think a bit about this error.  I am writing a .net 4.5 project.  I am using a component, NUnit, which should work with .net 4.5.  I get an error message about .net Standard Library.  This sequence doesn't make sense in the context I am in. There is a hidden dependency to .net Standard Library inside these "things", that is not stated anywhere.  And, as I show below, to fix the error, there is nothing I need to do related to .net Standard Library.  This error message is misleading. 

Now, we check for the update:

<a href="http://hermit.no/wp-content/uploads/2019/01/jan19-7.png"><img src="http://hermit.no/wp-content/uploads/2019/01/jan19-7.png" alt="" width="925" height="301" class="alignnone size-full wp-image-160591" /></a>

After we do this update we can install the NUnit package as expected,  the tests ran as it should, so the VSIX adapter - which is what we started out testing here, works as it should on Visual Studio 2013 Update 4 (as this machine had).   The original test objective has been met. Good!

<a href="http://hermit.no/wp-content/uploads/2019/01/Jan19-1.png"><img src="http://hermit.no/wp-content/uploads/2019/01/Jan19-1.png" alt="" width="641" height="413" class="alignnone size-full wp-image-160587" /></a>



Now.... wonder if it works on VS 2012....  VS 2015....,  Next update of VS2013....   Do I want to test that too?  Anyone volunteering ? 


<strong>Dependencies and dependency management</strong>

In the title I have also said "dependencies", and this is a case for some thinking about dependencies.  One often think about dependencies as references between components (dlls), but dependencies comes in many different forms.  

Take a look at this dependency diagram for the situation above:

<a href="http://hermit.no/wp-content/uploads/2019/01/2019-01-26_19-36-37.jpg"><img src="http://hermit.no/wp-content/uploads/2019/01/2019-01-26_19-36-37.jpg" alt="" width="1969" height="1434" class="alignnone size-full wp-image-160593" /></a>

I was going to test the adapter, which I in this case say is at Level 1 of my dependency chain.  There was no fault in the adapter.  It depends - for running tests - on NUnit, which is then at Level 2. There was no fault there either.  To install  NUnit, which is a Nuget package, I used Visual Studio, and then its subcomponent, the NuGet Extension.  This was then Level 3, and this is where the fault was. Now, this was not needed for running the tests, I could have used the command line, and then used NuGet directly, which also the extension does, it is then Level 4, and also only needed for installation - which is a design time dependency. 
Also note, that none of these dependencies are the type you have in code, there is no references here.  This are usage and design time dependencies, of which you have to *know* about.  

This chain shows only a part of a complex dependency hierarchy, or even better word is perhaps graph.  The more complex, and the more deep a dependency system goes, the harder it is to predict failures.  Likewise it is also very hard to come up with a viable test system for something like this. 

Just to give you a feeling of the total complexity, you can think about how many versions and variations of each component at each level that exists, then multiply them together. That gives you the total number of possibilities, the "system cyclomatic complexity", so to speak, of which only a subset is viable of course but enough to make any test procedure extremely hard. 

In the same way, attempts to do "dependency management" will also likely be a waste of efforts here, there are too many variations to handle. 

<strong>Conclusion</strong>

This is not an uncommon situation.  You go out to check for something simple, like the NUnit3TestAdapter, and just setting up a simple test project with NUnit - and it fails adding that simple package!  It fails before you can even start testing. On something that should just have worked. And in addition on something that is unrelated to the testing of the adapter itself.  
Now, I could have gone back a few versions of NUnit, since .net standard was added at some time. Obviously the NuGet Extension in Visual Studio cares about the content of that package.  Even if that content is not going to be used in the project, it causes it to fail.  Will this ever be fixed?   Seriously doubt it, we are 3-4 major versions back.  

So even if NUnit itself is backwards compatible, the adapter is backwards compatible, that doesn't mean you can freely use the latest of something and expect it to work, like I did here.  And, the error messages coming up may not even make sense to you.

Staying on the (b)leading edge is hard, because all the new stuff you get keeps failing.  However, staying on the "good old working" edge can be just as hard, because updating ANY of your components may break on any strange thing you have in there.  

Adding in the dependency thinking, there seems to be impossible to handle such systems, but we still do all the time. 
The way to handle this is to accept that the system is complex, then manage the dependency and test procedures at a scale that is manageable. There is no final correct answer.  Then you need to handle the cases which falls outside your "guards", and you do that using "speed of response".  You need to maintain your system!

So:
Are there anywhere safe?
I seriously doubt it :-)

Code needs to be maintained!  

Just love it - and have fun coding !
