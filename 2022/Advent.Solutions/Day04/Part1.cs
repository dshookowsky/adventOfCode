namespace Advent.Solutions.Day04;

public class Part1
{
    public int Solution(IEnumerable<string> lines)
    {
        int dupes = 0;

        foreach (var line in lines)
        {
            var pairs = line.Split(',');

            var minMaxA = pairs[0].Split('-');
            var minMaxB = pairs[1].Split('-');

            if (Convert.ToInt16(minMaxA[0]) <= Convert.ToInt16(minMaxB[0]) && Convert.ToInt16(minMaxA[1]) >= Convert.ToInt16(minMaxB[1]) ||
                Convert.ToInt16(minMaxB[0]) <= Convert.ToInt16(minMaxA[0]) && Convert.ToInt16(minMaxB[1]) >= Convert.ToInt16(minMaxA[1]))
            {
                Console.WriteLine("GOOD: " + line);
                dupes++;
            }
            else
            {
                Console.WriteLine("BAD: " + line);
            }

        }
        return dupes;
    }
}