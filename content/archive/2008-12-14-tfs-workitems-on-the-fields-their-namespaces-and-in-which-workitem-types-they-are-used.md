---
id: 127888
title: 'TFS Workitems : On the fields, their namespaces and in which workitem types they are used'
date: 2008-12-14T16:06:34+01:00
author: terje
layout: post
categories:
  - Azure DevOps
  - Workitems
---
At the moment there are five different popular process templates, three from Microsoft official, one on Codeplex (by some Microsoft guys afaik), and one from [Conchango](http://scrumforteamsystem.com/en/default.aspx).  The fields defined in the workitemtypes found in these templates belongs to a set of namespaces.  The System namespace is a predefined Microsoft namespace, with special behavior.  The other ones are in reality free text.  However, since some effort has been placed on defining these namespaces, and some of these fields are used in several reports, in mappings to Microsoft Project etc., it is wise to adhere to these definitions. It will at least reduce the work you have to do if you're modifying them, or defining your own types.  It is also wise to keep the fields named as equally as possible between types, and even processes, because it also simplifies querying across types. See [http://teamfoundation.blogspot.com/2008/05/work-item-customization-tidbits-part-1.html](http://teamfoundation.blogspot.com/2008/05/work-item-customization-tidbits-part-1.html) for a great tutorial on how-to-do-it.

I have listed out the different namespaces, and linked the fields up to whatever workitem type is using them.  I've only included the Microsoft'ish templates - the Conchango template only use the System namespace in addition to its own defined namespace fields.

The Process templates described are:

## Microsoft CMMI 4.2   [CMMI Download](http://www.microsoft.com/Downloads/details.aspx?FamilyID=12a8d806-bb98-4eb4-bf6b-fb5b266171eb&amp;displaylang=en)

### Microsoft Agile 4.2  [Agile Download](http://www.microsoft.com/DOWNLOADS/details.aspx?FamilyID=ea75784e-3a3f-48fb-824e-828bf593c34d&amp;displaylang=en)

#### Microsoft eScrum 1.1 [eScrum Download](http://www.microsoft.com/downloads/details.aspx?familyid=55a4bde6-10a7-4c41-9938-f388c1ed15e9&amp;displaylang=en)

##### Codeplex VSTS Scrum 2.1  [VSTS Scrum Download](http://www.codeplex.com/VSTSScrum)

Even if a workitem type has the field defined, it doesn't mean it really uses the field, that is, fills it with useful information.

The different namespaces used in these processes are listed below, and their details below that again:

<table border="1" cellspacing="0" cellpadding="2" width="921">
    <tbody>
        <tr>
            <td valign="top" width="207">**Namespace**</td>
            <td valign="top" width="151">**No of defined fields**</td>
            <td valign="top" width="553">**Comment**</td>
        </tr>
        <tr>
            <td valign="top" width="207">System</td>
            <td valign="top" width="151">26</td>
            <td valign="top" width="546">These fields have special behavior. Even if they are not present in a WIT, they can still be filled with information which can be read from the API or a query. See details [http://msdn.microsoft.com/en-us/library/ms194971.aspx](http://msdn.microsoft.com/en-us/library/ms194971.aspx).</td>
        </tr>
        <tr>
            <td valign="top" width="207">Microsoft.VSTS.Common</td>
            <td valign="top" width="151">18</td>
            <td valign="top" width="541">Here they've packed in the most common fields, which is used across several processes and types.</td>
        </tr>
        <tr>
            <td valign="top" width="207">Microsoft.VSTS.Build</td>
            <td valign="top" width="151">2</td>
            <td valign="top" width="537">Used by the build system. See [details here](http://msdn.microsoft.com/en-us/library/ms194965.aspx)</td>
        </tr>
        <tr>
            <td valign="top" width="207">Microsoft.VSTS.Scheduling</td>
            <td valign="top" width="151">7</td>
            <td valign="top" width="534">Used in Microsoft Project mappings. See f.e. [http://msdn.microsoft.com/en-us/library/ms364081.aspx](http://msdn.microsoft.com/en-us/library/ms364081.aspx) and [http://www.devx.com/dotnet/Article/30187/1954](http://www.devx.com/dotnet/Article/30187/1954)</td>
        </tr>
        <tr>
            <td valign="top" width="207">Microsoft.VSTS.Test</td>
            <td valign="top" width="151">3</td>
            <td valign="top" width="531">Used by the test system See [http://msdn.microsoft.com/en-us/library/ms194965.aspx](http://msdn.microsoft.com/en-us/library/ms194965.aspx)</td>
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

## System Namespace:

(This is the only namespace which is also documented on MSDN)

<div style="direction: ltr">
<table border="1" cellspacing="0" cellpadding="0" valign="top" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; border-collapse: collapse; direction: ltr; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid">
    <tbody>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Used in CMMI

            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Used in Agile

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Used in eScrum

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Used in VSTS Scrum

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            AreaId

            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            AreaPath

            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Risk,Review,Req,Issue,CR,Bug,Task

            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Scenario,Risk,QoS,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            PBI,PD,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Backlog,UserStory,Defect,Impediment,Release,Review

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            AssignedTo

            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Risk,Review,Req,Issue,CR,Bug,Task

            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Scenario,Risk,QoS,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            PBI,PD,SD,SR,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Backlog,UserStory,Defect,Impediment,Release,Review

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            AttachedFileCount

            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            AuthorizedAs

            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            ChangedBy

            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Risk,Review,Req,Issue,CR,Bug,Task

            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Scenario,Risk,QoS,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            PD,SD

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Backlog,UserStory,Defect,Impediment,Release,Review

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            ChangedDate

            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Risk,Review,Req,Issue,CR,Bug,Task

            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Scenario,Risk,QoS,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            PD,SD,Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Backlog,UserStory,Defect,Impediment,Release,Review

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            CreatedBy

            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Risk,Review,Req,Issue,CR,Bug,Task

            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Scenario,Risk,QoS,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            PD,SD,Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Backlog,UserStory,Defect,Impediment,Release,Review

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            CreatedDate

            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Risk,Review,Req,Issue,CR,Bug,Task

            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Scenario,Risk,QoS,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            PD,SD,Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Backlog,UserStory,Defect,Impediment,Release,Review

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Description

            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Risk,Review,Req,Issue,CR,Task

            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Scenario,Risk,QoS,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            PBI,PD,SD,SR,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Backlog,UserStory,Defect,Impediment,Release

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            ExternalLinkCount

            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            History

            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Risk,Review,Req,Issue,CR,Bug,Task

            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Scenario,Risk,QoS,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            (PBI),PD,SD,SR,Bug,(Task)

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Backlog,UserStory,Defect,Impediment,Release,Review

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            HyperLinkCount

            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Id

            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Risk,Review,Req,Issue,CR,Bug,Task

            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Scenario,Risk,QoS,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            PBI,PD,SD,SR,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Backlog,UserStory,Defect,Impediment,Release,Review

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            IterationId

            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            IterationPath

            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Risk,Review,Req,Issue,CR,Bug,Task

            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Scenario,Risk,QoS,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            SD,SR,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Backlog,UserStory,Defect,Impediment,Release,Review

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            NodeName

            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Reason

            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Risk,Review,Req,Issue,CR,Bug,Task

            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Scenario,Risk,QoS,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Backlog,UserStory,Defect,Impediment,Release,Review

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            RelatedLinkCount

            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Rev

            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            RevisedDate

            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            State

            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Risk,Review,Req,Issue,CR,Bug,Task

            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Scenario,Risk,QoS,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            PBI,PD,SD,SR,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Backlog,UserStory,Defect,Impediment,Release,Review

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            TeamProject

            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            TeamProject

            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Title

            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Risk,Review,Req,Issue,CR,Bug,Task

            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Scenario,Risk,QoS,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            PBI,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Backlog,UserStory,Defect,Impediment,Release,Review

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.996in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            WorkItemType

            </td>
            <td width="254" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.465in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td width="156" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.252in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.203in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.071in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
        </tr>
    </tbody>
</table>
</div>
For CMMI:  CR = Change Request, QoS = QualityOfService requirement, Req = Requirement

For eScrum: PD = ProductDetails, SD = SprintDetails, SR = SprintRetrospective, Task = SprintTask, PBI = ProductBacklogItem

## Microsoft.VSTS.Common namespace

<div style="direction: ltr">
<table border="1" cellspacing="0" cellpadding="0" valign="top" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; border-collapse: collapse; direction: ltr; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid">
    <tbody>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Name

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Used in CMMI

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Used in Agile

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Used in eScrum

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Used in VSTS Scrum

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            ActivatedBy

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Risk,Review,Requirement,Issue,CR,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Scenario,Risk,QoS,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Backlog,UserStory,Defect,Impediment,Release,Review

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            ActivatedDate

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Risk,Review,Requirement,Issue,CR,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Scenario,Risk,QoS,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Backlog,UserStory,Defect,Impediment,Release,Review

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            ClosedBy

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Risk,Review,RRequirementeq,Issue,CR,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Scenario,Risk,QoS,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Backlog,UserStory,Defect,Impediment,Release,Review

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            ClosedDate

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Risk,Review,Requirement,Issue,CR,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Scenario,Risk,QoS,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Backlog,UserStory,Defect,Impediment,Release,Review

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Discipline

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Backlog,UserStory

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Exit Criteria

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Risk,Requirement,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Scenario,Risk,QoS,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Backlog,UserStory,Release

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Issue

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Risk,Requirement,Issue,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Scenario,Risk,QoS,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Backlog,UserStory,Defect,Impediment,Release

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            IssueType

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Priority

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Risk,Requirement,Issue,CR,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Backlog,UserStory,Defect,Impediment,Release

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            QualityOfServiceType

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            QoS

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Rank

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Risk,Requirement,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Scenario,Risk,QoS,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Backlog,UserStory,Release

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Regression

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            ResolvedBy

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Risk,Review,Requirement,Issue,CR,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Scenario,QoS,Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Backlog,UserStory,Defect,Impediment,Release,Review

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            ResolvedDate

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Risk,Review,Requirement,Issue,CR,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Scenario,QoS,Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Backlog,UserStory,Defect,Impediment,Release,Review

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            ResolvedReason

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Defect

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            RoughOrderOfMagnitude

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt"> </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Scenario,QoS

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt"> </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt"> </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Severity

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Risk,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Risk

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            StateChangeDate

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Risk,Review,Requirement,Issue,CR,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Scenario,Risk,QoS,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Backlog,UserStory,Defect,Impediment,Release,Review

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.061in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Triage

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.781in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Requirement,Issue,CR,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.222in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.919in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.004in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Defect,Impediment

            </td>
        </tr>
    </tbody>
</table>
</div>

## Microsoft.VSTS.Build namespace

<div style="direction: ltr">
<table border="1" cellspacing="0" cellpadding="0" valign="top" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; border-collapse: collapse; direction: ltr; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid">
    <tbody>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.084in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Name

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.957in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

## Used in CMMI :

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.611in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

## Used in Agile :

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.115in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

## Used in eScrum

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.927in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

## Used in VSTS Scrum:

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.084in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            FoundIn

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.957in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Risk,Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.611in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Risk,Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.115in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.927in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Defect

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.084in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            IntegrationBuild

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.957in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Risk,Review,Req,Issue,CR,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.611in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Scenario,Risk,QoS,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.115in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 2.927in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Backlog,UserStory,Defect,Impediment,Release,Review

            </td>
        </tr>
    </tbody>
</table>
</div>
CR = Change Request, QoS = QualityOfService requirement, Req = Requirement

## Microsoft.VSTS.Scheduling namespace

<div style="direction: ltr">
<table border="1" cellspacing="0" cellpadding="0" valign="top" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; border-collapse: collapse; direction: ltr; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid">
    <tbody>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.799in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Name

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.527in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

## Used in CMMI

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.352in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

## Used in Agile

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.227in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

## Used in eScrum

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.895in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

## Used in VSTS Scrum

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.799in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            RemainingWork

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.527in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Risk,Req,CR,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.352in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.227in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.895in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Backlog,UserStory,Release

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.799in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            CompletedWork

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.527in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Risk,Req,CR,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.352in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.227in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.895in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Backlog,UserStory,Release

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.799in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            BaselineWork

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.527in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Risk,Req,CR,Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.352in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.227in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            PBI,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.895in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Backlog,UserStory,Release

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.799in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            StartDate

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.527in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.352in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Scenario,QoS,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.227in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.895in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Backlog,UserStory,Release

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.799in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            FinishDate

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.527in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.352in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Scenario,QoS,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.227in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.895in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Backlog,UserStory,Release

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.799in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            TaskHierarchy

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.527in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.352in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.227in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.895in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Backlog,UserStory,Release

            </td>
        </tr>
    </tbody>
</table>
</div>
<div style="direction: ltr"> </div>
<div style="direction: ltr">CR = Change Request, QoS = QualityOfService requirement, Req = Requirement</div>

## Microsoft.VSTS.Test namespace

<div style="direction: ltr">
<table border="1" cellspacing="0" cellpadding="0" valign="top" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; border-collapse: collapse; direction: ltr; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid">
    <tbody>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.843in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

## Name

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.101in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

## Used in CMMI

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.026in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

## Used in Agile

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.597in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

## Used in eScrum types

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.454in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

## Used in VSTS Scrum

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.843in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.101in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.026in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.597in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.454in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.843in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            TestName

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.101in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.026in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Risk,Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.597in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.454in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Defect

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.843in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            TestId

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.101in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.026in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Risk,Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.597in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.454in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Defect

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.843in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            TestPath

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.101in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Bug,Task

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.026in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Risk,Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.597in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Bug

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.454in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Defect

            </td>
        </tr>
    </tbody>
</table>
</div>

**Microsoft.VSTS.CMMI namespace**     (Not used in Agile or eScrum)

<table border="1" cellspacing="0" cellpadding="2" width="400">
    <tbody>
        <tr>
            <td valign="top" width="133">**Name**</td>
            <td valign="top" width="133">**Used in CMMI**</td>
            <td valign="top" width="133">**Used in VSTS Scrum**</td>
        </tr>
        <tr>
            <td valign="top" width="133">
            ActualAttendee[1-8]

            </td>
            <td valign="top" width="133">
            Review

            </td>
            <td valign="top" width="133"> </td>
        </tr>
        <tr>
            <td valign="top" width="133">
            Analysis

            </td>
            <td valign="top" width="133">
            Issue

            </td>
            <td valign="top" width="133">
            Impediment

            </td>
        </tr>
        <tr>
            <td valign="top" width="133">
            Blocked

            </td>
            <td valign="top" width="133">
            Risk,Requirement,CR,Bug,Task

            </td>
            <td valign="top" width="133">
            Backlog,UserStory,Defect,Release

            </td>
        </tr>
        <tr>
            <td valign="top" width="133">
            CalledBy

            </td>
            <td valign="top" width="133">
            Review

            </td>
            <td valign="top" width="133">
            Review

            </td>
        </tr>
        <tr>
            <td valign="top" width="133">
            CalledDate

            </td>
            <td valign="top" width="133">
            Review

            </td>
            <td valign="top" width="133">
            Review

            </td>
        </tr>
        <tr>
            <td valign="top" width="133">
            Comments

            </td>
            <td valign="top" width="133">
            Review

            </td>
            <td valign="top" width="133">
            Review

            </td>
        </tr>
        <tr>
            <td valign="top" width="133">
            Committed

            </td>
            <td valign="top" width="133">
            Requirement

            </td>
            <td valign="top" width="133"> </td>
        </tr>
        <tr>
            <td valign="top" width="133">
            CorrectiveActionActualResolution

            </td>
            <td valign="top" width="133">
            Issue

            </td>
            <td valign="top" width="133">
            Impediment

            </td>
        </tr>
        <tr>
            <td valign="top" width="133">
            CorrectiveActionPlan

            </td>
            <td valign="top" width="133">
            Issue

            </td>
            <td valign="top" width="133">
            Impediment

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

## And then some special namespaces which are only used by one process

### Microsoft.eScrum.Common namespace

<div style="direction: ltr">
<table border="1" cellspacing="0" cellpadding="0" valign="top" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; border-collapse: collapse; direction: ltr; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid">
    <tbody>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.769in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

## Name

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.226in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

## Used in eScrum

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.769in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Category

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.226in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            ProductBacklogItem,SprintTask

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.769in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Order

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.226in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            ProductBacklogItem,SprintTask

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.769in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Goals

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.226in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            ProductBacklogItem,SprintDetails

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 0.769in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            Source

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.226in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            ProductBacklogItem

            </td>
        </tr>
    </tbody>
</table>
</div>

## Microsoft.eScrum.Product namespace

<div style="direction: ltr">
<table border="1" cellspacing="0" cellpadding="0" valign="top" style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; border-collapse: collapse; direction: ltr; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid">
    <tbody>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.323in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

## Name

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.226in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">

## Used in eScrum

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.323in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            MembersXml

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.226in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            ProductDetails

            </td>
        </tr>
        <tr>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.323in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            BugDatabasesXml

            </td>
            <td style="border-bottom: #a3a3a3 1pt solid; border-left: #a3a3a3 1pt solid; padding-bottom: 4pt; padding-left: 4pt; width: 1.226in; padding-right: 4pt; vertical-align: top; border-top: #a3a3a3 1pt solid; border-right: #a3a3a3 1pt solid; padding-top: 4pt">
            ProductDetails

            </td>
        </tr>
    </tbody>
</table>
</div>

    </ul>
</ul>
