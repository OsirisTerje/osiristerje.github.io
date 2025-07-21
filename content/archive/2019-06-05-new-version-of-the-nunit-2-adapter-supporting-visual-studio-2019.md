---
id: 160617
title: New version of the NUnit 2 adapter supporting Visual Studio 2019
date: 2019-06-05T19:15:18+01:00
author: terje
layout: post
guid: http://hermit.no/?p=160617
permalink: /new-version-of-the-nunit-2-adapter-supporting-visual-studio-2019/

categories:
  - Uncategorized
---
<!-- wp:paragraph -->
<p>The NUnit 2.X framework have been superseded by the NUnit 3 framework several years ago.  Each framework "family" needs a separate adapter, one for the V2 and one for the V3.  The V3 have been maintained continuously, and have 3-4 releases per year.  The V2 adapter however, has not been updated since mid 2017.</p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>The thinking have been that developers should move to the V3 version of the framework.  Over time that has happened, but there are still some that need the V2 version for various reasons. Although the V3 framework is an enhancement of V2, there are some breaking changes between them.  And for some systems those prevents upgrading.  </p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>The current V2 adapter supports all Visual Studio versions up to VS 2017, but there are issues, in particular when using the new SDK format, and with VS 2019 it doesn't seem to work. One example, with workarounds, can be found in <a href="https://github.com/nunit/nunit-vs-adapter/issues/180" target="_blank" rel="noreferrer noopener" aria-label="this github issue (opens in a new tab)">this github issue</a>.</p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>So, in order to properly support VS 2019 (and VS2017), we have made an upgrade to the V2 adapter, release 2.2.  It only contains two bug fixes, the VS 2019 is one, the other is another blocking issue.  The release notes are <a rel="noreferrer noopener" aria-label="here (opens in a new tab)" href="https://github.com/nunit/docs/wiki/AdapterV2-Release-Notes" target="_blank">here</a>.</p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p> The upgrade works with both the NuGet adapter, which is the preferred way of adding adapters, and a VSIX version.  The VSIX support is in the process of being deprecated in Visual Studio.</p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>The major change in the adapter for support of VS 2019, is that the adapter and its support dlls are being copied into the output folder of the test project.  </p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>Now, this is no problem with respect to the NUnit dll's themselves, but the adapter is also using the <a rel="noreferrer noopener" aria-label="Mono.Cecil (opens in a new tab)" href="https://www.nuget.org/packages/Mono.Cecil/" target="_blank">Mono.Cecil</a> library, version 0.9.6.4, which is lagging behind the latest version, 0.10.4.  This will not create any issues if you're not using Mono.Cecil for anything else.   If you are, please raise an issue for it, or - seriously - convert to V3. </p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p><strong>Links</strong></p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p><a href="https://www.nuget.org/packages/NUnitTestAdapter/2.2.0" target="_blank" rel="noreferrer noopener" aria-label="Nuget adapter (opens in a new tab)">Nuget adapter</a></p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p><a href="https://marketplace.visualstudio.com/items?itemName=NUnitDevelopers.NUnitTestAdapter" target="_blank" rel="noreferrer noopener" aria-label="VSIX Adapter (opens in a new tab)">VSIX Adapter</a></p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p><a href="https://github.com/nunit/nunit-vs-adapter" target="_blank" rel="noreferrer noopener" aria-label="Project site (opens in a new tab)">Project site</a></p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p><a href="https://github.com/nunit/docs/wiki/AdapterV2-Release-Notes" target="_blank" rel="noreferrer noopener" aria-label="Release notes (opens in a new tab)">Release notes</a></p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p></p>
<!-- /wp:paragraph -->