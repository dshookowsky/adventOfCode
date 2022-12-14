namespace Advent.Tests;
using Advent.Solutions.Day07;

[TestClass]
public class Day07Tests
{
    [TestMethod]
    public void Part1ReturnsCorrectSolution()
    {
        var lines = File.ReadAllLines(@"C:\Projects\AdventOfCode\2022\Advent.Solutions\Day07\input.txt");

        var part1 = new Part1();

        var solution = part1.Solution(lines);

        Assert.AreEqual(1491614, solution);
    }

    [TestMethod]
    public void Part2ReturnsCorrectSolution()
    {
        var lines = File.ReadAllLines(@"C:\Projects\AdventOfCode\2022\Advent.Solutions\Day07\input.txt");
        var part2 = new Part2();

        var solution = part2.Solution(lines);

        Assert.AreEqual(6400111, solution);
    }
}