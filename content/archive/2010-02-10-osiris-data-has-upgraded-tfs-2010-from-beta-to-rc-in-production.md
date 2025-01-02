---
id: 137915
title: Osiris Data has upgraded TFS 2010 from beta to RC in production
date: 2010-02-10T17:06:59+01:00
author: terje
layout: post
guid: http://terje.wpengine.com/?p=137915
permalink: /osiris-data-has-upgraded-tfs-2010-from-beta-to-rc-in-production/
dsq_thread_id:
  - "5132085923"
categories:
  - Uncategorized
---
<p>We have just upgraded our TFS production system to the RC from Beta 2.  Upgrading and Migration were done in 1.5 hour.  More than <strong>75 team projects</strong> upgraded.  Our <strong>30 internal developers</strong> and some more external will wake up to a new world tomorrow morning :-).</p>  <p>Martin Hinshelwood managed to beat us with some hours <a title="http://blog.hinshelwood.com/archive/2010/02/10/upgrading-from-tfs-2010-beta-2-to-tfs-2010-rc.aspx" href="http://blog.hinshelwood.com/archive/2010/02/10/upgrading-from-tfs-2010-beta-2-to-tfs-2010-rc.aspx">http://blog.hinshelwood.com/archive/2010/02/10/upgrading-from-tfs-2010-beta-2-to-tfs-2010-rc.aspx</a> but we must still be one of the very first companies to move over!  </p>  <p>We have a two-tier solution, on raw iron, no hyper-v here, so we :</p>  <ol>   <li>Backed up the sql server databases</li>    <li>Uninstalled application tier with all components</li>    <li>Installed RC according to procedure</li>    <li>Configured the RC, using the wizard</li>    <li>Up and run</li> </ol>  <p>Tested the thing using our internal projects with components for the TFS Server, including our own checkin policies, build components, and miscellaneous event handler components.  All worked very smoothly.</p>