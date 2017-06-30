
class Solver
{
    public static string[][] SolveCase(string[][] Input)
    {
        string[][] Output = new string[1][];
        string EncryptedWord = Input[0][0];
        int Length = EncryptedWord.Length;
        char[] DecryptedWord = new char[Length];
        DecryptedWord[1] = EncryptedWord[0];
        DecryptedWord[Length - 2] = EncryptedWord[Length - 1];
        if (Length == 4)
        {
            int First = EncryptedWord[1] - DecryptedWord[2];
            DecryptedWord[0] = (char)(Mod(First, 26) + 65);

            int Last = EncryptedWord[2] - DecryptedWord[1];
            DecryptedWord[3] = (char)(Mod(Last, 26) + 65);
        }
        if (Length == 3)
        {
            Output[0] = new string[] { "AMBIGUOUS" };
        }
        else
        {
            Output[0] = new string[] { new string(DecryptedWord) };
        }
        return Output;
    }

    static int Alpha(char character)
    {
        return character - (int)'a';
    }

    static int Mod(int x, int m)
    {
        return (x % m + m) % m;
    }
}