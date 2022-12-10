namespace Advent.Solutions.Day02
{
    public class Part2
    {
        const int rock = 1;
        const int paper = 2;
        const int scissors = 3;

        const int win = 6;
        const int lose = 0;
        const int draw = 3;

        public int Solution(IEnumerable<string> lines)
        {
            Dictionary<string, Dictionary<string, int>> shape = new()
        {
            {"A", new Dictionary<string, int> {
                {"X" , scissors + lose },
                {"Y" , rock + draw },
                {"Z", paper + win }
            } } ,
            {"B", new Dictionary<string, int> {
                {"X" , rock + lose },
                {"Y" , paper + draw },
                {"Z", scissors + win }
            } },
            {"C", new Dictionary<string, int> {
                {"X" , paper + lose },
                {"Y" , scissors + draw },
                {"Z", rock + win }
            } }
        };

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