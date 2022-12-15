namespace Advent.Solutions.Day15;

using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

public class Part1
{
    private int minX = int.MaxValue;
    private int maxX = int.MinValue;
    private int minY = int.MaxValue;
    private int maxY = int.MinValue;

    public long Solution(string[] lines, int targetLine)
    {
        var map = new Dictionary<Tuple<int, int>, char>();

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

            minX = Math.Min(minX, Math.Min(sensorX - sensor.ManhattanDistance, beaconX));
            minY = Math.Min(minY, Math.Min(sensorY - sensor.ManhattanDistance, beaconY));
            maxX = Math.Max(maxX, Math.Max(sensorX + sensor.ManhattanDistance, beaconX));
            maxY = Math.Max(maxY, Math.Max(sensorY + sensor.ManhattanDistance, beaconY));
        }

        int total = 0;
        CheckRow(sensorNetwork, map, targetLine);
        total = map.Where(kv => kv.Key.Item2 == targetLine).Where(kv => kv.Value == '#').Count();

        return total;
    }

    private static long ManhattanDistance(Tuple<int, int> start, Tuple<int, int> destination)
    {
        return Math.Abs(start.Item1 - destination.Item1) + Math.Abs(start.Item2 - destination.Item2);
    }

    private void CheckRow(IEnumerable<Sensor> sensors, Dictionary<Tuple<int, int>, char> map, int row)
    {
        for (int x = minX; x <= maxX; x++)
        {
            var currentLocation = new Tuple<int, int>(x, row);

            if (map.ContainsKey(currentLocation))
            {
                continue;
            }

            if (sensors.Where(s => s.Reaches(row)).Any(s => ManhattanDistance(s.SensorLocation, currentLocation) <= s.ManhattanDistance))
            {
                map[currentLocation] = '#';
            }
        }
    }

    private void VisualizeSensors(IEnumerable<Sensor> sensorNetwork, Dictionary<Tuple<int, int>, char> map)
    {
        var builder = new StringBuilder();

        for (int row = minY; row <= maxY; row++)
        {
            CheckRow(sensorNetwork, map, row);

            for (int col = minX; col <= maxX; col++)
            {
                var currentLocation = new Tuple<int, int>(col, row);

                builder.Append(map.ContainsKey(currentLocation) ? map[currentLocation] : ".");
            }

            builder.AppendLine();
        }

        Debug.WriteLine(builder.ToString());
    }

}
