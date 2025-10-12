---
id: 127385
title: 'Code Metrics &#8211; suggestions for appropriate limits'
date: 2008-11-25T21:20:49+01:00
author: terje
layout: post
categories:
  - Code Analysis
  - Code Quality
  - Visual Studio
---

I like Code Metrics.  They give a certain "objective" evaluation of a piece of code.  You can use it for yourself just to make it pinpoint potential trouble areas, or just some code where you were a bit sloppy - happens from time to time......  And when you're going to do a peer review, it's much better to point to some numbers instead of  the "This code sucks....."-thing.   So when it finally arrived inside Visual Studio I was delighted.

There are however a few things there which should be nice candidates for the next upgrade.

First, it doesn't work on Team Builds, and it won't be fixed in TFS 2008.  The people I spoke to at the PDC said it would be integrated with team build in TFS 2010 !

Second, the levels they have for red/yellow/green limits are strange.  It is only the Maintenance Index that "powers" these flags.  At the method level they are fixed at &lt;10 for Red and &lt;20 for Yellow.  The Maintenance index (MI) is a normalized variation of work done at Carnegie Mellon University, see [http://blogs.msdn.com/fxcop/archive/2007/11/20/maintainability-index-range-and-meaning.aspx](http://blogs.msdn.com/fxcop/archive/2007/11/20/maintainability-index-range-and-meaning.aspx) for information on it, and how they normalized the MI. The original metric had a maximum at 171.  In VS2008 MI is defined to have a range from 0 to 100, so in principle it is scaled down by a factor of 100/171. In addition they did not allow negative values, which is just fine.

However, a [study](http://doi.ieeecomputersociety.org/10.1109/2.303623) made by Hewlett Packard (using the original metrics), published in IEEE Computer back in 1994,  where they analyzed several projects found that levels below 65 should be in the red, yellow from 65 to 85, and green beyond that.  Normalizing these limits again, suggest values of 39 and 50 respectively, which is far higher than the 10/20 limits now in effect.  My own experience have been to set these levels at 40 and 60, quite close to the HP findings.  Code written with MI metrics values below 40 is rather nasty, so I believe these values still holds, even if the study is a few years back.

For the Cyclomatic complexity metric, which is a often used metric, the recommendations for red/yellow/green is Green &lt;10, Yellow 10-15/20 and Red &gt; 15/20.  See this [article](http://www.aivosto.com/project/help/pm-complexity.html).  Some also says everything above 10 should be  red.

The Class coupling is more complex, and it also depends on the Depth of Inheritance.  I have not been able to find any solid recommendations there, but it seems that values beyond 15 to 20 should be avoided.

It would be nice if the flags shown in Visual Studio Code Metrics window could have customized limits - put them into a configuration file!  First, they are fixed in code down in a method IconForMaintainabilityIndex in the CodeMetricsBranch class of the  Microsoft.VisualStudio.Metrics.Package.UI.  However, we *can* live without yellow and red flags, as long as the appropriate levels are known.

The table below summarizes this:

<table cellspacing="0" cellpadding="2" width="457" border="1">
    <tbody>
        <tr>
            <td valign="top" width="82"> </td>
            <td valign="top" width="130">Maintainability Index</td>
            <td valign="top" width="107">Cyclomatic Complexity</td>
            <td valign="top" width="136">Class Coupling</td>
        </tr>
        <tr>
            <td valign="top" width="88">Green</td>
            <td valign="top" width="134">&gt; 60</td>
            <td valign="top" width="111">&lt; 10</td>
            <td valign="top" width="135">&lt; 20</td>
        </tr>
        <tr>
            <td valign="top" width="90">Yellow</td>
            <td valign="top" width="136">40 - 60</td>
            <td valign="top" width="113">10 - 15</td>
            <td valign="top" width="133"> </td>
        </tr>
        <tr>
            <td valign="top" width="91">Red</td>
            <td valign="top" width="137">&lt; 40</td>
            <td valign="top" width="114">&gt; 15</td>
            <td valign="top" width="132">&gt; 20</td>
        </tr>
    </tbody>
</table>

Note that the values applies to the method level !
