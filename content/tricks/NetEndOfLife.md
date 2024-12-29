---
layout: post
---

# Beware of the end-of-life for .Net Framework and .Net Core versions

There are multiple versions of .Net Framework, and also of .Net Core.  Many of the versions have now reached their end of life point.   That means the versions are no longer supported, not with bug fixes and not with security fixes either.  

Some version are in the LTS (Long Term Support) mode.  This means they will receive critical fixes, and compatible fixes for a period of 3 years.  Microsoft also states that every second release will be set up for LTS.

Looking at how this is for .Net Core, the following screen shot is from the [.Net Core LifeCycle](https://dotnet.microsoft.com/download/dotnet-core) per Nov 6th 2019.

![](https://github.com/OsirisTerje/osiristerje.github.io/blob/master/images/2019-11-06_17-10-12.jpg)

Note that the only fully supported .Net Core version will be version 3.0 by the end of this year!  The .Net Core 2.1 will be on LTS however.  

The [.Net Core Support Policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) describes in more details how this works, also what release cadence they have right now.

And a similar list for the [.Net Framework lifecycle](https://dotnet.microsoft.com/download/dotnet-framework)

![](https://github.com/OsirisTerje/osiristerje.github.io/blob/master/images/2019-11-06_20-56-00.jpg)

As can be seen here the .net 4.0 to .net 4.5.1 is at end of life. If you got anything here, it is really time to upgrade.

## Don't panic

Now all of this doesn't mean that you can't use the older versions, at least when they are fairly new, like .Net Core 2.2.  It is more about the risk increasing as other parts of your system evolves.

What you will see is that there will be no further minor upgrades, and no bugs and security fixes on your chosen framework version.  This may not be that much of an issue for the near future. Depending on what operating systems you're supporting, you may get into unwanted situation for newer ones.  It may mean you might need to hold back on updating certain other components in your system.

And, as time goes on, you could expect to see other tools dropping support.  

E.g. For [NUnit](https://nunit.org) - support for .Net Core 1.* is being dropped now.

## Supported OS lifecycles

Your chosen .net framework or .net core version will run on an operating system, and the different versions support different version of the available operating system.  Microsoft will handle only OS support for their own operating system. When you try to figure out where it all ends, you need to work through this dependency chain of lifecycle support.  It is pretty obvious that the earlier versions you try to support, the harder it will be.

The [.Net Core Supported OS Policy](https://github.com/dotnet/core/blob/master/os-lifecycle-policy.md) covers what operating systems are supported by the different versions of .Net Core.  It has links to the underlying operating sysyems supports.  E.g. the .Net Core 3.0 are supported by [these operating systems](https://github.com/dotnet/core/blob/master/release-notes/3.0/3.0-supported-os.md).  


## Links

[Download start page for all .net core and .net frameworks](https://dotnet.microsoft.com/download)

[Microsoft Lifecycle Policy FAQ](https://support.microsoft.com/en-us/help/17140)

[.NET Core Support Policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core)

