namespace Advent.Tests;
using Advent.Solutions.Day10;

/// <summary>
/// Tests for Day 10.
/// </summary>
[TestClass]
public class Day10Tests
{
    /// <summary>
    /// Part 1 returns the correct value for a known solution.
    /// </summary>
    [TestMethod]
    public void Part1ReturnsKnownSolution()
    {
        var lines = File.ReadAllLines(@"C:\Projects\AdventOfCode\2022\Advent.Solutions\Day10\sample.txt");

        var part1 = new Part1();

        var solution = part1.Solution(lines);
        Assert.AreEqual(13140, solution);
    }

    /// <summary>
    /// Part 1 returns the correct value for the input data.
    /// </summary>
    [TestMethod]
    public void Part1ReturnsCorrectSolution()
    {
        var lines = File.ReadAllLines(@"C:\Projects\AdventOfCode\2022\Advent.Solutions\Day10\input.txt");

        var part1 = new Part1();

        var solution = part1.Solution(lines);
        Assert.AreEqual(11820, solution);
    }

    /// <summary>
    /// Part 1 returns the correct value for a known solution.
    /// </summary>
    [TestMethod]
    [Ignore]
    public void Part2ReturnsKnownSolution()
    {
        var lines = File.ReadAllLines(@"C:\Projects\AdventOfCode\2022\Advent.Solutions\Day10\sample.txt");
        var expected = new string[]
        {
           "##..##..##..##..##..##..##..##..##..##..",
           "###...###...###...###...###...###...###.",
           "####....####....####....####....####....",
           "#####.....#####.....#####.....#####.....",
           "######......######......######......####",
           "#######.......#######.......#######.....",
        };

        var part2 = new Part2();
        var solution = Part2.Solution(lines);
        for (var i = 0; i < expected.Length; i++)
        {
            Assert.AreEqual(expected[i], solution[i]);
        }
    }

    /// <summary>
    /// Part 1 returns the correct value for the input data.
    /// </summary>
    [TestMethod]
    public void Part2ReturnsCorrectSollution()
    {
        var lines = File.ReadAllLines(@"C:\Projects\AdventOfCode\2022\Advent.Solutions\Day10\input.txt");
        var expected = new string[]
        {
            "####.###....##.###..###..#..#..##..#..#.",
            "#....#..#....#.#..#.#..#.#.#..#..#.#..##",
            "###..#..#....#.###..#..#.##...#..#.#####",
            "#....###.....#.#..#.###..#.#..####.#..#.",
            "#....#....#..#.#..#.#.#..#.#..#..#.#..##",
            "####.#.....##..###..#..#.#..#.#..#.#..#.",
        };

        var part2 = new Part2();

        var solution = Part2.Solution(lines);
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.AreEqual(expected[i], solution[i]);
        }
    }
}