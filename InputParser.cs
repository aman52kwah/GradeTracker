using System.Globalization;

namespace GradeTracker;

//Turns raw text typed by the user into validated values.
public static class  InputParser
{
    //True when the text is a score from 0 to 100. Decimals like 85.5 are allowed.
    public static bool TryParseScore(string? input, out double score)
    {
        score = 0;

        if (string.IsNullOrWhiteSpace(input))
            return false;

        // InvariantCulture means the decimal separator is always "." on every computer.
        if (!double.TryParse(input.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out double parsed))
            return false;

        // "NaN" and "Infinity" parse successfully, so they must be rejected explicitly.
        if (!double.IsFinite(parsed) || parsed < Student.MinScore || parsed > Student.MaxScore)
            return false;

        score = parsed;
        return true;
    }

    // True when the text contains a name once spaces are trimmed off.
    public static bool TryParseName(string? input, out string name)
    {
        name = string.Empty;

        if (string.IsNullOrWhiteSpace(input))
            return false;

        name = input.Trim();
        return true;
    }
}

