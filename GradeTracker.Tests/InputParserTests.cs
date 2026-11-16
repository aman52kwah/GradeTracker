namespace GradeTracker.Tests;

public class InputParserTests
{
    [Theory]
    [InlineData("85", 85)]
    [InlineData("0", 0)]
    [InlineData("100", 100)]
    [InlineData("85.5", 85.5)]
    [InlineData("72.5", 72.5)]
    [InlineData("  90  ", 90)]
    public void TryParseScore_AcceptsValidScore(string input, double expected)
    {
        bool result = InputParser.TryParseScore(input, out double score);
        Assert.True(result);
        Assert.Equal(expected, score);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("abc")]
    [InlineData("85.5.5")]
    [InlineData("-1")]
    [InlineData("101")]
    [InlineData("NaN")]
    [InlineData("Infinity")]
    public void TryParseScore_RejectsInvalidScore(string? input)
    {
        bool result = InputParser.TryParseScore(input, out double score);
        Assert.False(result);
    }

    [Theory]
    [InlineData("Ada", "Ada")]
    [InlineData("  Ada  ", "Ada")]
    [InlineData("Grace Hopper", "Grace Hopper")]
    public void TryParseName_AcceptsValidName(string input, string expected)
    {
        bool result = InputParser.TryParseName(input, out string name);
        Assert.True(result);
        Assert.Equal(expected, name);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void TryParseName_RejectsInvalidName(string? input)
    {
        bool result = InputParser.TryParseName(input, out string name);
        Assert.False(result);
        Assert.Equal(string.Empty, name);
    }
}
