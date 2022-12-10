namespace Advent.Solutions.Day03
{
    public class Part2
    {
        public int SolutionValue(string[] lines)
        {
            int lineIndex = 0;
            var total = 0;
            while (lineIndex < lines.Length)
            {
                var x = lines[lineIndex++];
                var y = lines[lineIndex++];
                var z = lines[lineIndex++];

                var i = x.Intersect(y).Intersect(z);

                total += Priority.Score(i.First());
            }


            return total;
        }

    }
}