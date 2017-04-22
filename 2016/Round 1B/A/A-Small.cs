using static System.Int32;
using static System.IO.File;
using static System.String;
using static System.Console;
using System.Collections.Generic;
using System.Linq;

class Program
{
    const string InputFilePath = "A-small-attempt0.in";
    const string OutputFilePath = "SmallOutput.txt";

    public static double MinTime { get; private set; }

    static void Main(string[] args)
    {
        string[] InputFile = ReadAllLines(InputFilePath);
        int TestCases = Parse(InputFile[0]);

        string[] OutputFile = new string[TestCases];
        int ReadLocation = 1;
        for (int i = 0; i < TestCases; i++)
        {
            int LinesToRead = Parse(InputFile[ReadLocation].Split(' ')[1]);
            string[][] Case = GetCase(InputFile, ReadLocation, LinesToRead + 1);
            string Solution = SolveCase(Case);
            PutCaseSolution(OutputFile, i + 1, i, Solution);
            ReadLocation += LinesToRead + 1;
        }
        WriteAllText(OutputFilePath, Join("\r\n", OutputFile));
    }

    // Writes each row of Solution as a line, joined by spaces, to OutputFile starting at WriteLocation
    // Inserts a line at WriteLocation - 1 with a case label indicated by CaseNum
    static void PutCaseSolution(string[] OutputFile, int CaseNum, int WriteLocation, string Solution)
    {
        OutputFile[WriteLocation] = "Case #" + CaseNum + ": " + Solution;
        
    }

    // Returns a 2D string array which:
    //      Contains consecutive lines of InputFile starting from ReadLocation
    //      Has Length number of rows, each being a line in InputFile
    //      Each row in the array contains a line delimited by spaces
    static string[][] GetCase(string[] InputFile, int ReadLocation, int Length)
    {
        string[][] Result = new string[Length][];
        for (int i = 0; i < Length; i++)
        {
            Result[i] = InputFile[ReadLocation + i].Split(' ');
        }
        return Result;
    }

    // Returns a 2D string array which is the solution to the given 2D string input
    static string SolveCase(string[][] Input)
    {
        int Destination = Parse(Input[0][0]);
        int NumOfHourses = Parse(Input[0][1]);
        SortedDictionary<int, int> LocationSpeedPairs = new SortedDictionary<int, int>();
        for (int i = 0; i < NumOfHourses; i++)
        {
            int Location = Parse(Input[i + 1][0]);
            int Speed = Parse(Input[i + 1][1]);
            LocationSpeedPairs.Add(Location, Speed);
        }
        double MaxTime = double.MinValue;
        for (int i = NumOfHourses - 1; i >= 0; i--)
        {
            int Location = LocationSpeedPairs.ElementAt(i).Key;
            int Speed = LocationSpeedPairs.ElementAt(i).Value;
            double Time = (double)(Destination - Location) / Speed;
            if (Time > MaxTime) MaxTime = Time;
        }
        return "" + Destination / MaxTime;
    }
}