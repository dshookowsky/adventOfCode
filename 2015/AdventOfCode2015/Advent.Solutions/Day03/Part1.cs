using System.Drawing;
using System.Reflection.Metadata.Ecma335;

namespace Advent.Solutions.Day03;

public class Part1
{
    public int Solution(IEnumerable<string> lines)
    {
        var input = lines.First().ToCharArray();

        var point = new Point(0, 0);
        Dictionary<Point, int> housePresents = new();

        var movements = new Dictionary<char, Func<Point, Point>>()
        {
            { '>' , (p) => new Point(p.X + 1, p.Y) },
            { '<' , (p) => new Point(p.X - 1, p.Y) },
            { '^' , (p) => new Point(p.X, p.Y + 1) },
            { 'v' , (p) => new Point(p.X, p.Y - 1) },
        };

        foreach (char c in input)
        {
            if (housePresents.ContainsKey(point))
                housePresents[point]++;
            else
                housePresents.Add(point, 1);

            point = movements[c](point);
            if (housePresents.ContainsKey(point))
                housePresents[point]++;
            else
                housePresents.Add(point, 1);

        }

        return housePresents.Keys.Count;
    }
}
