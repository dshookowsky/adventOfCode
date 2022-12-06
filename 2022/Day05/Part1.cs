using System.Text;

namespace Day05;

public class Part1
{
    public string Solution(IEnumerable<string> lines)
    {
        var (crateStacks, instructions) = InputParser.ParseInput(lines);

        List<Stack<char>> stacks = new();
        foreach (IEnumerable<char> crateStack in crateStacks)
        {
            stacks.Add(new Stack<char>(crateStack));
        }

        //var stacks = new[] {
        //    new Stack<char>(new char[] { 'D', 'B', 'J', 'V' }),
        //    new Stack<char>(new char[] { 'P', 'V', 'B', 'W', 'R', 'D', 'F' }),
        //    new Stack<char>(new char[] { 'R', 'G', 'F', 'L', 'D', 'C', 'W', 'Q'}),
        //    new Stack<char>(new char[] { 'W', 'J', 'P', 'M', 'L', 'N', 'D', 'B' }),
        //    new Stack<char>(new char[] { 'H', 'N', 'B', 'P', 'C', 'S', 'Q' }),
        //    new Stack<char>(new char[] { 'R', 'D', 'B', 'S', 'N', 'G'}),
        //    new Stack<char>(new char[] { 'Z', 'B', 'P', 'M', 'Q', 'F', 'S', 'B'}),
        //    new Stack<char>(new char[] { 'W', 'L', 'F'}),
        //    new Stack<char>(new char[] { 'S', 'V', 'F', 'M', 'R'})
        //};

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
