---
id: 160474
title: Fixing missing project.json error in old csproj format
date: 2017-11-25T15:55:15+01:00
author: terje
layout: post

---
When moving between old and new csproj formats, and back again when it doesn't work, I have several times ended with a project.json error looking like this:

<a href="http://hermit.no/wp-content/uploads/2017/11/pjson.png" target="_blank" rel="noopener"><img class="wp-image-160475 size-full" src="http://hermit.no/wp-content/uploads/2017/11/pjson.png" alt="project.json error message" width="492" height="65" /></a>

&nbsp;

The cause comes from left over files in your obj catalogues.  The file in question seems to named project.assets.json.

Deleting these in all subfolders seems to do the trick.

Run, from the root of your repo:
<pre>del project.assets.json /s /q</pre>
&nbsp;

[The below didn't always work]

And whatever I do to get rid of it, clearing caches and more, nothing seems to help  once it appears, until I stumbled over this cute little trick:

For the project which are affected, add the following snippet into your csproj file.
<pre>&lt;<span class="pl-ent">PropertyGroup</span>&gt;
  &lt;<span class="pl-ent">RuntimeIdentifiers</span>&gt;win&lt;/<span class="pl-ent">RuntimeIdentifiers</span>&gt;
&lt;/<span class="pl-ent">PropertyGroup</span>&gt;

</pre>
Ref: Source of fix:  <a href="https://github.com/emgarten" target="_blank" rel="noopener">Emgarten's</a> comment on <a href="https://github.com/NuGet/Home/issues/4163" target="_blank" rel="noopener">this Nuget issue</a>