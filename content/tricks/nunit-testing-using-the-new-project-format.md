---
id: 160538
title: NUnit testing using the new project format
date: 2018-06-10T16:38:00+01:00
author: terje
layout: page

categories:
 - nunit
---

# NUnit testing using the SDK project format

This is a short recipe for how to set up your project for NUnit testing usign the SDK project format

Microsoft Visual Studio supports two project formats. The new format uses package references and are much simpler than the old one. It will also pick up any C# file in your folder, so you don't need to add them explicitly.

All you need to do to use NUnit with the new format is as shown in the example csproj below. The target framework can be any of the .net framework ones. For information on using .net core, see [a short recipe for that](http://hermit.no/net-core-setup/)

```

<Project Sdk="Microsoft.NET.Sdk">

    <PropertyGroup>
        <TargetFramework>net472</TargetFramework>
        <LangVersion>latest</LangVersion>
    </PropertyGroup>

    <ItemGroup>
        <PackageReference Include="NUnit" Version="3.12.0" />
        <PackageReference Include="NUnit3TestAdapter" Version="3.15.1" />
        <PackageReference Include="Microsoft.NET.Test.Sdk" Version="16.3.0" />
    </ItemGroup>

</Project>
```

That's all!

Tips:

1. You don't really need the LangVersion, but this is the way to ensure you have the latest minor version of C# enabled.
2. It can be wise to add the following two attributes to the first propertygroup, to set the assembly and namespace to something specific, and not rely on the default mapping:

```

<RootNamespace>MyCompany.MyApp.MyComponent</RootNamespace>
<AssemblyName>MyCompany.MyApp.MyComponent</AssemblyName>
```

For more details on .NET Framework versions, see [this migration guide](https://docs.microsoft.com/en-us/dotnet/framework/migration-guide/versions-and-dependencies) and the [framework overview](https://docs.microsoft.com/en-us/dotnet/framework/).
