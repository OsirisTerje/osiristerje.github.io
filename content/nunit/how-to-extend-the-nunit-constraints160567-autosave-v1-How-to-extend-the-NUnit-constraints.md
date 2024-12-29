---
id: 160568
title: How to extend the NUnit constraints
date: 2018-11-01T02:28:14+01:00
author: terje
layout: post
guid: http://hermit.no/160567-autosave-v1/
permalink: /160567-autosave-v1/
---
<div id="page" class="hfeed site">
<div id="main" class="clearfix">
<div class="wrapper">
<div class="content-sidebar-wrap">
<div id="primary">
<div id="content" role="main">
<div class="entry-summary">
<div id="2ef9569d-7a39-42c7-9fe0-0adb75ac50c2" class="postBody" contenteditable="true">
<p style="text-align: left;"><a href="http://nunit.org/" target="_blank" rel="noopener">NUnit</a> has a very rich and readable constraint set.  Normally you don’t need to do anything. But, there are some cases where it would be nice to be able to tweak these constraints.  You can always wrap them and extend them that way, but then you lose all the other good stuff, like chaining.  What is not so well known is that you can extend the existing constraints, they are **designed** to be extendable!   In this post I will show how you can do that easily.</p>
<p style="text-align: left;">You can also use this approach to build your own custom test "language" for your own domain testing. Doing that this way means you build on top of NUnit instead of inventing everything from scratch.</p>
<p style="text-align: left;">That also means that all existing testing tools that can run NUnit, like Visual Studio Test Explorer, <a href="https://azure.microsoft.com/en-us/services/devops/" target="_blank" rel="noopener">Azure Devops</a> testing tasks, NUnit Console and more will ALL work with your constraints and your custom test language.</p>

<div id="page" class="hfeed site">
<div id="main" class="clearfix">
<div class="wrapper">
<div class="content-sidebar-wrap">
<div id="primary">
<div id="content" role="main">
<div class="entry-summary">
<div id="2ef9569d-7a39-42c7-9fe0-0adb75ac50c2" class="postBody" style="text-align: left;" contenteditable="true">
<h2 style="text-align: left;">The scenario</h2>
<p style="text-align: left;">Let us start with a very "complex" piece of code that obviously need some heavy unit testing:</p>

<pre>public class Math
{
     public double Add(double a, double b)
     {
         return a + b;
     }
}</pre>
And we add a standard test method to verify this code:
<pre>public void TestAddStandard()
{
     var sut = new Math();
     var res = sut.Add(42d, 42d);
     Assert.That(res, Is.EqualTo(84).Within(0.001));
}</pre>
Note that since we are testing double values, the operations may not be exact, so we have added the Within with a specified tolerance.  If we have a lot of test code like this, which all uses the same tolerance, this soon starts to look like something that could be simplified.

Now, if we take some inspiration from e.g. Python, which for its PyTest has a constraint named 'approx'.  What it does is the same as the Is.EqualTo(...).Within(tolerance), but with a predefined tolerance.

When you know your domain, having a predefined tolerance can be a saver.  So, let us make a Approx constraint for NUnit!

First, let us see how a test using it would look like:
<pre>[Test]
public void TestAddCustom()
{
    var sut = new Math();
    var res = sut.Add(42d, 42d);
    Assert.That(res, Is.Approx(84d));
}</pre>
<h2> Adding new constraints</h2>
There are two ways we can extend this, one is a rather generic way of doing it, which is a bit more code, the other matches the requirement we have above, and possibly many others, but with less code.
<pre>using NUnit.Framework.Constraints;
/// &lt;summary&gt;
/// Generic way of extending by using the inherent constraints
/// &lt;/summary&gt;
public class DoubleConstraint : Constraint
{
     private const double DefaultPrecision = 0.0001;
     public DoubleConstraint(double expected) : base(expected)
     {
     }

     public override ConstraintResult ApplyTo&lt;TActual&gt;(TActual actual)
     {
        return NUnit.Framework.Is.EqualTo(Arguments[0])
              .Within(DefaultPrecision).ApplyTo(actual);
     }
}

/// &lt;summary&gt;
/// Option 2, which matches this case and similar
/// &lt;/summary&gt;
public class DoubleVerification2 : EqualConstraint
{
      private const double DefaultPrecision = 0.0001;
      public DoubleVerification2(double expected) : base(expected)
      {
          Within(DefaultPrecision);
      }
}</pre>
The code above is the constraints themselves, but we need to get them into the same syntax, so we will also extend the 'Is'  for the two methods we have above:
<pre>/// &lt;summary&gt;
/// This extends the Is functionality
/// &lt;/summary&gt;
public class Is : NUnit.Framework.Is
{
      public static DoubleConstraint Approx(double expected)
      {
          return new DoubleConstraint(expected);
      }

      public static DoubleVerification2 Approx2(double expected)
      {
          return new DoubleVerification2(expected);
      }
}</pre>
And finally we add an extension method that allow us to chain our new constraint with others:
<pre> /// &lt;summary&gt;
/// This allows for chaining
/// &lt;/summary&gt;
public static class Verifications
{
      public static DoubleConstraint Approx(this ConstraintExpression expression, double expected)
      { 
          var constraint = new DoubleConstraint(expected);
          expression.Append(constraint);
          return constraint;
      }
}</pre>
This will allow us to do stuff like below, where we use the 'Is.Not' before the Approx, that is what we mean by chaining.
<pre>[Test]
public void TestAddCustom3()
{
      var sut = new Math();
      var res = sut.Add(42, 42);
      Assert.That(res, Is.Not.Approx(80d));
}</pre>
&nbsp;

Acknowledgement:

Thanks to my fellow <a href="http://nunit.org/" target="_blank" rel="noopener">NUnit</a> core team member <a href="https://github.com/jnm2" target="_blank" rel="noopener">Joseph Musser</a> for good suggestions and clarifications !

&nbsp;

&nbsp;

&nbsp;

&nbsp;

&nbsp;

&nbsp;

</div>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
</div>