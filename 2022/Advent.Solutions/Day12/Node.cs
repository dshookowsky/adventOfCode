using System.Drawing;

namespace Advent.Solutions.Day12;

public class Node
{
    public Node? Parent;
    public int Elevation;
    public int Distance = int.MaxValue;
    public Point Coordinate;

    public Node(Point coordinate, int elevation)
    {
        Coordinate = coordinate;
        Elevation = elevation;
    }

    public Point[] Neighbors =>
        new List<Point>()
        {
                new Point(Coordinate.X + 1, Coordinate.Y),
                new Point(Coordinate.X - 1, Coordinate.Y),
                new Point(Coordinate.X, Coordinate.Y + 1),
                new Point(Coordinate.X, Coordinate.Y - 1),
        }.ToArray();
}
