---
id: 160516
title: Managing userdumps using IFIX
date: 2018-01-08T11:47:11+01:00
author: terje
layout: post
categories:
  - Visual Studio
tags:
  - Diagnostics
---
User dumps are powerful diagnostics you can enable when an application crashes, and in particular when you see no obvious reason for it to crash.

In my case I have been struggling with Visual Studio crashes, and have been reporting these back to Microsoft.  The devs there love user dumps, because they show the exact state of the application when it crashed.   A user dump can be opened in a debugger, to reveal call stacks and lot of other useful information.

To learn more about it, read e.g.  [Analyzing a User-Mode Dump File with WinDbg](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/analyzing-a-user-mode-dump-file-with-windbg),   and   [Using Dump Files](https://msdn.microsoft.com/en-us/library/d5zhxt22.aspx)

User dumps have to be enabled and disabled using the registry, and a registry script is handy to do that.  I have posted the details on that [here](http://hermit.no/enabledisable-user-dumps/), including links to reg script files.

However, it is much easier to do that using a tool, so I added it to [IFix](http://visualstudiogallery.msdn.microsoft.com/b8ba97b0-bb89-4c21-a1e2-53ef335fd9cb).   Download IFix to get both this and a lot of other sweet commands.

### Enabling/disabling  user dumps

#### Ifix diagnostics –d 1 -f

[![image](/images/2018/01/image_thumb.png)](/images/2018/01/image.png)

## Disabling user dumps:

### Ifix diagnostics –d 0 -f

[![image](/images/2018/01/image_thumb-1.png)](/images/2018/01/image-1.png)

## Check the current settings:

### Ifix diagnostics –d 0 –c

[![image](/images/2018/01/image_thumb-2.png)](/images/2018/01/image-2.png)

You can also change the dump folder, the tool sets it to C:\dumps by default.

Ifix diagnostics –D C:\userdumps  -f

[![image](/images/2018/01/image_thumb-3.png)](/images/2018/01/image-3.png)

&nbsp;

### Dump files

The user dumps can be mini dumps or full dumps (see [here for the difference](https://stackoverflow.com/questions/6903329/minidump-vs-fulldump)) , so they might be later large, and you might eat up your disk pretty fast.  A Visual Studio crash will give you a dump file in the order of 0.5 GB.   Smaller apps give you much smaller dumps of course.   So you should make it a habit of turning off the user dumps after you have done your diagnostics.

Now, looking at what I have collected over a couple of days:

[![image](/images/2018/01/image_thumb-4.png)](/images/2018/01/image-4.png)

I have a couple of IFix dumps, which bugs I am pretty sure I managed to fix.  I have a couple of explorer crashes, interesting in itself – but I think I know how I provoked those, and then some weird crashes I really have no clue why happened.  That is of course interesting, and should be target for an upcoming investigation.

If your machine is having random crashes, or is behaving strange, you can turn userdumps on for a while and see what it picks up.

### Looking inside a user dump file

When you have a userdump file, you can open it directly in Visual Studio, either by loading it in, just by drag/dropping the file directly into Visual Studio:

[![image](/images/2018/01/image_thumb-5.png)](/images/2018/01/image-5.png)

Just from this information I can get an idea of what is happening.  I see an exception code (1), which if I google it, points to me – in this case – just to an “unknown” exception.   I can check the version that is crashing (2), and also see what modules is loaded – and check if that makes sense.

In many cases you don’t have the source code, or symbols (in this case I have, but we’ll start pretending I have not).  So, I’ll go to start debugging the dump (!), by selecting (3) – Debug with Mixed.

And after having waited for symbols to load (whatever the debugger can find),  I am presented with this nice dialog:

[![image](/images/2018/01/image_thumb-6.png)](/images/2018/01/image-6.png)

Ahh,  I have been trying to access the registry, but without the right access rights!!  That makes sense.  To read the registry I need to run from an elevated admin prompt, which I obviously didn’t do,  but the code should not crash on me –  this should be fixed.

What is also very nice here, is that I can view the call stack (!), even without symbols, it picks what it can get.  I don’t see all of my own code there, but enough to understand what is going on.

[![image](/images/2018/01/image_thumb-7.png)](/images/2018/01/image-7.png)

And I now has as much information as I need, I might not even need the symbols/source to fix this.

However, if you have the source code, and want to drill down using that, you can add that to the debugger, see [this for all information on that](https://docs.microsoft.com/en-us/visualstudio/debugger/specify-symbol-dot-pdb-and-source-files-in-the-visual-studio-debugger).  One thing to be aware of is that you must have a 100% match between the code that crashes and the source/symbols that are to be loaded.  If you don’t have that, it will not accept the symbols.

The easy way is to load the dump into Visual  Studio with your project open.  It should preferably be in debug mode, or you should enable full debug symbols with your release code.   But then, if you have the source, you could also just run it directly from your debugger, which is far simpler anyway.

#### Tips

1) If you want to enable/disable dumps for Windows itself, see this [post](http://blog.nirsoft.net/2010/07/27/how-to-configure-windows-to-create-minidump-files-on-bsod/).

2) There are many ways to enable dumps, see this [post](https://www.wintellect.com/how-to-capture-a-minidump-let-me-count-the-ways/).
