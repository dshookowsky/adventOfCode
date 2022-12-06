namespace Day06;

public class Part1
{
    public int Solution(string line)
    {
        var chars = line.ToCharArray();
        for (int i = 0; i < chars.Count() - 4; i++) 
        {

            var testSet = chars.Skip(i).Take(4).ToList();

            var groups = testSet.GroupBy(x => x).ToList();
            if (groups.Count() == 4) return i + 4;
        }
        return 0;
    }
}
