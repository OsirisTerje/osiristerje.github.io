---
id: 137915
title: Osiris Data has upgraded TFS 2010 from beta to RC in production
date: 2010-02-10T17:06:59+01:00
author: terje
layout: post
categories:
  - Uncategorized
---
We have just upgraded our TFS production system to the RC from Beta 2.  Upgrading and Migration were done in 1.5 hour.  More than **75 team projects** upgraded.  Our **30 internal developers** and some more external will wake up to a new world tomorrow morning :-).

  Martin Hinshelwood managed to beat us with some hours [http://blog.hinshelwood.com/archive/2010/02/10/upgrading-from-tfs-2010-beta-2-to-tfs-2010-rc.aspx](http://blog.hinshelwood.com/archive/2010/02/10/upgrading-from-tfs-2010-beta-2-to-tfs-2010-rc.aspx) but we must still be one of the very first companies to move over!

  We have a two-tier solution, on raw iron, no hyper-v here, so we :

  <ol>   <li>Backed up the sql server databases</li>    <li>Uninstalled application tier with all components</li>    <li>Installed RC according to procedure</li>    <li>Configured the RC, using the wizard</li>    <li>Up and run</li> </ol>  Tested the thing using our internal projects with components for the TFS Server, including our own checkin policies, build components, and miscellaneous event handler components.  All worked very smoothly.
