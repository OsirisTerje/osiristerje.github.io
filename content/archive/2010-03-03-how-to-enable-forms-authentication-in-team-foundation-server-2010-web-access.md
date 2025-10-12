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

Forms authentication is not what “they” normally recommend from a  security point of view, but in some cases it solves access problems. Particularly for companies which doesnt allow the Windows authentication protocol to pass, and those companies do exist.  To enable it in TFS 2010 is a bit more than a oneliner.  The recipe below shows you how to enable it.

One has to change the web.config file for the Web Access. There are instructions within the file, but those instructions are incorrect and don’t work as intended.  This is probably leftovers from the 2008 version.

A bit down in the file it says:

<!-- For Integrated Windows Authentication, set Authentication Mode to "Windows"

    For Forms authentication, set it to None -->

This is incorrect.  Change it and add the following instead:

```xml
<authentication mode="Forms">
    <forms loginUrl="UI/Pages/Login.aspx"
           protection="All"
           timeout="30"
           name=".ASPXAUTH"
           path="/"
           requireSSL="false"
           slidingExpiration="true"
           defaultUrl="default.aspx"
           cookieless="UseDeviceProfile"
           enableCrossAppRedirects="false" />
</authentication>
```

Also note that the setting at the top of the file:

```xml
<webAccessSettings>
    <!-- Specifies whether the login form is enabled. If disabled, only
    Integrated Windows Authentication is allowed. -->
    <formsAuthentication enabled="true" />
</webAccessSettings>
```

has no effect at all.   It can safely be ignored.
