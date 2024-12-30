---
title: How to get NUnit3TestAdapter pre-release packages
date: 2018-02-06T21:59:50+01:00
author: terje
layout: post
---

## Adapter pre-releases

We publish pre-release packages for every pull request merge to the master branch in the <a href="https://github.com/nunit/nunit3-vs-adapter" target="_blank" rel="noopener">NUnit3TestAdapter</a> project.    They are published to our <a href="https://www.myget.org/F/nunit/api/v3/index.json" target="_blank" rel="noopener">NUnit MyGet feed</a>,
<pre>Feed:      <span style="font-family: Georgia, 'Bitstream Charter', serif; font-weight: normal;">https://www.myget.org/F/nunit/api/v3/index.json</span></pre>
Instructions for getting it for the different package tools, and also to see which is the latest version, go here:

<a href="https://www.myget.org/feed/nunit/package/nuget/NUnit3TestAdapter" target="_blank" rel="noopener">https://www.myget.org/feed/nunit/package/nuget/NUnit3TestAdapter </a>

For NuGet (package.config)
<blockquote>
<pre>Install-Package NUnit3TestAdapter -Version 3.10.0-dev-00702 -Source https://www.myget.org/F/nunit/api/v3/index.json</pre>
</blockquote>
For Nuget (PackageReference in csproj)
<pre>&lt;PackageReference Include="NUnit3TestAdapter" Version="3.10.0-dev-00702" /&gt;

</pre>
<strong>Tip 1:</strong>  The PackageReference version require you to have the feed URL in the nuget.config file.
<pre> &lt;packageSources&gt;
     &lt;add key="NuGet.org" value="http://api.nuget.org/v3/index.json" /&gt;
     &lt;add key="NUnit.Myget.org" value="https://www.myget.org/F/nunit/api/v3/index.json" /&gt;
 &lt;/packageSources&gt;</pre>
<strong>Tip 2:</strong>  You can also get the NUnit proper pre-release packages from the same feed.

## Analyzer alpha releases

You get the Analyzer package from our alpha feed at MyGet

The feed is located at :

```text
https://www.myget.org/F/nunit-analyzers/api/v3/index.json 
```

You can add this into your VS Nuget package settings, sources.

Or

You can add it to a repo nuget.config file, it should look like:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
    <packageSources>
        <add key="NUnit alpha feed at MyGet" value="https://www.myget.org/F/nunit-analyzers/api/v3/index.json" />
  </packageSources>
</configuration>
```
