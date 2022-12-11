using Advent.Solutions.Day02;

namespace Advent.Tests;

[TestClass]
public class Day02Tests
{
    [TestMethod]
    public void Part1ReturnsKnownSolution()
    {
        var lines = new string[]
        {
            "2x3x4",
        };

        var part1 = new Part1();
        var solution = part1.Solution(lines);
        Assert.AreEqual(58, solution);
    }

    [TestMethod]
    public void Part1ReturnsKnownSolution2()
    {
        var lines = new string[]
        {
            "1x1x10",
        };

        var part1 = new Part1();
        var solution = part1.Solution(lines);
        Assert.AreEqual(43, solution);
    }

    [TestMethod]
    public void Part1ReturnsCorrectSolution()
    {
        var lines = File.ReadAllLines(@"C:\Projects\AdventOfCode\2015\AdventOfCode2015\Advent.Solutions\Day02\input.txt");

        var part1 = new Part1();
        var solution = part1.Solution(lines);
        Assert.AreEqual(1588178, solution);
    }

    [TestMethod]
    public void Part2ReturnsCorrectSolution()
    {
        var lines = File.ReadAllLines(@"C:\Projects\AdventOfCode\2015\AdventOfCode2015\Advent.Solutions\Day02\input.txt");

        var part2 = new Part2();
        var solution = part2.Solution(lines);
        Assert.AreEqual(3783758, solution);
    }
}
