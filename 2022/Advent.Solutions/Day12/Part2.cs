using System.Drawing;

namespace Advent.Solutions.Day12;

public class Part2
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

    /// <summary>
    /// Get all of the distances so from last-to-first so that 
    /// we don't have to re-run the search for each possible 
    /// starting locations.
    /// </summary>
    /// <param name="nodes"></param>
    /// <param name="startingNode">This is where the search starts, but is actually the E node</param>
    /// <returns></returns>
    private int Dijkstra(Node[] nodes, Node startingNode)
    {
        List<Node> Vertices = new(nodes);

        // Unlike the first-to-last case, starting with the
        // ending location has a cost associated with it
        startingNode.Distance = 1; 

        while (Vertices.Any())
        {
            Node u = Vertices.OrderBy(v => v.Distance).First();
            Vertices.Remove(u);

            foreach (var neighbor in Neighbors(u.Coordinate))
            {
                var v = Vertices
                    .Where(v => v.Coordinate == neighbor).FirstOrDefault();
                if (v == null) continue;

                if (u.Elevation - v.Elevation > 1) continue; // inverted logic for finding valid nodes

                int distance = u.Distance + 1;
                if (distance < v.Distance)
                {
                    v.Distance = distance;
                    v.Parent = u;
                }
            }
        }

        // Find the min distance of all of the possible start points
        return nodes.Where(n => n.Elevation == 1).Min(n => n.Distance);
    }

    public int Solution(string[] lines)
    {
        List<Node> nodes = new();

        lines = lines.Reverse().ToArray();

        Point endingLocation = new();
        List<Point> startingLocations = new();
        for (int row = 0; row < lines.Length; row++)
        {
            var line = lines[row];
            for (int col = 0; col < line.Length; col++)
            {
                int elevation = 0;
                Point point = new(col, row);
                switch (line[col])
                {
                    case 'S':
                        elevation = 'a' - 'a';
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
                nodes.Add(node);
            }
        }

        var startingNodes = nodes.Where(v => v.Elevation == 0).ToList();
        var endingNode = nodes.Where(n => n.Coordinate == endingLocation).First();

        int distance = Dijkstra(nodes.ToArray(), endingNode);

        return distance; 
    }
}
