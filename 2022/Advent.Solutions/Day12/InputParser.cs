using System.Drawing;

namespace Advent.Solutions.Day12;

public class InputParser
{
    public static (Node[], Node? startNode, Node? endNode) ParseInput(string[] lines, Func<char, bool> isStartNode, Func<char, bool> isEndNode)
    {
        List<Node> nodes = new();
        Node? startNode = null;
        Node? endNode = null;

        lines = lines.Reverse().ToArray();

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
                        elevation = 'a' - 'a';
                        break;
                    case 'E':
                        elevation = 'z' - 'a';
                        break;
                    default:
                        elevation = line[col] - 'a';
                        break;
                }

                var node = new Node(point, elevation);
                if (isStartNode(line[col])) startNode = node;
                if (isEndNode(line[col])) endNode = node;
                nodes.Add(node);
            }

        }
        return (nodes.ToArray(), startNode, endNode);
    }
}
