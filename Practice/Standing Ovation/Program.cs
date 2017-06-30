using static System.Console;
using static System.Int32;
using static System.IO.File;
using static System.String;

class Program
{
    const string InputFilePath = "A-large-practice.in";
    const string OutputFilePath = "LargeOutput.txt";

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
        Read();
    }

    // Takes in an input line and returns the appropriate output line
    static string SolveCase(string Input)
    {
        string[] InputData = Input.Split(' ');
        int S_Max = Parse(InputData[0]);
        string Audience = InputData[1];
        int CurrClapping = 0;
        int FriendsNeeded = 0;
        for (int i = 0; i < Audience.Length; i++)
        {
            if (CurrClapping < i)
            {
                FriendsNeeded++;
                CurrClapping++;
            }
            CurrClapping += Parse("" + Audience[i]);
        }
        WriteLine(FriendsNeeded);
        return "" + FriendsNeeded;
    }
}