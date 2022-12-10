namespace Advent.Solutions.Day10;

public class Part1
{
    public int Solution(IEnumerable<string> lines)
    {
        int x = 1;
        int cycle = 1;
        Dictionary<int, int> signalStrength = new();
        int nextCycle = 20;
        foreach (var line in lines)
        {
            var command = line.Split(' ');
            var instruction = command[0];
            var initialX = x;
            int instructionCycles = 0;

            int data = 0;
            if (instruction != "noop")
            {
                data = int.Parse(command[1].Trim());
            }
            switch (instruction)
            {
                case "addx":
                    x += data;
                    instructionCycles = 2;
                    break;
                case "noop":
                    instructionCycles = 1;
                    break;
                default:
                    
                    break;
            }
            cycle += instructionCycles;
            if (cycle == nextCycle)
            {
                signalStrength[cycle] = x * cycle;
                nextCycle += 40;
            }
            else if (cycle > nextCycle && cycle - instructionCycles < nextCycle)
            {
                signalStrength[nextCycle] = initialX * nextCycle;
                nextCycle += 40;
            }
        }

        return signalStrength.Values.Sum();
    }
}
