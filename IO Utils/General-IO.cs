using static System.Console;
using static System.Int32;
using static System.IO.File;
using static System.String;

class UtilsIO
{
    static string InputFilePath = "TestInput.txt";
    static string OutputFilePath = "TestOutput.txt";
    static string[] InputFile = ReadAllLines(InputFilePath);
    static string[] OutputFile = new string[InputFile.Length - 1]; // CONFIG

    static void Main()
    {
        int TestCases = Parse(InputFile[0]);

        int ReadLocation = 1;
        int WriteLocation = 0;
        for (int i = 0; i < TestCases; i++)
        {
            int ReadLength = 1; // CONFIG
            string[][] InputData = ReadCase(ReadLocation, ReadLength);
            string[][] OutputData = Solver.SolveCase(InputData);

            int WriteLength = OutputData.GetLength(0);
            WriteCase(WriteLocation, i + 1, OutputData, false); // CONFIG
            ReadLocation += ReadLength;
            WriteLocation += WriteLength;
        }
        WriteAllText(OutputFilePath, Join("\r\n", OutputFile));
    }

    static string[][] ReadCase(int ReadLocation, int ReadLength)
    {
        string[][] InputData = new string[ReadLength][];
        for (int i = 0; i < ReadLength; i++)
        {
            InputData[i] = InputFile[ReadLocation + i].Split(' ');
        }
        return InputData;
    }

    static void WriteCase(int WriteLocation, int CaseNum, string[][] OutputData, bool OneLiner)
    {
        if (OneLiner)
        {
            OutputFile[WriteLocation] = "Case #" + CaseNum + ": " + OutputData[0][0];
        }
        else
        {
            OutputFile[WriteLocation] = "Case #" + CaseNum + ": ";
            for (int i = 0; i < OutputData.GetLength(0); i++)
            {
                OutputFile[WriteLocation + 1 + i] = Join(" ", OutputData[i]);
            }
        }
    }

    static void Print2DArray(string[][] InputData)
    {
        for (int i = 0; i < InputData.GetLength(0); i++)
        {
            for (int j = 0; j < InputData[i].Length; j++)
            {
                Write(InputData[i][j] + " ");
            }
            WriteLine();
        }
        WriteLine();
    }
}