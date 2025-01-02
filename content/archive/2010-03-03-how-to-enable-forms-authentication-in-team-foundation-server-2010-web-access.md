---
id: 138309
title: How to enable Forms authentication in Team Foundation Server 2010 Web Access
date: 2010-03-03T12:40:47+01:00
author: terje
layout: post
guid: http://terje.wpengine.com/?p=138309
permalink: /how-to-enable-forms-authentication-in-team-foundation-server-2010-web-access/
dsq_thread_id:
  - "5513025271"
categories:
  - none
---
<p>Forms authentication is not what “they” normally recommend from a  security point of view, but in some cases it solves access problems. Particularly for companies which doesnt allow the Windows authentication protocol to pass, and those companies do exist.  To enable it in TFS 2010 is a bit more than a oneliner.  The recipe below shows you how to enable it. </p>
<p>One has to change the web.config file for the Web Access. There are instructions within the file, but those instructions are incorrect and don’t work as intended.  This is probably leftovers from the 2008 version.</p>
<p>A bit down in the file it says:</p>
<p>&lt;!-- For Integrated Windows Authentication, set Authentication Mode to "Windows"</p>
<p>    For Forms authentication, set it to None --&gt;</p>
<p>    &lt;authentication mode="None"/&gt;</p>
<p>This is incorrect.  Change it and add the following instead :</p>
<p>&lt;authentication mode="Forms"&gt; </p>
<p>        &lt;forms loginUrl="UI/Pages/Login.aspx"</p>
<p>           protection="All"</p>
<p>           timeout="30"</p>
<p>           name=".ASPXAUTH"</p>
<p>           path="/"</p>
<p>           requireSSL="false"</p>
<p>           slidingExpiration="true"</p>
<p>           defaultUrl="default.aspx"</p>
<p>           cookieless="UseDeviceProfile"</p>
<p>           enableCrossAppRedirects="false" /&gt;</p>
<p>    &lt;/authentication&gt;</p>
<p> </p>
<p>Also note that the setting at the top of the file:</p>
<p>&lt;webAccessSettings&gt;</p>
<p>    &lt;!-- Specifies whether the login form is enabled. If disabled, only</p>
<p>    Integrated Windows Authentication is allowed. --&gt;</p>
<p>    &lt;formsAuthentication enabled="true" /&gt;  </p>
<p> </p>
<p>has no effect at all.   It can safely be ignored.</p>