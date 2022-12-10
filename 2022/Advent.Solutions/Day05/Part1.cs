using System.Text;

namespace Advent.Solutions.Day05;

public class Part1
{
    public string Solution(IEnumerable<string> lines)
    {
        var (crateStacks, instructions) = InputParser.ParseInput(lines);

        // Turn the collection of IEnumerables into a collection of stacks.
        List<Stack<char>> stacks = new();
        foreach (IEnumerable<char> crateStack in crateStacks)
        {
            stacks.Add(new Stack<char>(crateStack));
        }

        const int countIndex = 1;
        const int fromIndex = 3;
        const int toIndex = 5;

        foreach (var line in instructions)
        {
            var instruction = line.Split(' ');
            var count = Convert.ToInt16(instruction[countIndex]);
            var from = Convert.ToInt16(instruction[fromIndex]) - 1;
            var to = Convert.ToInt16(instruction[toIndex]) - 1;

            for (int i = 0; i < count; i++)
            {
                stacks[to].Push(stacks[from].Pop());
            }
        }

        StringBuilder sb = new();
        foreach (var stack in stacks)
        {
            sb.Append(stack.Pop());
        }
        return sb.ToString();
    }
}