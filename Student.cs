namespace GradeTracker;


/// One student: a name and a score. This replaces the two parallel arrays
/// (names[] and scores[]) from the first version, so a name can never get
/// out of step with its score.

public class Student
{
    public const double MinScore = 0;
    public const double MaxScore = 100;

    public Student(string name, double score)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.", nameof(name));

        if (double.IsNaN(score) || score < MinScore || score > MaxScore)
            throw new ArgumentOutOfRangeException(nameof(score), $"Score must be from {MinScore} to {MaxScore}.");

        Name = name.Trim();
        Score = score;
    }

    public string Name { get; }
    public double Score { get; }

    /// The letter grade, worked out from the score each time it is read.
    public string Grade => GetGrade(Score);

    // A switch expression with relational patterns (C# 9 or newer).
    // Cases are checked top to bottom, and _ is the catch-all.
    public static string GetGrade(double score) => score switch
    {
        >= 90 => "A",
        >= 80 => "B",
        >= 70 => "C",
        >= 60 => "D",
        _ => "F"
    };
}

