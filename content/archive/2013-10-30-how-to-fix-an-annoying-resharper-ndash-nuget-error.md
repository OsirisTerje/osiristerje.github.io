---
id: 154502
title: 'How to fix an annoying ReSharper &ndash; NuGet error'
date: 2013-10-30T22:13:17+01:00
author: terje
layout: post
categories:
  - Extensions
  - Resharper
  - Visual Studio
---
Using [NuGet](https://nuget.codeplex.com/) in Visual Studio together with [ReSharper](http://www.jetbrains.com/resharper/) may sometimes lead you into an annoying error where ReSharper indicates your code has an error, but the solution builds just fine.     <br />This may happen if you have a set of NuGet packages, and you either just restore them, or delete them on disk and then restore again.  Your code ends up looking like this, note the red missing functions, which comes from the [Moq](https://code.google.com/p/moq/) library - which is downloaded from NuGet:

  [![image](/images/2015/08/GWB-WindowsLiveWriter-HowtofixanannoyingReSharperNuGeterror_12A62-image_thumb_1.png)](https://gwb.blob.core.windows.net/terje/WindowsLiveWriter/HowtofixanannoyingReSharperNuGeterror_12A62/image_4.png)

  while the Build is still fine, it compiles without any errors:

  [![image](/images/2015/08/GWB-WindowsLiveWriter-HowtofixanannoyingReSharperNuGeterror_12A62-image_thumb_2.png)](https://gwb.blob.core.windows.net/terje/WindowsLiveWriter/HowtofixanannoyingReSharperNuGeterror_12A62/image_6.png)

  This [stackoverflow question](http://stackoverflow.com/questions/15713167/resharper-can-not-resolve-symbol-even-when-project-builds) gives some different approaches to solve this, but my experience have been that the Resharper Suspend-Resume trick most often solves the issue:     <br />In Visual Studio:  Go to Tools/Options/Resharper

  Press Suspend:

  [![image](/images/2015/08/GWB-WindowsLiveWriter-HowtofixanannoyingReSharperNuGeterror_12A62-image_thumb_3.png)](https://gwb.blob.core.windows.net/terje/WindowsLiveWriter/HowtofixanannoyingReSharperNuGeterror_12A62/image_8.png)

  When this is done the error markers disappear, since ReSharper now is inactive.

  Then just press Resume again:

  [![image](/images/2015/08/GWB-WindowsLiveWriter-HowtofixanannoyingReSharperNuGeterror_12A62-image_thumb_4.png)](https://gwb.blob.core.windows.net/terje/WindowsLiveWriter/HowtofixanannoyingReSharperNuGeterror_12A62/image_10.png)

  This has been submitted to Jetbrains support,  here [http://youtrack.jetbrains.com/issue/RSRP-396411](http://youtrack.jetbrains.com/issue/RSRP-396411) – Comment and votes please.
