namespace Advent.Solutions.Day14;
using System.Drawing;

public class InputParser
{
    public static Point[] ParseInput(string[] lines)
    {
        List<Point> rockCoordinates = new ();
        foreach (var line in lines)
        {
            Point? previousCoordinate = null;
            foreach (var coordinatePair in line.Split(" -> "))
            {
                var coordinateArray = coordinatePair.Split(",");
                var x = int.Parse(coordinateArray[0]);
                var y = int.Parse(coordinateArray[1]);
                Point currentCoordinate = new (x, y);

                if (previousCoordinate.HasValue)
                {
                    var s = previousCoordinate.Value;
                    rockCoordinates.AddRange(new Vector(s, currentCoordinate).Points);
                }

                previousCoordinate = currentCoordinate;
            }
        }

        return rockCoordinates.Distinct().ToArray();
    }

    private class Vector
    {
        private readonly List<Point> m_points = new ();

        public Vector(Point start, Point end)
        {
            if (start.X != end.X)
            {
                for (var rockX = start.X; Math.Abs(rockX - end.X) > 0; rockX += end.X.CompareTo(rockX))
                {
                    m_points.Add(new Point(rockX, start.Y));
                }
            }
            else if (start.Y != end.Y)
            {
                for (var rockY = start.Y; Math.Abs(rockY - end.Y) > 0; rockY += end.Y.CompareTo(rockY))
                {
                    m_points.Add(new Point(start.X, rockY));
                }
            }

            m_points.Add(end); // Add the last point because the loop terminator doesn't include it.
        }

        public IEnumerable<Point> Points => m_points;
    }
}
