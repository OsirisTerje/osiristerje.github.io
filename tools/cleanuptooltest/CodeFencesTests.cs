using CleanupTool;

namespace cleanuptooltest;

public class CodeFencesTests
{
    private const string blankfencesDefault = @"\r\nRun the tool\r\n\r\n```\r\n\r\nyourtoolname\r\n```\r\n";

    private const string blankfencesCmd =
        @"```\r\ndotnet tool install --global Project2015To2017.Migrate2019.Tool\r\n```\r\n";
    
    [TestCase(blankfencesDefault,"csharp")]
    [TestCase(blankfencesCmd, "cmd")]
    public void TestBlankCodeFences(string input,string codeTag)
    {
        var output = Processor.NormalizeFencedCodeBlocks(input);
        Assert.That(output,Does.Contain($"```{codeTag}"));
    }
}
