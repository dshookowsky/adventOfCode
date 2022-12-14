namespace Advent.Solutions.Day13;
using System.Diagnostics;

public class Part1
{
    public static int Solution(string[] lines)
    {
        int lineIndex = 0;
        int total = 0;
        int pairIndex = 0;

        while (lineIndex + 2 <= lines.Length)
        {
            pairIndex++;
            Debug.WriteLine($"Pair {pairIndex}");

            string left = lines[lineIndex++];
            string right = lines[lineIndex++];
            Debug.WriteLine(left);
            Debug.WriteLine(right);

            var packet1 = new Packet(left);
            var packet2 = new Packet(right);

            if (packet1.CompareTo(packet2) < 0)
            {
                total += pairIndex;
            }

            lineIndex++;
        }

        return total;
    }
}
