namespace Advent.Tests;

using Advent.Solutions.Day15;

[TestClass]
public class Day15Tests
{
    [TestMethod]
    public void Part1ReturnsKnownSolution()
    {
        var lines = File.ReadAllLines(@"C:\Projects\AdventOfCode\2022\Advent.Solutions\Day15\sample.txt");

        var part1 = new Part1();
        var solution = part1.Solution(lines, 10);
        Assert.AreEqual(26, solution);
    }

    [TestMethod]
    public void Part1ReturnsCorrectSolution()
    {
        var lines = File.ReadAllLines(@"C:\Projects\AdventOfCode\2022\Advent.Solutions\Day15\input.txt");

        var part1 = new Part1();
        var solution = part1.Solution(lines, 2_000_000);
        Assert.AreEqual(5125700, solution); // 4_030_975, 4_030_976 too low
    }

    [TestMethod]
    public void Part2ReturnsKnownSolution()
    {
        var lines = File.ReadAllLines(@"C:\Projects\AdventOfCode\2022\Advent.Solutions\Day15\sample.txt");

        var part2 = new Part2();
        var solution = part2.Solution(lines, 10);
        Assert.AreEqual(56000011L, solution);
    }

    [TestMethod]
    public void Part2ReturnsCorrectSolution()
    {
        var lines = File.ReadAllLines(@"C:\Projects\AdventOfCode\2022\Advent.Solutions\Day15\input.txt");

        var part2 = new Part2();
        var solution = part2.Solution(lines, 2_000_000);
        Assert.AreEqual(11379394658764, solution); 
    }
}
