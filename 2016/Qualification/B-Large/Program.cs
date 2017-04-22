using System;
using System.IO;
using static System.Math;

class Program
{
    const string InputFilePath = "B-large.in";
    const string OutputFilePath = "LargeOutput.txt";

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
        File.WriteAllText(OutputFilePath, String.Join("\r\n", OutputFile));
    }

    static long Solve(long Num)
    {
        int[] Digits = GetDigitArray(Num);
        for (int i = 1; i < Digits.Length; i++)
        {
            if (Digits[i - 1] > Digits[i]) // Left digits is greater than right digit, thus Num isn't tidy
            {
                Digits[i - 1]--;
                for (int j = i; j < Digits.Length; j++) // Finds the next canidate
                {
                    Digits[j] = 9;
                }
                for (int j = i - 1; j > 0; j--)
                {
                    if (Digits[j - 1] > Digits[j]) // This only happens if Digits[j - 1] was equal to Digits[j] before finding the next canidate
                    {
                        Digits[j - 1]--;
                        Digits[j] = 9;
                    }
                }
                // Could add a break statement here since it is now impossible for Digits[i - 1] > Digits[i]
            }
        }
        return GetNumFromArray(Digits);
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

    // Returns a number where each digit is an element of Digits
    static long GetNumFromArray(int[] Digits)
    {
        long Num = 0;
        for (int i = 0; i < Digits.Length; i++)
        {
            Num += Digits[i] * (long)Pow(10, Digits.Length - 1 - i);
        }
        return Num;
    }

    // Returns the number of digits in Num
    static int DigitCount(long Num)
    {
        return (int)Floor(Log10(Num) + 1);
    }
}
