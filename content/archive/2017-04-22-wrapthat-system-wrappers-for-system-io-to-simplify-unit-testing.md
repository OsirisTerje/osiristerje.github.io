---
id: 160397
title: 'WrapThat.System :  Wrappers for system.io to simplify unit testing'
date: 2017-04-22T10:48:17+01:00
author: terje
layout: post
guid: http://hermit.no/?p=160397
permalink: /wrapthat-system-wrappers-for-system-io-to-simplify-unit-testing/
dsq_thread_id:
  - "5749244210"
categories:
  - Code
  - NUnit
  - Unit Testing
tags:
  - WrapThat.System
---
<h2>Introduction</h2> <p>You have all seen it, you have all done it: Written code using the static methods from the System.IO namespace for handling directories and files.&nbsp;&nbsp; Or, you are maintaining legacy code where that usage is common in certain places.&nbsp; And now the code is huge,&nbsp; you have no unit tests, because unit testing classes that directly access the file system is just pain,&nbsp; and the cost of a rewrite is too big.</p> <p>You have either realized you need to change this code before it grows even more,&nbsp; or you might have been given the task of encapsulating that code in unit tests.&nbsp; But, how do you proceed with that?&nbsp; Because these are static methods in static classes.&nbsp; And the amount of code is too much to rewrite into something more modern, using file providers or something similar. </p> <p>You’re thinking of shims, and shudders when you remember the earlier attempts of that kind of mock frameworks.&nbsp; And you already are using modern mocking frameworks like <a href="https://www.nuget.org/packages/Moq/" target="_blank">Moq</a> or <a href="https://www.nuget.org/packages/NSubstitute/" target="_blank">NSubstitute</a>.&nbsp;&nbsp; You want something more lightweight than reflection based shims. </p> <p>The question then is:&nbsp; What is the minimal impact change you can do, in such a way that you don’t touch the underlying functionality, but still make the code testable. </p> <p>This is where the wrapper technique comes in handy, combined with injection.&nbsp; And this is where the use of the WrapThat.System package can be very useful.</p> <p>Note that the same principles as are being used in the WrapThat.System can be used with any other library or system you want to isolate for unit testing. </p> <h2></h2> <h2>The works</h2> <p>The WrapThat.System package contains a 100% 1-to-1 wrapping of the System.IO and System.Console static methods, replacing the existing static classes with instance classes, and exposing them as injectable interfaces.&nbsp; </p> <p>You need to do but a small change to your code, which will not change the functionality.&nbsp; </p> <p>You have two scenarios:</p> <p>1) Production scenario.&nbsp; The code should work as before.</p> <p>2) Unit Test Scenario.&nbsp; The code should be testable, with the ability to mock the file system. </p> <p>Let’s look at the unit test scenario first, since that is the objective for the change.&nbsp; </p> <p>Using the WrapThat.System package, the&nbsp; unit test program pass in mocked instances of the interfaces to the software under test.&nbsp; </p> <p>Common injection can be done either as constructor injection or as property injection.&nbsp; In the example we look at constructor injection.&nbsp; </p> <p>This means that the constructor, or constructors, of the class under test must be enhanced with one more parameter, to the mocked interface.&nbsp; </p> <p>&nbsp;</p><pre class="xml" name="code">public FileHandling()
{
           
}
</pre>
<p>Now let us start by adding in the injection, but so that it doesn’t get in the way for the old usage,&nbsp; we default it to null.</p><pre class="xml" name="code">public FileHandling(ISystemIO systemIo=null)
{
     
}</pre>
<p>The ISystemIO interface contains two properties, one is the Directory, and one is the File.&nbsp; These are the two main static classes in System.IO that are being wrapped now by the WrapThat.System package.</p>
<p>We will make two properties for these, named exactly like their static class they’re wrapping, and also redirect the usage of any subsequent use of these to the wrapper library.&nbsp; </p><pre class="xml" name="code"><p>using ISystemIO = WrapThat.SystemIO.ISystemIO;</p><p>// Redirect subsequent use </p><p>using Directory = WrapThat.SystemIO.Directory;<br>using File = WrapThat.SystemIO.File;</p><p>&nbsp;</p><p> // Add the two properties
 public IDirectory Directory { get;  }
 public IFile File { get; }

       
 // Initialize it in the ctor
 public FileHandling(ISystemIO systemIo=null)
 {
     Directory = systemIo?.Directory ?? new Directory();
     File = systemIo?.File ?? new File();
 }</p></pre>
<p>This is all we need to do to the “class under test”.&nbsp; Now, since the property names are identical to the old System.IO static classes, all the rest of the code in the class are completely unaware that these calls have been wrapped. </p>
<p>Note that the injected interface is deliberately defaulted to null, so that the constructor appears unchanged to the rest of the code.&nbsp; In that case, a new instance of Directory and File will be added to the properties, otherwise, they get their values from the injected interface.</p>
<p>Note again that the naming of the properties MUST match the original static class names, otherwise the rest of the code would be very confused.</p>
<p>The using statements also ensures that you can keep your old “using System.IO” statement.&nbsp;&nbsp; </p>
<p>Let us see how a small unit test may look like, for a very trivial example (too trivial to make any sense, but just so you get the idea).&nbsp; Let us just assume we have the following method in the class FileHandling:</p>
<p><a href="http://hermit.no/wp-content/uploads/2017/04/image.png"><img title="image" style="border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px" border="0" alt="image" src="http://hermit.no/wp-content/uploads/2017/04/image_thumb.png" width="322" height="87"></a></p>
<p>With File being static, this can’t be mocked, but now that we have it wrapped, we can.</p>
<p><a href="http://hermit.no/wp-content/uploads/2017/04/image-1.png"><img title="image" style="border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px" border="0" alt="image" src="http://hermit.no/wp-content/uploads/2017/04/image_thumb-1.png" width="421" height="279"></a></p>
<p>(The code above uses NSubstitute and NUnit 3) </p>
<p>Note that if your class is only using Directory or File, you can just pass in the interface to those instead of the SystemIO interface.&nbsp; The SystemIO interface is just to avoid having to pass in multiple interfaces if you use both. </p>
<h2>System.Console wrapping</h2>
<p>If you have code with a lot of Console handling,&nbsp; like Console writeline , it will be testable, but it will also be slow.&nbsp; Further, if you add in some ReadLine commands, then you’re stuck.&nbsp; With the System.Console wrapper you can unit test that stuff too.&nbsp; </p>
<p>Assume we have the following class, ready prepared with the injection</p>
<p><a href="http://hermit.no/wp-content/uploads/2017/04/image-2.png"><img title="image" style="border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px" border="0" alt="image" src="http://hermit.no/wp-content/uploads/2017/04/image_thumb-2.png" width="421" height="338"></a></p>
<p>And the tests for these two methods then look like this:</p>
<p><a href="http://hermit.no/wp-content/uploads/2017/04/image-3.png"><img title="image" style="border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px" border="0" alt="image" src="http://hermit.no/wp-content/uploads/2017/04/image_thumb-3.png" width="431" height="440"></a></p>
<p>&nbsp;</p>

<h2>The package</h2>
<p>Download the package from Nuget:&nbsp; <a title="https://www.nuget.org/packages/WrapThat.System" href="https://www.nuget.org/packages/WrapThat.System">https://www.nuget.org/packages/WrapThat.System</a>&nbsp; </p>
<p>The package contains wrappers for the System.IO classes Directory and File, and the System.Console class.&nbsp;&nbsp; It is currently based on .net 4.0.</p>
<p>You have to add the package to both the code that you’re wrapping, that is your production code, and to the test project where you are going to test your code. </p>
<p>&nbsp;</p>
<h2>How is it done</h2>
<p>The wrappers are generated by reflecting over the types.&nbsp;&nbsp;&nbsp; This means all method wrappers are in principle the same.&nbsp;&nbsp; The parameters and return types are not changed. </p>
<p>The wrappers look like this:</p>
<p><a href="http://hermit.no/wp-content/uploads/2017/04/image-4.png"><img title="image" style="border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px" border="0" alt="image" src="http://hermit.no/wp-content/uploads/2017/04/image_thumb-4.png" width="653" height="95"></a></p>
<p>As you can see they are simple one line wrappers that don’t change any behavior.</p>
<h2>Source and example code</h2>
<p>The source code for the wrappers, the generator and some examples of using them can be found in the git repository at <a title="https://github.com/wrapthat" href="https://github.com/wrapthat">https://github.com/wrapthat</a>&nbsp; </p>



<h2>What is coming</h2>
<p>Wrappers for the instance classes in System.IO are next up.&nbsp; Stay tuned!</p>