using System;
using static System.Int32;
using static System.IO.File;
using static System.String;

class Program
{
    const string InputFilePath = "";
    const string OutputFilePath = "";

    static void Main(string[] args)
    {
        string[] InputFile = ReadAllLines(InputFilePath);
        int TestCases = Parse(InputFile[0]);

        string[] OutputFile = new string[TestCases];
        for (int i = 0; i < TestCases; i++)
        {
            string CaseString = "Case #" + (i + 1) + ": ";
            string Solution = SolveCase(InputFile[i + 1]);
            OutputFile[i] = CaseString + Solution;
        }
        WriteAllText(OutputFilePath, Join("\r\n", OutputFile));
    }

    // Takes in an input line and returns the appropriate output line
    static string SolveCase(string Input)
    {
        throw new NotImplementedException();
    }
}