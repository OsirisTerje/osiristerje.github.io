---
id: 147695
title: Guide to reduce TFS database growth using the Test Attachment Cleaner
date: 2011-11-15T15:35:03+01:00
author: terje
layout: post
guid: http://terje.wpengine.com/?p=147695
permalink: /guide-to-reduce-tfs-database-growth-using-the-test-attachment-cleaner/
dsq_thread_id:
  - "4773053402"
catchevolution-sidebarlayout:
  - default
categories:
  - none
---
UPDATED March 24th 2016:   Test Data Retention is now added to TFS 2015 Update 1,  see<a href="http://hermit.no/test-data-retention-policy-added-in-tfs-update-1/"> this post</a> for more information.

<span style="color: #ff0000;">UPDATED Apr 15th 2013: </span><span style="color: #000000;">Corrected to VS2012 Update 2</span>

<span style="color: #ff0000;">UPDATED Mar 23rd 2012: </span><span style="color: #000000;">Added information about VS 11 </span>

<span style="color: #ff0000;">UPDATED Mar 21st 2012:  </span><span style="color: #000000;">Added info and link to VS/TFS 11 tool for getting the Test Attachment Cleaner, now included with the TFS Power Tools</span>

<span style="color: #ff0000;">UPDATED Mar 17th 2012: </span><span style="color: #000000;">Added sql queries for TFS 11 Beta.  Changed structure after <a href="http://www.adamcogan.com/" target="_blank"><u>Adam’s</u></a> advices. Updated information. </span>

<span style="color: #ff0000;">UPDATED Jan 9th 2012:</span> Added link to SQL 2008 R2 SP1 CU4 for ghost file fix

<strong><span style="font-size: medium;">Background</span></strong>

Recently there has been several reports on TFS databases growing too fast and growing too big.  Notable this has been observed when one has started to use more features of the Testing system.  Also, the TFS 2010 handles test results differently from TFS 2008, and this leads to more data stored in the TFS databases. As a consequence of this there has been released some tools to remove unneeded data in the database, and also some fixes to correct for bugs which has been found and corrected during this process.  Further some preventive practices and maintenance rules should be adopted.

Scenarios that trigger this is:
<ul>
	<li>You have started to run manual tests, and includes video’s, images and collects a lot of data during the runs.</li>
	<li>You have automated your test runs, and includes code coverage information. This adds all the binaries to the TFS too.</li>
	<li>You are running a version of Visual studio 2010 that haven’t been updated (as detailed below), and thus manual testing and automated testing during build pushes up binary files.</li>
</ul>
<strong>VS 2012 Improvements</strong>

In VS 2012 the following changes have been done to improve the situation:
<ul>
	<li>Deployment items are no longer being uploaded, even for code coverage there is no upload, as the way it works have changed.</li>
	<li>System information files are now uploaded once per test run.  If your testrun consists of multiple test cases, like when you use a test suite as basis for a test run, you will now only get one system information file, whereas in 2010 you got one per test case regardless of how it was run. As they are identical, this was just waste.</li>
	<li>All test attachments are now compressed and decompressed on the client side, reducing both space on server and download time.</li>
	<li>A trx file consists of multiple small tr_ files.  In VS 2012 a single trx file is uploaded, which consist of all test case results for that test run.</li>
</ul>
See <a href="http://blogs.msdn.com/b/shyam1/archive/2012/03/15/test-attachments-size-reduction-features-in-visual-studio-11-beta.aspx" target="_blank"><u>this blogpost</u></a> for detailed information about this.

<strong>Links</strong>

A lot of people have blogged about this, among these are:

<a href="http://blogs.msdn.com/b/anutthara/archive/2011/10/30/gsjgd.aspx" target="_blank"><u>Anu’s very important blog post</u></a> here describes both the problem and solutions to handle it.  She describes both the Test Attachment Cleaner tool, and also some QFE/CU releases to fix some underlying bugs which prevented the tool from being fully effective.

<a href="http://blogs.msdn.com/b/bharry/archive/2011/10/31/tfs-databases-growing-out-of-control.aspx" target="_blank"><u>Brian Harry’s blog post here</u></a> describes the problem too

<a href="http://social.msdn.microsoft.com/Forums/en-AU/tfsgeneral/thread/188cf534-d928-46b0-afa4-0b1192714d24" target="_blank"><u>This forum thread</u></a> describes the problem with some solution hints.

Ravi Shanker’s blog post here describes best practices on solving this (TBP)

<a href="http://blogs.msdn.com/b/granth/archive/2011/02/12/tfs2010-test-attachment-cleaner-and-why-you-should-be-using-it.aspx" target="_blank"><u>Grant Holidays blogpost here</u></a> describes strategies to use the Test Attachment Cleaner both to detect space problems and how to rectify them.

<strong>What features can cause the problem:</strong>
<ul>
	<li>Publishing of test results from builds</li>
	<li>Publishing of manual test results and their attachments in particular</li>
	<li>Publishing of deployment binaries for use during a test run</li>
	<li>Bugs in SQL server preventing total cleanup of data</li>
</ul>
All the published data above is published into the TFS database as attachments.

The test results will include all data being collected during the run.  Some of this data can grow rather large, like IntelliTrace logs and video recordings.

Particularly annoying is the pushing of binaries which happen for automated test runs.  This is in earlier versions of TFS the default setting, whereas in later versions it has been reversed. The binaries includes all the programs dll’s and exe’s, and is pushed up to prepare for a second run. Normally that never happens, so there is really no point in polluting the database with these binaries.  These binaries are often seen to be the highest size contributor.

The goal of this post is to give you a step-by-step process to get a smaller database.
<ol>
	<li>Set up your system to minimize potential database issues</li>
	<li>Find out if you have a database space issue</li>
	<li>If you have the “problem”, clean up the database and otherwise keep it clean</li>
</ol>
<strong><span style="font-size: medium;">Step 1: Ensure your Visual Studio (MTM) and SQL Server for TFS is properly set up</span></strong>

Even if you have got the problem or if have yet not got the problem, you should ensure the Visual Studio MTM and SQL server is set up so that the risk of getting into this problem is minimized. To ensure this you should install the following set of updates and components.  Note that the TFS Server itself does not affect this, but you should also keep that up to the latest upgrade.

See my <a href="http://geekswithblogs.net/terje/archive/2010/12/05/visual-studio-amp-tfs-ndash-list-of-addins-extensions-patches.aspx" target="_blank"><u>blog post here for the latest extensions</u></a>, updates and patches or <a href="http://blogs.msdn.com/b/granth/archive/2012/01/03/tfs-2010-what-service-packs-and-hotfixes-should-i-install.aspx" target="_blank"><u>Grant Holidays excellent post here</u></a> for further details.

<strong>Visual Studio updates:</strong>
<ol>
	<li>Visual Studio 2010 SP1 CU2 or Visual Studio 2012 (any version from RTM to Update 2)
<ol>
	<li>These have the fix included</li>
</ol>
</li>
	<li>Visual Studio 2010 SP1 pre-CU2
<ol>
	<li>You should preferable update to CU2, otherwise you can install the QFE for <a href="http://support.microsoft.com/kb/2608743" target="_blank"><u>KB2608743</u></a> – which also contains detailed instructions on its use, <a href="http://hotfixv4.microsoft.com/Visual%20Studio%202010/sp1/DevDiv953788/40219.350/free/438787_intl_i386_zip.exe" target="_blank"><u>download from here</u></a>.</li>
</ol>
</li>
</ol>
The default settings (for both 1 and 2 above) will be to not upload deployed binaries, which are used in automated test runs, given the following conditions:
<ul>
	<li>However, note that binaries will still be uploaded if:
<ul>
	<li>Code coverage is enabled in the test settings.</li>
	<li>You change the <strong>UploadDeploymentItem</strong> to true in the testsettings file.
<ul>
	<li>This has to be done by editing the testsettings file as <u>an XML file,</u> this is not in the UI.  Change it in the element named Deployment.
<pre> &lt;Deployment enabled="false" uploadDeploymentItems="false"  /&gt;</pre>
</li>
</ul>
</li>
</ul>
</li>
</ul>
<ul>
<ul>
	<li>Be aware that this might be reset back to true by another user which haven't installed this QFE, or is running a non-CU2 VS/MTM.</li>
</ul>
	<li>The CU2 or hotfix should be installed to
<ul>
	<li>The build servers (the build agents)</li>
	<li>The machine hosting the Test Controller</li>
	<li>Local development computers (Visual Studio)</li>
	<li>Local test computers (MTM)</li>
</ul>
<ul>
<ul>
	<li>It is not required to install it to the TFS Server, test agents or the build controller – it has no effect on these programs. The hotfix is named as a TFS Server hotfix, but further down in small letters it is stated it doesn’t apply to the server itself.</li>
</ul>
</ul>
</li>
</ul>
<strong>SQL Server updates:</strong>
<ul>
	<li>If you use the SQL Server 2008 R2 SP1 you should also install <a href="http://support.microsoft.com/kb/973602" target="_blank">the CU 4</a> (or later) (for pre-SP1 it is the <a href="http://support.microsoft.com/kb/2591746" target="_blank"><u>the CU 10</u></a> ). This CU fixes a <a href="http://support.microsoft.com/kb/2622823" target="_blank"><u>potential problem</u></a> of hanging “ghost” files. This seems to happen only in certain trigger situations, but to ensure it doesn’t bite you, it is better to make sure this CU is installed.
<ul>
	<li>There is no such CU for SQL Server 2008 pre-R2
<ul>
	<li><strong>Work around</strong>: If you suspect hanging ghost files, they can – with some mental effort, be deduced from the ghost counters using the following SQL query:
<table border="0" width="400" cellspacing="0" cellpadding="2">
<tbody>
<tr>
<td valign="top" width="400">
<pre class="csharpcode"><span class="kwrd">use</span> master
<span class="kwrd">SELECT</span> DB_NAME(database_id) <span class="kwrd">as</span> <span class="str">'database'</span>,OBJECT_NAME(object_id) <span class="kwrd">as</span> <span class="str">'objectname'</span>,
index_type_desc,ghost_record_count,version_ghost_record_count,record_count,avg_record_size_in_bytes 
<span class="kwrd">FROM</span> sys.dm_db_index_physical_stats (DB_ID(N<span class="str">'&lt;DatabaseName&gt;'</span>), OBJECT_ID(N<span class="str">'&lt;TableName&gt;'</span>), <span class="kwrd">NULL</span>, <span class="kwrd">NULL</span> , <span class="str">'DETAILED'</span>)</pre>
</td>
</tr>
</tbody>
</table>
</li>
	<li>The problem is a stalled ghost cleanup process. Restarting the SQL server after having stopped all components that depends on it, like the TFS Server and SPS services – that is all applications that connect to the SQL server. Then restart the SQL server, and finally start up all dependent processes again. (I would guess a complete server reboot would do the trick too.) After this the ghost cleanup process will run properly again.</li>
</ul>
</li>
	<li>The "hanging ghost file” issue came up after one have run the TAC, and deleted enormous amount of data. The SQL Server can get into this hanging state (without the QFE) in certain cases due to this.</li>
</ul>
</li>
</ul>
<strong>TFS Attachment cleaner:</strong>
<ul>
	<li>For Visual Studio 2010:  Install and set up the Test Attachment Cleaner (TAC) on your own computer. It works through the client API, so you can run it from any client computer.</li>
	<li>For Visual Studio/TFS 2010 download <a href="http://visualstudiogallery.msdn.microsoft.com/3d37ce86-05f1-4165-957c-26aaa5ea1010" target="_blank"><u>Test Attachment Cleaner command line power tool</u></a> from here or download the <a title="TFS Power Tools December 2011 for TFS 2010" href="http://visualstudiogallery.msdn.microsoft.com/c255a1e4-04ba-4f68-8f4e-cd473d6b971f" target="_blank">TFS Power Tools December 2011 for TFS 2010</a>. The TAC is included with this.</li>
	<li>For Visual Studio/TFS 2012 download  the TFS Power tools.  The TAC is included with this. See <a href="http://geekswithblogs.net/terje/archive/2013/04/02/visual-studio-amp-tfs-2012-ndash-list-of-extensions-and.aspx" target="_blank"><u>this post</u></a> for information for the different versions.</li>
</ul>
<strong><span style="font-size: medium;">Step 2:  Analyze the data</span></strong>

Are your database(s) growing ?  Are unused test results growing out of proportion?

To find out about this you need to query your TFS database for some of the information, and use the <a href="http://visualstudiogallery.msdn.microsoft.com/3d37ce86-05f1-4165-957c-26aaa5ea1010" target="_blank"><u>Test Attachment Cleaner</u></a> (TAC) to obtain some  more detailed information.

If you don’t have too many databases you can use the SQL Server reports from within the Management Studio to analyze the database and table sizes. Or, you can use a set of queries. I find queries often faster to use because I can tweak them the way I want them.  But be aware that these queries are non-documented and non-supported and may change when the product team wants to change them.

<strong>Step 1.1: If you have multiple Project Collections, find out which might have problems:</strong>

Open a SQL Management Studio session onto the SQL Server where you have your TFS Databases.

Use the query below to find the Project Collection databases and their sizes, in descending size order.
<table border="0" width="400" cellspacing="0" cellpadding="2">
<tbody>
<tr>
<td valign="top" width="400">
<pre class="csharpcode"><span class="kwrd">use</span> master
<span class="kwrd">select</span> DB_NAME(database_id) <span class="kwrd">AS</span> DBName, (<span class="kwrd">size</span>/128) SizeInMB
 <span class="kwrd">FROM</span> sys.master_files 
 <span class="kwrd">where</span> type=0  <span class="kwrd">and</span> <span class="kwrd">substring</span>(db_name(database_id),1,4)=<span class="str">'Tfs_'</span> <span class="kwrd">and</span> DB_NAME(database_id)&lt;&gt;<span class="str">'Tfs_Configuration'</span> <span class="kwrd">order</span> <span class="kwrd">by</span> <span class="kwrd">size</span> <span class="kwrd">desc</span></pre>
</td>
</tr>
</tbody>
</table>
Doing this on one of our SQL servers gives the following results:

<a href="http://gwb.blob.core.windows.net/terje/Windows-Live-Writer/9d5d9927ea0a_143E6/image_2.png"><img style="background-image: none; padding-left: 0px; padding-right: 0px; display: inline; padding-top: 0px; border-width: 0px;" title="image" src="http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-9d5d9927ea0a_143E6-image_thumb.png" alt="image" width="221" height="162" border="0" /></a>

It is pretty easy to see on which collection to start the work <img class="wlEmoticon wlEmoticon-smile" src="http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-9d5d9927ea0a_143E6-wlEmoticon-smile_2.png" alt="Smile" />

<strong>Step 1.2: Find out which tables are possibly too large</strong>

Keep a special watch out for the Tfs_Attachment table.

Use the script at the bottom of <a href="http://blogs.msdn.com/b/granth/archive/2011/02/12/tfs2010-test-attachment-cleaner-and-why-you-should-be-using-it.aspx" target="_blank"><u>Grant’s blog</u></a> to find the table sizes in descending size order.  Add a “use Tfs_DefaultCollection” or whatever name you have for your collection database( s) at the top of the script.

In our case we got this result:

<a href="http://gwb.blob.core.windows.net/terje/Windows-Live-Writer/9d5d9927ea0a_143E6/image_4.png"><img style="background-image: none; padding-left: 0px; padding-right: 0px; display: inline; padding-top: 0px; border-width: 0px;" title="image" src="http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-9d5d9927ea0a_143E6-image_thumb_1.png" alt="image" width="410" height="224" border="0" /></a>

From Grant’s blog we learnt that the tbl_Content is in the Version Control category, so the major only big issue we have here is the tbl_AttachmentContent.

<strong>Step 1.3: Find out which team projects have possibly too large attachments</strong>

In order to use the TAC to find and eventually delete attachment data we need to find out which team projects have these attachments. The team project is a required parameter to the TAC.

Use the following query to find this, replace the collection database name with whatever applies in your case:
<table border="0" width="400" cellspacing="0" cellpadding="2">
<tbody>
<tr>
<td valign="top" width="400"></td>
</tr>
</tbody>
</table>
<div id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:bb7908f7-e85f-4aa4-8a00-32db5d484e3c" class="wlWriterEditableSmartContent" style="margin: 0px; display: inline; float: none; padding: 0px;">
<div style="border: #000080 1px solid; color: #000; font-family: 'Courier New', Courier, Monospace; font-size: 10pt;">
<div style="background: #000080; color: #fff; font-family: Verdana, Tahoma, Arial, sans-serif; font-weight: bold; padding: 2px 5px;">For TFS 2010</div>
<div style="background-color: #ffffff; max-height: 300px; overflow: auto; padding: 2px 5px;"><span style="color: #0000ff;">use</span> Tfs_DefaultCollection
<span style="color: #0000ff;">select</span>  p<span style="color: #808080;">.</span>projectname<span style="color: #808080;">,</span> <span style="color: #ff00ff;">sum</span><span style="color: #808080;">(</span>a<span style="color: #808080;">.</span>compressedlength<span style="color: #808080;">)/</span>1024<span style="color: #808080;">/</span>1024 <span style="color: #0000ff;">as</span> sizeInMB <span style="color: #0000ff;">from</span> dbo<span style="color: #808080;">.</span>tbl_Attachment <span style="color: #0000ff;">as</span> a
<span style="color: #808080;">inner</span> <span style="color: #808080;">join</span> tbl_testrun <span style="color: #0000ff;">as</span> tr <span style="color: #0000ff;">on</span> a<span style="color: #808080;">.</span>testrunid<span style="color: #808080;">=</span>tr<span style="color: #808080;">.</span>testrunid
<span style="color: #808080;">inner</span> <span style="color: #808080;">join</span> tbl_project <span style="color: #0000ff;">as</span> p <span style="color: #0000ff;">on</span> p<span style="color: #808080;">.</span>projectid<span style="color: #808080;">=</span>tr<span style="color: #808080;">.</span>projectid
<span style="color: #0000ff;">group</span> <span style="color: #0000ff;">by</span> p<span style="color: #808080;">.</span>projectname
<span style="color: #0000ff;">order</span> <span style="color: #0000ff;">by</span> <span style="color: #ff00ff;">sum</span><span style="color: #808080;">(</span>a<span style="color: #808080;">.</span>compressedlength<span style="color: #808080;">)</span> <span style="color: #0000ff;">desc</span></div>
</div>
</div>
<div id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:021eccd4-a2d9-4f24-ad05-ab6d25d14b4b" class="wlWriterEditableSmartContent" style="margin: 0px; display: inline; float: none; padding: 0px;">
<div style="border: #000080 1px solid; color: #000; font-family: 'Courier New', Courier, Monospace; font-size: 10pt;">
<div style="background: #000080; color: #fff; font-family: Verdana, Tahoma, Arial, sans-serif; font-weight: bold; padding: 2px 5px;">For TFS 2012</div>
<div style="background-color: #ffffff; max-height: 500px; overflow: auto; padding: 2px 5px;"><span style="color: #0000ff;">use</span> Tfs_DefaultCollection
<span style="color: #0000ff;">select</span>  p<span style="color: #808080;">.</span>projectname<span style="color: #808080;">,</span> <span style="color: #ff00ff;">sum</span><span style="color: #808080;">(</span>a<span style="color: #808080;">.</span>uncompressedlength<span style="color: #808080;">)/</span>1024<span style="color: #808080;">/</span>1024 <span style="color: #0000ff;">as</span> sizeInMBUncompressed<span style="color: #808080;">,</span> <span style="color: #ff00ff;">SUM</span><span style="color: #808080;">(</span>f<span style="color: #808080;">.</span>compressedlength<span style="color: #808080;">)/</span>1024<span style="color: #808080;">/</span>1024 <span style="color: #0000ff;">as</span> sizeInMBCompressed <span style="color: #0000ff;">from</span> dbo<span style="color: #808080;">.</span>tbl_Attachment <span style="color: #0000ff;">as</span> a
<span style="color: #808080;">inner</span> <span style="color: #808080;">join</span> tbl_File <span style="color: #0000ff;">as</span> f <span style="color: #0000ff;">on</span> a<span style="color: #808080;">.</span>TfsFileId<span style="color: #808080;">=</span>f<span style="color: #808080;">.</span>FileId
<span style="color: #808080;">inner</span> <span style="color: #808080;">join</span> tbl_testrun <span style="color: #0000ff;">as</span> tr <span style="color: #0000ff;">on</span> a<span style="color: #808080;">.</span>testrunid<span style="color: #808080;">=</span>tr<span style="color: #808080;">.</span>testrunid
<span style="color: #808080;">inner</span> <span style="color: #808080;">join</span> tbl_project <span style="color: #0000ff;">as</span> p <span style="color: #0000ff;">on</span> p<span style="color: #808080;">.</span>projectid<span style="color: #808080;">=</span>tr<span style="color: #808080;">.</span>projectid
<span style="color: #0000ff;">group</span> <span style="color: #0000ff;">by</span> p<span style="color: #808080;">.</span>projectname
<span style="color: #0000ff;">order</span> <span style="color: #0000ff;">by</span> <span style="color: #ff00ff;">sum</span><span style="color: #808080;">(</span>f<span style="color: #808080;">.</span>compressedlength<span style="color: #808080;">)</span> <span style="color: #0000ff;">desc</span></div>
</div>
</div>
In our case we got this result (had to remove some names), out of more than 100 team projects accumulated over quite some years:

<a href="http://gwb.blob.core.windows.net/terje/Windows-Live-Writer/9d5d9927ea0a_143E6/image_6.png"><img style="background-image: none; margin: 0px; padding-left: 0px; padding-right: 0px; display: inline; padding-top: 0px; border-width: 0px;" title="image" src="http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-9d5d9927ea0a_143E6-image_thumb_2.png" alt="image" width="219" height="205" border="0" /></a>

As can be seen here it is pretty obvious the “Byggtjeneste – Projects” are the main team project to take care of, with the ones on lines 2-4 as the next ones.

&nbsp;

<strong>Step 1.4: Check which attachment types take up the most space</strong>

It can be nice to know which attachment types takes up the space, so run the following query:
<table border="0" width="400" cellspacing="0" cellpadding="2">
<tbody>
<tr>
<td valign="top" width="400"></td>
</tr>
</tbody>
</table>
<div id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:5cd3ee1e-107d-46ce-8b3e-82f324c70e1a" class="wlWriterEditableSmartContent" style="margin: 0px; display: inline; float: none; padding: 0px;">
<div style="border: #000080 1px solid; color: #000; font-family: 'Courier New', Courier, Monospace; font-size: 10pt;">
<div style="background: #000080; color: #fff; font-family: Verdana, Tahoma, Arial, sans-serif; font-weight: bold; padding: 2px 5px;">For TFS 2010</div>
<div style="background-color: #ffffff; max-height: 300px; overflow: auto; padding: 2px 5px;"><span style="color: #0000ff;">use</span> Tfs_DefaultCollection
<span style="color: #0000ff;">select</span>  a<span style="color: #808080;">.</span>attachmenttype<span style="color: #808080;">,</span> <span style="color: #ff00ff;">sum</span><span style="color: #808080;">(</span>a<span style="color: #808080;">.</span>compressedlength<span style="color: #808080;">)/</span>1024<span style="color: #808080;">/</span>1024 <span style="color: #0000ff;">as</span> sizeInMB <span style="color: #0000ff;">from</span> dbo<span style="color: #808080;">.</span>tbl_Attachment <span style="color: #0000ff;">as</span> a
<span style="color: #808080;">inner</span> <span style="color: #808080;">join</span> tbl_testrun <span style="color: #0000ff;">as</span> tr <span style="color: #0000ff;">on</span> a<span style="color: #808080;">.</span>testrunid<span style="color: #808080;">=</span>tr<span style="color: #808080;">.</span>testrunid
<span style="color: #808080;">inner</span> <span style="color: #808080;">join</span> tbl_project <span style="color: #0000ff;">as</span> p <span style="color: #0000ff;">on</span> p<span style="color: #808080;">.</span>projectid<span style="color: #808080;">=</span>tr<span style="color: #808080;">.</span>projectid
<span style="color: #0000ff;">group</span> <span style="color: #0000ff;">by</span> a<span style="color: #808080;">.</span>attachmenttype
<span style="color: #0000ff;">order</span> <span style="color: #0000ff;">by</span> <span style="color: #ff00ff;">sum</span><span style="color: #808080;">(</span>a<span style="color: #808080;">.</span>compressedlength<span style="color: #808080;">)</span> <span style="color: #0000ff;">desc</span></div>
</div>
</div>
<div id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:c41e7112-41d0-45bc-b737-16c278e017bf" class="wlWriterEditableSmartContent" style="margin: 0px; display: inline; float: none; padding: 0px;">
<div style="border: #000080 1px solid; color: #000; font-family: 'Courier New', Courier, Monospace; font-size: 10pt;">
<div style="background: #000080; color: #fff; font-family: Verdana, Tahoma, Arial, sans-serif; font-weight: bold; padding: 2px 5px;">For TFS 2012</div>
<div style="background-color: #ffffff; max-height: 300px; overflow: auto; padding: 2px 5px;"><span style="color: #0000ff;">use</span> Tfs_DefaultCollection
<span style="color: #0000ff;">select</span>  a<span style="color: #808080;">.</span>attachmenttype<span style="color: #808080;">,</span> <span style="color: #ff00ff;">sum</span><span style="color: #808080;">(</span>f<span style="color: #808080;">.</span>compressedlength<span style="color: #808080;">)/</span>1024<span style="color: #808080;">/</span>1024 <span style="color: #0000ff;">as</span> sizeInMB <span style="color: #0000ff;">from</span> dbo<span style="color: #808080;">.</span>tbl_Attachment <span style="color: #0000ff;">as</span> a
<span style="color: #808080;">inner</span> <span style="color: #808080;">join</span> tbl_File <span style="color: #0000ff;">as</span> f <span style="color: #0000ff;">on</span> a<span style="color: #808080;">.</span>TfsFileId<span style="color: #808080;">=</span>f<span style="color: #808080;">.</span>FileId
<span style="color: #808080;">inner</span> <span style="color: #808080;">join</span> tbl_testrun <span style="color: #0000ff;">as</span> tr <span style="color: #0000ff;">on</span> a<span style="color: #808080;">.</span>testrunid<span style="color: #808080;">=</span>tr<span style="color: #808080;">.</span>testrunid
<span style="color: #808080;">inner</span> <span style="color: #808080;">join</span> tbl_project <span style="color: #0000ff;">as</span> p <span style="color: #0000ff;">on</span> p<span style="color: #808080;">.</span>projectid<span style="color: #808080;">=</span>tr<span style="color: #808080;">.</span>projectid
<span style="color: #0000ff;">group</span> <span style="color: #0000ff;">by</span> a<span style="color: #808080;">.</span>attachmenttype
<span style="color: #0000ff;">order</span> <span style="color: #0000ff;">by</span> <span style="color: #ff00ff;">sum</span><span style="color: #808080;">(</span>f<span style="color: #808080;">.</span>compressedlength<span style="color: #808080;">)</span> <span style="color: #0000ff;">desc</span></div>
</div>
</div>
We then got this result for a TFS 2010 database:

<a href="http://gwb.blob.core.windows.net/terje/Windows-Live-Writer/9d5d9927ea0a_143E6/image_8.png"><img style="background-image: none; margin: 0px; padding-left: 0px; padding-right: 0px; display: inline; padding-top: 0px; border-width: 0px;" title="image" src="http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-9d5d9927ea0a_143E6-image_thumb_3.png" alt="image" width="244" height="187" border="0" /></a>

From this it is pretty obvious that the problem here is the binary files, as also mentioned in Anu’s blog.

<strong>Step 1.5: Check which file types, by their extension, takes up the most space</strong>

Run the following query
<table border="0" width="400" cellspacing="0" cellpadding="2">
<tbody>
<tr>
<td valign="top" width="400"></td>
</tr>
</tbody>
</table>
<div id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:75a05179-8156-4cc2-b3ec-ec8b229dd98f" class="wlWriterEditableSmartContent" style="margin: 0px; display: inline; float: none; padding: 0px;">
<div style="border: #000080 1px solid; color: #000; font-family: 'Courier New', Courier, Monospace; font-size: 10pt;">
<div style="background: #000080; color: #fff; font-family: Verdana, Tahoma, Arial, sans-serif; font-weight: bold; padding: 2px 5px;">For TFS 2010</div>
<div style="background-color: #ffffff; max-height: 300px; overflow: auto; padding: 2px 5px;"><span style="color: #0000ff;">use</span> Tfs_DefaultCollection
<span style="color: #0000ff;">select</span>  <span style="color: #ff00ff;">SUBSTRING</span><span style="color: #808080;">(</span><span style="color: #0000ff;">filename</span><span style="color: #808080;">,</span><span style="color: #ff00ff;">len</span><span style="color: #808080;">(</span><span style="color: #0000ff;">filename</span><span style="color: #808080;">)-</span><span style="color: #ff00ff;">CHARINDEX</span><span style="color: #808080;">(</span><span style="color: #ff0000;">'.'</span><span style="color: #808080;">,</span><span style="color: #ff00ff;">REVERSE</span><span style="color: #808080;">(</span><span style="color: #0000ff;">filename</span><span style="color: #808080;">))+</span>2<span style="color: #808080;">,</span>999<span style="color: #808080;">)</span><span style="color: #0000ff;">as</span> Extension<span style="color: #808080;">,</span> <span style="color: #ff00ff;">sum</span><span style="color: #808080;">(</span>compressedlength<span style="color: #808080;">)/</span>1024 <span style="color: #0000ff;">as</span> SizeInKB <span style="color: #0000ff;">from</span> tbl_Attachment
<span style="color: #0000ff;">group</span> <span style="color: #0000ff;">by</span> <span style="color: #ff00ff;">SUBSTRING</span><span style="color: #808080;">(</span><span style="color: #0000ff;">filename</span><span style="color: #808080;">,</span><span style="color: #ff00ff;">len</span><span style="color: #808080;">(</span><span style="color: #0000ff;">filename</span><span style="color: #808080;">)-</span><span style="color: #ff00ff;">CHARINDEX</span><span style="color: #808080;">(</span><span style="color: #ff0000;">'.'</span><span style="color: #808080;">,</span><span style="color: #ff00ff;">REVERSE</span><span style="color: #808080;">(</span><span style="color: #0000ff;">filename</span><span style="color: #808080;">))+</span>2<span style="color: #808080;">,</span>999<span style="color: #808080;">)</span>
<span style="color: #0000ff;">order</span> <span style="color: #0000ff;">by</span> <span style="color: #ff00ff;">sum</span><span style="color: #808080;">(</span>compressedlength<span style="color: #808080;">)</span> <span style="color: #0000ff;">desc</span></div>
</div>
</div>
<div id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:c94ded8e-cee9-4e76-892f-eb98ce4acbe7" class="wlWriterEditableSmartContent" style="margin: 0px; display: inline; float: none; padding: 0px;">
<div style="border: #000080 1px solid; color: #000; font-family: 'Courier New', Courier, Monospace; font-size: 10pt;">
<div style="background: #000080; color: #fff; font-family: Verdana, Tahoma, Arial, sans-serif; font-weight: bold; padding: 2px 5px;">For TFS 2012</div>
<div style="background-color: #ffffff; max-height: 300px; overflow: auto; padding: 2px 5px;"><span style="color: #0000ff;">use</span> Tfs_DefaultCollection
<span style="color: #0000ff;">select</span>  <span style="color: #ff00ff;">SUBSTRING</span><span style="color: #808080;">(</span>a<span style="color: #808080;">.</span><span style="color: #0000ff;">filename</span><span style="color: #808080;">,</span><span style="color: #ff00ff;">len</span><span style="color: #808080;">(</span>a<span style="color: #808080;">.</span><span style="color: #0000ff;">filename</span><span style="color: #808080;">)-</span><span style="color: #ff00ff;">CHARINDEX</span><span style="color: #808080;">(</span><span style="color: #ff0000;">'.'</span><span style="color: #808080;">,</span><span style="color: #ff00ff;">REVERSE</span><span style="color: #808080;">(</span>a<span style="color: #808080;">.</span><span style="color: #0000ff;">filename</span><span style="color: #808080;">))+</span>2<span style="color: #808080;">,</span>999<span style="color: #808080;">)</span><span style="color: #0000ff;">as</span> Extension<span style="color: #808080;">,</span> <span style="color: #ff00ff;">sum</span><span style="color: #808080;">(</span>f<span style="color: #808080;">.</span>compressedlength<span style="color: #808080;">)/</span>1024 <span style="color: #0000ff;">as</span> SizeInKB <span style="color: #0000ff;">from</span> tbl_Attachment <span style="color: #0000ff;">as</span> a
<span style="color: #808080;">inner</span> <span style="color: #808080;">join</span> tbl_File <span style="color: #0000ff;">as</span> f <span style="color: #0000ff;">on</span> a<span style="color: #808080;">.</span>TfsFileId<span style="color: #808080;">=</span>f<span style="color: #808080;">.</span>fileid
<span style="color: #0000ff;">group</span> <span style="color: #0000ff;">by</span> <span style="color: #ff00ff;">SUBSTRING</span><span style="color: #808080;">(</span>a<span style="color: #808080;">.</span><span style="color: #0000ff;">filename</span><span style="color: #808080;">,</span><span style="color: #ff00ff;">len</span><span style="color: #808080;">(</span>a<span style="color: #808080;">.</span><span style="color: #0000ff;">filename</span><span style="color: #808080;">)-</span><span style="color: #ff00ff;">CHARINDEX</span><span style="color: #808080;">(</span><span style="color: #ff0000;">'.'</span><span style="color: #808080;">,</span><span style="color: #ff00ff;">REVERSE</span><span style="color: #808080;">(</span>a<span style="color: #808080;">.</span><span style="color: #0000ff;">filename</span><span style="color: #808080;">))+</span>2<span style="color: #808080;">,</span>999<span style="color: #808080;">)</span>
<span style="color: #0000ff;">order</span> <span style="color: #0000ff;">by</span> <span style="color: #ff00ff;">sum</span><span style="color: #808080;">(</span>f<span style="color: #808080;">.</span>compressedlength<span style="color: #808080;">)</span> <span style="color: #0000ff;">desc</span></div>
</div>
</div>
This gives a result like this:

<a href="http://gwb.blob.core.windows.net/terje/Windows-Live-Writer/9d5d9927ea0a_143E6/image_10.png"><img style="background-image: none; margin: 0px; padding-left: 0px; padding-right: 0px; display: inline; padding-top: 0px; border-width: 0px;" title="image" src="http://hermit.no/wp-content/uploads/2015/08/GWB-Windows-Live-Writer-9d5d9927ea0a_143E6-image_thumb_4.png" alt="image" width="162" height="244" border="0" /></a>

Now you should have collected enough information to tell you what to do – if you got to do something, and some of the information you need in order to set up your TAC settings file, both for a cleanup and for scheduled maintenance later.

<strong><span style="font-size: medium;">Step 3: Cleaning out the attachments</span></strong>

The TAC is run from the command line using a set of parameters and controlled by a settingsfile.  The parameters point out a server uri including the team project collection and also point at a specific team project. So in order to run this for multiple team projects regularly one has to set up a script to run the TAC multiple times, once for each team project.  When you install the TAC there is a very useful readme file in the same directory.

There  are some guidelines about running the TAC from Ravi Shanker:
<ul>
	<li>“<i>When you run TAC, ensure that you are deleting small chunks of data at regular intervals (say run TAC every night at 3AM to delete data that is between age 730 to 731 days) – this will ensure that small amounts of data are being deleted and SQL ghosted record cleanup can catch up with the number of deletes performed. “</i>
<ul>
	<li>This rule minimizes the risk of the ghosted hang problem to occur, and further makes it easier for the SQL server ghosting process to work smoothly.</li>
</ul>
</li>
	<li><i>“Run DBCC SHRINKDB post the ghosted records are cleaned up to physically reclaim the space on the file system”</i>
<ul>
	<li>This is the last step in a 3 step process of removing SQL server data. First they are logically deleted. Then they are cleaned out by the ghosting process, and finally removed using the shrinkdb command.</li>
</ul>
</li>
</ul>
<ul><!--EndFragment--></ul>
When the deployment binaries are published to the TFS server, ALL items are published up from the deployment folder. That often means much more files than you would assume are necessary. This is a brute force technique. It works, but you need to take care when cleaning up.

Grant has shown how their settings file looks in his blog post, removing all attachments older than 180 days , as long as there are no active workitems connected to them. This setting can be useful to clean out all items, both in a clean-up once operation, and in a general cleanup.

There are two scenarios we need to consider:
<ol>
	<li>Cleaning up an existing overgrown database</li>
	<li>Maintaining a server to avoid an overgrown database using scheduled TAC</li>
</ol>
<strong>3.1: Cleaning up a database which has grown too big due to these attachments.</strong>

This job is a “Once” job.  We do this once and then move on to make sure it won’t happen again, by taking the actions in 2) below.  In this scenario you should only consider the large files. Your goal should be to simply reduce the size, and don’t bother about  the smaller stuff. That can be left a scheduled TAC cleanup ( 2 below).

Here you can use a very general settings file, and just remove the large attachments, or you can choose to remove any old items.  Grant’s settings file is an example of the last one.  A settings file to remove only large attachments could look like this:
<table border="0" width="400" cellspacing="0" cellpadding="2">
<tbody>
<tr>
<td valign="top" width="400">
<pre class="csharpcode"><span class="rem">&lt;!-- Scenario : Remove large files --&gt;</span>
<span class="kwrd">&lt;</span><span class="html">DeletionCriteria</span><span class="kwrd">&gt;</span>
    <span class="kwrd">&lt;</span><span class="html">TestRun</span> <span class="kwrd">/&gt;</span>
    <span class="kwrd">&lt;</span><span class="html">Attachment</span><span class="kwrd">&gt;</span>
        <span class="kwrd">&lt;</span><span class="html">SizeInMB</span> <span class="attr">GreaterThan</span><span class="kwrd">="10"</span> <span class="kwrd">/&gt;</span>
    <span class="kwrd">&lt;/</span><span class="html">Attachment</span><span class="kwrd">&gt;</span>
<span class="kwrd">&lt;/</span><span class="html">DeletionCriteria</span><span class="kwrd">&gt;</span></pre>
</td>
</tr>
</tbody>
</table>
Or like this:

If you want only to remove dll’s and pdb’s about that size, add an Extensions-section.  Without that section, all extensions will be deleted.
<table border="0" width="400" cellspacing="0" cellpadding="2">
<tbody>
<tr>
<td valign="top" width="400">
<pre class="csharpcode"><span class="rem">&lt;!-- Scenario : Remove large files of type dll's and pdb's --&gt;</span>
<span class="kwrd">&lt;</span><span class="html">DeletionCriteria</span><span class="kwrd">&gt;</span>
    <span class="kwrd">&lt;</span><span class="html">TestRun</span> <span class="kwrd">/&gt;</span>
    <span class="kwrd">&lt;</span><span class="html">Attachment</span><span class="kwrd">&gt;</span>
        <span class="kwrd">&lt;</span><span class="html">SizeInMB</span> <span class="attr">GreaterThan</span><span class="kwrd">="10"</span> <span class="kwrd">/&gt;</span>
        <span class="kwrd">&lt;</span><span class="html">Extensions</span><span class="kwrd">&gt;</span>
            <span class="kwrd">&lt;</span><span class="html">Include</span> <span class="attr">value</span><span class="kwrd">="dll"</span> <span class="kwrd">/&gt;</span>
            <span class="kwrd">&lt;</span><span class="html">Include</span> <span class="attr">value</span><span class="kwrd">="pdb"</span> <span class="kwrd">/&gt;</span>
        <span class="kwrd">&lt;/</span><span class="html">Extensions</span><span class="kwrd">&gt;</span>
    <span class="kwrd">&lt;/</span><span class="html">Attachment</span><span class="kwrd">&gt;</span>
<span class="kwrd">&lt;/</span><span class="html">DeletionCriteria</span><span class="kwrd">&gt;</span></pre>
</td>
</tr>
</tbody>
</table>
Before you start up your scheduled maintenance, you should clear out all older items.

<strong>3.2: Scheduled maintenance using the TAC</strong>

If you run a schedule every night, and remove old items, and also remove them in small batches.  It is important to run this often, like every night, in order to keep the number of deleted items low. That way the SQL ghost process works better.

One approach could be to delete all items older than some number of days, let’s say 180 days. This could be combined with restricting it to keep attachments with active or resolved bugs.  Doing this every night ensures that only small amounts of data are deleted.
<table border="0" width="400" cellspacing="0" cellpadding="2">
<tbody>
<tr>
<td valign="top" width="400">
<pre class="csharpcode"><span class="rem">&lt;!-- Scenario : Remove old items except if they have active or resolved bugs --&gt;</span>
<span class="kwrd">&lt;</span><span class="html">DeletionCriteria</span><span class="kwrd">&gt;</span> 
  <span class="kwrd">&lt;</span><span class="html">TestRun</span><span class="kwrd">&gt;</span> 
    <span class="kwrd">&lt;</span><span class="html">AgeInDays</span> <span class="attr">OlderThan</span><span class="kwrd">="180"</span> <span class="kwrd">/&gt;</span> 
  <span class="kwrd">&lt;/</span><span class="html">TestRun</span><span class="kwrd">&gt;</span> 
  <span class="kwrd">&lt;</span><span class="html">Attachment</span> <span class="kwrd">/&gt;</span> 
  <span class="kwrd">&lt;</span><span class="html">LinkedBugs</span><span class="kwrd">&gt;</span>     
     <span class="kwrd">&lt;</span><span class="html">Exclude</span> <span class="attr">state</span><span class="kwrd">="Active"</span> <span class="kwrd">/&gt;</span> 
     <span class="kwrd">&lt;</span><span class="html">Exclude</span> <span class="attr">state</span><span class="kwrd">="Resolved"</span><span class="kwrd">/&gt;</span>
  <span class="kwrd">&lt;/</span><span class="html">LinkedBugs</span><span class="kwrd">&gt;</span> 
<span class="kwrd">&lt;/</span><span class="html">DeletionCriteria</span><span class="kwrd">&gt;</span></pre>
</td>
</tr>
</tbody>
</table>
In my experience there are projects which are left with active or resolved workitems, although no further work is done.  It can be wise to have a cleanup process with no restrictions on linked bugs at all. Note that you then have to remove the whole LinkedBugs section.

A approach which could work better here is to do a two-step approach, use the schedule above to with no LinkedBugs as a sweeper cleaning task taking away all data older than you could care about.  Then have another scheduled TAC task to take out more specifically attachments that you are not likely to use. This task could be much more specific, and based on your analysis clean out what you know is troublesome data.
<table border="0" width="400" cellspacing="0" cellpadding="2">
<tbody>
<tr>
<td valign="top" width="400">
<pre class="csharpcode"><span class="rem">&lt;!-- Scenario : Remove specific files early --&gt;</span>
<span class="kwrd">&lt;</span><span class="html">DeletionCriteria</span><span class="kwrd">&gt;</span>
    <span class="kwrd">&lt;</span><span class="html">TestRun</span> <span class="kwrd">&gt;</span>
        <span class="kwrd">&lt;</span><span class="html">AgeInDays</span> <span class="attr">OlderThan</span><span class="kwrd">="30"</span> <span class="kwrd">/&gt;</span>
    <span class="kwrd">&lt;/</span><span class="html">TestRun</span><span class="kwrd">&gt;</span>
    <span class="kwrd">&lt;</span><span class="html">Attachment</span><span class="kwrd">&gt;</span>
        <span class="kwrd">&lt;</span><span class="html">SizeInMB</span> <span class="attr">GreaterThan</span><span class="kwrd">="10"</span> <span class="kwrd">/&gt;</span>
        <span class="kwrd">&lt;</span><span class="html">Extensions</span><span class="kwrd">&gt;</span>
            <span class="kwrd">&lt;</span><span class="html">Include</span> <span class="attr">value</span><span class="kwrd">="iTrace"</span><span class="kwrd">/&gt;</span>
            <span class="kwrd">&lt;</span><span class="html">Include</span> <span class="attr">value</span><span class="kwrd">="dll"</span><span class="kwrd">/&gt;</span>
            <span class="kwrd">&lt;</span><span class="html">Include</span> <span class="attr">value</span><span class="kwrd">="pdb"</span><span class="kwrd">/&gt;</span>
            <span class="kwrd">&lt;</span><span class="html">Include</span> <span class="attr">value</span><span class="kwrd">="wmv"</span><span class="kwrd">/&gt;</span>
        <span class="kwrd">&lt;/</span><span class="html">Extensions</span><span class="kwrd">&gt;</span>
    <span class="kwrd">&lt;/</span><span class="html">Attachment</span><span class="kwrd">&gt;</span>
    <span class="kwrd">&lt;</span><span class="html">LinkedBugs</span><span class="kwrd">&gt;</span>
        <span class="kwrd">&lt;</span><span class="html">Exclude</span> <span class="attr">state</span><span class="kwrd">="Active"</span> <span class="kwrd">/&gt;</span>
        <span class="kwrd">&lt;</span><span class="html">Exclude</span> <span class="attr">state</span><span class="kwrd">="Resolved"</span> <span class="kwrd">/&gt;</span>
    <span class="kwrd">&lt;/</span><span class="html">LinkedBugs</span><span class="kwrd">&gt;</span>
<span class="kwrd">&lt;/</span><span class="html">DeletionCriteria</span><span class="kwrd">&gt;</span></pre>
</td>
</tr>
</tbody>
</table>
The readme document for the TAC says that it recognizes “internal” extensions, but it does recognize any extension.

<strong>To run the tool, use the following command:</strong>
<table border="0" width="400" cellspacing="0" cellpadding="2">
<tbody>
<tr>
<td valign="top" width="400">
<pre class="csharpcode">tcmpt attachmentcleanup /collection:your_tfs_collection_url /teamproject:your_team_project /settingsfile:path_to_settingsfile /outputfile:%temp%/teamproject.tcmpt.log /mode:delete</pre>
</td>
</tr>
</tbody>
</table>
<strong>3.3: Shrinking the database</strong>

You could run a shrink database command after the TAC has run in cases where there are a lot of data being deleted.  In this case you SHOULD do it, to free up all that space.  But, after the shrink operation you should do a “rebuild indexes”, since the shrink operation will leave the database in a very fragmented state, which will reduce performance. Note that you need to rebuild indexes, reorganizing is not enough.

For smaller amounts of data you should NOT shrink the database, since the data will be reused by the SQL server when it needs to add more records.  In fact, it is regarded as a bad practice to shrink the database regularly.  On a daily maintenance schedule you should NOT shrink the database.

To shrink the database you do a DBCC SHRINKDATABASE command, and then follow up with a DBCC INDEXDEFRAG afterwards.  I find the easiest way to do this is to create a SQL Maintenance plan including the Shrink Database Task and the Rebuild Index Task and just execute it when you need to do this.