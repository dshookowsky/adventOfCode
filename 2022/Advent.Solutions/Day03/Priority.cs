namespace Advent.Solutions.Day03
{
    internal class Priority
    {
        private static readonly Dictionary<char, int> Values = new ();

        static Priority()
        {
            foreach (char c in Enumerable.Range(Convert.ToUInt16('a'), 26))
            {
                Values[c] = Convert.ToUInt16(c) - 96;
            }

            foreach (char c in Enumerable.Range(Convert.ToUInt16('A'), 26))
            {
                Values[c] = Convert.ToUInt16(c) - 64 + 26;
            }
        }

        internal static int Score(char c)
        {
            return Values[c];
        }
    }
}