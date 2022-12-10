using Advent.Solutions.Day10;

namespace Advent.Tests
{
    [TestClass]
    public class Day10Tests
    {
        [TestMethod]
        public void Part1ReturnsKnownSolution()
        {
            var lines = File.ReadAllLines(@"C:\Projects\AdventOfCode\2022\Advent.Solutions\Day10\sample.txt");

            var part1 = new Part1();

            var solution = part1.Solution(lines);
            Assert.AreEqual(13140, solution);
        }

        [TestMethod]
        public void Part1ReturnsCorrectSolution()
        {
            var lines = File.ReadAllLines(@"C:\Projects\AdventOfCode\2022\Advent.Solutions\Day10\input.txt");

            var part1 = new Part1();

            var solution = part1.Solution(lines);
            Assert.AreEqual(11820, solution);
        }

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
               "#######.......#######.......#######....."
            };

            var part2 = new Part2();
            var solution = part2.Solution(lines);
            for (var i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], solution[i]);

            }
        }

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

            var solution = part2.Solution(lines);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], solution[i]);
            }
        }
    }
}