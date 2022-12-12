using Advent.Solutions.Day03;

namespace Advent.Tests;

[TestClass]
public class Day03Tests
{
    [TestMethod]
    public void Part1ReturnsKnownSolution()
    {
        var lines = new string[] { "^>v<" };

        var part1 = new Part1();

        var solution = part1.Solution(lines);

        Assert.AreEqual(4, solution);
    }

    [TestMethod]
    public void Part1ReturnsCorrectSolution()
    {
        var lines = File.ReadAllLines(@"C:\Projects\AdventOfCode\2015\AdventOfCode2015\Advent.Solutions\Day03\input.txt");

        var part1 = new Part1();

        var solution = part1.Solution(lines);

        Assert.AreEqual(2081, solution);
    }

    [TestMethod]
    public void Part2ReturnsKnownSolution()
    {
        var lines = new string[] { "^v^v^v^v^v" };
        var part2 = new Part2();

        var solution = part2.Solution(lines);
        Assert.AreEqual(11, solution);
    }

    [TestMethod]
    public void Part2ReturnsCorrectSolution()
    {
        var lines = File.ReadAllLines(@"C:\Projects\AdventOfCode\2015\AdventOfCode2015\Advent.Solutions\Day03\input.txt");
        var part2 = new Part2();

        var solution = part2.Solution(lines);
        Assert.AreEqual(2341, solution);
    }
}
