namespace GradeTracker;


/// Holds all the students in a List&lt;Student&gt; and calculates the statistics.
/// It never touches the console, so it is easy to unit test.

public class GradeBook
{
    // A List grows as you Add to it. An array has a fixed size,
    // which is why we asked "How many students?" up front before.
    private readonly List<Student> _students = new();

    public int Count => _students.Count;
    public bool HasStudents => _students.Count > 0;

    /// A read-only view, so outside code cannot change the list directly.
    public IReadOnlyList<Student> Students => _students;

    public void Add(Student student)
    {
        ArgumentNullException.ThrowIfNull(student);
        _students.Add(student);
    }

    public double Average()
    {
        RequireStudents();

        double sum = 0;
        foreach (Student s in _students)
            sum += s.Score;

        return sum / _students.Count;
    }

    /// The student with the top score. On a tie, the first one entered.
    public Student Highest()
    {
        RequireStudents();

        Student best = _students[0];
        for (int i = 1; i < _students.Count; i++)
            if (_students[i].Score > best.Score)
                best = _students[i];

        return best;
    }

    /// The student with the lowest score. On a tie, the first one entered.
    public Student Lowest()
    {
        RequireStudents();

        Student worst = _students[0];
        for (int i = 1; i < _students.Count; i++)
            if (_students[i].Score < worst.Score)
                worst = _students[i];

        return worst;
    }

    private void RequireStudents()
    {
        if (_students.Count == 0)
            throw new InvalidOperationException("There are no students yet.");
    }
}

