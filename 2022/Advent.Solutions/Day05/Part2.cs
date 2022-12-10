using System.Text;

namespace Advent.Solutions.Day05;

public class Part2
{
    public string Solution(IEnumerable<string> lines)
    {
        var (crates, instructions) = InputParser.ParseInput(lines);

        List<List<char>> stacks = new();
        foreach (var crate in crates)
        {
            stacks.Add(new List<char>(crate));
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

            // Determine how many items will remain in the list. Take all the other items
            // and put them in a moving pile. Update the pile to exclude those moving items.
            int remainingItemsCount = stacks[from].Count - count;
            var moving = stacks[from].Skip(remainingItemsCount);
            stacks[from] = stacks[from].Take(remainingItemsCount).ToList();
            stacks[to].AddRange(moving);
        }

        StringBuilder sb = new();
        foreach (var stack in stacks)
        {
            sb.Append(stack.Last());
        }
        return sb.ToString();
    }

}