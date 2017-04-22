using System;
using System.IO;

class Program
{
    const string InputFilePath = "A-large.in";
    const string OutputFilePath = "LargeOutput.txt";

    static void Main(string[] args)
    {
        string[] InputFile = File.ReadAllLines(InputFilePath);
        int TestCases = Int32.Parse(InputFile[0]);

        string[] OutputFile = new string[TestCases];
        for (int i = 0; i < TestCases; i++)
        {
            string CaseString = "Case #" + (i + 1) + ": ";
            string Solution = Solve(InputFile[i + 1]);
            OutputFile[i] = CaseString + Solution;
        }
        File.WriteAllText(OutputFilePath, String.Join("\r\n", OutputFile));
    }

    static string Solve(string InputLine)
    {
        string[] Input = InputLine.Split(' ');
        bool[] State = GetBoolArray(Input[0]);
        int FlipperSize = Int32.Parse(Input[1]);
        int Flips = 0;
        for (int i = 0; i < State.Length - FlipperSize + 1; i++)
        {
            if (State[i])
            {
                for (int j = i; j < i + FlipperSize; j++)
                {
                    State[j] = !State[j];
                }
                Flips++;
            }
        }
        for (int i = 0; i < State.Length; i++)
        {
            if (State[i]) return "IMPOSSIBLE";
        }
        return "" + Flips;
    }

    // Returns an array with false for + and true for -
    private static bool[] GetBoolArray(string Pancake)
    {
        bool[] Result = new bool[Pancake.Length];
        for (int i = 0; i < Pancake.Length; i++)
        {
            Result[i] = Pancake[i] == '-';
        }
        return Result;
    }
}