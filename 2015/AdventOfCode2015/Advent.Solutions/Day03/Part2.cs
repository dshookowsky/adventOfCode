using System.Drawing;
using System.Runtime.CompilerServices;

namespace Advent.Solutions.Day03;

public class Part2
{
    private readonly Dictionary<Point, int> _housePresents = new();

    public class Santa
    {
        private readonly string _name;
        public string Name => _name;
        private Point _point = new(0, 0);
        public Point Location => _point;

        public Santa(string name)
        {
            _name = name;
        }

        private readonly Dictionary<char, Func<Point, Point>> _moveMap = new()  {
            { '>' , (p) => new (p.X + 1, p.Y) },
            { '<' , (p) => new (p.X - 1, p.Y) },
            { '^' , (p) => new (p.X, p.Y + 1) },
            { 'v' , (p) => new (p.X, p.Y - 1) },
        };

        public Point Move(char c)
        {
            _point = _moveMap[c](_point);
            return _point;
        }
    }
   
    public int Solution(IEnumerable<string> lines)
    {
        var input = lines.First().ToCharArray();

        var santa = new Santa("santa");
        var roboSanta = new Santa("roboSanta");

        var santas = new Santa[]
        {
            santa,
            roboSanta
        };


        var charIndex = 0;
        foreach (var c in input)
        {
            var s = santas[charIndex++ % santas.Length];
           DeliverPresent(s, c);
        }

        return _housePresents.Keys.Count;
        
    }

    private void DeliverPresent(Santa santa, char direction)
    {
        if (_housePresents.ContainsKey(santa.Location))
        {
            _housePresents[santa.Location]++;
        } else
        {
            _housePresents.Add(santa.Location, 1);
        }

        santa.Move(direction);
        if (_housePresents.ContainsKey(santa.Location))
        {
            _housePresents[santa.Location]++;
        }
        else
        {
            _housePresents.Add(santa.Location, 1);
        }
    }
}
