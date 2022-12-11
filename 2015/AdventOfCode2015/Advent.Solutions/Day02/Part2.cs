namespace Advent.Solutions.Day02;

public class Part2
{
    public int Solution(IEnumerable<string> lines)
    {
        var total = 0;
        foreach (var line in lines)
        {
            var sortedEdges = line
                .Split('x')
                .Select(x => int.Parse(x))
                .OrderBy(x => x)
                .ToArray();

            var perimeter = 2 * sortedEdges[0] + 2 * sortedEdges[1];
            var bow = sortedEdges[0] * sortedEdges[1] * sortedEdges[2];

            total += perimeter + bow;
        }
        return total;
    }
 }
