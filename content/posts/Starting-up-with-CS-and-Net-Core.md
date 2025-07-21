---
layout: post
date: 2021-12-29
---

# Starting up with C# and .Net Core

## Get the tools

### .Net core
Ensure you have the .net core sdk installed.

[Download and install it from here](https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-3.1.301-windows-x64-installer)

The run the following command to ensure you got it all right:

```cmd
dotnet
```

then

```cmd
dotnet --list-sdks
```

The first should just show you itself.  The second lists the sdks you have installed with their version numbers.

### IDEs

You should at least have [Visual Studio Code](https://code.visualstudio.com/download)

Start it up and from the Extensions icon (on the left side, 5th down probably) add the following extensions:

* C#  (from Microsoft)
* GitLens

Optionally you can also install [Visual Studio (large IDE)](https://visualstudio.microsoft.com/downloads/) which is superb for debugging.  Can come in handy. Select Community Edition, which is free. 

## Basic c# .net core command line application

Create a basic application, Add a folder Test and then there:

```
dotnet new nunit
```

This is a scaffolding operation for a unit test project, the code generated is the csproj project files, and then the UnitTest1.cs file which contains the unit test itself in C# code. 

You can build and run test tests simply by:

```
dotnet test
```

If you just wanted to build, without running the test, it is just

```
dotnet build
```

The start code by writing:

```
code .
```

(Notice the dot!)

And it will start up with the project in the editor.

The `dotnet new`  command has multiple templates to choose from.  Get a list by using the `dotnet new --list`

Create a new sibling folder to test (name it cons), and then run `dotnet new console` which gives you the basic Hello World example program.

You can also add yet another sibling folder MyLib, and then run `dotnet new classlib`.

*Notice, some of the classnames and namespaces are in lower case only.  In C# the convention is Pascal convention,  first letter Uppercase, the rest lower case.*

**Notice:  Arrange each project you have as a SUBFOLDER under your root solution folder**

[More info on dotnet new](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new)

Now change the name from Class1 to Math

Add a method like:

```
public double Add (double a, double b)
{
    return a + b;
}

```

The project is called mylib (as the file mylib.csproj).  You rename this to e.g. MyMath.csproj.

Now, go back to the root folder for these three projects and run:

```
dotnet new sln
```

It will create a file named after the folder you're in, in my case `examples.sln`

Assuming you have installed VS Community edition, start it up doing:

```
devenv examples.sln
```

It will be slower on startup than VS code, as expected - it is a bigger IDE, but after a while you'll see the Solution explorer to the right side, showing a single node named Solution (which is the last file you created)

Now from the context menu on that node, select Add/Existing projects, and located and add the three csproj files you have recently created. 

When finished, it should look like:

![](https://github.com/OsirisTerje/osiristerje.github.io/blob/master/images/sln-example.jpg)


Select the top level Build menu, and do Build solution

If you get any problems, open up the 3 csproj files (double click in sln).
Ensure the Cons and the Test have TargetFramework set to netcoreapp3.1 and the MyMath have the same set to netstandard2.1

*Do another build, and you should be fine..... perhaps a context menu Restore Nuget packages, if it is hard to get going.*

Now, click the Dependency node on Cons and select Add Project Reference. and then select the MyMath project.  Do the same for the Test project.

Now, take a look inside the csproj files and see that it has now added a ProjectReference node.  Now you know how it looks, and you can add these in the editor later, if you prefer that.

```
<ItemGroup>
    <ProjectReference Include="..\mylib\MyMath.csproj" />
  </ItemGroup>
```

Now change your program code in Program.cs to look like:

```csharp
using System;
using System.Linq;

namespace cons
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (!args.Any())
            {
                Console.WriteLine("Math arg1 arg2");
                return;
            }

            if (args.Length != 2)
            {
                Console.WriteLine($"Math needs two arguments, just got {args.Length}");
                return;
            }

            var ok = double.TryParse(args[0], out double a);
            if (!ok)
            {
                Console.WriteLine($"First argument must be a float number, but was {args[0]}");
                return;
            }

            ok = double.TryParse(args[1], out double b);
            if (!ok)
            {
                Console.WriteLine($"Second argument must be a float number, but was {args[1]}");
                return;
            }

            var math = new MyLib.Math();
            var result = math.Add(a, b);
            Console.WriteLine($"Result is {result:F2}");
        }
    }
}

```

And you can try to run it doing :

```
dotnet run 45.5  45
Result is 90.50
```
or without arguments or whatever, to check the error handling.

Notice in the code the use of string interpolation, using the `$" {somevar}"` syntax.

Notice also the inclusion of the `System.Linq`, which gave you access to the Any method. 

And notice the use of the `var` keyword, which says that the variable should be anything inferred by what is on the right hand side.  So in this case the `result` will be a double, because the math.Add statement returns a double.

Now, the code is a bit duplicated, and the static Main is a bit big, so let us rearrange it a bit.

```
using System;
using System.Collections.Generic;
using System.Linq;

namespace cons
{
    public class Program
    {
        static void Main(string[] args)
        {
            var program = new Program(args);
            program.Run();
        }

        private readonly IReadOnlyCollection<string> arguments;

        public Program(IReadOnlyCollection<string> args)
        {
            arguments = args;
        }

        public void Run()
        {
            if (!arguments.Any())
            {
                Console.WriteLine("Math arg1 arg2");
                return;
            }

            if (arguments.Count != 2)
            {
                Console.WriteLine($"Math needs two arguments, just got {arguments.Count}");
                return;
            }

            var result1 = Parse(arguments.First(), "First");
            if (!result1.Ok)
                return;
            var result2 = Parse(arguments.Skip(1).First(), "Second");
            if (!result2.Ok)
                return;
            
            var math = new MyLib.Math();
            var result = math.Add(result1.Result, result2.Result);
            Console.WriteLine($"Result is {result:F2}");
        }

        private (bool Ok, double Result) Parse(string arg, string position)
        {
            var ok = double.TryParse(arguments.First(), out double parsedValue);
            if (!ok)
            {
                Console.WriteLine($"{position} argument must be a float number, but was {arg}");
            }

            return (ok, parsedValue);
        }
    }
}

```

We have now introduced a few more concepts:

* The program is split into a simple static Main, and the rest as Instance methods.
* Constructors with parameters
* Local member variable
* Generic list with string
* Tuples as results from a method
* Private function

```
dotnet run 45.5  45
Result is 91.00
```

Oops - something went wrong somewhere.....   That result is not correct.

## Unit testing

Now go into the test project.

Return to Visual Studio,a dn look at the left side.  You should see a Test Explorer window there.  (If not, get it from the top menu, Test/Test Explorer)

Press the Run All button to the left in the top button bar of that hub.

It should go green.  Double click the Test1 node, to see the code.

We now want to unit test the program we wrote.  

Let us start with checking the Math library we had

```csharp
        [Test]
        public void TestMath()
        {
            var sut = new MyLib.Math();
            var result = sut.Add(45.5, 45);
            Assert.That(result, Is.EqualTo(90.5).Within(0.001));
        }
```

Notice the Within constraint added.  Doubles are never exact, so we put a range to it.

Now do a Test All again, and it should go green. 

#### Testing the program

The program itself seems to have the error, but it is not that easy to test.  So let us make the program itself more testable.

First, add a project reference in the Test project to the cons project.

Then make the Run method return a double, which should be the result from the Add operation.  There is one snag here, and that is in case of errors, we can't really see that explicitly.  So we will introduce a bool Property.

Add the following to the class:

```csharp
        public bool Ok { get; private set; } = false;
```

Now, in the Run method, after the parsing, just before the call the Math.Add, do:

```csharp
    Ok = true;
```

This property is now read only from the outside.  The private set'er ensures we can set it from inside the class.

Then, make the Parse method public too. We do this so that we can test this by itself.  Make a /// comment above the Parse method in Visual Studio, it should expand to a comment block:  Add the comment `Made public for testing`

Go back to the test project, and create a new test class for testing the Program class. The other is now for Math Test. And yes, you should rename it!

Add a new Test method, but now we shall use another type of test:

```csharp
using System.Collections.Generic;
using cons;
using NUnit.Framework;

namespace examples
{
    public class ProgramTest
    {
        [TestCase("45.5", "45", 90.5)]
        public void TestRunMethod(string a, string b, double expected)
        {
            var sut = new Program(new List<string> {a,b});

            var result = sut.Run();

            Assert.That(result, Is.EqualTo(expected).Within(0.001));
        }
    }
}
```

This is a parameterized tests, and we can add more cases if we like.  Add a few more to check. 

Running this test, will show it as red.  We sort of knew that already, so we have to dig deeper.  We know that the Math test is green, this is sort of integrating the two.  Let us see if we can remove the Math class from the equation first.

We start off by adding an interface to the Math class:

```csharp
    public interface IMath
    {
        double Add (double a, double b);
    }

    public class Math : IMath
    {
        public double Add (double a, double b)
        {
            return a + b;
        }
    }
```

And then we inject that into the Program instead of new'ing it up internally:

```csharp
 public class Program
    {
        static void Main(string[] args)
        {
            var program = new Program(args, new MyLib.Math());
            program.Run();
        }

        private readonly IReadOnlyCollection<string> arguments;
        private IMath Math { get; }

        public Program(IReadOnlyCollection<string> args, IMath math)
        {
            arguments = args;
            Math = math;
        }
```

and using it, we can remove the new'ing further down, and just use the private Math Property.  Notice we don't have any setter on it, since it is initialized in the constructor.

```csharp
        var result = Math.Add(result1.Result, result2.Result);
        Console.WriteLine($"Result is {result:F2}");
        return result;
```

Now, we can turn to the test again, and let us start with adding in mocking.

In the test project csproj file, add in the NSubstitute package:

```xml
 <ItemGroup>
    <PackageReference Include="NUnit" Version="3.12.0" />
    <PackageReference Include="NUnit3TestAdapter" Version="3.16.1" />
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="16.5.0" />
    <PackageReference Include="NSubstitute" Version="4.2.2" />
  </ItemGroup>
```

First, you need to add in the `new MyLib.Math()` to the ctor for the Program call.  

Then create a new copy of that test, call it TestRunMethodOnly, but now add in a mock for the Math instance.

```csharp
        [Test]
        public void TestRunMethodOnly()
        {
            var math = Substitute.For<IMath>();
            math.Add(45.5, 45).Returns(90.5);
            var sut = new Program(new List<string> { "45.5", "45" }, math);

            var result = sut.Run();

            Assert.That(result, Is.EqualTo(90.5).Within(0.001));
        }

```

Try to run these.  You will see they both are red, which means the error must be in the Program class, since the last one doesn't have the real Math class, but are using a mock.

Now, let us test the Parse method. Notice we still need to construct the Program class, but we will not be using the arguments, so they can be dummies both of them. We will still use the same arguments though, just since we have it.

```csharp
        [TestCase("10", 10.0)]
        [TestCase("20.4", 20.4)]
        [TestCase("45.5", 45.5)]
        public void TestParse(string arg, double expected)
        {
            var math = Substitute.For<IMath>();
            var sut = new Program(new List<string> { "45.5", "45" }, math);
            var result = sut.Parse(arg, "whatever");
            Assert.Multiple(() =>
            {
                Assert.That(result.Ok);
                Assert.That(result.Result, Is.EqualTo(expected).Within(0.001));
            });
        }
```

Running this, we get the following results:

![](https://github.com/OsirisTerje/osiristerje.github.io/blob/master/images/testfails.jpg)

And, we see that regardless of what we give in, the result is equal to 45.5.  Which incidentially is the same number as what we have inserted as parameter in the constructor, so the Parse method seems to pick that one up instead of the real parameter. 

Looking at the Parse method we see the line:

```csharp
public (bool Ok, double Result) Parse(string arg, string position)
        {
            var ok = double.TryParse(arguments.First(), out double parsedValue);
```
and indeed, the argument is arguments.First(), and not the arg parameter to the method.  We fix this, and then rerun the tests:



