using static System.Int32;

class Solver
{
    public static string[][] SolveCase(string[][] Input)
    {
        int Size = Parse(Input[0][0]);
        string[][] Output = new string[1][];
        bool RowsHaveZeroOrThree = false;
        bool ColsHaveZeroOrThree = false;
        for (int i = 0; i < Size; i++)
        {
            int RowSum = 0;
            int ColSum = 0;
            for (int j = 0; j < Size; j++)
            {
                if ("" + Input[i + 1][0].ToCharArray(0, Size)[j] == "X") RowSum++;
                if ("" + Input[j + 1][0].ToCharArray(0, Size)[i] == "X") ColSum++;
            }
            if (RowSum == 0 || RowSum == 3)
            {
                RowsHaveZeroOrThree = true;
            }
            if (ColSum == 0 || ColSum == 3)
            {
                ColsHaveZeroOrThree = true;
            }
        }
        if (ColsHaveZeroOrThree || RowsHaveZeroOrThree)
        {
            Output[0] = new string[] { "IMPOSSIBLE" };
        }
        else
        {
            Output[0] = new string[] { "POSSIBLE" };
        }
        return Output;
    }
}