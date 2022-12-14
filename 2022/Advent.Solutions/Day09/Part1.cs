namespace Advent.Solutions.Day09;

using System.Diagnostics;
using System.Drawing;
using System.Text;

public class Part1
{
    public record State(
#pragma warning disable SA1313 // Parameter names should begin with lower-case letter
        Dictionary<string, int> TailHistory,
        Point Head,
        Point Tail);
#pragma warning restore SA1313 // Parameter names should begin with lower-case letter

    public State MoveHead(State state, int dX, int dY)
    {
        Point head = state.Head;
        Point tail = state.Tail;
        var tailHistory = state.TailHistory;

        Point destination = new (head.X + dX, head.Y + dY);

        while (head != destination)
        {
            int xDirection = destination.X.CompareTo(head.X);
            int yDirection = destination.Y.CompareTo(head.Y);
            head.X += xDirection;
            head.Y += yDirection;
            tail = MoveTail(head, tail);
            var newKey = $"{tail.X},{tail.Y}";

            if (tailHistory.ContainsKey(newKey))
            {
                tailHistory[newKey] += 1;
            }
            else
            {
                tailHistory[newKey] = 1;
            }

            // PrintState(new State(tailHistory, head, tail));
        }

        return new State
        (
            tailHistory,
            destination,
            tail);
    }

    public Point MoveTail(Point head, Point tail)
    {
        var tailX = tail.X;
        var tailY = tail.Y;
        int directionX = head.X.CompareTo(tailX);
        int directionY = head.Y.CompareTo(tailY);

        if (head.X != tail.X && head.Y == tailY) // same row
        {
            while (Math.Abs(tailX - head.X) > 1)
            {
                tailX += directionX;
            }
        }
        else if (head.Y != tail.Y && head.X == tailX) // same column
        {
            while (Math.Abs(tailY - head.Y) > 1)
            {
                tailY += directionY;
            }
        }
        else // different rows and columns
        {
            if (Math.Abs(tailX - head.X) + Math.Abs(tailY - head.Y) > 2)
            {
                tailX += directionX;
                tailY += directionY;
            }
        }

        return new Point(tailX, tailY);
    }

    public int Solution(IEnumerable<string> lines)
    {
        State state = new (
            new Dictionary<string, int>()
            {
                { "0,0", 1 }
            },
            new Point(0, 0),
            new Point(0, 0));

        int step = 0;
        foreach (var line in lines)
        {
            var split = line.Split(' ');
            string direction = split[0];
            int distance = int.Parse(split[1]);

            switch (direction)
            {
                case "L":
                    state = MoveHead(state, -distance, 0);
                    break;
                case "R":
                    state = MoveHead(state, distance, 0);
                    break;
                case "U":
                    state = MoveHead(state, 0, distance);
                    break;
                case "D":
                    state = MoveHead(state, 0, -distance);
                    break;
            }

            ++step;

            // PrintState(state, ++step);
        }

        return state.TailHistory.Keys.Count;
    }

    private void PrintState(State state, int step)
    {
        var coordinates = state.TailHistory.Keys.Select(k =>
        {
            var coord = k.Split(',');
            return new { X = Convert.ToInt32(coord[0]), Y = Convert.ToInt32(coord[1]) };
        });
        var xMin = coordinates.Min(p => p.X);
        var xMax = coordinates.Max(p => p.X);
        var yMin = coordinates.Min(p => p.Y);
        var yMax = coordinates.Max(p => p.Y);

        xMin = new[] { xMin, state.Head.X, state.Tail.X }.Min();
        xMax = new[] { xMax, state.Head.X, state.Tail.X }.Max();
        yMin = new[] { yMin, state.Head.Y, state.Tail.Y }.Min();
        yMax = new[] { yMax, state.Head.Y, state.Tail.Y }.Max();

        StringBuilder output = new ();
        output.AppendLine($"Step {step}");

        for (var y = yMax; y >= yMin; y--)
        {
            output.AppendFormat("{0,5}  ", y);
            for (var x = xMin; x <= xMax; x++)
            {
                Point point = new (x, y);
                if (point == state.Head)
                {
                    output.Append('H');
                }
                else if (point == state.Tail)
                {
                    output.Append('T');
                }
                else if (point == new Point(0, 0))
                {
                    output.Append('s');
                }
                else if (state.TailHistory.ContainsKey($"{x},{y}"))
                {
                    output.Append('#');
                }
                else
                {
                    output.Append('.');
                }
            }

            output.Append('\n');
        }

        Debug.WriteLine(output.ToString());
        Debug.WriteLine("-------------------------------");
    }
}