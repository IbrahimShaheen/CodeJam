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

        string[] OutputFile = new string[InputFile.Length - 1];
        int ReadLocation = 1;
        for (int i = 0; i < TestCases; i++)
        {
            int Rows = Parse(InputFile[ReadLocation].Split(' ')[0]);
            string[][] Case = GetCase(InputFile, ReadLocation, Rows);
            string[][] Solution = SolveCase(Case);
            PutCaseSolution(OutputFile, i + 1, ReadLocation, Solution);
        }
        WriteAllText(OutputFilePath, Join("\r\n", OutputFile));
    }

    // Writes each row of Solution as a line, joined by spaces, to OutputFile starting at WriteLocation
    // Inserts a line at WriteLocation - 1 with a case label indicated by CaseNum
    static void PutCaseSolution(string[] OutputFile, int CaseNum, int WriteLocation, string[][] Solution)
    {
        OutputFile[WriteLocation - 1] = "Case #" + CaseNum + ": ";
        for (int i = 0; i < Solution.GetLength(0); i++)
        {
            OutputFile[WriteLocation + i] = Join(" ", Solution[i]);
        }
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
            Result[i] = InputFile[ReadLocation + Length].Split(' ');
        }
        return Result;
    }

    // Returns a 2D string array which is the solution to the given 2D string input
    static string[][] SolveCase(string[][] Input)
    {
        throw new NotImplementedException();
    }
}