---
id: 146456
title: 'Visual Studio Testing Tools&ndash;Two new hotfixes released'
date: 2011-08-07T09:04:30+01:00
author: terje
layout: post
categories:
  - Testing
  - Visual Studio
---
<font size="2"><font color="#ff0000">Update</font>: These have been superseded and included in later Cumulative Updates. See [http://wblo.gs/cu8v](http://wblo.gs/cu8v) for checking what you got and updates, or [download the tool](http://visualstudiogallery.msdn.microsoft.com/bce6cbf1-fb55-4a7d-b39b-8589634d846f). Also see info about the [updates and extensions here](http://wblo.gs/bCd).</font>

<font size="2">During the summer Microsoft has released two important hotfixes for the Testing tools. These two hotfixes solves 7 serious problems:</font>

  <table border="0" cellspacing="0" cellpadding="2" width="769"><tbody>     <tr>       <td valign="top" width="31">**<font size="2">#</font>**</td>        <td valign="top" width="601">**<font size="2">Issue solved</font>**</td>        <td valign="top" width="135">**<font size="2">Fix in :</font>**</td>     </tr>      <tr>       <td valign="top" width="31"><font size="2">1.1</font></td>        <td valign="top" width="601"><font size="2">Appdomain error when running a test agent on a computer with Visual Studio installed</font></td>        <td valign="top" width="135"><font size="2">1)</font></td>     </tr>      <tr>       <td valign="top" width="31"><font size="2">1.2</font></td>        <td valign="top" width="601"><font size="2">Exception with search error may happen on playback of a coded UI test on some WPF controls</font></td>        <td valign="top" width="135"><font size="2">1)</font></td>     </tr>      <tr>       <td valign="top" width="31"><font size="2">1.3</font></td>        <td valign="top" width="601"><font size="2">OutOfMemory exception may occur when creating a work item from the Test Result pane.  More frequent when TFS server has many builds.</font></td>        <td valign="top" width="135"><font size="2">1)</font></td>     </tr>      <tr>       <td valign="top" width="31"><font size="2">1.4</font></td>        <td valign="top" width="601"><font size="2">Publishing of test results and builds stop responding for tests run in a build, due to a MSTest crash.</font></td>        <td valign="top" width="135"><font size="2">1)</font></td>     </tr>      <tr>       <td valign="top" width="31"><font size="2">2.1</font></td>        <td valign="top" width="601"><font size="2">Test runner says “waiting for application under test” due to a crash when running a Manual test and you create a bug or run a test.</font></td>        <td valign="top" width="135"><font size="2">2)</font></td>     </tr>      <tr>       <td valign="top" width="31"><font size="2">2.2</font></td>        <td valign="top" width="601"><font size="2">Unit tests fail to start after editing of testsettings when using batch files. </font></td>        <td valign="top" width="135"><font size="2">2)</font></td>     </tr>      <tr>       <td valign="top" width="31"><font size="2">2.3</font></td>        <td valign="top" width="601"><font size="2">StackOverflowException occurs in Test Manager</font></td>        <td valign="top" width="135"><font size="2">2)</font></td>     </tr>   </tbody></table>  <font size="1">Note 1:  KB2544407</font>

  <font size="1">Note 2:  KB2443428</font>

  <font size="2">More detailed information on these problems can be found in the detailed description for each KB,  </font>[KB2544407 details here](http://support.microsoft.com/kb/2544407)<font size="2"> and  </font>[KB2443428 details here](http://support.microsoft.com/kb/2443428)<font size="2">. </font>

  <font size="2">There are two blog entries explaining more for each of them :  </font>[KB2544407 blog here](http://blogs.msdn.com/b/vstsqualitytools/archive/2011/06/24/new-qfe-for-visual-studio-2010-testing-tools.aspx)<font size="2"> and </font>[KB2443428 blog here](http://blogs.msdn.com/b/vstsqualitytools/archive/2011/08/03/qfe-for-visual-studio-2010-sp1-testing-tools.aspx)

  <font size="2">They can be downloaded from :  </font>[KB2544407 download here](http://connect.microsoft.com/VisualStudio/Downloads/DownloadDetails.aspx?DownloadID=36847)<font size="2">  and </font>[KB2443428 download here](http://connect.microsoft.com/VisualStudio/Downloads/DownloadDetails.aspx?DownloadID=37587)

  <font size="2"></font>

  <font size="2">These two hotfixes are not accumulative, so you have to download and install both of them.  The sequence does not matter, they are well behaved !</font>
