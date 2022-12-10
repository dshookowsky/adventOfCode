using System.Drawing;

namespace Advent.Solutions.Day09;

public class Part2
{
    private class State
    {
        public Point Point = new(0, 0);
        public Dictionary<Point, int> PointHistory = new()
    {
        { new Point(0,0), 1 }
    };

        public void Move(Point point)
        {
            Point = point;

            if (PointHistory.ContainsKey(point))
            {
                PointHistory[point]++;
            }
            else
            {
                PointHistory.Add(point, 1);
            }
        }
    }

    public Point MoveTail(Point head, Point tail)
    {
        var tailX = tail.X;
        var tailY = tail.Y;
        int directionX = head.X.CompareTo(tailX);
        int directionY = head.Y.CompareTo(tailY);

        if (head.X != tail.X && head.Y == tailY) // same row
        {
            if (Math.Abs(tailX - head.X) > 1) tailX += directionX;
        }
        else if (head.Y != tail.Y && head.X == tailX) // same column
        {
            if (Math.Abs(tailY - head.Y) > 1) tailY += directionY;
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

        List<State> knots = new();

        for (int x = 0; x < 10; x++)
        {
            knots.Add(new State());
        }

        int step = 0;
        foreach (var line in lines)
        {
            var instructions = line.Split(' ');
            string direction = instructions[0];
            int distance = int.Parse(instructions[1]);

            Dictionary<string, Func<Point, Point>> directions = new()
        {
            { "L" , (p) => new Point(p.X - 1, p.Y) },
            { "R" , (p) => new Point(p.X + 1, p.Y) },
            { "U" , (p) => new Point(p.X, p.Y + 1) },
            { "D" , (p) => new Point(p.X, p.Y - 1) }
        };

            State head = knots[0];
            for (var i = 0; i < distance; i++)
            {
                head.Move(directions[direction](head.Point));

                for (var knotIndex = 1; knotIndex < knots.Count; knotIndex++)
                {
                    knots[knotIndex].Move(
                        MoveTail(knots[knotIndex - 1].Point, knots[knotIndex].Point)
                    );
                }
            }

            ++step;
        }

        return knots.Last().PointHistory.Keys.Count;
    }
}