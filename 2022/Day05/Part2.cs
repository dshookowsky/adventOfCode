using System.Text;

namespace Day05;

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

            var moving = stacks[from].Skip(stacks[from].Count - count);
            stacks[from] = stacks[from].Take(stacks[from].Count - count).ToList();
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
