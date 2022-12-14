namespace Advent.Tests;
using Advent.Solutions.Day13;
using System.Diagnostics.CodeAnalysis;

[SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1122:UseStringEmptyForEmptyStrings", Justification = "Reviewed.")]
[TestClass]
public class Day13Tests
{
    [TestMethod]
    public void Part1ReturnsKnownSolution()
    {
        var lines = new[]
        {
            "[1, 1, 3, 1, 1]",
            "[1, 1, 5, 1, 1]",
            "",
            "[[1],[2, 3, 4]]",
            "[[1],4]",
            "",
            "[9]",
            "[[8,7,6]]",
            "",
            "[[4,4],4,4]",
            "[[4,4],4,4,4]",
            "",
            "[7,7,7,7]",
            "[7,7,7]",
            "",
            "[]",
            "[3]",
            "",
            "[[[]]]",
            "[[]]",
            "",
            "[1,[2,[3,[4,[5,6,7]]]],8,9]",
            "[1,[2,[3,[4,[5,6,0]]]],8,9]",
        };

        var part1 = new Part1();
        var solution = part1.Solution(lines);
        Assert.AreEqual(13, solution);
    }

    [TestMethod]
    public void Part1ReturnsCorrectSolution()
    {
        var lines = File.ReadAllLines(@"C:\Projects\AdventOfCode\2022\Advent.Solutions\Day13\input.txt");
        var part1 = new Part1();

        var solution = part1.Solution(lines);
        Assert.AreEqual(0, solution); // 5504, 5742 too high
    }
}
