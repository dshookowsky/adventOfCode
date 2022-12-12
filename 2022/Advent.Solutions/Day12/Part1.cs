using System.Drawing;

namespace Advent.Solutions.Day12;

public class Part1
{
    public Point[] Neighbors(Point targetPoint)
    {
        return new List<Point>()
            {
                new Point(targetPoint.X + 1, targetPoint.Y),
                new Point(targetPoint.X - 1, targetPoint.Y),
                new Point(targetPoint.X, targetPoint.Y + 1),
                new Point(targetPoint.X, targetPoint.Y - 1),
            }.ToArray();
    }

    public Point GetCharacterPosition(char target, string[] lines)
    {
        for (int row = 0; row < lines.Length; row++)
        {
            var position = lines[row].IndexOf(target);
            if (position > -1)
            {
                return new Point(position, row);
            }
        }
        throw new Exception("Character not found");
    }



    private class Node
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
    }
    private readonly List<Node> Vertices = new();

    public int Solution(string[] lines)
    {
        lines = lines.Reverse().ToArray();

        Point startingLocation = new();
        Point endingLocation = new();

        for (int row = 0; row < lines.Length; row++)
        {
            var line = lines[row];
            for (int col = 0; col < line.Length; col++)
            {
                int elevation = 0;
                Point point = new(row, col);
                switch (line[col])
                {
                    case 'S':
                        elevation = 'a' - 'a' ;
                        startingLocation = point;
                        break;
                    case 'E':
                        elevation = 'z' - 'a';
                        endingLocation = point;
                        break;
                    default:
                        elevation = line[col] - 'a';
                        break;
                }

                var node = new Node(point, elevation);
                Vertices.Add(node);
            }
        }

        var startingNode = Vertices.Where(v => v.Coordinate == startingLocation).First();
        startingNode.Distance = 0;
        var endingNode = Vertices.Where(v => v.Coordinate == endingLocation).First();

        while (Vertices.Any())
        {
            Node u = Vertices.OrderBy(v => v.Distance).First();
            Vertices.Remove(u);

            foreach (var neighbor in Neighbors(u.Coordinate))
            {
                var v = Vertices
                    .Where(v => v.Coordinate == neighbor).FirstOrDefault();
                if (v == null) continue;
                if (v.Elevation - u.Elevation > 1) continue;

                int distance = u.Distance + 1;
                if (distance < v.Distance)
                {
                    v.Distance = distance;
                    v.Parent = u;
                }
            }
        }

        return endingNode.Distance;
    }
}
