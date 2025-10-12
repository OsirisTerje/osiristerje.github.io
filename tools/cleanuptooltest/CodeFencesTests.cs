using CleanupTool;

namespace cleanuptooltest;

public class CodeFencesTests
{
    private static readonly List<string> blankfencesDefault =
    [
        "",
        "Run the tool",
        "",
        "```",
        "",
        "yourtoolname",
        "```",
        ""
    ];

    private static readonly List<string> blankfencesDefaultOutput =
    [
        "Run the tool",
        "",
        "```csharp",
        "",
        "yourtoolname",
        "```whatever",
        "",
        "",
        ""
    ];

    private static readonly List<string> blankfencesCmd =
    [
        "```",
        "dotnet tool install --global Project2015To2017.Migrate2019.Tool",
        "```",
        ""
    ];

    private static readonly List<string> blankfencesCmdOutput =
    [
        "```cmd",
        "dotnet tool install --global Project2015To2017.Migrate2019.Tool",
        "```whatever",
        ""
    ];

    private static readonly object[] TestCases =
    [
        new object[] { blankfencesDefault, "csharp" },
        new object[] { blankfencesCmd, "cmd" }
    ];
    private static readonly object[] TestCases2 =
    [
        new object[] { blankfencesDefaultOutput, "csharp" },
        new object[] { blankfencesCmdOutput, "cmd" }
    ];


    [TestCaseSource(nameof(TestCases))]
    public void TestBlankCodeFences(List<string> input,string codeTag)
    {
        var output = Processor.NormalizeFencedCodeBlocks(input);
        Assert.That(output,Does.Contain($"```{codeTag}"));

        
    }

    [TestCaseSource(nameof(TestCases2))]
    public void FixClosingFencedCodeBlockEndingsTests(List<string> input,string codeTag)
    {
        var output = Processor.FixClosingFencedCodeBlockEndings(input);
        Assert.That(output, Does.Contain($"```{codeTag}"));
        Assert.That(output.Last(), Is.EqualTo(string.Empty));
        Assert.That(output[^2], Is.EqualTo("```"));
    }



}
