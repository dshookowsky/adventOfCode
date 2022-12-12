using Advent.Solutions.Day04;

namespace Advent.Tests;

[TestClass]
public class Day04Tests
{
    [TestMethod]
    public void Part1ReturnsKnownSolution()
    {
        var key = "abcdef";

        var part1 = new Part1();
        var solution = part1.Solution(key);

        Assert.AreEqual(609043, solution);
    }

    [TestMethod]
    public void Part1ReturnsCorrectSolution()
    {
        var key = "yzbqklnj";

        var part1 = new Part1();
        var solution = part1.Solution(key);

        Assert.AreEqual(282749, solution);
    }

    [TestMethod]
    public void Part2ReturnsCorrectSolution()
    {
        var key = "yzbqklnj";

        var part2 = new Part2();
        var solution = part2.Solution(key);

        Assert.AreEqual(9962624, solution);
    }
}
