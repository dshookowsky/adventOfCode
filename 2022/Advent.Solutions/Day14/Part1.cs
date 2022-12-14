namespace Advent.Solutions.Day14;
using System.Drawing;

public class Part1
{
    private readonly Dictionary<Point, char> m_map = new ();
    private int m_minX = int.MaxValue;

    public int Solution(string[] lines)
    {
        foreach (var p in InputParser.ParseInput(lines))
        {
            m_map.Add(p, '#');
            m_minX = Math.Min(m_minX, p.X);
        }

        int totalSand = 0;
        Point? nextPoint;
        while (true)
        {
            nextPoint = GetNextPoint();
            if (nextPoint == null)
            {
                break;
            }

            totalSand++;
            m_map.Add(nextPoint.Value, 'O');
        }

        return totalSand;
    }

    private IEnumerable<Point> GetCandidates(Point p)
    {
        var candidates = new List<Point>()
        {
            new Point(p.X, p.Y + 1),
            new Point(p.X - 1, p.Y + 1),
            new Point(p.X + 1, p.Y + 1),
        };

        return candidates;
    }

    private Point? GetNextPoint()
    {
        Point p = new (500, 0);

        bool isBlocked = false;

        while (!isBlocked)
        {
            if (!m_map.Where(m => m.Value == '#').Any(rock => rock.Key.X == p.X))
            {
                return null;
            }

            var candidates = GetCandidates(p).Where(c => !m_map.ContainsKey(c));

            if (!candidates.Any())
            {
                isBlocked = true;
            }
            else
            {
                p = candidates.First();
            }
        }

        return p;
    }
}
