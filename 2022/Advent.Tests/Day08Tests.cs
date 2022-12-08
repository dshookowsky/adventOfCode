using Day08;

namespace Advent.Tests;

[TestClass]
public class Day08Tests
{
    [TestMethod]
    public void Part1SolutionReturnsKnownValue()
    {
        var lines = new string[]
        {
            "30373",
            "25512",
            "65332",
            "33549",
            "35390"
        };

        var solution = new Part1().Solution(lines);

        Assert.AreEqual(21, solution);
    }

    [TestMethod]
    public void Part2SolutionReturnsKnownValue()
    {
        var lines = new string[]
        {
            "30373",
            "25512",
            "65332",
            "33549",
            "35390"
        };

        var solution = new Part2().Solution(lines);

        Assert.AreEqual(8, solution);
    }

    [TestMethod]
    public void Part1SolutionReturnsCorrectValue()
    {
        var lines = File.ReadAllLines(@"C:\Projects\AdventOfCode\2022\Day08\input.txt");

        var part1 = new Part1();
        var solution = part1.Solution(lines);
        Assert.AreEqual(1695, solution);
    }

    [TestMethod]
    public void Part2SolutionReturnsCorrectValue()
    {
        var lines = File.ReadAllLines(@"C:\Projects\AdventOfCode\2022\Day08\input.txt");

        var part2 = new Part2();
        var solution = part2.Solution(lines);
        Assert.AreEqual(287040, solution);
    }
}
