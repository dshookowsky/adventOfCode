namespace Advent.Solutions.Day14;

using System.Diagnostics;
using System.Drawing;
using System.Text;

public class Part2
{
    private readonly Dictionary<Point, char> m_map = new ();
    private int m_minX = int.MaxValue;
    private int m_maxX = int.MinValue;
    private int m_maxY = int.MinValue;

    public int Solution(string[] lines)
    {
        foreach (var p in InputParser.ParseInput(lines))
        {
            m_map.Add(p, '#');
            m_minX = Math.Min(m_minX, p.X);
            m_maxX = Math.Max(m_maxX, p.X);
            m_maxY = Math.Max(m_maxY, p.Y);
        }

        m_maxY += 2;

        int totalSand = 0;
        var roof = new Point(500, 0);

        Point? nextPoint;
        while (true)
        {
            nextPoint = GetNextPoint();
            if (nextPoint == null)
            {
                break;
            }

            totalSand++;

            // if (totalSand % 100 == 0) RenderMap();
            m_map.Add(nextPoint.Value, 'O');
            if (nextPoint == roof)
            {
                break;
            }

            m_minX = Math.Min(m_minX, nextPoint.Value.X);
            m_maxX = Math.Max(m_maxX, nextPoint.Value.X);
        }

        return totalSand;
    }

    private static IEnumerable<Point> GetCandidates(Point p)
    {
        var candidates = new List<Point>()
        {
            new Point(p.X, p.Y + 1),
            new Point(p.X - 1, p.Y + 1),
            new Point(p.X + 1, p.Y + 1),
        };

        return candidates;
    }

    private char MapContainsKey(Point p)
    {
        return p.Y >= m_maxY ? '#' : m_map.ContainsKey(p) ? m_map[p] : '.';
    }

    private Point? GetNextPoint()
    {
        Point p = new (500, 0);

        bool isBlocked = false;

        while (!isBlocked)
        {
            var candidates = GetCandidates(p).Where(c => MapContainsKey(c) == '.');

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

    private void RenderMap()
    {
        for (int row = 0; row <= m_maxY; row++)
        {
            StringBuilder rowBuilder = new ();
            for (int col = m_minX; col < m_maxX; col++)
            {
                rowBuilder.Append(MapContainsKey(new Point(col, row)));
            }

            Debug.WriteLine(rowBuilder.ToString());
        }
    }
}
