namespace GradeTracker;

public class Program
{
    static void Main()
    {
        var book = new GradeBook();
        bool running = true;

        while (running)
        {
            ShowMenu();
            string? choice = Console.ReadLine();

            if (choice is null)   // input stream closed (Ctrl+D / Ctrl+Z), so stop instead of looping forever
                break;

            switch (choice.Trim())
            {
                case "1": AddStudent(book); break;
                case "2": ShowReport(book); break;
                case "3": ShowStatistics(book); break;
                case "4": running = false; break;
                default: Console.WriteLine("Invalid choice, try again."); break;
            }
        }

        Console.WriteLine("Goodbye!");
    }

    static void ShowMenu()
    {
        Console.WriteLine("\n=== Grade Tracker ===");
        Console.WriteLine("1. Add a student");
        Console.WriteLine("2. View report (with grades)");
        Console.WriteLine("3. View statistics");
        Console.WriteLine("4. Quit");
        Console.Write("Choose: ");
    }

    static void AddStudent(GradeBook book)
    {
        string? name = ReadName("Student name: ");
        if (name is null) return;

        double? score = ReadScore($"Score for {name} (0-100): ");
        if (score is null) return;

        book.Add(new Student(name, score.Value));
        Console.WriteLine($"Added {name}. Students so far: {book.Count}.");
    }

    static void ShowReport(GradeBook book)
    {
        if (!HasData(book)) return;

        Console.WriteLine($"\n{"Name",-20}{"Score",8}{"Grade",8}");

        foreach (Student s in book.Students)
            Console.WriteLine($"{s.Name,-20}{s.Score,8:F1}{s.Grade,8}");
    }

    static void ShowStatistics(GradeBook book)
    {
        if (!HasData(book)) return;

        Student highest = book.Highest();
        Student lowest = book.Lowest();

        Console.WriteLine($"\nStudents: {book.Count}");
        Console.WriteLine($"Average:  {book.Average():F1}");
        Console.WriteLine($"Highest:  {highest.Name} ({highest.Score:F1}, grade {highest.Grade})");
        Console.WriteLine($"Lowest:   {lowest.Name} ({lowest.Score:F1}, grade {lowest.Grade})");
    }

    static bool HasData(GradeBook book)
    {
        if (!book.HasStudents)
        {
            Console.WriteLine("No students yet. Choose option 1 first.");
            return false;
        }
        return true;
    }

    /// Keeps asking until a valid name is typed. Returns null if input ends.
    static string? ReadName(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? line = Console.ReadLine();

            if (line is null) return null;

            if (InputParser.TryParseName(line, out string name))
                return name;

            Console.WriteLine("Name cannot be empty.");
        }
    }

    /// <summary>Keeps asking until a valid score is typed. Returns null if input ends.</summary>
    static double? ReadScore(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? line = Console.ReadLine();

            if (line is null) return null;

            if (InputParser.TryParseScore(line, out double score))
                return score;

            Console.WriteLine("Enter a number from 0 to 100 (for example 85 or 72.5).");
        }
    }
}
