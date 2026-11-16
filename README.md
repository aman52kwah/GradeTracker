# Grade Tracker

A .NET console application for tracking student grades through a menu-driven CLI.

## Features

- Add students with a name and score (0–100, decimals allowed)
- View a report showing each student's name, score, and letter grade
- View statistics: student count, average score, highest and lowest scores
- Input validation for names (non-empty) and scores (0–100, finite numbers)
- Letter grades: A (≥90), B (≥80), C (≥70), D (≥60), F (<60)

## How to run

```bash
dotnet run
```

Choose an option from the menu:

```
=== Grade Tracker ===
1. Add a student
2. View report (with grades)
3. View statistics
4. Quit
Choose:
```

All data lives in memory for the session and is not persisted to disk.

## How to test

The project includes an xUnit test project with 54 tests covering `Student`, `GradeBook`, and `InputParser`:

```bash
dotnet test
```

## Project structure

```
GradeTracker/
├── Program.cs          # Console UI / menu loop
├── Student.cs          # Student value object + grade logic
├── GradeBook.cs        # Holds students and calculates statistics
├── InputParser.cs      # Validates and parses user input
├── GradeTracker.csproj # Main app (net11.0)
├── GradeTracker.Tests/
│   ├── GradeTracker.Tests.csproj
│   ├── StudentTests.cs
│   ├── GradeBookTests.cs
│   └── InputParserTests.cs
└── README.md
```

## Design

- **`Student`** — immutable value object (name + score). Computes its letter grade on demand. Validates that the score is between 0 and 100.
- **`GradeBook`** — holds the student list and computes count, average, highest, and lowest. Contains no console code, so it's easy to unit test.
- **`InputParser`** — static helper that turns raw console text into validated names and scores.
- **`Program`** — the only file that touches the console; runs a menu loop until the user quits or the input stream closes.

## Requirements

- .NET SDK 11 (preview) or later

```bash
dotnet --version
```