namespace Advent.Solutions.Day13;
using System.Diagnostics;

public class Part2
{
    public static int Solution(string[] lines)
    {
        int lineIndex = 0;
        int pairIndex = 0;

        List<Packet> packets = new ();
        while (lineIndex + 2 <= lines.Length)
        {
            pairIndex++;

            string left = lines[lineIndex++];
            string right = lines[lineIndex++];

            packets.Add(new Packet(left));
            packets.Add(new Packet(right));

            lineIndex++; // consume blank line
        }

        var twoPacket = new Packet("[[2]]");
        var sixPacket = new Packet("[[6]]");

        packets.Add(twoPacket);
        packets.Add(sixPacket);

        packets.Sort();

        foreach (var packet in packets)
        {
            Debug.WriteLine(packet);
        }

        return (packets.IndexOf(twoPacket) + 1) * (packets.IndexOf(sixPacket) + 1);
    }
}
