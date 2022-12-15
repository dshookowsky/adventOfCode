namespace Advent.Solutions.Day15;

public class Sensor
{
    private readonly Tuple<int, int> m_sensorLocation;
    private readonly Tuple<int, int> m_beaconLocation;
    private readonly int m_distance;

    public Sensor(Tuple<int, int> sensorLocation, Tuple<int, int> beaconLocation)
    {
        m_distance = Math.Abs(beaconLocation.Item1 - sensorLocation.Item1) +
            Math.Abs(beaconLocation.Item2 - sensorLocation.Item2);

        m_sensorLocation = sensorLocation;
        m_beaconLocation = beaconLocation;
    }

    public Tuple<int, int> SensorLocation => m_sensorLocation;

    public Tuple<int, int> BeaconLocation => m_beaconLocation;

    public int ManhattanDistance => m_distance;

    public int X => m_sensorLocation.Item1;

    public int Y => m_sensorLocation.Item2;

    public bool Reaches(int lineNumber) => Math.Abs(Y - lineNumber) <= ManhattanDistance;
}
