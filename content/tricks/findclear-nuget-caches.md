---
title: How to find/clear your Nuget caches
date: 2017-10-12T19:25:20+01:00
author: terje
layout: post
---

Nuget maintains a set of caches on your local machine, or your build server.

Sometimes you need to find and clear a particular package, or simple clear the caches.

The most used locations can be found at:

```

%LocalAppData%\NuGet\Cache
%UserProfile%\.nuget\packages
```

The easiest way to find all of them however is to use nuget itself:

The following command lists all the cache locations:

```

nuget locals all -list
```

You will see four different cache locations.

[![NuGet cache listing example](/images/2017/10/nuget1.jpg)](/images/2017/10/nuget1.jpg)

If you want to clear all the caches the following command will do that:

```

nuget locals all -clear
```

The options for nuget locals:

[![NuGet cache options example](/images/2017/10/nuget2.jpg)](/images/2017/10/nuget2.jpg)
