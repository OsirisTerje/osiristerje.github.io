---
id: 160617
title: New version of the NUnit 2 adapter supporting Visual Studio 2019
date: 2019-06-05T19:15:18+01:00
author: terje
layout: post
---

The NUnit 2.X framework have been superseded by the NUnit 3 framework several years ago.  Each framework "family" needs a separate adapter, one for the V2 and one for the V3.  The V3 have been maintained continuously, and have 3-4 releases per year.  The V2 adapter however, has not been updated since mid 2017.

The thinking have been that developers should move to the V3 version of the framework.  Over time that has happened, but there are still some that need the V2 version for various reasons. Although the V3 framework is an enhancement of V2, there are some breaking changes between them.  And for some systems those prevents upgrading.

The current V2 adapter supports all Visual Studio versions up to VS 2017, but there are issues, in particular when using the new SDK format, and with VS 2019 it doesn't seem to work. One example, with workarounds, can be found in [this github issue](https://github.com/nunit/nunit-vs-adapter/issues/180).

So, in order to properly support VS 2019 (and VS2017), we have made an upgrade to the V2 adapter, release 2.2.  It only contains two bug fixes, the VS 2019 is one, the other is another blocking issue.  The release notes are [here](https://github.com/nunit/docs/wiki/AdapterV2-Release-Notes).

The upgrade works with both the NuGet adapter, which is the preferred way of adding adapters, and a VSIX version.  The VSIX support is in the process of being deprecated in Visual Studio.

The major change in the adapter for support of VS 2019, is that the adapter and its support dlls are being copied into the output folder of the test project.

Now, this is no problem with respect to the NUnit dll's themselves, but the adapter is also using the [Mono.Cecil](https://www.nuget.org/packages/Mono.Cecil/) library, version 0.9.6.4, which is lagging behind the latest version, 0.10.4.  This will not create any issues if you're not using Mono.Cecil for anything else.   If you are, please raise an issue for it, or - seriously - convert to V3.

## Links

[Nuget adapter](https://www.nuget.org/packages/NUnitTestAdapter/2.2.0)

[VSIX Adapter](https://marketplace.visualstudio.com/items?itemName=NUnitDevelopers.NUnitTestAdapter)

[Project site](https://github.com/nunit/nunit-vs-adapter)

[Release notes](https://github.com/nunit/docs/wiki/AdapterV2-Release-Notes)
