namespace Day03;

internal class Priority
{
    private readonly static Dictionary<char, int> values = new();
    static Priority()
    {
        foreach (char c in Enumerable.Range(Convert.ToUInt16('a'), 26))
        {
            values[c] = Convert.ToUInt16(c) - 96;
        }

        foreach (char c in Enumerable.Range(Convert.ToUInt16('A'), 26))
        {
            values[c] = Convert.ToUInt16(c) - 64 + 26;
        }
    }

    internal static int Score(char c)
    {
        return values[c];
    }
}
