using static System.Int32;
using static System.IO.File;
using static System.String;
using System.Collections.Generic;
using System.Linq;
using System;

class Program
{
    const string InputFilePath = "B-small-attempt1.in";
    const string OutputFilePath = "B-small-attempt1.txt";

    public static object LessColor { get; private set; }

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
        int N = Parse(Input.Split(' ')[0]);
        string[] Result = new string[N];
        Dictionary<string, int> CountColorPair = new Dictionary<string, int>();
        CountColorPair.Add("R", Parse(Input.Split(' ')[1]));
        CountColorPair.Add("Y", Parse(Input.Split(' ')[3]));
        CountColorPair.Add("B", Parse(Input.Split(' ')[5]));
        if (!Possible(CountColorPair)) return "IMPOSSIBLE";
        for (int i = 0; i < N / 2; i++)
        {
            var List = GetSorted(CountColorPair);
            var MaxColor = List.ElementAt(2);
            var LessMaxColor = List.ElementAt(1);
            Result[2 * i] = MaxColor.Key;
            Result[2 * i + 1] = LessMaxColor.Key;
            CountColorPair[MaxColor.Key]--;
            CountColorPair[LessMaxColor.Key]--;
        }
        if (N % 2 != 0)
        {
            var List = GetSorted(CountColorPair);
            var MaxColor = List.ElementAt(2);
            Result[N - 1] = MaxColor.Key;
        }
        if (Result[0] == Result[N - 1])
        {
            string temp = Result[N - 1];
            Result[N - 1] = Result[N - 2];
            Result[N - 2] = temp;
        }
        return Join("", Result);
    }

    private static bool Possible(Dictionary<string, int> CountColorPair)
    {
        var List = GetSorted(CountColorPair);
        if (List.ElementAt(2).Value > List.ElementAt(1).Value + List.ElementAt(0).Value)
        {
            return false;
        }
        return true;
    }

    private static List<KeyValuePair<string, int>> GetSorted(Dictionary<string, int> aDictionary)
    {
        List<KeyValuePair<string, int>> myList = aDictionary.ToList();
        myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
        return myList;
    }
}