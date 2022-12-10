namespace Advent.Solutions.Day04;

public class Part2
{
    public int Solution(IEnumerable<string> lines)
    {
        var dupes = 0;
        foreach (var line in lines)
        {
            var pairs = line.Split(',');

            var minMaxA = pairs[0].Split('-');
            var minMaxB = pairs[1].Split('-');

            var a = Enumerable.Range(Convert.ToInt16(minMaxA[0]), Convert.ToInt16(minMaxA[1]) - Convert.ToInt16(minMaxA[0]) + 1).ToArray();
            var b = Enumerable.Range(Convert.ToInt16(minMaxB[0]), Convert.ToInt16(minMaxB[1]) - Convert.ToInt16(minMaxB[0]) + 1).ToArray();

            var intersection = a.Intersect(b).ToArray();
            var count = intersection.Length;
            if (count > 0) dupes++;
        }
        return dupes;
    }
}