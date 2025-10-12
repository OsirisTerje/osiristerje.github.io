---
title: How to get NUnit3TestAdapter pre-release packages
date: 2018-02-06T21:59:50+01:00
author: terje
layout: post
categories:
 - nunit
---

## Adapter pre-releases

We publish pre-release packages for every pull request merge to the master branch in the [NUnit3TestAdapter](https://github.com/nunit/nunit3-vs-adapter) project. They are published to our [NUnit MyGet feed](https://www.myget.org/F/nunit/api/v3/index.json).

Feed:

```

https://www.myget.org/F/nunit/api/v3/index.json
```

Instructions for getting it for the different package tools, and also to see which is the latest version, go here:

[NUnit3TestAdapter package page on MyGet](https://www.myget.org/feed/nunit/package/nuget/NUnit3TestAdapter)

For NuGet (package.config)

```

Install-Package NUnit3TestAdapter -Version 3.10.0-dev-00702 -Source https://www.myget.org/F/nunit/api/v3/index.json
```

For NuGet (PackageReference in csproj)

```

<PackageReference Include="NUnit3TestAdapter" Version="3.10.0-dev-00702" />
```

**Tip 1:** The PackageReference version requires you to have the feed URL in the nuget.config file.

```

<packageSources>
    <add key="NuGet.org" value="http://api.nuget.org/v3/index.json" />
    <add key="NUnit.Myget.org" value="https://www.myget.org/F/nunit/api/v3/index.json" />
</packageSources>
```

**Tip 2:** You can also get the NUnit proper pre-release packages from the same feed.

## Analyzer alpha releases

You get the Analyzer package from our alpha feed at MyGet

The feed is located at :

```

https://www.myget.org/F/nunit-analyzers/api/v3/index.json
```

You can add this into your VS Nuget package settings, sources.

Or

You can add it to a repo nuget.config file, it should look like:

```

<?xml version="1.0" encoding="utf-8"?>
<configuration>
    <packageSources>
        <add key="NUnit alpha feed at MyGet" value="https://www.myget.org/F/nunit-analyzers/api/v3/index.json" />
  </packageSources>
</configuration>
```
