﻿namespace Advent.Solutions.Day12;
using System.Drawing;

public class InputParser
{
    public static (Node[], Node? startNode, Node? endNode) ParseInput(string[] lines, Func<char, bool> isStartNode, Func<char, bool> isEndNode)
    {
        List<Node> nodes = new ();
        Node? startNode = null;
        Node? endNode = null;

        lines = lines.Reverse().ToArray();

        for (int row = 0; row < lines.Length; row++)
        {
            var line = lines[row];
            for (int col = 0; col < line.Length; col++)
            {
                Point point = new (col, row);
                var elevation = line[col] switch
                {
                    'S' => 'a' - 'a',
                    'E' => 'z' - 'a',
                    _ => line[col] - 'a',
                };

                var node = new Node(point, elevation);
                if (isStartNode(line[col]))
                {
                    startNode = node;
                }

                if (isEndNode(line[col]))
                {
                    endNode = node;
                }

                nodes.Add(node);
            }
        }

        return (nodes.ToArray(), startNode, endNode);
    }
}
