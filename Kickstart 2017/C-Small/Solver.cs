using System;
using static System.Math;
using static System.Int32;

class Solver
{
    public static string[][] SolveCase(string[][] Input)
    {
        int QuestionCount = Parse(Input[0][1]);
        int PointsLost = QuestionCount - Parse(Input[3][0]);
        int Difference = GetDifference(Input, QuestionCount);
        int RealPointsLost = Abs(Difference - PointsLost);
        int Score = QuestionCount - RealPointsLost;
        string[][] Output = new string[1][];
        Output[0] = new string[] { "" + Score };
        return Output;
    }

    private static int GetDifference(string[][] Input, int QuestionCount)
    {
        int Diffs = 0;
        for (int i = 0; i < QuestionCount; i++)
        {
            if (Input[1][0][i] != Input[2][0][i])
            {
                Diffs++;
            }
        }
        return Diffs;
    }
}