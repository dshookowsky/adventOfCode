namespace Advent.Solutions.Day06;

public class Part2
{
    public int Solution(string line)
    {
        var chars = line.ToCharArray();
        for (int i = 0; i < chars.Length - 14; i++)
        {
            var testSet = chars.Skip(i).Take(14).ToList();

            var groups = testSet.GroupBy(x => x).ToList();
            if (groups.Count == 14)
            {
                return i + 14;
            }
        }

        return 0;
    }
}