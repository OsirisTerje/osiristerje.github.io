---
id: 143011
title: 'Visual Studio &amp; TFS 2010 &ndash; List of extensions and upgrades'
date: 2010-12-05T12:28:48+01:00
author: terje
layout: post
guid: http://terje.wpengine.com/?p=143011
permalink: /visual-studio-amp-tfs-2010-ndash-list-of-extensions-and-upgrades/
dsq_thread_id:
  - "4844106880"
categories:
  - none
---
<p><font size="2"><font color="#ff0000">This post is about VS 2010, go here for the <a title="VS/TFS 11 extensions" href="http://geekswithblogs.net/terje/archive/2013/04/02/visual-studio-amp-tfs-2012-ndash-list-of-extensions-and.aspx" target="_blank"><u>VS/TFS 11 extensions</u></a>. </font></font></p>  <p><font size="2"><font color="#ff0000">UPDATED </font><font color="#000000">Apr 9th</font><font color="#000000"> 2012: VersionInfo, NuGet, Code Contracts  </font></font></p>  <p><font size="2"><font color="#ff0000">UPDATED </font><font color="#000000">Oct 7th</font><font color="#000000"> 2012:  New Visual Studio GDR</font></font></p>  <p><font size="2"><font color="#ff0000">UPDATED </font><font color="#000000">Aug 31th</font><font color="#000000"> 2012: New versions updated of ReSharper, NDepend, Web Essentials, Community Build Manager,  Code Contracts (March 2012), NuGet, ILSpy, DotPeek, Just Decompile, tangible T4 editor, LinqPad. Added the <a href="http://visualstudiogallery.msdn.microsoft.com/bce6cbf1-fb55-4a7d-b39b-8589634d846f" target="_blank"><u>VersionInfo</u></a> tool, so you know you have the latest update of VS 2010</font></font></p>  <p><font size="2"><font color="#ff0000">UPDATED </font><font color="#000000">April 20th</font><font color="#000000"> 2012: New version of NuGet manager. Added the GREAT ILSpy to the list. </font></font></p>  <p><font size="2"><font color="#ff0000">UPDATED </font><font color="#000000">March 22nd 2012:  New GDR update of Visual Studio (Client) components. Added Community Build Manager.</font></font></p>  <p><font size="2"><font color="#ff0000">UPDATED </font><font color="#000000">Feb</font><font color="#000000"> 17th 2012: New version of ReSharper 6.1.1 and Code Contracts with Silverlight 5 support +++</font></font></p>  <p><font size="2"><font color="#ff0000">UPDATED </font><font color="#000000">Feb</font><font color="#000000"> 16th 2012:  Added Visual Studio and TFS Server 2010 SP1  Cumulative Update 2. </font></font></p>  <p><font size="2"><font color="#ff0000">UPDATED </font><font color="#000000">Jan 9th 2012: New versions of Resharper, NuGet and Code Contracts.  Added link to a <a href="http://blogs.msdn.com/b/granth/archive/2012/01/03/tfs-2010-what-service-packs-and-hotfixes-should-i-install.aspx" target="_blank">blog post</a> by Grant Holiday on TFS/VS SP’s and hotfixes. Added link to CU4 for SQL 2008 R2 SP1. </font></font></p>  <p><font size="2"><font color="#ff0000">UPDATED </font><font color="#000000">Dec 16th: New version of TFS Power tools, and NuGet</font></font></p>  <p><font size="2"><font color="#ff0000">UPDATED </font><font color="#000000">Nov 28th: Added NuGet, new versions WebEssentials &amp; Beyond Compare </font></font></p>  <p><font size="2"><font color="#ff0000">UPDATED </font><font color="#000000">Nov 11th: Added the cloud update to Visual Studio which includes multistep test steps and bug fixes, updates to TFS and SQL, dotPeek, Test Attachment Cleaner and new version of our BuildExplorer, and of NDepend. Added Web Essentials. </font></font></p>  <p><font size="2"><font color="#ff0000">UPDATED </font><font color="#000000">Aug 23rd &amp; 26th: Added TFS SP1 Cumulative update 1. Fixes timeouts on source control. (26th: Fixed the link to the same)</font></font></p>  <p><font size="2"><font color="#ff0000">UPDATED</font> Aug 19th &amp; 21st 2011: New version of the TFS Power tools released.  Some more suggestions from Adam fixed, Moles/Pex updates included.   </font></p>  <p><font size="2"><font color="#ff0000">UPDATED</font> Aug 8th 2011:  Two Visual Studio Testing tools Rollup updates added</font></p>  <p><font size="2"><font color="#ff0000">UPDATED</font> July 27th 2011: <a href="http://Www.adamcogan.com"><u>Adam Cogan</u></a> suggested a different layout and information structure.  </font></p>  <p><font size="2">This post is a list of the addins and extensions we (I ) recommend for use at <a href="http://www.inmeta.com" target="_blank"><u>Inmeta</u></a>.  It’s coming up all the time – what to install, where are the download sites, last version, etc etc, and thus I thought it better to post it here and keep it updated. The basics are Visual Studio 2010 connected to a Team Foundation Server 2010.  </font></p>  <p><font size="2">The list is more or less in priority order.</font></p>  <p><font size="2">The focus is to get a setup which can be used for a complete coding experience for the whole ALM process. </font></p>  <p><font size="2">The list of course reflects what I use for my work , so it is by no means complete, and for some of the tools there are equally useful alternatives.  The components directly associated with Visual Studio from Microsoft should be common, see the Microsoft column.</font></p>  <p><font size="2">Also be sure to check out  <a href="http://blogs.msdn.com/b/granth/archive/2012/01/03/tfs-2010-what-service-packs-and-hotfixes-should-i-install.aspx" target="_blank">Grant’s blogpost</a> – it contains a complete description of what to install and in what sequence for the different TFS layers. </font></p>  <p> </p>  <p><strong><font size="2">Components for VS 2010</font></strong></p>  <table border="0" cellspacing="0" cellpadding="2" width="1234"><tbody>     <tr>       <td valign="top" width="170"><strong><font size="2">Product </font></strong></td>        <td valign="top" width="383"><strong><font size="2">Notes</font></strong></td>        <td valign="top" width="131"><strong><font size="2">Latest Version</font></strong></td>        <td valign="top" width="225"><strong><font size="2">License</font></strong></td>        <td valign="top" width="171"><strong><font size="2">Applicable to</font></strong></td>        <td valign="top" width="152"><strong><font size="2">Microsoft</font></strong></td>     </tr>      <tr>       <td valign="top" width="175"><font size="2"><a href="http://visualstudiogallery.msdn.microsoft.com/c255a1e4-04ba-4f68-8f4e-cd473d6b971f" target="_blank"><u>TFS Power Tools December 2011</u></a><font size="2"><strong><font color="#000000"><font color="#000080" size="2"><sup>1</sup></font></font></strong></font></font></td>        <td valign="top" width="388"> </td>        <td valign="top" width="136"><font size="2">December 2011 (10.0.41206.0) </font></td>        <td valign="top" width="228"><font size="2">Free</font></td>        <td valign="top" width="175"><font size="2">TFS integration</font></td>        <td valign="top" width="155"><font size="2">Yes</font></td>     </tr>      <tr>       <td valign="top" width="178"><font size="2"><u><a href="http://visualstudiogallery.msdn.microsoft.com/EA4AC039-1B5C-4D11-804E-9BEDE2E63ECF/" target="_blank">ReSharper</a></u></font></td>        <td valign="top" width="383"><font size="2">Trial only</font></td>        <td valign="top" width="140"><font size="2">7.0.1 (1098.2760)</font></td>        <td valign="top" width="228"><a href="http://www.jetbrains.com/resharper/buy/index.jsp" target="_blank"><font size="2"><u>Licensed</u></font></a></td>        <td valign="top" width="179"><font size="2">Coding &amp; Quality</font></td>        <td valign="top" width="156"><font size="2">No</font></td>     </tr>      <tr>       <td valign="top" width="180"><a href="http://visualstudiogallery.msdn.microsoft.com/en-us/d0d33361-18e2-46c0-8ff2-4adea1e34fef" target="_blank"><font color="#000080" size="2"><u>Productivity Power Tools</u></font></a><font size="2"><strong><font color="#000000"><font color="#000080" size="2"><sup>1</sup></font> </font></strong></font></td>        <td valign="top" width="378"> </td>        <td valign="top" width="143"><font color="#000000" size="2">10.0.20626.18</font></td>        <td valign="top" width="226"><font color="#000000" size="2">Free</font></td>        <td valign="top" width="182"><font color="#000000" size="2">Coding</font></td>        <td valign="top" width="156"><font color="#000000" size="2">Yes</font></td>     </tr>      <tr>       <td valign="top" width="181"><a href="http://visualstudiogallery.msdn.microsoft.com/35daa606-4917-43c4-98ab-38632d9dbd45/" target="_blank"><font size="2"><u>Inmeta Build Explorer</u></font></a><font size="2"><strong><font size="2"><sup>1</sup></font> </strong></font></td>        <td valign="top" width="375"> </td>        <td valign="top" width="145"><font size="2">1.1.8</font></td>        <td valign="top" width="225"><font size="2">Free</font></td>        <td valign="top" width="184"><font size="2">TFS integration</font></td>        <td valign="top" width="156"><font size="2">No</font></td>     </tr>      <tr>       <td valign="top" width="181"><font size="2"><a href="http://visualstudiogallery.msdn.microsoft.com/16bafc63-0f20-4cc3-8b67-4e25d150102c" target="_blank"><u>Build Manager</u></a></font></td>        <td valign="top" width="374"><font size="2">Community Build Manager.  Info from <a title="Jakob here" href="http://geekswithblogs.net/jakob/archive/2011/12/30/introducing-community-tfs-build-manager.aspx" target="_blank">Jakob here</a>.</font></td>        <td valign="top" width="147"><font size="2">1.4.0.6</font></td>        <td valign="top" width="224"><font size="2">Free</font></td>        <td valign="top" width="186"><font size="2">TFS Integration</font></td>        <td valign="top" width="155"><font size="2">No</font></td>     </tr>      <tr>       <td valign="top" width="181"><font size="2"><a href="http://visualstudiogallery.msdn.microsoft.com/bce6cbf1-fb55-4a7d-b39b-8589634d846f" target="_blank"><u>Version Info</u></a></font></td>        <td valign="top" width="374"><font size="2"></font></td>        <td valign="top" width="147"><font size="2">1.0.5</font></td>        <td valign="top" width="224"><font size="2">Free</font></td>        <td valign="top" width="186"><font size="2">Visual Studio</font></td>        <td valign="top" width="155"><font size="2">No</font></td>     </tr>      <tr>       <td valign="top" width="181"><a href="http://msdn.microsoft.com/en-us/devlabs/dd491992.aspx#5" target="_blank"><font size="2"><u>Code Contracts</u></font></a></td>        <td valign="top" width="374"> </td>        <td valign="top" width="147"><font size="2">1.4.60317.12</font></td>        <td valign="top" width="224"><font size="2">Free</font></td>        <td valign="top" width="186"><font size="2">Coding &amp; Quality</font></td>        <td valign="top" width="155"><font size="2">Yes</font></td>     </tr>      <tr>       <td valign="top" width="181"><a href="http://visualstudiogallery.msdn.microsoft.com/en-us/85f0aa38-a8a8-4811-8b86-e7f0b8d8c71b" target="_blank"><font size="2"><u>Code Contracts Editor Extensions</u></font></a><font size="2"><strong><font size="2"><sup>1</sup></font> </strong></font></td>        <td valign="top" width="372"> </td>        <td valign="top" width="149"><font size="2">1.5.60326.11</font></td>        <td valign="top" width="223"><font size="2">Free</font></td>        <td valign="top" width="188"><font size="2">Coding &amp; Quality</font></td>        <td valign="top" width="155"><font size="2">Yes</font></td>     </tr>      <tr>       <td valign="top" width="180"><a href="http://visualstudiogallery.msdn.microsoft.com/en-us/e5f41ad9-4edc-4912-bca3-91147db95b99?SRC=VSIDE" target="_blank"><font size="2"><u>Power Commands</u></font></a><font size="2"><strong><font size="2"><sup>1</sup></font> </strong></font></td>        <td valign="top" width="371"> </td>        <td valign="top" width="150"><font size="2">1.0.2.3</font></td>        <td valign="top" width="222"><font size="2">Free</font></td>        <td valign="top" width="189"><font size="2">Coding</font></td>        <td valign="top" width="155"><font size="2">Yes</font></td>     </tr>      <tr>       <td valign="top" width="180"><a href="http://visualstudiogallery.msdn.microsoft.com/27077b70-9dad-4c64-adcf-c7cf6bc9970c?SRC=Home" target="_blank"><font size="2"><u>NuGet Package Manager</u></font></a><strong><font size="2"><sup>1</sup> </font></strong></td>        <td valign="top" width="370"><font size="2">If upgrading fails, there is a signature mismatch  between this and the former version you have preventing upgrading. Uninstall the former first, and then install the new one.</font> </td>        <td valign="top" width="151"><font size="2">2.0.40116.9051</font></td>        <td valign="top" width="222"><font size="2">Free</font></td>        <td valign="top" width="190"><font size="2">Coding</font></td>        <td valign="top" width="154"><font size="2">Yes</font></td>     </tr>      <tr>       <td valign="top" width="180"><a href="http://visualstudiogallery.msdn.microsoft.com/a15c3ce9-f58f-42b7-8668-53f6cdc2cd83" target="_blank"><font size="2"><u>Web Std Update</u></font></a><font size="2"><strong><font size="2"><sup>1</sup></font> </strong></font></td>        <td valign="top" width="370"> </td>        <td valign="top" width="151"><font size="2">1.0.4</font></td>        <td valign="top" width="222"><font size="2">Free</font></td>        <td valign="top" width="190"><font size="2">Coding (Web)</font></td>        <td valign="top" width="154"><font size="2">Yes (MSFT)</font></td>     </tr>      <tr>       <td valign="top" width="180"><a href="http://visualstudiogallery.msdn.microsoft.com/6ed4c78f-a23e-49ad-b5fd-369af0c2107f?SRC=VSIDE" target="_blank"><font size="2"><u>Web Essentials</u></font></a> <font size="2"><strong><font size="2"><sup>1</sup></font></strong></font></td>        <td valign="top" width="369"> </td>        <td valign="top" width="152"><font size="2">2.7</font></td>        <td valign="top" width="222"><font size="2">Free</font></td>        <td valign="top" width="191"><font size="2">Coding (Web)</font></td>        <td valign="top" width="153"><font size="2">Yes (MSFT)</font></td>     </tr>      <tr>       <td valign="top" width="180"><a href="http://msdn.microsoft.com/en-us/vstudio/ff655021.aspx" target="_blank"><font size="2"><u>FeaturePack 2</u></font></a> <sup><strong>2</strong></sup></td>        <td valign="top" width="369"><font size="2">Found in MSDN Subscriber download under Visual Studio 2010</font></td>        <td valign="top" width="152"><font size="2">FP2</font></td>        <td valign="top" width="222"><font size="2">Part of MSDN Subscription</font></td>        <td valign="top" width="191"><font size="2">Modeling &amp; Testing</font></td>        <td valign="top" width="153"><font size="2">Yes</font></td>     </tr>      <tr>       <td valign="top" width="179"><font size="2"><a href="http://visualstudiogallery.msdn.microsoft.com/3d37ce86-05f1-4165-957c-26aaa5ea1010" target="_blank"><u>Test Attachment Cleaner</u></a><font size="2"><strong><font size="2"><sup>1</sup></font></strong></font></font></td>        <td valign="top" width="368"> </td>        <td valign="top" width="153"><font size="2">1.0</font></td>        <td valign="top" width="221"><font size="2">Free</font></td>        <td valign="top" width="192"><font size="2">Testing</font></td>        <td valign="top" width="154"><font size="2">Yes</font></td>     </tr>      <tr>       <td valign="top" width="179"><font size="2"><a href="http://wiki.sharpdevelop.net/ILSpy.ashx" target="_blank"><u>ILSpy</u></a></font></td>        <td valign="top" width="368"><font size="2">Decompiler. Can also export assembly as C# project</font></td>        <td valign="top" width="153"><font size="2">2.1.0.1603</font></td>        <td valign="top" width="221"><font size="2">Free</font></td>        <td valign="top" width="192"><font size="2">Coding/Investigation</font></td>        <td valign="top" width="154"><font size="2">No</font></td>     </tr>      <tr>       <td valign="top" width="179"><font size="2"><a href="http://www.jetbrains.com/decompiler/" target="_blank"><u>DotPeek</u></a></font></td>        <td valign="top" width="368"> </td>        <td valign="top" width="153"><font size="2">1.0.0.8644</font></td>        <td valign="top" width="221"><font size="2">Free</font></td>        <td valign="top" width="192"><font size="2">Coding/Investigation</font></td>        <td valign="top" width="154"><font size="2">No</font></td>     </tr>      <tr>       <td valign="top" width="179"><font size="2"><a href="http://www.telerik.com/products/decompiling.aspx" target="_blank"><u>Just Decompile</u></a></font></td>        <td valign="top" width="368"> </td>        <td valign="top" width="153"><font size="2">2012.2.607</font></td>        <td valign="top" width="221"><font size="2">Free</font></td>        <td valign="top" width="192"><font size="2">Coding/Investigation</font></td>        <td valign="top" width="154"><font size="2">No</font></td>     </tr>      <tr>       <td valign="top" width="179"><a href="http://www.scootersoftware.com/download.php" target="_blank"><font size="2"><u>Beyond Compare</u></font></a></td>        <td valign="top" width="367"> </td>        <td valign="top" width="153"><font size="2">3.3.4 (build 14431)</font></td>        <td valign="top" width="221"><font size="2">Licensed</font></td>        <td valign="top" width="193"><font size="2">Coding/Investigation</font></td>        <td valign="top" width="154"><font size="2">No</font></td>     </tr>      <tr>       <td valign="top" width="179"><a href="http://www.jetbrains.com/resharper/buy/index.jsp" target="_blank"><font size="2"><u>dotTrace</u></font></a></td>        <td valign="top" width="367"> </td>        <td valign="top" width="153"><font size="2">4.5.1</font></td>        <td valign="top" width="221"><a href="http://www.jetbrains.com/profiler/buy/index.jsp" target="_blank"><font size="2"><u>Licensed</u></font></a></td>        <td valign="top" width="193"><font size="2">Quality</font></td>        <td valign="top" width="154"><font size="2">No</font></td>     </tr>      <tr>       <td valign="top" width="179"><a href="http://www.ndepend.com/" target="_blank"><font size="2"><u>NDepend</u></font></a></td>        <td valign="top" width="367"><font size="2">Trial only</font></td>        <td valign="top" width="153">         <p><font size="2">4.0.2.6750</font></p>       </td>        <td valign="top" width="221"><a href="http://www.ndepend.com/Purchase.aspx" target="_blank"><font size="2"><u>Licensed</u></font></a></td>        <td valign="top" width="193"><font size="2">Quality</font></td>        <td valign="top" width="154"><font size="2">No</font></td>     </tr>      <tr>       <td valign="top" width="179"><a href="http://visualstudiogallery.msdn.microsoft.com/en-us/60297607-5fd4-4da4-97e1-3715e90c1a23?SRC=VSIDE" target="_blank"><font size="2"><u>tangible T4 editor</u></font></a><font size="2"><strong><font size="2"><sup>1</sup></font></strong></font></td>        <td valign="top" width="367"> </td>        <td valign="top" width="153"><font size="2">2.0.2</font></td>        <td valign="top" width="221"><font size="2">Lite version Free (Good enough)</font></td>        <td valign="top" width="193"><font size="2">Coding (T4 templates)</font></td>        <td valign="top" width="154"><font size="2">No</font></td>     </tr>      <tr>       <td valign="top" width="179"><a href="http://research.microsoft.com/en-us/projects/pex/downloads.aspx" target="_blank"><font size="2"><u>Pex and Moles</u></font></a>           <br /><font size="2"><a href="http://visualstudiogallery.msdn.microsoft.com/b3b41648-1c21-471f-a2b0-f76d8fb932ee" target="_blank"><u>Moles x86</u></a><font size="2"><font size="2"><font size="2"><strong><font size="2"><sup>1</sup></font></strong></font></font> </font>            <br /><a href="http://visualstudiogallery.msdn.microsoft.com/22c07bda-ffc9-479a-9766-bfd6ccacabd4" target="_blank"><u>Moles x64</u></a><font size="2"><font size="2"><font size="2"><strong><font size="2"><sup>1</sup></font></strong></font></font> </font></font></td>        <td valign="top" width="367"><font size="2">Complete package found in MSDN Subscriber download under Visual Studio 2010            <br /></font></td>        <td valign="top" width="153"><font size="2">0.94.51023</font></td>        <td valign="top" width="221"><font size="2">Part of MSDN Subscription            <br /><a href="http://research.microsoft.com/en-us/projects/pex/downloads.aspx" target="_blank"><u>License information here</u></a></font></td>        <td valign="top" width="193"><font size="2">Coding &amp; Unit Testing</font></td>        <td valign="top" width="154"><font size="2">Yes</font></td>     </tr>      <tr>       <td valign="top" width="179"><a href="http://www.linqpad.net/" target="_blank"><font size="2"><u>LinqPad</u></font></a></td>        <td valign="top" width="367"> </td>        <td valign="top" width="153"><font size="2">4.42.1</font></td>        <td valign="top" width="221"><font size="2">Licensed</font></td>        <td valign="top" width="193"><font size="2">Coding</font></td>        <td valign="top" width="154"><font size="2">No</font></td>     </tr>      <tr>       <td valign="top" width="179"><a href="http://www.apexsql.com/products.aspx" target="_blank"><font size="2"><u>ApexSQL</u></font></a></td>        <td valign="top" width="367"> </td>        <td valign="top" width="153"> </td>        <td valign="top" width="221"><font size="2">Licensed</font></td>        <td valign="top" width="193"><font size="2">SQL</font></td>        <td valign="top" width="154"><font size="2">No</font></td>     </tr>      <tr>       <td valign="top" width="179"><a href="http://visualstudiogallery.msdn.microsoft.com/en-us/d491911d-97f3-4cf6-87b0-6a2882120acf" target="_blank"><font size="2"><u>VSCommands</u></font></a><font size="2"><strong><font size="2"><sup>1</sup></font> </strong></font></td>        <td valign="top" width="367"> </td>        <td valign="top" width="153"><font size="2">10.3.9.12</font></td>        <td valign="top" width="221"><font size="2">Lite version Free (Good enough)</font></td>        <td valign="top" width="193"><font size="2">Coding</font></td>        <td valign="top" width="154"><font size="2">No</font></td>     </tr>   </tbody></table>  <p>#1 Get via Visual Studio’s Tools | Extension Manager (or <a href="http://gallery.msdn.microsoft.com/en-us"><u><strong>The Code Gallery</strong></u></a><strong>).</strong>  (From <a href="http://www.adamcogan.com" target="_blank"><u>Adam</u></a> : All these are <strong>auto updated</strong> by the Extension Manager in Visual Studio)</p>  <p>#2 Works with ultimate only</p>  <p> </p>  <p><strong><font size="2">Upgrades and patches for VS/TFS 2010</font></strong></p>  <p><font size="2">Go to <a href="http://blogs.msdn.com/b/granth/archive/2012/01/03/tfs-2010-what-service-packs-and-hotfixes-should-i-install.aspx" target="_blank">Grant’s blogpost</a> to see a complete list of patches and updates for installing TFS and VS. His post details what to install and where, and covers all updates and patches you need to handle, and also links to relevant documentation. </font></p>  <table border="0" cellspacing="0" cellpadding="2" width="1105"><tbody>     <tr>       <td valign="top" width="172"><strong><font size="2">Product</font></strong></td>        <td valign="top" width="530"><strong><font size="2">Notes</font></strong></td>        <td valign="top" width="145"><strong><font size="2">Date</font></strong></td>        <td valign="top" width="142"><strong><font size="2">Applicable to</font></strong></td>        <td valign="top" width="114"><strong>File version number</strong></td>     </tr>      <tr>       <td valign="top" width="172"><font size="2"><a href="http://www.microsoft.com/en-us/download/details.aspx?id=34677" target="_blank"><u>VS 2010 SP1 GDR</u></a></font></td>        <td valign="top" width="530"><font size="2">Adds compatibility support for VS 2012 and Windows 8 for the test tools and VS 2010.  Cumulative update. See info here  <a href="http://support.microsoft.com/kb/2736182" target="_blank"><u>KB2736182</u></a> and on the <a href="http://blogs.msdn.com/b/visualstudioalm/archive/2012/10/02/microsoft-update-for-visual-studio-2010-sp1-with-compatibility-support-for-visual-studio-2012-and-windows-8.aspx" target="_blank"><u>ALM blog</u></a>.  Now delivered through Windows Update. </font></td>        <td valign="top" width="145"><font size="2">Sept 2012</font></td>        <td valign="top" width="142"><font size="2">Visual Studio, MTM,</font></td>        <td valign="top" width="114"><font size="2">10.0.40219.415</font></td>     </tr>      <tr>       <td valign="top" width="172"><font size="2"><a href="http://www.microsoft.com/download/en/details.aspx?id=29082" target="_blank"><u><strike>VS 2010 SP1 TFS11 Compatibility GDR</strike></u></a></font></td>        <td valign="top" width="530"><font size="2"><strike>For the client components this upgrade replaces all client fixes from CU2, so can be installed directly on top of SP1. Info here </strike><a href="http://support.microsoft.com/kb/2662296" target="_blank"><u><strike>KB2662296</strike></u></a><strike>. Fixes certain problems related to connecting to TFS 11 for the MTM and the Test Controllers. </strike></font></td>        <td valign="top" width="145"><font size="2"><strike>March 2012</strike></font></td>        <td valign="top" width="142"><font size="2"><strike>Visual Studio, MTM, Test Ctrls</strike></font></td>        <td valign="top" width="114"><font size="2">10.0.40219.383</font></td>     </tr>      <tr>       <td valign="top" width="172"><a href="http://go.microsoft.com/fwlink/?LinkID=236945&amp;clcid=0x409" target="_blank"><u><font size="2">TFS and VS 2010 SP1 CU2</font></u></a></td>        <td valign="top" width="530"><font color="#000000" size="2">Important:  This CU2 should be applied to both the TFS server and the Visual Studio/MTM clients, even if the title wrongly mentions only the server. It is stated further down in small letters in the </font><a href="http://support.microsoft.com/kb/2643415" target="_blank"><font color="#000000" size="2">KB2643415</font></a><font size="2"><font color="#000000">  It contains all code for CU1 and for the GDR.</font> </font></td>        <td valign="top" width="145"><font size="2">Feb 2012</font></td>        <td valign="top" width="142"><font size="2">Visual Studio, MTM <strong>AND</strong> TFS Server</font></td>        <td valign="top" width="114"> </td>     </tr>      <tr>       <td valign="top" width="172"><font size="2"><a href="http://hotfixv4.microsoft.com/Visual%20Studio%202010/sp1/DevDiv953788/40219.350/free/438787_intl_i386_zip.exe" target="_blank"><u><strike>TFS 2010 Hotfix KB2608743</strike></u></a></font></td>        <td valign="top" width="530"><font size="2"><strike>This hotfix can reduce the size of the test data saved to the TFS.  See </strike><a href="http://blogs.msdn.com/b/anutthara/archive/2011/10/30/gsjgd.aspx" target="_blank"><u><strike>Anu’s blog here</strike></u></a><strike> and <font size="2"><a href="http://support.microsoft.com/kb/2608743" target="_blank"><u>KB2608743 details here</u></a></font>.</strike></font></td>        <td valign="top" width="145"><font size="2"><strike>Oct 2011</strike></font></td>        <td valign="top" width="142"><font size="2"><strike>Visual Studio, MTM, Test Ctrls.Build Agent</strike></font></td>        <td valign="top" width="114"> </td>     </tr>      <tr>       <td valign="top" width="172"><font size="2"><a href="http://support.microsoft.com/kb/973602" target="_blank"><u>SQL Server 2008 R2 SP1 Cumulative Update 4</u></a>  - or -<a href="http://support.microsoft.com/hotfix/KBHotfix.aspx?kbnum=2591746&amp;kbln=en-us" target="_blank"><u>                <br />SQL Server 2008 R2 Cumulative Update 10</u></a>  </font></td>        <td valign="top" width="530"><font size="2">This update should be applied before using the <a href="http://visualstudiogallery.msdn.microsoft.com/3d37ce86-05f1-4165-957c-26aaa5ea1010" target="_blank"><u>Test Attachment Cleaner</u></a>. The TAC may leave ghost records in the database due to a bug in the SQL Server.   See </font><a href="http://blogs.msdn.com/b/anutthara/archive/2011/10/30/gsjgd.aspx" target="_blank"><u><font size="2">Anu’s blog here</font></u></a><font size="2"> and <a href="http://support.microsoft.com/default.aspx?scid=kb;EN-US;2591746" target="_blank"><u>more info here</u></a>. </font></td>        <td valign="top" width="145"><font size="2">Oct 2011/Dec 2011</font></td>        <td valign="top" width="142"><font size="2">SQL Server 2008 R2 (SP1 and pre-SP1)</font></td>        <td valign="top" width="114"> </td>     </tr>      <tr>       <td valign="top" width="172"><a href="http://go.microsoft.com/fwlink/?LinkID=212065&amp;clcid=0x409" target="_blank"><font size="2">Visual <strike>Studio 2010 SP1 TFS Compatibility GDR</strike></font></a></td>        <td valign="top" width="530"><font size="2"><strike>Visual Studio update to access a TFS 11 server and Team Foundation services preview, TFS in the cloud.  Includes some bug fixes and adds multiline test step support for the MTM. See </strike></font><a href="http://blogs.msdn.com/b/bharry/archive/2011/10/19/multi-line-test-steps-available-in-microsoft-test-manager-among-other-things.aspx" target="_blank"><font size="2"><strike>Brian Harry’s blog here</strike></font></a><strike> <font size="2">and </font></strike><a href="http://support.microsoft.com/kb/2581206" target="_blank"><font size="2"><strike>KB2581206</strike></font></a><font size="2"><strike>.</strike></font></td>        <td valign="top" width="145"><font size="2"><strike>Oct 2011</strike></font></td>        <td valign="top" width="142"><font size="2"><strike>Visual Studio</strike></font></td>        <td valign="top" width="114"> </td>     </tr>      <tr>       <td valign="top" width="172"><font size="2"><a href="http://www.microsoft.com/download/en/details.aspx?id=26211" target="_blank"><u><strike>TFS 2010 SP1 Cumulative Update 1</strike></u></a></font></td>        <td valign="top" width="530"><font size="2"><strike>See </strike><a href="http://support.microsoft.com/kb/2536929" target="_blank"><u><strike>KB2580221</strike></u></a><strike> and </strike><a href="http://blogs.msdn.com/b/bharry/archive/2011/08/09/tfs-2010-cumulative-update-republished.aspx" target="_blank"><u><strike>Brian Harry’s blog here</strike></u></a><strike> and </strike><a href="http://blogs.msdn.com/b/bharry/archive/2011/06/13/tfs-2010-sp1-cumulative-update-1-available.aspx" target="_blank"><u><strike>here</strike></u></a></font></td>        <td valign="top" width="145"><font size="2"><strike>Aug 2011</strike></font></td>        <td valign="top" width="142"><font size="2"><strike>TFS</strike></font></td>        <td valign="top" width="114"> </td>     </tr>      <tr>       <td valign="top" width="172"><font size="2"><a href="http://connect.microsoft.com/VisualStudio/Downloads/DownloadDetails.aspx?DownloadID=37587" target="_blank"><u><strike>Visual Studio SP1 Rollup Update 2</strike></u></a></font></td>        <td valign="top" width="530"><font size="2"><strike>A rollup update for the SP1 Testing tools, KB2443428.  See more info </strike><a href="http://blogs.msdn.com/b/vstsqualitytools/archive/2011/08/03/qfe-for-visual-studio-2010-sp1-testing-tools.aspx" target="_blank"><u><strike>blog here</strike></u></a><strike> and </strike><a href="http://support.microsoft.com/kb/2443428" target="_blank"><u><strike>details here</strike></u></a><strike> </strike></font></td>        <td valign="top" width="145"><font size="2"><strike>Aug 2011</strike></font></td>        <td valign="top" width="142"><font size="2"><strike>Visual Studio Testing tools</strike></font></td>        <td valign="top" width="114"> </td>     </tr>      <tr>       <td valign="top" width="172"><a href="http://connect.microsoft.com/VisualStudio/Downloads/DownloadDetails.aspx?DownloadID=36847" target="_blank"><font size="2"><u><strike>Visual Studio SP1 Rollup Update 1</strike></u></font></a></td>        <td valign="top" width="530"><font size="2"><strike>A rollup update for the SP1 Testing tools, KB2544407.  See more info </strike></font><a href="http://blogs.msdn.com/b/vstsqualitytools/archive/2011/06/24/new-qfe-for-visual-studio-2010-testing-tools.aspx" target="_blank"><font size="2"><u><strike>blog here</strike></u></font></a><font size="2"><strike> and </strike></font><a href="http://support.microsoft.com/kb/2544407" target="_blank"><font size="2"><u><strike>details here</strike></u></font></a></td>        <td valign="top" width="145"><font size="2"><strike>June 2011</strike></font></td>        <td valign="top" width="142"><font size="2"><strike>Visual Studio Testing</strike> tools</font></td>        <td valign="top" width="114"> </td>     </tr>      <tr>       <td valign="top" width="172"><a href="http://www.microsoft.com/downloads/en/details.aspx?FamilyID=75568aa6-8107-475d-948a-ef22627e57a5" target="_blank"><font size="2"><u>Visual Studio SP1</u></font></a></td>        <td valign="top" width="530"><font size="2">SP1 contains all earlier patches + a lot of new fixes            <br />See </font><a href="http://blogs.msdn.com/b/bharry/archive/2011/03/09/installing-all-the-new-stuff.aspx" target="_blank"><font size="2"><u>Brian Harry’s blog</u></font></a><font size="2"> for information on what to install and how. Also contains links to a lot of the stuff to install.            <br />Be aware of </font><a href="http://msdn.microsoft.com/nb-no/visualc/gg697159" target="_blank"><font size="2"><u>this potential problem</u></font></a><font size="2"> and workaround if you are using C++ and W7 SDK </font></td>        <td valign="top" width="146"><font size="2">March 2011</font></td>        <td valign="top" width="142"><font size="2">Visual Studio</font></td>        <td valign="top" width="115"> </td>     </tr>      <tr>       <td valign="top" width="172"><a href="http://www.microsoft.com/downloads/en/details.aspx?FamilyID=43d9f36a-6347-4ac4-86b6-cee4cd54b5d2&amp;displaylang=en" target="_blank"><font size="2"><u>TFS 2010 SP1</u></font></a></td>        <td valign="top" width="528"><font size="2">SP1 for the TFS server. </font></td>        <td valign="top" width="146"><font size="2">March 2011</font></td>        <td valign="top" width="142"><font size="2">TFS</font></td>        <td valign="top" width="115"> </td>     </tr>      <tr>       <td valign="top" width="173"><a href="http://archive.msdn.microsoft.com/KB2522890" target="_blank"><font size="2"><u><strike>2010 SP1 fix for accessing TFS 2008</strike></u></font></a><font size="2"><strike> KB2522890</strike></font></td>        <td valign="top" width="526"><font size="2">See info </font><a href="http://blogs.msdn.com/b/bharry/archive/2011/03/22/team-explorer-2010-sp1-bug-viewing-build-summary.aspx" target="_blank"><font size="2"><u>here</u></font></a>    (Aug 23rd: Included in SP1 Cumulative Update 1, see above)</td>        <td valign="top" width="147"><font size="2">March 2011</font></td>        <td valign="top" width="143"><font size="2">Visual Studio with TFS 2008</font></td>        <td valign="top" width="115"> </td>     </tr>      <tr>       <td valign="top" width="172"> </td>        <td valign="top" width="533"> </td>        <td valign="top" width="157"> </td>        <td valign="top" width="152"> </td>        <td valign="top" width="132"> </td>     </tr>   </tbody></table>  <p> </p>  <p><strong><font size="2">Some important earlier Patches, upgrades and fixes  (pre-SP1)</font></strong></p>  <table border="0" cellspacing="0" cellpadding="2" width="1106"><tbody>     <tr>       <td valign="top" width="174"><strong><font size="2">Product</font></strong></td>        <td valign="top" width="650"><strong><font size="2">Notes</font></strong></td>        <td valign="top" width="140"><strong><font size="2">Date</font></strong></td>        <td valign="top" width="140"><strong><font size="2">Applicable to</font></strong></td>     </tr>      <tr>       <td valign="top" width="182"><font size="2"><strike>Scrolling context menu </strike></font><a href="http://code.msdn.microsoft.com/KB2345133" target="_blank"><font size="2"><strike>KB2345133</strike></font></a><font size="2"><strike> and </strike></font><a href="http://code.msdn.microsoft.com/KB2413613" target="_blank"><font size="2"><strike>KB2413613</strike></font></a></td>        <td valign="top" width="661"><a href="http://blogs.msdn.com/b/visualstudio/archive/2010/10/14/hotfixes-available-for-scrolling-context-menu-problem.aspx" target="_blank"><font size="2"><u>Here</u></font></a>  Solve the problem with having a small/short context menu with scroll bars, which is much smaller than the available screen height. After the fix, the context menu uses all available screen height before scroll bars are added.</td>        <td valign="top" width="145"><font size="2">October 2010</font></td>        <td valign="top" width="145"><font size="2">Visual Studio</font></td>     </tr>      <tr>       <td valign="top" width="185"><a href="https://connect.microsoft.com/VisualStudio/Downloads/DownloadDetails.aspx?DownloadID=31858" target="_blank"><font size="2"><strike>MTM Patch</strike></font></a></td>        <td valign="top" width="657"><a href="http://blogs.msdn.com/b/anutthara/archive/2010/11/01/patch-for-microsoft-test-manager-released.aspx" target="_blank"><font size="2"><u>Here</u></font></a><font size="2"> and </font><a href="http://support.microsoft.com/kb/2387011" target="_blank"><font size="2"><u>here</u></font></a><font size="2">  KB2387011  <font size="2">Recommended (if you use MTM)</font></font></td>        <td valign="top" width="148"><font size="2">October 2010</font></td>        <td valign="top" width="148"><font size="2">MTM</font></td>     </tr>      <tr>       <td valign="top" width="187"><a href="http://support.microsoft.com/kb/2222312" target="_blank"><font size="2"><strike>Data warehouse fix</strike></font></a></td>        <td valign="top" width="651"><font size="2">Iteration dates fails with SQL 2008 R2.  KB2222312. Affects Burndown chart in Agile workbook.  <font size="2">Only for SQL 2008 R2</font></font></td>        <td valign="top" width="151"><font size="2">June 2010</font></td>        <td valign="top" width="151"><font size="2">Server</font></td>     </tr>      <tr>       <td valign="top" width="188"><a href="http://support.microsoft.com/kb/2135068" target="_blank"><font size="2"><strike>Upgrade 2008 to 2010 issue</strike></font></a><font size="2"><strike> and </strike></font><a href="http://www.microsoft.com/downloads/en/details.aspx?FamilyID=5f1d1e63-a9e2-4e05-8db0-9e3edaa49d9e&amp;displaylang=en" target="_blank"><font size="2"><strike>hotfix</strike></font></a></td>        <td valign="top" width="647"><font size="2">Fixes problems with labels and branches which are lost during upgrade. Apply before upgrade. Note: This has been fixed in the latest re-release of the TFS Server dated Aug 5th 2010. See </font><a href="http://blogs.msdn.com/b/bharry/archive/2010/08/05/update-on-the-tfs-upgrade-fix.aspx" target="_blank"><font size="2"><u>here</u></font></a>. Recommends downloading the latest bits. <font size="2">Only if upgrade from 2008 from earlier bits</font></td>        <td valign="top" width="153"><font size="2">August 2010</font></td>        <td valign="top" width="153"><font size="2">Server</font></td>     </tr>   </tbody></table>