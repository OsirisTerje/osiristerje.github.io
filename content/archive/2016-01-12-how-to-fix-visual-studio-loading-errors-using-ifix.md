---
id: 160335
title: 'How to fix Visual studio loading errors,  using IFix'
date: 2016-01-12T13:19:00+01:00
author: terje
layout: post
guid: http://hermit.no/?p=160335
permalink: /how-to-fix-visual-studio-loading-errors-using-ifix/
dsq_thread_id:
  - "4484190807"
catchevolution-sidebarlayout:
  - default
categories:
  - Visual Studio
tags:
  - IFix
  - Visual Studio
---
Visual Studio is normally a very stable environment, but some times it might crash on you.  This might happen if you either install some new extension, or even if you update Visual Studio.  The latter can be rather annoying of course.

A “common” error message is the loading error, it says it can’t load some component correctly, like in the image below.

<a href="http://hermit.no/wp-content/uploads/2016/01/image.png"><img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border: 0px;" title="image" src="http://hermit.no/wp-content/uploads/2016/01/image_thumb.png" alt="image" width="375" height="212" border="0" /></a>

What component it is might vary, it doesn’t seem to be any pattern to it.  And some times it even give you multiple of these.

A very common cause for these crashes is a corrupted MEF cache.

All versions of Visual Studio (post 2012) uses MEF to load it’s own components.  These components are also being cached in a mef cache.

When you do install things, or do some updates to Visual Studio it happens that this cache gets corrupted, and then Visual Studio might do this complaining about not loading correctly.

The way to fix this is to delete the appropriate cache.

You can either use the command line tool  <a href="http://visualstudiogallery.msdn.microsoft.com/b8ba97b0-bb89-4c21-a1e2-53ef335fd9cb" target="_blank">IFix</a> , using the command “ifix  mefcache –f     - - all” , which deletes all caches for all versions:

<a href="http://hermit.no/wp-content/uploads/2016/01/image-1.png"><img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border: 0px;" title="image" src="http://hermit.no/wp-content/uploads/2016/01/image_thumb-1.png" alt="image" width="652" height="82" border="0" /></a>

or for a specific version, doing “ifix mefcache  -f    - -vs2015”

<a href="http://hermit.no/wp-content/uploads/2016/01/image-2.png"><img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border: 0px;" title="image" src="http://hermit.no/wp-content/uploads/2016/01/image_thumb-2.png" alt="image" width="673" height="44" border="0" /></a>

It doesn’t matter from where you run the IFix tool, it can be from anywhere.

Or do it manually, doing a rmdir -  using the information below:

The different versions have their cache at:
<table border="1" width="368" cellspacing="0" cellpadding="2">
<tbody>
<tr>
<td valign="top" width="57"><strong>Version</strong></td>
<td valign="top" width="309"><strong>Location</strong></td>
</tr>
<tr>
<td valign="top" width="57">VS 2012</td>
<td valign="top" width="309">%localappdata%\Microsoft\VisualStudio\11.0ComponentModelCache</td>
</tr>
<tr>
<td valign="top" width="57">VS 2013</td>
<td valign="top" width="309">%localappdata%\Microsoft\VisualStudio\12.0\ComponentModelCache</td>
</tr>
<tr>
<td valign="top" width="57">VS2015</td>
<td valign="top" width="309">%localappdata%\Microsoft\VisualStudio\14.0\ComponentModelCache</td>
</tr>
</tbody>
</table>
After the cache has been deleted, you must restart Visual Studio.

Also, if you have any other type of error in Visual Studio that just suddenly happens, it can be wise to delete the mef cache.  It will rebuild itself when you restart, so it has no bad side effects.