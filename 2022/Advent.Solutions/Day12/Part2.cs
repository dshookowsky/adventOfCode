namespace Advent.Solutions.Day12;

public class Part2
{
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

            foreach (var neighbor in u.Neighbors)
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
        var (nodes, startingNode, endingNode) = InputParser.ParseInput(
            lines,
            (c) => false,
            (c) => c == 'E');

        if (endingNode == null) return 0;

        var startingNodes = nodes.Where(v => v.Elevation == 0).ToList();

        int distance = Dijkstra(nodes.ToArray(), endingNode);

        return distance; 
    }
}
