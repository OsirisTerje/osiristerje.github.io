---
id: 160538
title: NUnit testing using the new project format
date: 2018-06-10T16:38:00+01:00
author: terje
layout: page
guid: http://hermit.no/?page_id=160538
catchevolution-sidebarlayout:
  - default
---
This is a short recipe for how to set up your project for NUnit testing usign the new project format

Microsoft Visual Studio supports two project formats. The new format uses package references and are much simpler than the old one. It will also pick up any C# file in your folder, so you don't need to add them explicitly.

All you need to do to use NUnit with the new format is as shown in the example csproj below. The target framework can be any of the .net framework ones. For information on using .net core, see <a href="http://hermit.no/net-core-setup/">a short recipe for that</a>

<pre>&lt;Project Sdk="Microsoft.NET.Sdk"&gt;

&lt;PropertyGroup&gt;
 &lt;TargetFramework&gt;net472&lt;/TargetFramework&gt;
 &lt;LangVersion&gt;latest&lt;/LangVersion&gt;
 &lt;/PropertyGroup&gt;

&lt;ItemGroup&gt;
 &lt;PackageReference Include="NUnit" Version="3.12.0" /&gt;
 &lt;PackageReference Include="NUnit3TestAdapter" Version="3.15.1" /&gt;
 &lt;PackageReference Include="Microsoft.NET.Test.Sdk" Version="16.3.0" /&gt;
&lt;/ItemGroup&gt;

&lt;/Project&gt;
</pre>

That's all!

Tips:
1. You don't really need the LangVersion, but this is the way to ensure you have the latest minor version of C# enabled.
2. It can be wise to add the following two attributes to the first propertygroup, to set the assembly and namespace to something specific, and not rely on the default mapping:

<pre>&lt;RootNamespace&gt;MyCompany.MyApp.MyComponent&lt;/RootNamespace&gt;
&lt;AssemblyName&gt;MyCompany.MyApp.MyComponent&lt;/AssemblyName&gt;
</pre>

<ol>
    <li>For more details on .net framework versions, see <a href="https://docs.microsoft.com/en-us/dotnet/framework/migration-guide/versions-and-dependencies">this</a> and <a href="https://docs.microsoft.com/en-us/dotnet/framework/">this</a></li>
</ol>