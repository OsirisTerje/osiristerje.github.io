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

<a href="http://hermit.no/wp-content/uploads/2017/10/nuget1.jpg"><img class="alignnone wp-image-160437 size-full" src="http://hermit.no/wp-content/uploads/2017/10/nuget1.jpg" alt="" width="657" height="76" /></a>

If you want to clear all the caches the following command will do that:

```

nuget locals all -clear

```

The options for nuget locals:

<a href="http://hermit.no/wp-content/uploads/2017/10/nuget2.jpg"><img class="alignnone wp-image-160438 size-full" src="http://hermit.no/wp-content/uploads/2017/10/nuget2.jpg" alt="" width="1019" height="61" /></a>