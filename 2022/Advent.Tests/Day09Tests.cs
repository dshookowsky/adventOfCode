namespace Advent.Tests;

[TestClass]
public class Day09Tests
{
    [TestMethod]
    public void Part1ReturnsCorrectSolution()
    {
        var lines = File.ReadAllLines(@"C:\Projects\AdventOfCode\2022\Day09\input.txt");

        var part1 = new Day09.Part1();
        var solution = part1.Solution(lines);
        Assert.AreEqual(6464, solution);
    }

    [TestMethod]
    public void Part2ReturnsCorrectSolution()
    {
        var lines = File.ReadAllLines(@"C:\Projects\AdventOfCode\2022\Day09\input.txt");

        var part2 = new Day09.Part2();
        var solution = part2.Solution(lines);
        Assert.AreEqual(2604, solution);
    }

    [TestMethod]
    public void Part1ReturnsKnownSolution()
    {
        var lines = new string[]
        {
            "R 4",
            "U 4",
            "L 3",
            "D 1",
            "R 4",
            "D 1",
            "L 5",
            "R 2"
        };

        var part1 = new Day09.Part1();
        var solution = part1.Solution(lines);
        Assert.AreEqual(13, solution);
    }

    [TestMethod]
    public void Part2ReturnsKnownSolution()
    {
        var lines = new string[]
        {
            "R 4",
            "U 4",
            "L 3",
            "D 1",
            "R 4",
            "D 1",
            "L 5",
            "R 2"
        };

        var part2 = new Day09.Part2();
        var solution = part2.Solution(lines);
        Assert.AreEqual(1, solution);
    }
}
