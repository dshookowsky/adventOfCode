namespace Advent.Solutions.Day03
{
    public class Part1
    {
        public int SolutionValue(string[] lines)
        {
            int total = 0;
            foreach (var line in lines)
            {
                var (left, right) = Util.Split(line.ToCharArray(), line.Length / 2);
                var x = left.Intersect(right).ToArray();

                foreach (var c in x)
                {
                    total += Priority.Score(c);
                }

            }
            return total;
        }
    }
}