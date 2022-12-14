namespace Advent.Tests;

using Advent.Solutions.Day05;
using System.Diagnostics.CodeAnalysis;

[SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1122:UseStringEmptyForEmptyStrings", Justification = "Reviewed.")]
[TestClass]
public class Day05Tests
{
    [TestMethod]
    public void Part1ReturnsKnownSolution()
    {
        var part1 = new Part1();

        var lines = new List<string>
    {
        "    [D]    ",
        "[N] [C]    ",
        "[Z] [M] [P]",
        " 1   2   3 ",
        "",
        "move 1 from 2 to 1",
        "move 3 from 1 to 3",
        "move 2 from 2 to 1",
        "move 1 from 1 to 2",
    };

        var solution = part1.Solution(lines);

        Assert.AreEqual("CMZ", solution);
    }

    [TestMethod]
    public void Part1ReturnsCorrectSolution()
    {
        var lines = File.ReadLines(@"C:\Projects\AdventOfCode\2022\Advent.Solutions\Day05\input.txt");
        var part1 = new Part1();
        var solution = part1.Solution(lines);

        Assert.AreEqual("BSDMQFLSP", solution);
    }

    [TestMethod]
    public void Part2ReturnsKnownSolution()
    {
        var part2 = new Part2();

        var lines = new List<string>
    {
        "    [D]    ",
        "[N] [C]    ",
        "[Z] [M] [P]",
        " 1   2   3 ",
        "",
        "move 1 from 2 to 1",
        "move 3 from 1 to 3",
        "move 2 from 2 to 1",
        "move 1 from 1 to 2",
    };

        var solution = part2.Solution(lines);
        Assert.AreEqual("MCD", solution);
    }

    [TestMethod]
    public void Part2ReturnsCorrectSolution()
    {
        var lines = File.ReadLines(@"C:\Projects\AdventOfCode\2022\Advent.Solutions\Day05\input.txt");
        var part2 = new Part2();
        var solution = part2.Solution(lines);

        Assert.AreEqual("PGSQBFLDP", solution);
    }
}