namespace Advent.Tests;

using Advent.Solutions.Day14;

[TestClass]
public class Day14Tests
{
    [TestMethod]
    public void Part1ReturnsKnownSolution()
    {
        var lines = new[]
        {
            "498,4 -> 498,6 -> 496,6",
            "503,4 -> 502,4 -> 502,9 -> 494,9",
        };

        var part1 = new Part1();
        var solution = part1.Solution(lines);
        Assert.AreEqual(24, solution);
    }

    [TestMethod]
    public void Part2ReturnsKnownSolution()
    {
        var lines = new[]
        {
            "498,4 -> 498,6 -> 496,6",
            "503,4 -> 502,4 -> 502,9 -> 494,9",
        };

        var part2 = new Part2();
        var solution = part2.Solution(lines);
        Assert.AreEqual(93, solution);
    }

    [TestMethod]
    public void Part1ReturnsCorrectSolution()
    {
        var lines = File.ReadAllLines(@"C:\Projects\AdventOfCode\2022\Advent.Solutions\Day14\input.txt");

        var part1 = new Part1();
        var solution = part1.Solution(lines);
        Assert.AreEqual(1061, solution);
    }

    [TestMethod]
    public void Part2ReturnsCorrectSolution()
    {
        var lines = File.ReadAllLines(@"C:\Projects\AdventOfCode\2022\Advent.Solutions\Day14\input.txt");

        var part2 = new Part2();
        var solution = part2.Solution(lines);
        Assert.AreEqual(25055, solution);
    }
}
