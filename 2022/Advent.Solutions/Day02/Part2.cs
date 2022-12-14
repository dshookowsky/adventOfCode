namespace Advent.Solutions.Day02
{
    public class Part2
    {
#pragma warning disable SA1303 // Const field names should begin with upper-case letter
        private const int rock = 1;
        private const int paper = 2;
        private const int scissors = 3;

        private const int win = 6;
        private const int lose = 0;
        private const int draw = 3;
#pragma warning restore SA1303 // Const field names should begin with upper-case letter

        public int Solution(IEnumerable<string> lines)
        {
#pragma warning disable SA1500 // Braces for multi-line statements should not share line
            Dictionary<string, Dictionary<string, int>> shape = new ()
        {
            { "A", new Dictionary<string, int> {
                { "X", scissors + lose },
                { "Y", rock + draw },
                { "Z", paper + win }
            } },
            { "B", new Dictionary<string, int> {
                { "X", rock + lose },
                { "Y", paper + draw },
                { "Z", scissors + win }
            } },
            { "C", new Dictionary<string, int> {
                { "X", paper + lose },
                { "Y", scissors + draw },
                { "Z", rock + win }
            } }
        };
#pragma warning restore SA1500 // Braces for multi-line statements should not share line

            int score = 0;
            foreach (var line in lines)
            {
                var round = line.Split(" ");

                var move = shape[round[0]];
                score += move[round[1]];
            }

            return score;
        }
    }
}