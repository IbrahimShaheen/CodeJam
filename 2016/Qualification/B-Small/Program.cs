using System;
using System.IO;

class Program
{
    const string InputFilePath = "B-small-attempt0.in";
    const string OutputFilePath = "SmallOutput.txt";

    static void Main(string[] args)
    {
        string[] InputFile = File.ReadAllLines(InputFilePath);
        int TestCases = Int32.Parse(InputFile[0]);

        string[] OutputFile = new string[TestCases];
        for (int i = 0; i < TestCases; i++)
        {
            string CaseString = "Case #" + (i + 1) + ": ";
            long Solution = Solve(Int64.Parse(InputFile[i + 1]));
            OutputFile[i] = CaseString + Solution;
        }
        File.WriteAllLines(OutputFilePath, OutputFile);
    }

    static long Solve(long Num)
    {
        while (!IsTidy(Num))
        {
            Num--;
            Console.WriteLine(Num);
        }
        return Num;
    }

    // Returns true if Num's digits are in non decreasing order
    static bool IsTidy(long Num)
    {
        int[] Digits = GetDigitArray(Num);
        for (int i = 1; i < Digits.Length; i++)
        {
            if (Digits[i - 1] > Digits[i]) return false;
        }
        return true;
    }

    // Returns an array containing the digits of Num
    static int[] GetDigitArray(long Num)
    {
        int[] Result = new int[DigitCount(Num)];
        for (int i = Result.Length - 1; i >= 0; i--)
        {
            Result[i] = (int)(Num % 10);
            Num /= 10;
        }
        return Result;
    }

    // Returns the number of digits in Num
    static int DigitCount(long Num)
    {
        return (int)Math.Floor(Math.Log10(Num) + 1);
    }
}
