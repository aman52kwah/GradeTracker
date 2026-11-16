class Program
{
    
    static string[] names = Array.Empty<string>();
    static double[] scores = Array.Empty<double>();

    static void Main()
    {
        bool running = true;

        while (running)
        {
            ShowMenu();

            switch (Console.ReadLine()?.Trim())
            {
                case "1": EnterScores(); break;
                case "2": ShowReport(); break;
                case "3": ShowStatistics(); break;
                case "4" : running = false; break;
                default: Console.WriteLine("Invalid choice, try again."); break;
            }
        }

        Console.WriteLine("Goodbye!");
    }

    static void ShowMenu()
    {
        Console.WriteLine("\n=== Welcome to Grade Tracker ==");
        Console.WriteLine("1. Enter student scores");
        Console.WriteLine("2. View report( with grades)");
        Console.WriteLine("3. View statistics");
        Console.WriteLine("4. Quit");
        Console.WriteLine("Choose");
    }

    static void EnterScores()
    {
        int count = ReadInt("How many students?", 1, 50);

        names = new string[count];
        scores = new double[count];

        for (int i = 0; i < count; i++)
        {
            Console.Write($"Name of student {i + 1}: ");
            names[i] = Console.ReadLine()?.Trim() ?? "Unknown";
            scores[i] = ReadInt($"Score for {names[i]} (0-100): ", 0, 100);
        }
        Console.WriteLine("Scores saved.");
    }

    static void ShowReport()
    {
        if(!HasData()) return;

        Console.WriteLine($"\n{"Name", -15}{"Score", 8}{"Grade", 8}");

        for (int i = 0; i < scores.Length; i++)
        {
            Console.WriteLine($"{names[i], -15}{scores[i],8:F1}{GetGrade(scores[i],8)}");
        };
    }

    static void ShowStatistics()
    {
        if (!HasData()) return;
        int hi = FindHighestIndex(scores);
        int lo = FindLowestIndex(scores);


        Console.WriteLine($"\nAverage: {CalculateAverage(scores):F1}");
        Console.WriteLine($"Highest: {names[hi]}({scores[hi]})");
        Console.WriteLine($"Lowest: {names[lo]} ({scores[lo]})");
    }

    static bool HasData()
    {
        if (scores.Length == 0)
       { Console.WriteLine("No scores yet. Choose option 1 first.");
            return false;
        }
        return true;

    }

    static double CalculateAverage(double[] values)
    {
        double sum = 0;
        foreach(double v in values) sum += v;
        return sum / values.Length;
    }


   static int FindHighestIndex(double[] values)
    {
        int best = 0;
        for(int i = 1; i < values.Length; i++)
        if (values[i] > values[best]) best = i;

        return best;
    }

    static int FindLowestIndex(double[] values)
    {
        int worst = 0;
        for (int i = 1; i < values.Length; i++)
        if(values[i] < values[worst]) worst = i;

        return worst;
    }
    static string GetGrade(double score, int v) => score switch
    {
        >= 90 => "A",
        >= 80 => "B",
        >= 70 => "C",
        >= 60 => "D",
          >= 50 => "F",
    };

    static int ReadInt(string prompt, int min, int max)
    {
        while (true)
        {
            Console.Write(prompt);
            if(int.TryParse(Console.ReadLine(), out int values) && values >= min && values <= max)
            return values;
            Console.WriteLine($"Enter a whole number from {min} to {max}.");
        }
    }
    
}
