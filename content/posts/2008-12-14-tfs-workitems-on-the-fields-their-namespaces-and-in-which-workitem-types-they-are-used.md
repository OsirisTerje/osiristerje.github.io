---
id: 127888
title: 'TFS Workitems : On the fields, their namespaces and in which workitem types they are used'
date: 2008-12-14T16:06:34+01:00
author: terje
layout: post
guid: http://terje.wpengine.com/?p=127888
permalink: /tfs-workitems-on-the-fields-their-namespaces-and-in-which-workitem-types-they-are-used/
dsq_thread_id:
  - "5433811629"
categories:
  - Azure DevOps
  - Workitems
---
<p>At the moment there are five different popular process templates, three from Microsoft official, one on Codeplex (by some Microsoft guys afaik), and one from <a target="_blank" href="http://scrumforteamsystem.com/en/default.aspx">Conchango</a>.  The fields defined in the workitemtypes found in these templates belongs to a set of namespaces.  The System namespace is a predefined Microsoft namespace, with special behavior.  The other ones are in reality free text.  However, since some effort has been placed on defining these namespaces, and some of these fields are used in several reports, in mappings to Microsoft Project etc., it is wise to adhere to these definitions. It will at least reduce the work you have to do if you're modifying them, or defining your own types.  It is also wise to keep the fields named as equally as possible between types, and even processes, because it also simplifies querying across types. See <a title="http://teamfoundation.blogspot.com/2008/05/work-item-customization-tidbits-part-1.html" href="http://teamfoundation.blogspot.com/2008/05/work-item-customization-tidbits-part-1.html">http://teamfoundation.blogspot.com/2008/05/work-item-customization-tidbits-part-1.html</a> for a great tutorial on how-to-do-it.</p>
<p>I have listed out the different namespaces, and linked the fields up to whatever workitem type is using them.  I've only included the Microsoft'ish templates - the Conchango template only use the System namespace in addition to its own defined namespace fields.</p>
<p>The Process templates described are:</p>
<p><strong>Microsoft CMMI 4.2   <a target="_blank" href="http://www.microsoft.com/Downloads/details.aspx?FamilyID=12a8d806-bb98-4eb4-bf6b-fb5b266171eb&amp;displaylang=en">CMMI Download</a></strong></p>
<p><strong>Microsoft Agile 4.2  <a target="_blank" href="http://www.microsoft.com/DOWNLOADS/details.aspx?FamilyID=ea75784e-3a3f-48fb-824e-828bf593c34d&amp;displaylang=en">Agile Download</a></strong></p>
<p><strong>Microsoft eScrum 1.1 <a target="_blank" href="http://www.microsoft.com/downloads/details.aspx?familyid=55a4bde6-10a7-4c41-9938-f388c1ed15e9&amp;displaylang=en">eScrum Download</a></strong></p>
<p><strong>Codeplex VSTS Scrum 2.1  <a target="_blank" href="http://www.codeplex.com/VSTSScrum">VSTS Scrum Download</a></strong></p>
<p> </p>
<p>Even if a workitem type has the field defined, it doesn't mean it really uses the field, that is, fills it with useful information. </p>
<p> </p>
<p>The different namespaces used in these processes are listed below, and their details below that again:</p>
<table border="1" cellspacing="0" cellpadding="2" width="921">
    <tbody>
        <tr>
            <td valign="top" width="207"><strong>Namespace</strong></td>
            <td valign="top" width="151"><strong>No of defined fields</strong></td>
            <td valign="top" width="553"><strong>Comment</strong></td>
        </tr>
        <tr>
            <td valign="top" width="207">System</td>
            <td valign="top" width="151">26</td>
            <td valign="top" width="546">These fields have special behavior. Even if they are not present in a WIT, they can still be filled with information which can be read from the API or a query. See details <a title="http://msdn.microsoft.com/en-us/library/ms194971.aspx" href="http://msdn.microsoft.com/en-us/library/ms194971.aspx">http://msdn.microsoft.com/en-us/library/ms194971.aspx</a>.</td>
        </tr>
        <tr>
            <td valign="top" width="207">Microsoft.VSTS.Common</td>
            <td valign="top" width="151">18</td>
            <td valign="top" width="541">Here they've packed in the most common fields, which is used across several processes and types.</td>
        </tr>
        <tr>
            <td valign="top" width="207">Microsoft.VSTS.Build</td>
            <td valign="top" width="151">2</td>
            <td valign="top" width="537">Used by the build system. See <a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms194965.aspx">details here</a></td>
        </tr>
        <tr>
            <td valign="top" width="207">Microsoft.VSTS.Scheduling</td>
            <td valign="top" width="151">7</td>
            <td valign="top" width="534">Used in Microsoft Project mappings. See f.e. <a title="http://msdn.microsoft.com/en-us/library/ms364081.aspx" href="http://msdn.microsoft.com/en-us/library/ms364081.aspx">http://msdn.microsoft.com/en-us/library/ms364081.aspx</a> and <a title="http://www.devx.com/dotnet/Article/30187/1954" href="http://www.devx.com/dotnet/Article/30187/1954">http://www.devx.com/dotnet/Article/30187/1954</a></td>
        </tr>
        <tr>
            <td valign="top" width="207">Microsoft.VSTS.Test</td>
            <td valign="top" width="151">3</td>
            <td valign="top" width="531">Used by the test system See <a title="http://msdn.microsoft.com/en-us/library/ms194965.aspx" href="http://msdn.microsoft.com/en-us/library/ms194965.aspx">http://msdn.microsoft.com/en-us/library/ms194965.aspx</a></td>
        </tr>
        <tr>
            <td valign="top" width="207">Microsoft.VSTS.CMMI</td>
            <td valign="top" width="151">40</td>
            <td valign="top" width="529"> </td>
        </tr>
        <tr>
            <td valign="top" width="207">Microsoft.eScrum.Common</td>
            <td valign="top" width="151">4</td>
            <td valign="top" width="528"> </td>
        </tr>
        <tr>
            <td valign="top" width="207">Microsoft.eScrum.Product</td>
            <td valign="top" width="151">2</td>
            <td valign="top" width="527"> </td>
        </tr>
        <tr>
            <td valign="top" width="207">Microsoft.eScrum.Sprint</td>
            <td valign="top" width="151">3</td>
            <td valign="top" width="526"> </td>
        </tr>
        <tr>
            <td valign="top" width="207">Microsoft.eScrum.Retrospective</td>
            <td valign="top" width="151">4</td>
            <td valign="top" width="525"> </td>
        </tr>
        <tr>
            <td valign="top" width="207">Microsoft.eTools.Bug</td>
            <td valign="top" width="151">18</td>
            <td valign="top" width="525">Probably a leftover from older days, guess it also should have been eScrum, not eTools</td>
        </tr>
        <tr>
            <td valign="top" width="207">Microsoft.eScrum.Task</td>
            <td valign="top" width="151">2</td>
            <td valign="top" width="525"> </td>
        </tr>
        <tr>
            <td valign="top" width="207">Scrum</td>
            <td valign="top" width="151">4</td>
            <td valign="top" width="525"> </td>
        </tr>
    </tbody>
</table>
<p> </p>
<p> </p>
<p><strong>System Namespace:</strong>  (This is the only namespace which is also documented on MSDN)</p>
<div style="direction: ltr">
<table border="1" cellspacing="0" cellpadding="0" valign="top" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; border-collapse: collapse; direction: ltr; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid">
    <tbody>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt; font-weight: bold"> </p>
            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt; font-weight: bold">Used in CMMI</p>
            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt; font-weight: bold">Used in Agile</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt; font-weight: bold">Used in eScrum</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt; font-weight: bold">Used in VSTS Scrum</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">AreaId</p>
            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">AreaPath</p>
            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Risk,Review,Req,Issue,CR,Bug,Task</p>
            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Scenario,Risk,QoS,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">PBI,PD,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Backlog,UserStory,Defect,Impediment,Release,Review</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">AssignedTo</p>
            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Risk,Review,Req,Issue,CR,Bug,Task</p>
            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Scenario,Risk,QoS,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">PBI,PD,SD,SR,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Backlog,UserStory,Defect,Impediment,Release,Review</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">AttachedFileCount</p>
            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">AuthorizedAs</p>
            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">ChangedBy</p>
            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Risk,Review,Req,Issue,CR,Bug,Task</p>
            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Scenario,Risk,QoS,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">PD,SD</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Backlog,UserStory,Defect,Impediment,Release,Review</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">ChangedDate</p>
            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Risk,Review,Req,Issue,CR,Bug,Task</p>
            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Scenario,Risk,QoS,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">PD,SD,Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Backlog,UserStory,Defect,Impediment,Release,Review</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">CreatedBy</p>
            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Risk,Review,Req,Issue,CR,Bug,Task</p>
            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Scenario,Risk,QoS,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">PD,SD,Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Backlog,UserStory,Defect,Impediment,Release,Review</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">CreatedDate</p>
            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Risk,Review,Req,Issue,CR,Bug,Task</p>
            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Scenario,Risk,QoS,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">PD,SD,Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Backlog,UserStory,Defect,Impediment,Release,Review</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Description</p>
            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Risk,Review,Req,Issue,CR,Task</p>
            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Scenario,Risk,QoS,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">PBI,PD,SD,SR,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Backlog,UserStory,Defect,Impediment,Release</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">ExternalLinkCount</p>
            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">History</p>
            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Risk,Review,Req,Issue,CR,Bug,Task</p>
            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Scenario,Risk,QoS,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">(PBI),PD,SD,SR,Bug,(Task)</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Backlog,UserStory,Defect,Impediment,Release,Review</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">HyperLinkCount</p>
            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Id</p>
            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Risk,Review,Req,Issue,CR,Bug,Task</p>
            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Scenario,Risk,QoS,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">PBI,PD,SD,SR,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Backlog,UserStory,Defect,Impediment,Release,Review</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">IterationId</p>
            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">IterationPath</p>
            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Risk,Review,Req,Issue,CR,Bug,Task</p>
            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Scenario,Risk,QoS,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">SD,SR,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Backlog,UserStory,Defect,Impediment,Release,Review</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">NodeName</p>
            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Reason</p>
            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Risk,Review,Req,Issue,CR,Bug,Task</p>
            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Scenario,Risk,QoS,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Backlog,UserStory,Defect,Impediment,Release,Review</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">RelatedLinkCount</p>
            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Rev</p>
            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">RevisedDate</p>
            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">State</p>
            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Risk,Review,Req,Issue,CR,Bug,Task</p>
            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Scenario,Risk,QoS,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">PBI,PD,SD,SR,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Backlog,UserStory,Defect,Impediment,Release,Review</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">TeamProject</p>
            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">TeamProject</p>
            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Title</p>
            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Risk,Review,Req,Issue,CR,Bug,Task</p>
            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Scenario,Risk,QoS,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">PBI,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Backlog,UserStory,Defect,Impediment,Release,Review</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">WorkItemType</p>
            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
        </tr>
    </tbody>
</table>
</div>
<p>For CMMI:  CR = Change Request, QoS = QualityOfService requirement, Req = Requirement</p>
<p>For eScrum: PD = ProductDetails, SD = SprintDetails, SR = SprintRetrospective, Task = SprintTask, PBI = ProductBacklogItem</p>
<p> </p>
<p><strong>Microsoft.VSTS.Common namespace</strong></p>
<p> </p>
<div style="direction: ltr">
<table border="1" cellspacing="0" cellpadding="0" valign="top" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; border-collapse: collapse; direction: ltr; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid">
    <tbody>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt; font-weight: bold">Name</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt; font-weight: bold">Used in CMMI</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt; font-weight: bold">Used in Agile</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt; font-weight: bold">Used in eScrum</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt; font-weight: bold">Used in VSTS Scrum</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">ActivatedBy</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Risk,Review,Requirement,Issue,CR,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Scenario,Risk,QoS,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Backlog,UserStory,Defect,Impediment,Release,Review</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">ActivatedDate</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Risk,Review,Requirement,Issue,CR,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Scenario,Risk,QoS,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Backlog,UserStory,Defect,Impediment,Release,Review</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">ClosedBy</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Risk,Review,RRequirementeq,Issue,CR,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Scenario,Risk,QoS,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Backlog,UserStory,Defect,Impediment,Release,Review</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">ClosedDate</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Risk,Review,Requirement,Issue,CR,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Scenario,Risk,QoS,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Backlog,UserStory,Defect,Impediment,Release,Review</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Discipline</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Backlog,UserStory</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Exit Criteria</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Risk,Requirement,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Scenario,Risk,QoS,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Backlog,UserStory,Release</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Issue</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Risk,Requirement,Issue,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Scenario,Risk,QoS,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Backlog,UserStory,Defect,Impediment,Release</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">IssueType</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt; font-weight: bold"> </p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Priority</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Risk,Requirement,Issue,CR,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Backlog,UserStory,Defect,Impediment,Release</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">QualityOfServiceType</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">QoS</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt; font-weight: bold"> </p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Rank</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Risk,Requirement,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Scenario,Risk,QoS,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Backlog,UserStory,Release</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Regression</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt; font-weight: bold"> </p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">ResolvedBy</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Risk,Review,Requirement,Issue,CR,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Scenario,QoS,Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Backlog,UserStory,Defect,Impediment,Release,Review</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">ResolvedDate</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Risk,Review,Requirement,Issue,CR,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Scenario,QoS,Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Backlog,UserStory,Defect,Impediment,Release,Review</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">ResolvedReason</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt"> </p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Defect</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">RoughOrderOfMagnitude</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt"> </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Scenario,QoS</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt"> </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt"> </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Severity</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Risk,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Risk</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt; font-weight: bold"> </p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">StateChangeDate</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Risk,Review,Requirement,Issue,CR,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Scenario,Risk,QoS,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Backlog,UserStory,Defect,Impediment,Release,Review</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Triage</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Requirement,Issue,CR,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; color: black; font-size: 11pt">Defect,Impediment</p>
            </td>
        </tr>
    </tbody>
</table>
</div>
<p> </p>
<p> <strong>Microsoft.VSTS.Build namespace</strong></p>
<p> </p>
<div style="direction: ltr">
<table border="1" cellspacing="0" cellpadding="0" valign="top" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; border-collapse: collapse; direction: ltr; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid">
    <tbody>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.084in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Name</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.957in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt"><strong>Used in CMMI :</strong></p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.611in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt"><strong>Used in Agile :</strong></p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.115in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt"><strong>Used in eScrum </strong></p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.927in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt"><strong>Used in VSTS Scrum:</strong></p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.084in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">FoundIn</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.957in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Risk,Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.611in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Risk,Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.115in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.927in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Defect</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.084in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">IntegrationBuild</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.957in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Risk,Review,Req,Issue,CR,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.611in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Scenario,Risk,QoS,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.115in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.927in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Backlog,UserStory,Defect,Impediment,Release,Review</p>
            </td>
        </tr>
    </tbody>
</table>
</div>
<p style="margin: 0in; font-family: calibri; font-size: 11pt">CR = Change Request, QoS = QualityOfService requirement, Req = Requirement</p>
<p><strong>Microsoft.VSTS.Scheduling namespace</strong></p>
<div style="direction: ltr">
<table border="1" cellspacing="0" cellpadding="0" valign="top" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; border-collapse: collapse; direction: ltr; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid">
    <tbody>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.799in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Name</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.527in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt"><strong>Used in CMMI</strong></p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.352in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt"><strong>Used in Agile</strong></p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.227in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt"><strong>Used in eScrum</strong></p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.895in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt"><strong>Used in VSTS Scrum</strong></p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.799in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">RemainingWork</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.527in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Risk,Req,CR,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.352in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.227in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.895in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Backlog,UserStory,Release</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.799in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">CompletedWork</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.527in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Risk,Req,CR,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.352in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.227in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.895in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Backlog,UserStory,Release</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.799in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">BaselineWork</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.527in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Risk,Req,CR,Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.352in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.227in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">PBI,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.895in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Backlog,UserStory,Release</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.799in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">StartDate</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.527in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.352in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Scenario,QoS,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.227in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt"> </p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.895in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Backlog,UserStory,Release</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.799in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">FinishDate</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.527in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.352in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Scenario,QoS,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.227in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt"> </p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.895in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Backlog,UserStory,Release</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.799in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">TaskHierarchy</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.527in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.352in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.227in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.895in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Backlog,UserStory,Release</p>
            </td>
        </tr>
    </tbody>
</table>
</div>
<div style="direction: ltr"> </div>
<div style="direction: ltr">CR = Change Request, QoS = QualityOfService requirement, Req = Requirement</div>
<p style="margin: 0in; font-family: calibri; font-size: 11pt"> </p>
<p><strong>Microsoft.VSTS.Test namespace</strong></p>
<div style="direction: ltr">
<table border="1" cellspacing="0" cellpadding="0" valign="top" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; border-collapse: collapse; direction: ltr; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid">
    <tbody>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.843in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt"><strong>Name</strong></p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.101in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt"><strong>Used in CMMI</strong></p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.026in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt"><strong>Used in Agile</strong></p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.597in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt"><strong>Used in eScrum types</strong></p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.454in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt"><strong>Used in VSTS Scrum</strong></p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.843in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt"> </p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.101in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt"> </p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.026in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt"> </p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.597in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt"> </p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.454in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt"> </p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.843in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">TestName</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.101in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.026in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Risk,Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.597in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.454in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Defect</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.843in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">TestId</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.101in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.026in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Risk,Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.597in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.454in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Defect</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.843in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">TestPath</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.101in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Bug,Task</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.026in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Risk,Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.597in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Bug</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.454in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Defect</p>
            </td>
        </tr>
    </tbody>
</table>
</div>
<p style="margin: 0in; font-family: calibri; font-size: 11pt"> </p>
<p> </p>
<p><strong>Microsoft.VSTS.CMMI namespace</strong>     (Not used in Agile or eScrum)</p>
<p> </p>
<table border="1" cellspacing="0" cellpadding="2" width="400">
    <tbody>
        <tr>
            <td valign="top" width="133"><strong>Name</strong></td>
            <td valign="top" width="133"><strong>Used in CMMI</strong></td>
            <td valign="top" width="133"><strong>Used in VSTS Scrum</strong></td>
        </tr>
        <tr>
            <td valign="top" width="133">
            <p>ActualAttendee[1-8]</p>
            </td>
            <td valign="top" width="133">
            <p>Review</p>
            </td>
            <td valign="top" width="133"> </td>
        </tr>
        <tr>
            <td valign="top" width="133">
            <p>Analysis</p>
            </td>
            <td valign="top" width="133">
            <p>Issue</p>
            </td>
            <td valign="top" width="133">
            <p>Impediment</p>
            </td>
        </tr>
        <tr>
            <td valign="top" width="133">
            <p>Blocked</p>
            </td>
            <td valign="top" width="133">
            <p>Risk,Requirement,CR,Bug,Task</p>
            </td>
            <td valign="top" width="133">
            <p>Backlog,UserStory,Defect,Release</p>
            </td>
        </tr>
        <tr>
            <td valign="top" width="133">
            <p>CalledBy</p>
            </td>
            <td valign="top" width="133">
            <p>Review</p>
            </td>
            <td valign="top" width="133">
            <p>Review</p>
            </td>
        </tr>
        <tr>
            <td valign="top" width="133">
            <p>CalledDate</p>
            </td>
            <td valign="top" width="133">
            <p>Review</p>
            </td>
            <td valign="top" width="133">
            <p>Review</p>
            </td>
        </tr>
        <tr>
            <td valign="top" width="133">
            <p>Comments</p>
            </td>
            <td valign="top" width="133">
            <p>Review</p>
            </td>
            <td valign="top" width="133">
            <p>Review</p>
            </td>
        </tr>
        <tr>
            <td valign="top" width="133">
            <p>Committed</p>
            </td>
            <td valign="top" width="133">
            <p>Requirement</p>
            </td>
            <td valign="top" width="133"> </td>
        </tr>
        <tr>
            <td valign="top" width="133">
            <p>CorrectiveActionActualResolution</p>
            </td>
            <td valign="top" width="133">
            <p>Issue</p>
            </td>
            <td valign="top" width="133">
            <p>Impediment</p>
            </td>
        </tr>
        <tr>
            <td valign="top" width="133">
            <p>CorrectiveActionPlan</p>
            </td>
            <td valign="top" width="133">
            <p>Issue</p>
            </td>
            <td valign="top" width="133">
            <p>Impediment</p>
            </td>
        </tr>
        <tr>
            <td valign="top" width="133">Escalate</td>
            <td valign="top" width="133">Issue</td>
            <td valign="top" width="133">Impediment</td>
        </tr>
        <tr>
            <td valign="top" width="133">Estimate</td>
            <td valign="top" width="133">Risk,Requirement,CR,Bug,Task</td>
            <td valign="top" width="133"> </td>
        </tr>
        <tr>
            <td valign="top" width="133">FoundInEnvironment</td>
            <td valign="top" width="133">Bug</td>
            <td valign="top" width="133"> </td>
        </tr>
        <tr>
            <td valign="top" width="133">HowFound</td>
            <td valign="top" width="133">Bug</td>
            <td valign="top" width="133"> </td>
        </tr>
        <tr>
            <td valign="top" width="133">ImpactAssessment</td>
            <td valign="top" width="133">Requirement</td>
            <td valign="top" width="133"> </td>
        </tr>
        <tr>
            <td valign="top" width="133">ImpactOnArchitecture</td>
            <td valign="top" width="133">Change Request</td>
            <td valign="top" width="133"> </td>
        </tr>
        <tr>
            <td valign="top" width="133">ImpactOnDevelopment</td>
            <td valign="top" width="133">Change Request</td>
            <td valign="top" width="133"> </td>
        </tr>
        <tr>
            <td valign="top" width="133">ImpactOnProjectPromise</td>
            <td valign="top" width="133">Issue</td>
            <td valign="top" width="133">Impediment</td>
        </tr>
        <tr>
            <td valign="top" width="133">ImpactOnTechnicalPublications</td>
            <td valign="top" width="133">Change Request</td>
            <td valign="top" width="133"> </td>
        </tr>
        <tr>
            <td valign="top" width="133">ImpactOnTest</td>
            <td valign="top" width="133">Change Request</td>
            <td valign="top" width="133"> </td>
        </tr>
        <tr>
            <td valign="top" width="133">ImpactOnUserExperience</td>
            <td valign="top" width="133">Change Request</td>
            <td valign="top" width="133"> </td>
        </tr>
        <tr>
            <td valign="top" width="133">Justification</td>
            <td valign="top" width="133">Change Request</td>
            <td valign="top" width="133"> </td>
        </tr>
        <tr>
            <td valign="top" width="133">MeetingType</td>
            <td valign="top" width="133">Review</td>
            <td valign="top" width="133">Review</td>
        </tr>
        <tr>
            <td valign="top" width="133">Minutes</td>
            <td valign="top" width="133">Review</td>
            <td valign="top" width="133">Review</td>
        </tr>
        <tr>
            <td valign="top" width="133">MitigationPlan</td>
            <td valign="top" width="133">Risk</td>
            <td valign="top" width="133"> </td>
        </tr>
        <tr>
            <td valign="top" width="133">MitigationTriggers</td>
            <td valign="top" width="133">Risk</td>
            <td valign="top" width="133"> </td>
        </tr>
        <tr>
            <td valign="top" width="133">OptionalAttendee[1-8]</td>
            <td valign="top" width="133">Review</td>
            <td valign="top" width="133"> </td>
        </tr>
        <tr>
            <td valign="top" width="133">Probability</td>
            <td valign="top" width="133">Risk</td>
            <td valign="top" width="133"> </td>
        </tr>
        <tr>
            <td valign="top" width="133">ProposedFix</td>
            <td valign="top" width="133">Bug</td>
            <td valign="top" width="133"> </td>
        </tr>
        <tr>
            <td valign="top" width="133">Purpose</td>
            <td valign="top" width="133">Review</td>
            <td valign="top" width="133">Review</td>
        </tr>
        <tr>
            <td valign="top" width="133">RequiredAttendee[1-8]</td>
            <td valign="top" width="133">Review</td>
            <td valign="top" width="133"> </td>
        </tr>
        <tr>
            <td valign="top" width="133">RequirementType</td>
            <td valign="top" width="133">Requirement</td>
            <td valign="top" width="133"> </td>
        </tr>
        <tr>
            <td valign="top" width="133">RequiresReview</td>
            <td valign="top" width="133">Task</td>
            <td valign="top" width="133"> </td>
        </tr>
        <tr>
            <td valign="top" width="133">RequiresTest</td>
            <td valign="top" width="133">Task</td>
            <td valign="top" width="133"> </td>
        </tr>
        <tr>
            <td valign="top" width="133">RootCause</td>
            <td valign="top" width="133">Bug</td>
            <td valign="top" width="133"> </td>
        </tr>
        <tr>
            <td valign="top" width="133">StepsToReproduce</td>
            <td valign="top" width="133">Bug</td>
            <td valign="top" width="133"> </td>
        </tr>
        <tr>
            <td valign="top" width="133">SubjectMatterExpert[1-3]</td>
            <td valign="top" width="133">Requirement</td>
            <td valign="top" width="133"> </td>
        </tr>
        <tr>
            <td valign="top" width="133">Symptom</td>
            <td valign="top" width="133">Bug</td>
            <td valign="top" width="133"> </td>
        </tr>
        <tr>
            <td valign="top" width="133">TargetResolveDate</td>
            <td valign="top" width="133">Issue</td>
            <td valign="top" width="133">Impediment</td>
        </tr>
        <tr>
            <td valign="top" width="133">TaskType</td>
            <td valign="top" width="133">Task</td>
            <td valign="top" width="133"> </td>
        </tr>
        <tr>
            <td valign="top" width="133">UserAcceptanceTest</td>
            <td valign="top" width="133">Requirement</td>
            <td valign="top" width="133">UserStory</td>
        </tr>
    </tbody>
</table>
<p> </p>
<p><strong>And then some special namespaces which are only used by one process</strong></p>
<p> </p>
<p><strong>Microsoft.eScrum.Common namespace</strong></p>
<div style="direction: ltr">
<table border="1" cellspacing="0" cellpadding="0" valign="top" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; border-collapse: collapse; direction: ltr; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid">
    <tbody>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.769in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt"><strong>Name</strong></p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.226in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt"><strong>Used in eScrum</strong></p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.769in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Category</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.226in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">ProductBacklogItem,SprintTask</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.769in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Order</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.226in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">ProductBacklogItem,SprintTask</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.769in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Goals</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.226in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">ProductBacklogItem,SprintDetails</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.769in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">Source</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.226in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">ProductBacklogItem</p>
            </td>
        </tr>
    </tbody>
</table>
</div>
<p> </p>
<p> </p>
<p><strong>Microsoft.eScrum.Product namespace</strong></p>
<div style="direction: ltr">
<table border="1" cellspacing="0" cellpadding="0" valign="top" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; border-collapse: collapse; direction: ltr; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid">
    <tbody>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.323in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt"><strong>Name</strong></p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.226in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt"><strong>Used in eScrum</strong></p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.323in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">MembersXml</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.226in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">ProductDetails</p>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.323in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">BugDatabasesXml</p>
            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.226in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt">ProductDetails</p>
            </td>
        </tr>
    </tbody>
</table>
</div>
<p style="margin: 0in; font-family: calibri; font-size: 11pt"> </p>
<ul style="margin-top: 0in; unicode-bidi: embed; direction: ltr; margin-bottom: 0in; margin-left: 0.074in">
    <p style="margin: 0in; font-family: calibri; font-size: 11pt"> </p>
    <p style="margin: 0in; font-family: calibri; font-size: 11pt"> </p>
    <p style="margin: 0in; font-family: calibri; font-size: 11pt"><strong>Microsoft.eScrum.Sprint namespace</strong></p>
    <div style="direction: ltr">
    <table border="1" cellspacing="0" cellpadding="0" valign="top" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; border-collapse: collapse; direction: ltr; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid">
        <tbody>
            <tr>
                <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.042in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                <p style="margin: 0in; font-family: calibri; font-size: 11pt; font-weight: bold">Name</p>
                </td>
                <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.243in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                <p style="margin: 0in; font-family: calibri; font-size: 11pt; font-weight: bold">Used in eScrum</p>
                </td>
            </tr>
            <tr>
                <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.042in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                <p style="margin: 0in; font-family: calibri; font-size: 11pt">StartDate</p>
                </td>
                <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.243in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                <p style="margin: 0in; font-family: calibri; font-size: 11pt">SprintDetails</p>
                </td>
            </tr>
            <tr>
                <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.042in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                <p style="margin: 0in; font-family: calibri; font-size: 11pt">EndDate</p>
                </td>
                <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.243in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                <p style="margin: 0in; font-family: calibri; font-size: 11pt">SprintDetails</p>
                </td>
            </tr>
            <tr>
                <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.042in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                <p style="margin: 0in; font-family: calibri; font-size: 11pt">MembersXml</p>
                </td>
                <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.243in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                <p style="margin: 0in; font-family: calibri; font-size: 11pt"> </p>
                </td>
            </tr>
        </tbody>
    </table>
    </div>
    <div style="direction: ltr"> </div>
    <ul style="margin-top: 0in; unicode-bidi: embed; direction: ltr; margin-bottom: 0in; margin-left: 0.074in">
        <p style="margin: 0in; font-family: calibri; font-size: 11pt"> </p>
        <p style="margin: 0in; font-family: calibri; font-size: 11pt"> </p>
        <p style="margin: 0in; font-family: calibri; font-size: 11pt"><strong>Microsoft.eScrum.SprintRetrospective</strong></p>
        <div style="direction: ltr">
        <table border="1" cellspacing="0" cellpadding="0" valign="top" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; border-collapse: collapse; direction: ltr; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid">
            <tbody>
                <tr>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.448in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt"><strong>Name</strong></p>
                    </td>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.487in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt"><strong>Used in eScrum</strong></p>
                    </td>
                </tr>
                <tr>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.448in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">Date</p>
                    </td>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.487in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">SprintRetrospective</p>
                    </td>
                </tr>
                <tr>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.448in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">WhatWentWell</p>
                    </td>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.487in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">SprintRetrospective</p>
                    </td>
                </tr>
                <tr>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.448in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">WhatDidNotGoWell</p>
                    </td>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.487in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">SprintRetrospective</p>
                    </td>
                </tr>
                <tr>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.448in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">Improvements</p>
                    </td>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.487in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">SprintRetrospective</p>
                    </td>
                </tr>
            </tbody>
        </table>
        </div>
        <p style="margin: 0in; font-family: calibri; font-size: 11pt"> </p>
    </ul>
    <ul style="margin-top: 0in; unicode-bidi: embed; direction: ltr; margin-bottom: 0in; margin-left: 0.074in">
        <p style="margin: 0in; font-family: calibri; font-size: 11pt"> </p>
        <p style="margin: 0in; font-family: calibri; font-size: 11pt"> </p>
        <p style="margin: 0in; font-family: calibri; font-size: 11pt"><strong>Microsoft.eTools.Bug namespace</strong></p>
        <div style="direction: ltr">
        <table border="1" cellspacing="0" cellpadding="0" valign="top" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; border-collapse: collapse; direction: ltr; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid">
            <tbody>
                <tr>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.016in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt"><strong>Name</strong></p>
                    </td>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.226in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt"><strong>Used in eScrum</strong></p>
                    </td>
                </tr>
                <tr>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.016in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">ReproSteps</p>
                    </td>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.226in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">Bug</p>
                    </td>
                </tr>
                <tr>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.016in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">DevEstimate</p>
                    </td>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.226in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">Bug</p>
                    </td>
                </tr>
                <tr>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.016in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">TestEstimate</p>
                    </td>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.226in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">Bug</p>
                    </td>
                </tr>
                <tr>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.016in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">PMEstimate</p>
                    </td>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.226in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">Bug</p>
                    </td>
                </tr>
                <tr>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.016in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">Environment</p>
                    </td>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.226in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">Bug</p>
                    </td>
                </tr>
                <tr>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.016in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">Accessibility</p>
                    </td>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.226in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">Bug</p>
                    </td>
                </tr>
                <tr>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.016in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">Source</p>
                    </td>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.226in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">Bug</p>
                    </td>
                </tr>
                <tr>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.016in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">HowFound</p>
                    </td>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.226in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">Bug</p>
                    </td>
                </tr>
                <tr>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.016in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">Market</p>
                    </td>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.226in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">Bug</p>
                    </td>
                </tr>
                <tr>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.016in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">OSPlatform</p>
                    </td>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.226in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">Bug</p>
                    </td>
                </tr>
                <tr>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.016in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">Browsers</p>
                    </td>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.226in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">Bug</p>
                    </td>
                </tr>
                <tr>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.016in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">SourceID</p>
                    </td>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.226in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">Bug</p>
                    </td>
                </tr>
                <tr>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.016in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">Cause</p>
                    </td>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.226in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">Bug</p>
                    </td>
                </tr>
                <tr>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.016in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">Change</p>
                    </td>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.226in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">Bug</p>
                    </td>
                </tr>
                <tr>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.016in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">KBNeeded</p>
                    </td>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.226in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">Bug</p>
                    </td>
                </tr>
                <tr>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.016in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">Product</p>
                    </td>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.226in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">Bug</p>
                    </td>
                </tr>
                <tr>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.016in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">Release</p>
                    </td>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.226in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">Bug</p>
                    </td>
                </tr>
                <tr>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.016in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">Milestone</p>
                    </td>
                    <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.226in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                    <p style="margin: 0in; font-family: calibri; font-size: 11pt">Bug</p>
                    </td>
                </tr>
            </tbody>
        </table>
        </div>
        <div style="direction: ltr"> </div>
        <ul style="margin-top: 0in; unicode-bidi: embed; direction: ltr; margin-bottom: 0in; margin-left: 0.074in">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt"> </p>
            <p style="margin: 0in; font-family: calibri; font-size: 11pt"> </p>
            <p style="margin: 0in; font-family: calibri; font-size: 11pt"><strong>Microsoft.eScrum.Task namespace</strong></p>
            <div style="direction: ltr">
            <table border="1" cellspacing="0" cellpadding="0" valign="top" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; border-collapse: collapse; direction: ltr; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid">
                <tbody>
                    <tr>
                        <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.584in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                        <p style="margin: 0in; font-family: calibri; font-size: 11pt"><strong>Name</strong></p>
                        </td>
                        <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.226in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                        <p style="margin: 0in; font-family: calibri; font-size: 11pt"><strong>Used in eScrum</strong></p>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.584in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                        <p style="margin: 0in; font-family: calibri; font-size: 11pt">ProductBacklogItemId</p>
                        </td>
                        <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.226in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                        <p style="margin: 0in; font-family: calibri; font-size: 11pt">Task</p>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.584in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                        <p style="margin: 0in; font-family: calibri; font-size: 11pt">Discovered</p>
                        </td>
                        <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.226in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                        <p style="margin: 0in; font-family: calibri; font-size: 11pt">Task</p>
                        </td>
                    </tr>
                </tbody>
            </table>
            </div>
            <div style="direction: ltr"> </div>
            <div style="direction: ltr"> </div>
        </ul>
        <ul style="margin-top: 0in; unicode-bidi: embed; direction: ltr; margin-bottom: 0in; margin-left: 0.074in">
            <p style="margin: 0in; font-family: calibri; font-size: 11pt"> </p>
            <p style="margin: 0in; font-family: calibri; font-size: 11pt"><strong>Scrum namespace</strong></p>
            <div style="direction: ltr">
            <table border="1" cellspacing="0" cellpadding="0" valign="top" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; border-collapse: collapse; direction: ltr; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid">
                <tbody>
                    <tr>
                        <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.261in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                        <p style="margin: 0in; font-family: calibri; font-size: 11pt"><strong>Name</strong></p>
                        </td>
                        <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.904in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                        <p style="margin: 0in; font-family: calibri; font-size: 11pt"><strong>Used in VSTS Scrum</strong></p>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.261in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                        <p style="margin: 0in; font-family: calibri; font-size: 11pt">Complexity</p>
                        </td>
                        <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.904in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                        <p style="margin: 0in; font-family: calibri; font-size: 11pt">Backlog,UserStory,Release</p>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.261in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                        <p style="margin: 0in; font-family: calibri; font-size: 11pt">Acceptance</p>
                        </td>
                        <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.904in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                        <p style="margin: 0in; font-family: calibri; font-size: 11pt">UserStory</p>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.261in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                        <p style="margin: 0in; font-family: calibri; font-size: 11pt">Owner</p>
                        </td>
                        <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.904in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                        <p style="margin: 0in; font-family: calibri; font-size: 11pt">UserStory</p>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.261in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                        <p style="margin: 0in; font-family: calibri; font-size: 11pt">BuildInstructions</p>
                        </td>
                        <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.904in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
                        <p style="margin: 0in; font-family: calibri; font-size: 11pt">Release</p>
                        </td>
                    </tr>
                </tbody>
            </table>
            </div>
        </ul>
        <p style="margin: 0in; font-family: calibri; font-size: 11pt"> </p>
    </ul>
</ul>