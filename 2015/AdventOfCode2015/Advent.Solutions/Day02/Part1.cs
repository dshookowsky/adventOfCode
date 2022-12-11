namespace Advent.Solutions.Day02;

public class Part1
{
    public int Solution(IEnumerable<string> lines)
    {
        var total = 0;
        foreach (var line in lines)
        {
            var edges = line.Split('x').Select(x=> int.Parse(x)).ToArray();

            var subTotal = 0;
            subTotal += (
                2 * (edges[0] * edges[1]) + 
                2 * (edges[1] * edges[2]) + 
                2 * (edges[2] * edges[0]));

            var sorted = edges.OrderBy(x => x).ToArray();
            subTotal += sorted[0] * sorted[1]; 

            total += subTotal;
        }
        return total;
    }
}
