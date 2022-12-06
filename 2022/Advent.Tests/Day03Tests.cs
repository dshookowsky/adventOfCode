namespace Advent.Tests;

[TestClass]
public class Day03Tests
{
    [TestMethod]
    public void Part1ReturnsKnownSolution()
    {
        var part1 = new Day03.Part1();

        var lines = new List<string>
        {
            "vJrwpWtwJgWrhcsFMMfFFhFp",
            "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
            "PmmdzqPrVvPwwTWBwg",
            "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
            "ttgJtRGJQctTZtZT",
            "CrZsJsPPZsGzwwsLwLmpwMDw"
        };

        var solution = part1.SolutionValue(lines.ToArray());
        Assert.AreEqual(157, solution);
    }

    [TestMethod]
    public void Part1ReturnsCorrectSolution()
    {
        var lines = File.ReadAllLines(@"C:\Projects\AdventOfCode\2022\Day03\input.txt");
        var part1 = new Day03.Part1();
        var solution = part1.SolutionValue(lines.ToArray());
        Assert.AreEqual(8515, solution);
    }

    [TestMethod]
    public void Part2ReturnsKnownSolution()
    {
        var part2 = new Day03.Part2();

        var lines = new List<string>
        {
            "vJrwpWtwJgWrhcsFMMfFFhFp",
            "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
            "PmmdzqPrVvPwwTWBwg",
            "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
            "ttgJtRGJQctTZtZT",
            "CrZsJsPPZsGzwwsLwLmpwMDw"
        };

        var solution = part2.SolutionValue(lines.ToArray());
        Assert.AreEqual(70, solution);
    }

    [TestMethod]
    public void Part2ReturnsCorrectSolution()
    {
        var lines = File.ReadAllLines(@"C:\Projects\AdventOfCode\2022\Day03\input.txt");
        var part2 = new Day03.Part2();
        var solution = part2.SolutionValue(lines.ToArray());
        Assert.AreEqual(2434, solution);
    }
}
