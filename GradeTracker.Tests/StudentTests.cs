namespace GradeTracker.Tests;

public class StudentTests
{
    [Theory]
    [InlineData(95, "A")]
    [InlineData(90, "A")]
    [InlineData(89, "B")]
    [InlineData(80, "B")]
    [InlineData(79, "C")]
    [InlineData(70, "C")]
    [InlineData(69, "D")]
    [InlineData(60, "D")]
    [InlineData(59, "F")]
    [InlineData(0, "F")]
    [InlineData(50, "F")]
    public void GetGrade_ReturnsCorrectLetter(double score, string expectedGrade)
    {
        string actual = Student.GetGrade(score);
        Assert.Equal(expectedGrade, actual);
    }

    [Fact]
    public void Grade_Property_ReturnsSameAsGetGrade()
    {
        var student = new Student("Ada", 88);
        Assert.Equal("B", student.Grade);
    }

    [Fact]
    public void Constructor_TrimsName()
    {
        var student = new Student("  Ada  ", 88);
        Assert.Equal("Ada", student.Name);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_RejectsInvalidName(string? invalidName)
    {
        Assert.Throws<ArgumentException>(() => new Student(invalidName!, 88));
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(100.1)]
    [InlineData(double.NaN)]
    [InlineData(double.PositiveInfinity)]
    [InlineData(double.NegativeInfinity)]
    public void Constructor_RejectsInvalidScore(double invalidScore)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Student("Ada", invalidScore));
    }

    [Fact]
    public void Constructor_AcceptsBoundaryScores()
    {
        var low = new Student("Ada", 0);
        var high = new Student("Bob", 100);
        Assert.Equal(0, low.Score);
        Assert.Equal(100, high.Score);
    }
}
