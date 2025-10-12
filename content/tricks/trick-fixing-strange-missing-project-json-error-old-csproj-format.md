---
id: 160474
title: Fixing missing project.json error in old csproj format
date: 2017-11-25T15:55:15+01:00
author: terje
layout: post

---

When moving between old and new csproj formats, and back again when it doesn't work, I have several times ended with a project.json error looking like this:

[![project json error message](/images/2017/11/pjson.png)](/images/2017/11/pjson.png)

The cause comes from left over files in your obj catalogues.  The file in question seems to named project.assets.json.

Deleting these in all subfolders seems to do the trick.

Run, from the root of your repo:

```

del project.assets.json /s /q
```

[The below didn't always work]

And whatever I do to get rid of it, clearing caches and more, nothing seems to help  once it appears, until I stumbled over this cute little trick:

For the project which are affected, add the following snippet into your csproj file.

```

<PropertyGroup>
  <RuntimeIdentifiers>win</RuntimeIdentifiers>
</PropertyGroup>
```

Ref: Source of fix:  [Emgarten](https://github.com/emgarten)'s comment on [this Nuget issue](https://github.com/NuGet/Home/issues/4163)
