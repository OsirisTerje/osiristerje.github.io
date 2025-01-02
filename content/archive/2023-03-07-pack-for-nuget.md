# How to set up your project for Nuget packaging

You can create Nuget packages in two ways, either making a package directly from a csproj project, or by using a nuspec file.  The first option is the easiest, but the second option gives you more control over the package.

I will start out by showing the first option.

A nuget package could be very simple, but there are conventions on what it should contain, to make it easier to use them, to debug with them,  

What you would like to include in a nuget package is:

- Instructions for use, aka a Readme file.
- A license
- A nice icon
- Possibility for debugging it, and viewing the source code
- Semantic versioning (you actually need this).
- Urls to source code and project information
