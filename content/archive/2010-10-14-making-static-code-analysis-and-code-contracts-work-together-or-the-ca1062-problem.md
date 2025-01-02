---
id: 142294
title: Making Static Code Analysis and Code Contracts work together, or the CA1062 problem
date: 2010-10-14T12:21:18+01:00
author: terje
layout: post
guid: http://terje.wpengine.com/?p=142294
permalink: /making-static-code-analysis-and-code-contracts-work-together-or-the-ca1062-problem/
dsq_thread_id:
  - "4709718987"
categories:
  - none
---
<div class="wlWriterHeaderFooter" style="float:none; margin:0px; padding:4px 0px 4px 0px;"><iframe src="http://www.facebook.com/widgets/like.php?href=http://geekswithblogs.net/terje/archive/2010/10/14/making-static-code-analysis-and-code-contracts-work-together-or.aspx" scrolling="no" frameborder="0" style="border:none; width:450px; height:80px"></iframe></div><p><font color="#ff0000">UPDATED</font>: Feb 16th 2012:  Workaround #1 and #2 only works when run-time checking is not enabled. Added workaround #2B which seems to work.  Thanks to David S, Michael S and ZbynekZ for pointing this out, and sorry for not responding faster to this. Also added comments and overviews over what happens for different settings. </p>  <p> </p>  <p>There have been several reports on problems with the Static Code Analysis (SCA) not adhering to the statements of the Code Contract tools. See these links: <a href="https://connect.microsoft.com/VisualStudio/feedback/ViewFeedback.aspx?FeedbackID=488341&amp;wa=wsignin1.0" target="_blank">connect</a>, <a href="http://social.msdn.microsoft.com/Forums/en/codecontracts/thread/8016ba58-8ae1-483e-90ac-d14a4cb73a7c " target="_blank">forum1</a>, <a href="http://social.msdn.microsoft.com/Forums/en/codecontracts/thread/32f0f5c1-89fd-486f-9530-add3670552d0 " target="_blank">forum2</a>.</p>  <p>The problem can be shown in the following code snippet:</p>  <p> </p>  <p><font color="#ff0000">Code Problem:</font></p>  <pre class="csharpcode"> <span style="color: blue">public int </span>FindLength1(<span style="color: blue">string </span>something)
        {
            <span style="color: #2b91af">Contract</span>.Requires(something != <span style="color: blue">null</span>);
            <span style="color: blue">return </span>something.Length;
        }</pre>

<p>Running a Code Analysis gives a CA1062 warning (note: use a ruleset which enables this warning) saying:</p>

<p>Warning    5    CA1062 : Microsoft.Design : In externally visible method 'ParseNumber.FindLength1(string)', validate parameter 'something' before using it.    C:TFSDCodesamplesCodeContractAndCA1062ProblemCodeContractAndCA1062ProblemParseNumber.cs    133    CodeContractAndCA1062Problem</p>

<p>It complains that the parameter “something” can be null, but the Contract statement preceding this use says it can’t be null.</p>

<p>The problem is that the SCA doesn’t recognize the Contracts. As can be seen from the links above, this issue has proven to be a bit hard to fix.  So, we have to resort to workarounds to get this to work – until the bright guys have found a way to make the SCA work with contracts.</p>

<p>Workarounds are never as pretty as a proper solution can be, so you should choose the one which most applies to you, also taking your scenario into account.</p>

<p> </p>

<p>There is a problem with the binary rewriter and the code analysis. The code analysis is done after binary rewriting, and that means some of these workarounds will not work when you do run-time checking.  All of the workarounds work for static code checking,  but if you need to use runtime checking, you must enable assembly mode Custom Parameter Validation [CPV] .  See page 20 in <a href="http://research.microsoft.com/en-us/projects/contracts/userdoc.pdf" target="_blank">the user manual</a> for information on when to use Standard Contract Require mode and Custom Parameter Validation mode.</p>

<p>The following two statements were assumed, but it doesn’t seem to hold anymore, so the situation may be better than expected. It awaits confirmation though:</p>

<blockquote>
  <p><font size="2">If you enable run time checking with CPV, workaround 2B works.</font></p>
</blockquote>

<blockquote>
  <p><font size="2">If you can’t accept to use CPV – because it prevents inheritance of contracts – your only option is to use workaround 3.</font> </p>
</blockquote>

<p>The table below shows the effect of the workarounds and the different assembly mode and check setting combinations.  The red text shows what fails. </p>

<table border="1" cellspacing="0" cellpadding="2" width="398"><tbody>
    <tr>
      <td valign="top" width="58"> </td>

      <td valign="top" width="58"><strong></strong></td>

      <td valign="top" width="70"><strong>SCR</strong></td>

      <td valign="top" width="70"><strong>SCR</strong></td>

      <td valign="top" width="70"><strong>CPV</strong></td>

      <td valign="top" width="70"><strong>CPV</strong></td>
    </tr>

    <tr>
      <td valign="top" width="58"><strong></strong></td>

      <td valign="top" width="58"><strong></strong></td>

      <td valign="top" width="70"><strong>Static check only</strong></td>

      <td valign="top" width="70"><strong>+ Run time check</strong></td>

      <td valign="top" width="70"><strong>Static check only</strong></td>

      <td valign="top" width="70"><strong>+ Run time check</strong></td>
    </tr>

    <tr>
      <td valign="top" width="58"><strong>#1</strong></td>

      <td valign="top" width="58"><strong>CA1062 warning</strong></td>

      <td valign="top" width="70"><font color="#000000">No</font></td>

      <td valign="top" width="70"><font color="#ff0000">Yes</font></td>

      <td valign="top" width="70">No</td>

      <td valign="top" width="70"><font color="#ff0000">Yes</font></td>
    </tr>

    <tr>
      <td valign="top" width="58"><strong>#1</strong></td>

      <td valign="top" width="58"><strong>Contract check</strong></td>

      <td valign="top" width="70">Yes</td>

      <td valign="top" width="70">Yes</td>

      <td valign="top" width="70">Yes</td>

      <td valign="top" width="70">Yes</td>
    </tr>

    <tr>
      <td valign="top" width="58"><strong>#2</strong></td>

      <td valign="top" width="58"><strong>CA1062 warning</strong></td>

      <td valign="top" width="70">No</td>

      <td valign="top" width="70"><font color="#ff0000">Yes</font></td>

      <td valign="top" width="70">No</td>

      <td valign="top" width="70"><font color="#ff0000">Yes</font></td>
    </tr>

    <tr>
      <td valign="top" width="58"><strong>#2</strong></td>

      <td valign="top" width="58"><strong>Contract check</strong></td>

      <td valign="top" width="70">Yes</td>

      <td valign="top" width="70">Yes</td>

      <td valign="top" width="70">Yes</td>

      <td valign="top" width="70">Yes</td>
    </tr>

    <tr>
      <td valign="top" width="58"><strong>#2B</strong></td>

      <td valign="top" width="58"><strong>CA1062 warning</strong></td>

      <td valign="top" width="70">No</td>

      <td valign="top" width="70">No</td>

      <td valign="top" width="70">No</td>

      <td valign="top" width="70">No</td>
    </tr>

    <tr>
      <td valign="top" width="58"><strong>#2B</strong></td>

      <td valign="top" width="58"><strong>Contract check</strong></td>

      <td valign="top" width="70">Yes</td>

      <td valign="top" width="70">Yes</td>

      <td valign="top" width="70">Yes</td>

      <td valign="top" width="70">Yes</td>
    </tr>
  </tbody></table>

<p> </p>

<p>Workaround #1 and #2B gives this warning message when run in SCR:</p>

<p><em>Method 'TestCA1062.A.FindLength1(System.String)' has custom parameter validation but assembly mode is not set to support this. It will be treated as Requires&lt;E&gt;.  </em></p>

<p> </p>

<p>The different workarounds also give different exceptions when using the runtime checking:</p>

<table border="1" cellspacing="0" cellpadding="2" width="396"><tbody>
    <tr>
      <td valign="top" width="71"> </td>

      <td valign="top" width="162"><strong>SCR</strong></td>

      <td valign="top" width="161"><strong>CPV</strong></td>
    </tr>

    <tr>
      <td valign="top" width="71"><strong>CA1062 original problem</strong></td>

      <td valign="top" width="163">ContractException</td>

      <td valign="top" width="163">ContractException</td>
    </tr>

    <tr>
      <td valign="top" width="70"><strong>#1</strong></td>

      <td valign="top" width="164">ArgumentNullException</td>

      <td valign="top" width="163">ArgumentNullException</td>
    </tr>

    <tr>
      <td valign="top" width="70"><strong>#2</strong></td>

      <td valign="top" width="164">ContractException</td>

      <td valign="top" width="163">ContractException</td>
    </tr>

    <tr>
      <td valign="top" width="70"><strong>#2B</strong></td>

      <td valign="top" width="164">ArgumentNullException</td>

      <td valign="top" width="163">ArgumentNullException</td>
    </tr>
  </tbody></table>

<p>We want to have the ContractException, but as can be seen, the #2B gives its inner exception, the ArgumentNullException. </p>

<p>So, the conclusion from this is that none of the workarounds are all perfect, but  #2B gives the best compromise, as you get rid of the static code warning CA1062, and it works with runtime checking.</p>

<p> </p>

<p><font color="#ff0000">Workaround #1</font></p>

<p> </p>

<p>This workaround is useful where you have legacy code already in place, or if you don’t mind using old fashioned code checks. </p>

<pre class="code"><span style="color: blue">public int </span>FindLength2(<span style="color: blue">string </span>something)
       {
           <span style="color: blue">if </span>(something==<span style="color: blue">null</span>)
               <span style="color: blue">throw new </span><span style="color: #2b91af">ArgumentNullException</span>(<span style="color: #a31515">"something"</span>);
           <span style="color: #2b91af">Contract</span>.EndContractBlock();
           <span style="color: blue">return </span>something.Length;
       }</pre>

<p> </p>

<p>There are four things to note about this:</p>

<ol>
  <li>The use of the normal “if (something==null)” check is recognized by the SCA, thus eliminating the CA1062 warning. </li>

  <li>The Contract.EndContractBlock  statement turns the lines ahead into contracts, so the lines above “is equal to” a Contract.Requires(something!=null) statement  , but mind, it doesn’t give identical run time exceptions, the “equality” is only for static contract checking (Thanks for pointing this out Michael)</li>

  <li>Inheritance of contracts</li>

  <ol>
    <li>These contracts should not have been inheritable (as stated in #2 under here), but from testing now it seems they do.  Awaiting  confirmation on this one. </li>

    <li>(These contracts are not inherited to subtypes as a Contract.Requires is.  If you make use of inheritance trees with contracts, this will force you to implement these checks manually throughout the inheritance tree, which might be a problem.) </li>
  </ol>

  <li>This workaround is meant to run in Custom Parameter Validation (CPV) assembly mode.  If you run in  Standard Contract Require (SCR) mode, it reverts to a standard Requires&lt;E&gt; statement, and you get a warning about this.  This warning should have been informational, as there is no need to do anything about it.  </li>
</ol>

<p> </p>

<p><font color="#ff0000">Workaround #2</font></p>

<p> </p>

<p>This workaround requires a few other things to be put into place, and might be regarded as a bit strange code-wise, but does the job quite nicely. It also uses some extra features in the Code Contract suite.  Thanks to <a href="http://blogs.msdn.com/b/camerons/" target="_blank">Cameron Skinner</a> and <a href="http://research.microsoft.com/en-us/people/mbarnett/" target="_blank">Mike Barnett</a> for pointing me to this solution.  This workaround only works when static contract checking is used without having runtime checking enabled. </p>

<pre class="code"><span style="color: blue">public int </span>FindLength3(<span style="color: blue">string </span>something)
        {
            CheckNotNull(something);
            <span style="color: blue">return </span>something.Length;
        }


        [<span style="color: #2b91af">ContractAbbreviator</span>]
        <span style="color: blue">internal void </span>CheckNotNull&lt;T&gt;([<span style="color: #2b91af">ValidatedNotNull</span>]T whatever)
        {
            <span style="color: #2b91af">Contract</span>.Requires(whatever != <span style="color: blue">null</span>);
        }</pre>

<p>There are a few things to note about this too:</p>

<ol>
  <li>The contract in the FindLength method is replaced with a special method, CheckNotNull.  This might feel unusual, but solves the problem rather elegant. </li>

  <li>The CheckNotNull method is a special method, it must do the following: 
    <ol>
      <li>Be decorated by the ContractAbbreviator attribute, which is used to tell that this method contains one or more contracts. This will satisfy the Contract, and the contracts within will appear as contracts for the FindLength method. </li>

      <li>Have its method parameter decorated with an attribute named ValidatedNotNull.  This attribute name is picked up by the SCA (FxCop) and will silence the CA1062 warning. </li>
    </ol>
  </li>
</ol>

<p>The two attributes here must be added to the program.  The ContractAbbreviator is not part of the standard Contract assembly, but is available in source form from the folder %ProgramFiles%MicrosoftContractsLanguages....</p>

<p>or you can just add it yourself, it looks like this:</p>

<pre class="code"><span style="color: blue">namespace </span>System.Diagnostics.Contracts</pre>

<p> </p>

<pre class="code"><span style="color: gray">/// &lt;summary&gt;
 /// </span><span style="color: green">Enables writing abbreviations for contracts that get copied to other methods
 </span><span style="color: gray">/// &lt;/summary&gt;
 </span>[<span style="color: #2b91af">AttributeUsage</span>(<span style="color: #2b91af">AttributeTargets</span>.Method, AllowMultiple=<span style="color: blue">false</span>)]
 [<span style="color: #2b91af">Conditional</span>(<span style="color: #a31515">"CONTRACTS_FULL"</span>)]
 <span style="color: blue">internal sealed class </span><span style="color: #2b91af">ContractAbbreviatorAttribute </span>: <span style="color: blue">global</span>::System.<span style="color: #2b91af">Attribute
 </span>{
 }</pre>

<p> </p>

<p> </p>

<p>The other attribute, ValidatedNotNull can be defined as follows:</p>

<pre class="code">   [<span style="color: #2b91af">AttributeUsage</span>(<span style="color: #2b91af">AttributeTargets</span>.Parameter, AllowMultiple = <span style="color: blue">false</span>)]
   <span style="color: blue">internal sealed class </span><span style="color: #2b91af">ValidatedNotNullAttribute </span>: <span style="color: blue">global</span>::System.<span style="color: #2b91af">Attribute
   </span>{
   }</pre>

<p> </p>

<p>Namespace is not important for this attribute, place it wherever.</p>

<p> </p>

<p><font color="#ff0000">Workaround #2B     </font></p>

<p><font color="#000000">This is a variation of the pattern for #2, which   works in all modes, although it is intended to work for the CPV only.  It gives the annoying warning about wrong assembly mode, but otherwise works in all modes.  Thanks again to Mike Barnett and his colleague Manuel Fahndrich for coming up with this alternative.</font></p>

<p> </p>

<pre class="code"><span style="color: blue">public int </span>FindLength2B(<span style="color: blue">string </span>something)
       {
           CheckNotNullB(something);
           <span style="color: blue">return </span>something.Length;
       }

       [<span style="color: #2b91af">ContractArgumentValidator</span>]
       <span style="color: blue">internal void </span>CheckNotNullB&lt;T&gt;([<span style="color: #2b91af">ValidatedNotNull</span>]T whatever)
       {
           <span style="color: blue">if </span>(whatever == <span style="color: blue">null</span>)
           {
               <span style="color: blue">throw new </span><span style="color: #2b91af">ArgumentNullException</span>(<span style="color: #a31515">"whatever"</span>);
           }
           <span style="color: #2b91af">Contract</span>.EndContractBlock();
       }</pre>

<p>and it also requires you to define the attribute like this:</p>

<pre class="code">[<span style="color: #2b91af">AttributeUsageAttribute</span>(<span style="color: #2b91af">AttributeTargets</span>.Method, AllowMultiple = <span style="color: blue">false</span>)]
[<span style="color: #2b91af">ConditionalAttribute</span>(<span style="color: #a31515">"CONTRACTS_FULL"</span>)]
<span style="color: blue">public sealed class </span><span style="color: #2b91af">ContractArgumentValidatorAttribute </span>: <span style="color: #2b91af">Attribute
</span>{ }</pre>

<p>Note that this attribute is defined in the upcoming .Net framework 4.5, so when you start using that one, you should delete your own definition. </p>

<p> </p>

<p><font color="#ff0000">Workaround #3</font></p>

<p> </p>

<p>This is the simple way to do this, but it works too – suppress the warning.  And, it is not as dumb as one could fear – because the Suppress attribute to be used here can be made rather narrow:</p>

<p> </p>

<pre class="code">        [System.Diagnostics.CodeAnalysis.<span style="color: #2b91af">SuppressMessage</span>(<span style="color: #a31515">"Microsoft.Design"</span>, <span style="color: #a31515">"CA1062:Validate arguments of public methods"</span>, MessageId = <span style="color: #a31515">"0"</span>)]
        <span style="color: blue">public int </span>FindLength7(<span style="color: blue">string </span>something)
        {
            <span style="color: #2b91af">Contract</span>.Requires(something != <span style="color: blue">null</span>);
            <span style="color: blue">return </span>something.Length;
        }</pre>

<p>The MessageId parameter states which of the parameters is to be suppressed in case of multiple parameters.  </p>

<p>-----------------------</p>

<p>This workaround is more reactive than Workaround 1 and 2, which are more proactive.  When would I choose what?  </p>

<p> </p>

<ul>
  <li>Workaround 1: When I have legacy code, and just want to add contracts. </li>

  <li>Workaround 2: New code, including new methods on old code, where I want the code to be safe before I do more. </li>

  <li>Workaround 3: Legacy code, when adding SCA and contracts, and where no existing guards exist. </li>
</ul>