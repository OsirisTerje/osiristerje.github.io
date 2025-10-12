---
id: 147850
title: Using the Static Code Analysis feature of Visual Studio (Premium/Ultimate) to find memory leakage problems
date: 2011-11-27T23:10:24+01:00
author: terje
layout: post
categories:
  - none
---
<div class="wlWriterHeaderFooter" style="float:none; margin:0px; padding:4px 0px 4px 0px;"><iframe src="http://www.facebook.com/widgets/like.php?href=http://geekswithblogs.net/terje/archive/2011/11/27/using-the-static-code-analysis-feature-of-visual-studio-premiumultimate.aspx" scrolling="no" frameborder="0" style="border:none; width:450px; height:80px"></iframe></div>Memory for managed code is handled by the garbage collector, but if you use any kind of unmanaged code, like native resources of any kind, open files, streams and window handles, your application may leak memory if these are not properly handled.  To handle such resources the classes that own these in your application should implement the<u> [IDisposable](http://msdn.microsoft.com/en-us/library/system.idisposable.aspx)</u> interface, and preferably implement it according to the pattern described for that interface.

  When you suspect a memory leak, the immediate impulse would be to start up a memory profiler and start digging into that.   However, before you follow that impulse, do a Static Code Analysis run with a ruleset tuned to finding possible memory leaks in your code.  If you get any warnings from this, fix them before you go on with the profiling.

## How to use a ruleset

  In Visual Studio 2010 (Premium and Ultimate editions) you can define your own rulesets containing a list of Static Code Analysis checks.   I have defined the memory checks as shown in the lists below as ruleset files, which can be <font color="#ff0000">**downloaded** – **see bottom of this post**</font>.  When you get them, you can easily attach them to every project in your solution using the Solution Properties dialog. Right click the solution, and choose Properties at the bottom, or use the Analyze menu and choose “Configure Code Analysis for Solution”:

  [![image](/images/2015/08/GWB-Windows-Live-Writer-b46aceffca3e_D116-image_thumb.png)](http://gwb.blob.core.windows.net/terje/Windows-Live-Writer/b46aceffca3e_D116/image_2.png)

  In this dialog you can now choose the Memorycheck ruleset for every project you want to investigate.  Pressing Apply or Ok opens every project file and changes the projects code analysis ruleset to the one we have specified here.

  **How to define your own ruleset**  *(skip this if you just download my predefined rulesets)*

  If you want to define the ruleset yourself, open the properties on any project, choose Code Analysis tab near the bottom, choose any ruleset in the drop box and press Open

  [![image](/images/2015/08/GWB-Windows-Live-Writer-b46aceffca3e_D116-image_thumb_2.png)](http://gwb.blob.core.windows.net/terje/Windows-Live-Writer/b46aceffca3e_D116/image_6.png)

  Clear out all the rules by selecting “Source Rule Sets” in the Group By box, and unselect the box

  [![image](/images/2015/08/GWB-Windows-Live-Writer-b46aceffca3e_D116-image_thumb_3.png)](http://gwb.blob.core.windows.net/terje/Windows-Live-Writer/b46aceffca3e_D116/image_8.png)

  Change the Group By box to ID, and select the checks you want to include from the lists below.

  Note that you can change the action for each check to either warning, error or none, none being the same as unchecking the check.

  [![image](/images/2015/08/GWB-Windows-Live-Writer-b46aceffca3e_D116-image_thumb_4.png)](http://gwb.blob.core.windows.net/terje/Windows-Live-Writer/b46aceffca3e_D116/image_10.png)

  Now go to the properties window and set a new name and description for your ruleset.

  Then save (File/Save as) the ruleset using the new name as its name, and use it for your projects as detailed above.

  It can also be wise to add the ruleset to your solution as a solution item. That way it’s there if you want to enable Code Analysis in some of your TFS builds.

## Running the code analysis

  In Visual Studio 2010 you can either do your code analysis project by project using the context menu in the solution explorer and choose “Run Code Analysis”, you can define a new solution configuration, call it for example Debug (Code Analysis), in for each project here enable the Enable Code Analysis on Build

  [![image](/images/2015/08/GWB-Windows-Live-Writer-b46aceffca3e_D116-image_thumb_1.png)](http://gwb.blob.core.windows.net/terje/Windows-Live-Writer/b46aceffca3e_D116/image_4.png)

  In Visual Studio Dev-11 it is all much simpler, just go to the Solution root in the Solution explorer, right click and choose “Run code analysis on solution”.

## The ruleset checks

  The following list is the essential and critical memory checks.

  <table border="0" cellspacing="0" cellpadding="2" width="1137"><tbody>     <tr>       <td valign="top" width="107">**CheckID**</td>        <td valign="top" width="219">**Message**</td>        <td valign="top" width="350">**Can be ignored ?**</td>        <td valign="top" width="459">**Link to description with fix suggestions**</td>     </tr>      <tr>       <td valign="top" width="119">CA1001</td>        <td valign="top" width="235">Types that own disposable fields should be disposable</td>        <td valign="top" width="350">No</td>        <td valign="top" width="459"><u> [http://msdn.microsoft.com/en-us/library/ms182172.aspx](http://msdn.microsoft.com/en-us/library/ms182172.aspx)</u></td>     </tr>      <tr>       <td valign="top" width="124">CA1049</td>        <td valign="top" width="240">Types that own native resources should be disposable</td>        <td valign="top" width="350">Only if the pointers assumed to point to unmanaged resources point to something else</td>        <td valign="top" width="459"><u> </u>[http://msdn.microsoft.com/en-us/library/ms182173.aspx](http://msdn.microsoft.com/en-us/library/ms182173.aspx)</td>     </tr>      <tr>       <td valign="top" width="124">CA1063</td>        <td valign="top" width="240">Implement IDisposable correctly</td>        <td valign="top" width="350">No</td>        <td valign="top" width="459"><u> </u>[http://msdn.microsoft.com/en-us/library/ms244737.aspx](http://msdn.microsoft.com/en-us/library/ms244737.aspx)</td>     </tr>      <tr>       <td valign="top" width="124">CA2000</td>        <td valign="top" width="240">Dispose objects before losing scope</td>        <td valign="top" width="350">No</td>        <td valign="top" width="459"><u> </u>[http://msdn.microsoft.com/en-us/library/ms182289.aspx](http://msdn.microsoft.com/en-us/library/ms182289.aspx)</td>     </tr>      <tr>       <td valign="top" width="128">CA2115 <sup>**1**</sup></td>        <td valign="top" width="241">Call GC.KeepAlive when using native resources</td>        <td valign="top" width="350">See description</td>        <td valign="top" width="459"><u> </u>[http://msdn.microsoft.com/en-us/library/ms182300.aspx](http://msdn.microsoft.com/en-us/library/ms182300.aspx)</td>     </tr>      <tr>       <td valign="top" width="128">CA2213</td>        <td valign="top" width="241">Disposable fields should be disposed</td>        <td valign="top" width="350">If you are not responsible for release, of if Dispose occurs at deeper level</td>        <td valign="top" width="459"><u> </u>[http://msdn.microsoft.com/en-us/library/ms182328.aspx](http://msdn.microsoft.com/en-us/library/ms182328.aspx)</td>     </tr>      <tr>       <td valign="top" width="131">CA2215</td>        <td valign="top" width="241">Dispose methods should call base class dispose</td>        <td valign="top" width="350">Only if call to base happens at deeper calling level</td>        <td valign="top" width="459"><u> </u>[http://msdn.microsoft.com/en-us/library/ms182330.aspx](http://msdn.microsoft.com/en-us/library/ms182330.aspx)</td>     </tr>      <tr>       <td valign="top" width="134">CA2216</td>        <td valign="top" width="240">Disposable types should declare a finalizer</td>        <td valign="top" width="350">Only if type does not implement IDisposable for the purpose of releasing unmanaged resources</td>        <td valign="top" width="459"><u> </u>[http://msdn.microsoft.com/en-us/library/ms182329.aspx](http://msdn.microsoft.com/en-us/library/ms182329.aspx)</td>     </tr>      <tr>       <td valign="top" width="136">CA2220</td>        <td valign="top" width="240">Finalizers should call base class finalizers</td>        <td valign="top" width="350">No</td>        <td valign="top" width="459"><u> </u>[http://msdn.microsoft.com/en-us/library/ms182341.aspx](http://msdn.microsoft.com/en-us/library/ms182341.aspx)</td>     </tr>   </tbody></table>  Notes:

  *<font size="2">1) Does not result in memory leak, but may cause the application to crash</font>*

  The list below is a set of optional checks that may be enabled for your ruleset, because the issues these points too often happen as a result of attempting to fix up the warnings from the first set.

  <table border="0" cellspacing="0" cellpadding="2" width="1134"><tbody>     <tr>       <td valign="top" width="81">**ID**</td>        <td valign="top" width="173">**Message**</td>        <td valign="top" width="220">**Type of fault**</td>        <td valign="top" width="258">**Can be ignored ?**</td>        <td valign="top" width="400">**Link to description with fix suggestions**</td>     </tr>      <tr>       <td valign="top" width="81">CA1060</td>        <td valign="top" width="173">Move P/invokes to NativeMethods class</td>        <td valign="top" width="220">Security</td>        <td valign="top" width="258">No</td>        <td valign="top" width="400">[http://msdn.microsoft.com/en-us/library/ms182161.aspx](http://msdn.microsoft.com/en-us/library/ms182161.aspx)</td>     </tr>      <tr>       <td valign="top" width="81">CA1816</td>        <td valign="top" width="173">Call GC.SuppressFinalize correctly</td>        <td valign="top" width="220">Performance</td>        <td valign="top" width="258">Sometimes, see description</td>        <td valign="top" width="400">[http://msdn.microsoft.com/en-us/library/ms182269.aspx](http://msdn.microsoft.com/en-us/library/ms182269.aspx)</td>     </tr>      <tr>       <td valign="top" width="81">CA1821</td>        <td valign="top" width="173">Remove empty finalizers</td>        <td valign="top" width="220">Performance</td>        <td valign="top" width="258">No</td>        <td valign="top" width="400">[http://msdn.microsoft.com/en-us/library/bb264476.aspx](http://msdn.microsoft.com/en-us/library/bb264476.aspx)</td>     </tr>      <tr>       <td valign="top" width="81">CA2004</td>        <td valign="top" width="173">Remove calls to GC.KeepAlive</td>        <td valign="top" width="220">Performance and maintainability</td>        <td valign="top" width="258">Only if not technically correct to convert to SafeHandle</td>        <td valign="top" width="400">[http://msdn.microsoft.com/en-us/library/ms182293.aspx](http://msdn.microsoft.com/en-us/library/ms182293.aspx)</td>     </tr>      <tr>       <td valign="top" width="81">CA2006</td>        <td valign="top" width="173">Use SafeHandle to encapsulate native resources</td>        <td valign="top" width="220">Security</td>        <td valign="top" width="258">No</td>        <td valign="top" width="400">[http://msdn.microsoft.com/en-us/library/ms182294.aspx](http://msdn.microsoft.com/en-us/library/ms182294.aspx)</td>     </tr>      <tr>       <td valign="top" width="81">CA2202</td>        <td valign="top" width="173">Do not dispose of objects multiple times</td>        <td valign="top" width="220">Exception (System.ObjectDisposedException)</td>        <td valign="top" width="258">No</td>        <td valign="top" width="400">[http://msdn.microsoft.com/en-us/library/ms182334.aspx](http://msdn.microsoft.com/en-us/library/ms182334.aspx)</td>     </tr>      <tr>       <td valign="top" width="81">CA2205</td>        <td valign="top" width="173">Use managed equivalents of Win32 API</td>        <td valign="top" width="220">Maintainability and complexity</td>        <td valign="top" width="258">Only if the replace doesn’t provide needed functionality</td>        <td valign="top" width="400">[http://msdn.microsoft.com/en-us/library/ms182365.aspx](http://msdn.microsoft.com/en-us/library/ms182365.aspx)</td>     </tr>      <tr>       <td valign="top" width="81">CA2221</td>        <td valign="top" width="173">Finalizers should be protected</td>        <td valign="top" width="220">Incorrect implementation, only possible in MSIL coding</td>        <td valign="top" width="258">No</td>        <td valign="top" width="400">[http://msdn.microsoft.com/en-us/library/ms182340.aspx](http://msdn.microsoft.com/en-us/library/ms182340.aspx)</td>     </tr>   </tbody></table>

## Downloadable ruleset definitions

  I have defined three rulesets, one called Inmeta.Memorycheck with the rules in the first list above, and Inmeta.Memorycheck.Optionals containing the rules in the second list, and the last one called Inmeta.Memorycheck.All containing the sum of the two first ones.

  All three rulesets can be found in the <u> [zip archive  “Inmeta.Memorycheck” downloadable from here](http://www.hermit.no/Documents/Inmeta.Memorycheck.zip).</u>

## Links to some other resources relevant to Static Code Analysis

  [MSDN Magazine Article by Mickey Gousset on Static Code Analysis in VS2010](http://visualstudiomagazine.com/articles/2010/03/25/working-with-static-code-analysis.aspx)

  [MSDN :  Analyzing Managed Code Quality by Using Code Analysis, root of the documentation for this](http://msdn.microsoft.com/en-us/library/dd264939.aspx)

  [Preventing generated code from being analyzed using attributes](http://geekswithblogs.net/terje/archive/2008/11/10/hiding-generated-code-from-code-analysis-metrics-and-test-coverage.aspx)

  [Online training course on Using Code Analysis with VS2010](http://msdn.microsoft.com/en-us/gg712340)

  [Blogpost by Tatham Oddie on custom code analysis rules](http://blog.tatham.oddie.com.au/2010/01/06/custom-code-analysis-rules-in-vs2010-and-how-to-make-them-run-in-fxcop-and-vs2008-too/)

  [How to write custom rules, from Microsoft Code Analysis Team Blog](http://blogs.msdn.com/b/codeanalysis/archive/2010/03/26/how-to-write-custom-static-code-analysis-rules-and-integrate-them-into-visual-studio-2010.aspx)

  [Microsoft Code Analysis Team Blog](http://blogs.msdn.com/b/codeanalysis/)
