---
layout: post
---

# Some useful NUnitAnalyzer information

The NUnit Roslyn Analyzer project is still in alpha.
But that is no excuse for not using it!

## Set it up

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

You can then add the package into the projects of your choosing.  It will then activate and give you both warnings and tools to fix them. 

## NUnit Analyzer Repo

The repo can be found [here](https://github.com/nunit/nunit.analyzers)

