using Advent.Solutions.Day04;
namespace Advent.Tests
{
    [TestClass]
    public class Day04Tests
    {
        [TestMethod]
        public void Part1ReturnsKnownSolution()
        {
            var lines = new string[]
            {
            "2-4,6-8",
            "2-3,4-5",
            "5-7,7-9",
            "2-8,3-7",
            "6-6,4-6",
            "2-6,4-8"
            };
            var part1 = new Part1();

            var solution = part1.Solution(lines);
            Assert.AreEqual(2, solution);
        }

        [TestMethod]
        public void Part1ReturnsCorrectSolution()
        {
            var lines = File.ReadAllLines(@"C:\Projects\AdventOfCode\2022\Advent.Solutions\Day04\input.txt");
            var part1 = new Part1();
            var solution = part1.Solution(lines);
            Assert.AreEqual(530, solution);
        }

        [TestMethod]
        public void Part2ReturnsKnownSolution()
        {
            var lines = new string[]
            {
            "2-4,6-8",
            "2-3,4-5",
            "5-7,7-9",
            "2-8,3-7",
            "6-6,4-6",
            "2-6,4-8"
            };
            var part2 = new Part2();

            var solution = part2.Solution(lines);
            Assert.AreEqual(4, solution);
        }

        [TestMethod]
        public void Part2ReturnsCorrectSolution()
        {
            var lines = File.ReadAllLines(@"C:\Projects\AdventOfCode\2022\Advent.Solutions\Day04\input.txt");
            var part2 = new Part2();
            var solution = part2.Solution(lines);
            Assert.AreEqual(903, solution);
        }
    }
}