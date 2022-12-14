namespace Advent.Solutions.Day12;

public class Part2
{
    // Broken
    public int SolutionBFS(string[] lines)
    {
        var explored = new List<Node>();

        var (nodes, startingNode, endingNode) = InputParser.ParseInput(
            lines,
            (c) => c == 'S',
            (c) => c == 'E');

        if (endingNode == null)
        {
            return 0;
        }

        endingNode.Distance = 0;

        var queue = new Queue<Node>();
        queue.Enqueue(endingNode);
        explored.Add(endingNode);

        while (queue.Any())
        {
            var v = queue.Dequeue();

            foreach (var coordinate in v.Neighbors)
            {
                var neighbor = nodes.Where(n => n.Coordinate == coordinate).FirstOrDefault();
                if (neighbor == null)
                {
                    continue;
                }

                if (explored.Contains(neighbor))
                {
                    continue;
                }

                if (v.Elevation - neighbor.Elevation > 1)
                {
                    continue;
                }

                explored.Add(neighbor);
                neighbor.Parent = v;

                queue.Enqueue(neighbor);
            }
        }

        var steps = 0;
        var startingNodes = nodes.Where(n => n.Elevation == 0);
        foreach (var n in startingNodes)
        {
            var parent = n.Parent;
            while (parent != null)
            {
                steps++;
                parent = parent.Parent;
            }
        }

        return steps;
    }

    public int Solution(string[] lines)
    {
        var (nodes, startingNode, endingNode) = InputParser.ParseInput(
            lines,
            (c) => false,
            (c) => c == 'E');

        if (endingNode == null)
        {
            return 0;
        }

        int distance = Dijkstra(nodes.ToArray(), endingNode);

        return distance;
    }

    /// <summary>
    /// Get all of the distances from last-to-first so that
    /// we don't have to re-run the search for each possible
    /// starting location.
    /// </summary>
    /// <param name="nodes"></param>
    /// <param name="startingNode">This is where the search starts, but is actually the E node</param>
    /// <returns></returns>
    private int Dijkstra(Node[] nodes, Node startingNode)
    {
        List<Node> vertices = new (nodes);

        // Unlike the first-to-last case, starting with the
        // ending location has a cost associated with it
        startingNode.Distance = 1;

        while (vertices.Any())
        {
            Node u = vertices.OrderBy(v => v.Distance).First();
            vertices.Remove(u);

            foreach (var neighbor in u.Neighbors)
            {
                var v = vertices
                    .Where(v => v.Coordinate == neighbor).FirstOrDefault();
                if (v == null)
                {
                    continue;
                }

                if (u.Elevation - v.Elevation > 1)
                {
                    continue;
                } // inverted logic for finding valid nodes

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
}
