using System;
using System.Text;
using static System.Int32;
using static System.IO.File;
using static System.String;

class Program
{
    const string InputFilePath = "A-small-practice.in";
    const string OutputFilePath = "SmallOutput.txt";

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

    static int[] NUMBERS_MAPPING = { 0, 2, 4, 6, 8, 1, 3, 5, 7, 9};
    // Takes in an input line and returns the appropriate output line
    static string SolveCase(string Input)
    {
        string[] Numbers = { "ZERO", "TWO", "FOUR", "SIX", "EIGHT", "ONE", "THREE", "FIVE", "SEVEN", "NINE"};
        int[] Basis = { 0, 1, 2, 2, 2, 0, 0, 0, 0, 0};
        int[] CharCounts = GetCharCounts(Input);
        int[] DigitCounts = new int[10];
        for (int i = 0; i < Numbers.Length; i++)
        {
            int RemovedDigitLiterals = RemoveDigitLiterals(Numbers[i], Basis[i], CharCounts);
            DigitCounts[NUMBERS_MAPPING[i]] = RemovedDigitLiterals;
        }
        return GenerateNumber(DigitCounts);
    }

    static string GenerateNumber(int[] DigitCounts)
    {
        StringBuilder Result = new StringBuilder();
        for (int i = 0; i < DigitCounts.Length; i++)
        {
            for (int j = 0; j < DigitCounts[i]; j++)
            {
                Result.Append("" + i);
            }
        }
        return Result.ToString();
    }

    static int RemoveDigitLiterals(string Number, int BasisIndex, int[] CharCounts)
    {
        int BaseCharIndex = Number[BasisIndex] - 'A';
        int[] NumCharCounters = GetCharCounts(Number);
        int DigitLiteralsRemoved = CharCounts[BaseCharIndex] / NumCharCounters[BaseCharIndex];
        for (int i = 0; i < CharCounts.Length; i++)
        {
            CharCounts[i] -= DigitLiteralsRemoved * NumCharCounters[i];
        }
        return DigitLiteralsRemoved;
    }

    static int[] GetCharCounts(string Input)
    {
        int[] CharCounts = new int[26];
        for (int i = 0; i < Input.Length; i++)
        {
            int CharacterIndex = Input[i] - 'A';
            CharCounts[CharacterIndex]++;
        }
        return CharCounts;
    }
}