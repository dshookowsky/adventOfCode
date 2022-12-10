namespace Advent.Tests
{
    using Advent.Solutions.Day02;
    using System.IO;

    [TestClass]
    public class Day02Tests
    {
        [TestMethod]
        public void Part1ReturnsKnownSolution()
        {
            var part1 = new Part1();

            var lines = new List<string>
        {
            "A Y",
            "B X",
            "C Z"
        };

            var solution = part1.Solution(lines);

            Assert.AreEqual(15, solution);
        }

        [TestMethod]
        public void Part1ReturnsCorrectSolution()
        {
            var lines = File.ReadLines(@"C:\Projects\AdventOfCode\2022\Advent.Solutions\Day02\input.txt");
            var part1 = new Part1();
            var solution = part1.Solution(lines);

            Assert.AreEqual(12586, solution);
        }

        [TestMethod]
        public void Part2ReturnsKnownSolution()
        {
            var part2 = new Part2();

            var lines = new List<string>
        {
            "A Y",
            "B X",
            "C Z"
        };

            var solution = part2.Solution(lines);
            Assert.AreEqual(12, solution);
        }

        [TestMethod]
        public void Part2ReturnsCorrectSolution()
        {
            var lines = File.ReadLines(@"C:\Projects\AdventOfCode\2022\Advent.Solutions\Day02\input.txt");
            var part2 = new Part2();
            var solution = part2.Solution(lines);

            Assert.AreEqual(13193, solution);
        }

    }
}