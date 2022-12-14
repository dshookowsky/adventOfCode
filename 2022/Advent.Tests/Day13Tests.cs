namespace Advent.Tests;
using Advent.Solutions.Day13;

[TestClass]
public class Day13Tests
{
    [TestMethod]
    public void Part1ReturnsKnownSolution()
    {
        var lines = new[]
        {
            "[1, 1, 3, 1, 1]",
            "[1, 1, 5, 1, 1]",
            "",
            "[[1],[2, 3, 4]]",
            "[[1],4]",
            "",
            "[9]",
            "[[8,7,6]]",
            "",
            "[[4,4],4,4]",
            "[[4,4],4,4,4]",
            "",
            "[7,7,7,7]",
            "[7,7,7]",
            "",
            "[]",
            "[3]",
            "",
            "[[[]]]",
            "[[]]",
            "",
            "[1,[2,[3,[4,[5,6,7]]]],8,9]",
            "[1,[2,[3,[4,[5,6,0]]]],8,9]",
        };

        var solution = Part1.Solution(lines);
        Assert.AreEqual(13, solution);
    }

    [TestMethod]
    public void Part1ReturnsCorrectSolution()
    {
        var lines = File.ReadAllLines(@"C:\Projects\AdventOfCode\2022\Advent.Solutions\Day13\input.txt");

        var solution = Part1.Solution(lines);
        Assert.AreEqual(5503, solution); // 5504, 5742 too high
    }

    [TestMethod]
    public void Part2ReturnsKnownSolution()
    {
        var lines = new[]
        {
            "[1, 1, 3, 1, 1]",
            "[1, 1, 5, 1, 1]",
            "",
            "[[1],[2, 3, 4]]",
            "[[1],4]",
            "",
            "[9]",
            "[[8,7,6]]",
            "",
            "[[4,4],4,4]",
            "[[4,4],4,4,4]",
            "",
            "[7,7,7,7]",
            "[7,7,7]",
            "",
            "[]",
            "[3]",
            "",
            "[[[]]]",
            "[[]]",
            "",
            "[1,[2,[3,[4,[5,6,7]]]],8,9]",
            "[1,[2,[3,[4,[5,6,0]]]],8,9]",
        };

        var solution = Part2.Solution(lines);
        Assert.AreEqual(140, solution);
    }

    [TestMethod]
    public void Part2ReturnsCorrectSolution()
    {
        var lines = File.ReadAllLines(@"C:\Projects\AdventOfCode\2022\Advent.Solutions\Day13\input.txt");

        var solution = Part2.Solution(lines);
        Assert.AreEqual(20952, solution);
    }
}
