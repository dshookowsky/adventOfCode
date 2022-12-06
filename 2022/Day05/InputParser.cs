using System.Text.RegularExpressions;

namespace Day05;

internal class InputParser
{
    public static (IEnumerable<char>[], IEnumerable<string> instructions) ParseInput(IEnumerable<string> lines)
    {
        int crateLines = 0;

        Stack<string> cratesStack = new();
        foreach (string line in lines)
        {
            crateLines++;
            if (line == string.Empty) break;
            cratesStack.Push(line);
        }

        var indexLine = cratesStack.Pop();
        var crateIndices = Regex.Matches(indexLine, @"\d").Select(x => x.Index).ToArray();
        List<char>[] crates = new List<char>[crateIndices.Length];

        while (cratesStack.Count > 0)
        {
            var crateLine = cratesStack.Pop().ToCharArray();

            for (int arrayIndex = 0; arrayIndex < crateIndices.Length; arrayIndex++) 
            {
                int charIndex = crateIndices[arrayIndex];
                if (crates[arrayIndex] == null) crates[arrayIndex] = new List<char>();

                char crateLetter = crateLine[charIndex];
                if (crateLetter != ' ')
                {
                    crates[arrayIndex].Add(crateLetter) ;
                }
            }
        }

        var instructions = lines.Skip(crateLines);

        return (crates, instructions);

    }
}
