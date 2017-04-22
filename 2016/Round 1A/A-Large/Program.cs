using System;
using System.IO;

using static System.Console;

class Program
{
    const string InputFilePath = "A-large.in";
    const string OutputFilePath = "LargeOutput.txt";

    static void Main(string[] args)
    {
        string[] InputFile = File.ReadAllLines(InputFilePath);
        int TestCases = Int32.Parse(InputFile[0]);

        string[] OutputFile = new string[InputFile.Length - 1];
        int LineIndex = 1;
        for (int i = 0; i < TestCases; i++)
        {
            int Rows = Int32.Parse(InputFile[LineIndex].Split(' ')[0]);
            int Cols = Int32.Parse(InputFile[LineIndex].Split(' ')[1]);
            char[,] Case = new char[Rows, Cols];
            string CaseString = "Case #" + (i + 1) + ": ";
            OutputFile[LineIndex - 1] = CaseString;
            for (int j = 0; j < Rows; j++)
            {
                LineIndex++;
                for (int k = 0; k < Cols; k++)
                {
                    Case[j, k] = InputFile[LineIndex][k];
                }
            }
            char[,] Solution = Solve(Case);
            int rowLength = Solution.GetLength(0);
            int colLength = Solution.GetLength(1);
            for (int j = 0; j < rowLength; j++)
            {
                string RowStr = "";
                for (int k = 0; k < colLength; k++)
                {
                    RowStr += Solution[j, k];
                }
                OutputFile[LineIndex - rowLength + j] = RowStr;
            }
            LineIndex++;
        }
        File.WriteAllText(OutputFilePath, String.Join("\r\n", OutputFile));
    }

    private static char[,] Solve(char[,] Input)
    {
        char[,] Result = new char[Input.GetLength(0), Input.GetLength(1)];

        // Ensure each row has all full or all ?
        for (int i = 0; i < Input.GetLength(0); i++)
        {
            int FirstChar = 0;
            while (Input[i, FirstChar] == '?')
            {
                FirstChar++;
                if (FirstChar >= Input.GetLength(1))
                {
                    FirstChar = 0;
                    break;
                }
            }
            for (int j = 0; j < FirstChar; j++)
            {
                Result[i, j] = Input[i, FirstChar];
            }
            int LastChar = FirstChar;
            for (int j = FirstChar; j < Input.GetLength(1); j++)
            {
                if (Input[i, j] == '?' || Input[i, j] == Input[i, LastChar])
                {
                    Result[i, j] = Input[i, LastChar];
                }
                else
                {
                    LastChar = j;
                    Result[i, j] = Input[i, LastChar];
                }
            }
        }
        // Now copy each row, first case
        int FirstLine = 0;
        while (Result[FirstLine, 0] == '?')
        {
            FirstLine++;
            if (FirstLine >= Input.GetLength(0))
            {
                FirstLine = 0;
                break;
            }
        }
        for (int i = 0; i < FirstLine; i++)
        {
            for (int j = 0; j < Result.GetLength(1); j++)
            {
                Result[i, j] = Result[FirstLine, j];
            }
        }
        int LastLine = FirstLine;
        for (int i = FirstLine; i < Input.GetLength(0); i++)
        {
            if (Result[i, 0] == '?')
            {
                for (int j = 0; j < Result.GetLength(1); j++)
                {
                    Result[i, j] = Result[LastLine, j];
                }
            }
            else
            {
                LastLine = i;
            }
        }
        return Result;
    }

    static void Print2DArray(char[,] arr)
    {
        int rowLength = arr.GetLength(0);
        int colLength = arr.GetLength(1);
        for (int i = 0; i < rowLength; i++)
        {
            for (int j = 0; j < colLength; j++)
            {
                Console.Write(string.Format("{0}", arr[i, j]));
            }
            Console.Write(Environment.NewLine);
        }
    }
}