namespace Advent.Solutions.Day12;
using System.Drawing;

public class Node
{
    public Node(Point coordinate, int elevation)
    {
        Coordinate = coordinate;
        Elevation = elevation;
    }

    public Node? Parent { get; set; }

    public int Elevation { get; set; }

    public int Distance { get; set; } = int.MaxValue;

    public Point Coordinate { get; set; }

    public Point[] Neighbors =>
        new List<Point>()
        {
                new Point(Coordinate.X + 1, Coordinate.Y),
                new Point(Coordinate.X - 1, Coordinate.Y),
                new Point(Coordinate.X, Coordinate.Y + 1),
                new Point(Coordinate.X, Coordinate.Y - 1),
        }.ToArray();
}
