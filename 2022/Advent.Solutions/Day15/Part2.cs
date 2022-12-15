namespace Advent.Solutions.Day15;
using System.Text.RegularExpressions;

public class Part2
{
    private int m_maxRange;

    public long Solution(string[] lines, int targetLine)
    {
        Dictionary<Tuple<int, int>, char> map = new ();

        m_maxRange = 2 * targetLine;

        var sensorNetwork = new List<Sensor>();

        var regEx = new Regex(@".+x=(?<sensorX>-?\d+), y=(?<sensorY>-?\d+).+x=(?<beaconX>-?\d+), y=(?<beaconY>-?\d+)$");
        foreach (var line in lines)
        {
            var match = regEx.Match(line);

            var sensorX = int.Parse(match.Groups["sensorX"].Value);
            var sensorY = int.Parse(match.Groups["sensorY"].Value);
            var beaconX = int.Parse(match.Groups["beaconX"].Value);
            var beaconY = int.Parse(match.Groups["beaconY"].Value);

            var sensorLocation = new Tuple<int, int>(sensorX, sensorY);
            var beaconLocation = new Tuple<int, int>(beaconX, beaconY);
            var sensor = new Sensor(sensorLocation, beaconLocation);
            sensorNetwork.Add(sensor);

            map[sensorLocation] = 'S';
            map[beaconLocation] = 'B';
        }

        foreach (Sensor sensor in sensorNetwork)
        {
            var points = GetTestPoints(sensor);
            foreach (var point in points)
            {
                if (map.ContainsKey(point))
                {
                    continue;
                }

                if (TestPoint(sensorNetwork, point.Item1, point.Item2))
                {
                    var result = ((long)point.Item1 * 4000000) + point.Item2;
                    return result;
                } 
                else
                {
                    map[point] = '#';
                }
            }
        }

        return 0;
    }

    private static int ManhattanDistance(Tuple<int, int> start, Tuple<int, int> destination)
    {
        return Math.Abs(start.Item1 - destination.Item1) + Math.Abs(start.Item2 - destination.Item2);
    }

    private static bool TestPoint(IEnumerable<Sensor> sensors, int x, int y)
    {
        var currentLocation = new Tuple<int, int>(x, y);

        return !sensors
            .Where(s => s.Reaches(y))
            .Any(s => ManhattanDistance(s.SensorLocation, currentLocation) <= s.ManhattanDistance);
    }

    /// <summary>
    /// Beacon must be at a place where three or more sensors overlap e.g. 1 = sensor 1
    /// 2 = sensor 2, 3 = sensor 3 and B = beacon
    ///    3  1 2
    ///     31 2
    ///     132
    ///    1B23
    /// Walk around the perimeter of the sensor footprint and collect the valid points.
    /// </summary>
    /// <param name="sensor">A sensor</param>
    /// <returns>A list of points just outside the sensor's range.</returns>
    private IEnumerable<Tuple<int, int>> GetTestPoints(Sensor sensor)
    {
        var testPoints = new List<Tuple<int, int>>();

        int x = sensor.X;
        int y = sensor.Y + sensor.ManhattanDistance + 1;

        var operations = new {
            dy = new[] { -1, -1, 1, 1 },
            dX = new[] { 1, -1, -1, 1 }
        };

        for (int operationIndex = 0; operationIndex < operations.dy.Length; operationIndex++)
        {
            for (int index = 0; index < sensor.ManhattanDistance + 1; index++)
            {
                testPoints.Add(new Tuple<int, int>(x, y));
                x += operations.dX[operationIndex];
                y += operations.dy[operationIndex];
            }
        }

        return testPoints.Where(p => p.Item1 >= 0 && p.Item1 <= m_maxRange && p.Item2 >= 0 && p.Item2 <= m_maxRange);
    }
}
