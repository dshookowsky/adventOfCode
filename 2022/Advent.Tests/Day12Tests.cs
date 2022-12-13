using Advent.Solutions.Day12;

namespace Advent.Tests;

[TestClass]
public class Day12Tests
{
    [TestMethod]
    public void Part1ReturnsKnownSolution()
    {
        var part1 = new Part1();
        var lines = new string[]
        {
            "Sabqponm",
            "abcryxxl",
            "accszExk",
            "acctuvwj",
            "abdefghi"
        };

        var solution = part1.Solution(lines);
        Assert.AreEqual(31, solution);
    }

    [TestMethod]
    public void Part1BFSReturnsKnownSolution()
    {
        var part1 = new Part1();
        var lines = new string[]
        {
            "Sabqponm",
            "abcryxxl",
            "accszExk",
            "acctuvwj",
            "abdefghi"
        };

        var solution = part1.SolutionBFS(lines);
        Assert.AreEqual(31, solution);
    }

    [TestMethod]
    public void Part1ReturnsCorrectSolution()
    {
        var part1 = new Part1();
        var lines = File.ReadAllLines(@"C:\Projects\AdventOfCode\2022\Advent.Solutions\Day12\input.txt");

        var solution = part1.Solution(lines);
        Assert.AreEqual(394, solution);
    }

    [TestMethod]
    public void Part2ReturnsKnownSolution()
    {
        var part2 = new Part2();
        var lines = new string[] {
            "Sabqponm",
            "abcryxxl",
            "accszExk",
            "acctuvwj",
            "abdefghi"
        };

        var solution = part2.Solution(lines);
        Assert.AreEqual(29, solution);
    }

    [TestMethod]
    public void Part2ReturnsCorrectSolution()
    {
        var part2 = new Part2();
        var lines = File.ReadAllLines(@"C:\Projects\AdventOfCode\2022\Advent.Solutions\Day12\input.txt");

        var solution = part2.Solution(lines);
        Assert.AreEqual(388, solution);
    }
}
