namespace Advent.Solutions.Day12;

public class Part1
{
    public int Solution(string[] lines)
    {
        lines = lines.Reverse().ToArray();
        var (nodes, startingNode, endingNode) = InputParser.ParseInput(
            lines,
            (c) => c == 'S',
            (c) => c == 'E');
        
        if (startingNode == null || endingNode == null) return 0;

        startingNode.Distance = 0;

        List<Node> vertices = new(nodes);

        while (vertices.Any())
        {
            Node u = vertices.OrderBy(v => v.Distance).First();
            vertices.Remove(u);

            foreach (var neighbor in u.Neighbors)
            {
                var v = vertices
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
