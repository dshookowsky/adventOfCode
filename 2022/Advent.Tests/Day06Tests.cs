namespace Advent.Tests;

[TestClass]
public class Day06Tests
{
    [TestMethod]
    public void Part1ReturnsKnownSolution()
    {
        var lines = "bvwbjplbgvbhsrlpgdmjqwftvncz";

        var part1 = new Day06.Part1();
        var solution = part1.Solution(lines);
        Assert.AreEqual(5, solution);
    }

    [TestMethod]
    public void Part2ReturnsKnownSolution()
    {
        var lines = "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg";


        var part2 = new Day06.Part2();
        var solution = part2.Solution(lines);
        Assert.AreEqual(29, solution);
    }

    [TestMethod]
    public void Part1ReturnsCorrectSolution()
    {
        var lines = File.ReadAllLines(@"C:\projects\AdventOfCode\2022\Day06\input.txt").First();
    
        var part1 = new Day06.Part1();
        var solution = part1.Solution(lines);
        Assert.AreEqual(1760, solution);
    }

    [TestMethod]
    public void Part2ReturnsCorrectSolution()
    {
        var lines = File.ReadAllLines(@"C:\projects\AdventOfCode\2022\Day06\input.txt").First();

        var part2 = new Day06.Part2();
        var solution = part2.Solution(lines);
        Assert.AreEqual(2974, solution);
    }
}
