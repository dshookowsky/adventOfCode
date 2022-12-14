namespace Advent.Solutions.Day05;
using System.Text.RegularExpressions;

internal class InputParser
{
    public static (IEnumerable<char>[] crates, IEnumerable<string> instructions) ParseInput(IEnumerable<string> lines)
    {
        int crateLines = 0;

        // We want the crates in reverse order anyway, so push them on to a stack
        // until we determine what index is used for each pile of crates.
        Stack<string> cratesStack = new ();
        foreach (string line in lines)
        {
            crateLines++;
            if (line == string.Empty)
            {
                break;
            }

            cratesStack.Push(line);
        }

        // Pop the index line. This will be numbers separated by spaces.
        var indexLine = cratesStack.Pop();

        // Find the index of each digit. We'll use these indices to get the crates.
        var crateIndices = Regex.Matches(indexLine, @"\d").Select(x => x.Index).ToArray();
        var crates = new List<char>[crateIndices.Length];

        while (cratesStack.Count > 0)
        {
            var crateLine = cratesStack.Pop().ToCharArray();

            // crateLine represents one strata of crates in the piles. Pull the crate character
            // from the index and add it to the list of crates in that pile.
            for (int arrayIndex = 0; arrayIndex < crateIndices.Length; arrayIndex++)
            {
                int charIndex = crateIndices[arrayIndex];
                if (crates[arrayIndex] == null)
                {
                    crates[arrayIndex] = new List<char>();
                }

                char crateLetter = crateLine[charIndex];
                if (crateLetter != ' ')
                {
                    crates[arrayIndex].Add(crateLetter);
                }
            }
        }

        // The instructions are just everything after the crates.
        var instructions = lines.Skip(crateLines);

        return (crates, instructions);
    }
}