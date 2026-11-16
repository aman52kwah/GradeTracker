namespace GradeTracker.Tests;

public class GradeBookTests
{
    [Fact]
    public void NewBook_HasNoStudents()
    {
        var book = new GradeBook();
        Assert.Equal(0, book.Count);
        Assert.False(book.HasStudents);
    }

    [Fact]
    public void Add_IncreasesCountAndHasStudents()
    {
        var book = new GradeBook();
        book.Add(new Student("Ada", 88));
        Assert.Equal(1, book.Count);
        Assert.True(book.HasStudents);
    }

    [Fact]
    public void Add_RejectsNullStudent()
    {
        var book = new GradeBook();
        Assert.Throws<ArgumentNullException>(() => book.Add(null!));
    }

    [Fact]
    public void Average_ReturnsMeanOfScores()
    {
        var book = new GradeBook();
        book.Add(new Student("Ada", 80));
        book.Add(new Student("Bob", 90));
        book.Add(new Student("Cal", 70));

        Assert.Equal(80, book.Average());
    }

    [Fact]
    public void Highest_ReturnsStudentWithTopScore()
    {
        var book = new GradeBook();
        book.Add(new Student("Ada", 80));
        book.Add(new Student("Bob", 95));
        book.Add(new Student("Cal", 70));

        var top = book.Highest();
        Assert.Equal("Bob", top.Name);
        Assert.Equal(95, top.Score);
    }

    [Fact]
    public void Highest_OnTie_ReturnsFirstEntered()
    {
        var book = new GradeBook();
        book.Add(new Student("Ada", 90));
        book.Add(new Student("Bob", 90));

        var top = book.Highest();
        Assert.Equal("Ada", top.Name);
    }

    [Fact]
    public void Lowest_ReturnsStudentWithBottomScore()
    {
        var book = new GradeBook();
        book.Add(new Student("Ada", 80));
        book.Add(new Student("Bob", 95));
        book.Add(new Student("Cal", 70));

        var bottom = book.Lowest();
        Assert.Equal("Cal", bottom.Name);
        Assert.Equal(70, bottom.Score);
    }

    [Fact]
    public void Lowest_OnTie_ReturnsFirstEntered()
    {
        var book = new GradeBook();
        book.Add(new Student("Ada", 70));
        book.Add(new Student("Bob", 70));

        var bottom = book.Lowest();
        Assert.Equal("Ada", bottom.Name);
    }

    [Theory]
    [MemberData(nameof(EmptyBookMethodsThatThrow))]
    public void EmptyBook_ThrowsInvalidOperation(Action action)
    {
        var book = new GradeBook();
        Assert.Throws<InvalidOperationException>(action);
    }

    public static IEnumerable<object[]> EmptyBookMethodsThatThrow()
    {
        var book = new GradeBook();
        yield return new object[] { new Action(() => book.Average()) };
        yield return new object[] { new Action(() => book.Highest()) };
        yield return new object[] { new Action(() => book.Lowest()) };
    }
}
