namespace Advent.Solutions.Day12;

public class Part1
{
    public int SolutionBFS(string[] lines)
    {
        var explored = new List<Node>();

        var (nodes, startingNode, endingNode) = InputParser.ParseInput(
            lines,
            (c) => c == 'S',
            (c) => c == 'E');

        if (startingNode == null || endingNode == null) return 0;

        startingNode.Distance = 0;

        var queue = new Queue<Node>();
        queue.Enqueue(startingNode);
        explored.Add(startingNode);

        while (queue.Any())
        {
            var v = queue.Dequeue();
            if (v == endingNode) break;

            foreach (var coordinate in v.Neighbors)
            {
                var neighbor = nodes.Where(n => n.Coordinate == coordinate).FirstOrDefault();
                if (neighbor == null) continue;
                if (explored.Contains(neighbor)) continue;
                if (neighbor.Elevation - v.Elevation > 1) continue;

                explored.Add(neighbor);
                neighbor.Parent = v;

                queue.Enqueue(neighbor);
            }
        }

        var steps = 0;
        var parent = endingNode.Parent;
        while (parent != null) { steps++; parent = parent.Parent; }

        return steps;
    }


    public int Solution(string[] lines)
    {
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
