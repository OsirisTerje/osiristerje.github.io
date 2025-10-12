---
id: 142786
title: Fixing the default checkin action, make Associate the default instead of Resolve
date: 2010-11-19T02:33:50+01:00
author: terje
layout: post
categories:
  - Uncategorized
---
When checking in code with workitems, one should connect them with workitems.  In some cases you need to check in multiple times before the item is resolved.  If you are too quick there, the checkin action causes the workitem to go to the Resolved state as this is the default state, if you don’t manually change it to Associate.  This default state can now – in VS 2010 – be turned around, so that Associate becomes the default action.

  See [this blog post for the details](http://www.edsquared.com/2010/11/17/Set+Associate+To+Default+Action+Instead+Of+Resolved+For+TFS+Work+Item+Changeset+Associations.aspx).

  As noted in Ed’s post, this key has to be changed on the developers machines, so it has to be rolled out to all developers. To make it simpler, copy the following into a file named for example AssociateAsDefaultCheckinAction.reg:

  <hr />  Windows Registry Editor Version 5.00   <br />    <br />[HKEY_CURRENT_USERSoftwareMicrosoftVisualStudio10.0TeamFoundationSourceControlBehavior]    <br /><span class="str">"ResolveAsDefaultCheckinAction"</span>=<span class="str">"False"</span>    <br />

  <hr />  and just right click it in Explorer and choose Merge, or just run it from a command prompt.
