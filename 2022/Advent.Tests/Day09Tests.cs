using Advent.Solutions.Day09;
using System.Drawing;

namespace Advent.Tests
{
    [TestClass]
    public class Day09Tests
    {
        [TestMethod]
        public void Part1ReturnsCorrectSolution()
        {
            var lines = File.ReadAllLines(@"C:\Projects\AdventOfCode\2022\Advent.Solutions\Day09\input.txt");

            var part1 = new Part1();
            var solution = part1.Solution(lines);
            Assert.AreEqual(6464, solution);
        }

        [TestMethod]
        public void Part2ReturnsCorrectSolution()
        {
            var lines = File.ReadAllLines(@"C:\Projects\AdventOfCode\2022\Advent.Solutions\Day09\input.txt");

            var part2 = new Part2();
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

            var part1 = new Part1();
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

            var part2 = new Part2();
            var solution = part2.Solution(lines);
            Assert.AreEqual(1, solution);
        }

        [TestMethod]
        public void MoveTailInSameRowMovesCorrectDirection()
        {
            var part2 = new Part2();

            var head = new Point(5, 0);
            var tail = new Point(3, 0);

            var actual = part2.MoveTail(head, tail);
            Assert.AreEqual(new Point(4, 0), actual);

            head = new Point(-5, 0);
            tail = new Point(-1, 0);
            actual = part2.MoveTail(head, tail);
            Assert.AreEqual(new Point(-2, 0), actual);
        }

        [TestMethod]
        public void MoveTailInSameColumnMovesCorrectDirection()
        {
            var part2 = new Part2();

            var head = new Point(0, 5);
            var tail = new Point(0, 3);

            var actual = part2.MoveTail(head, tail);
            Assert.AreEqual(new Point(0, 4), actual);
        }

        [TestMethod]
        public void TailMovesDiagonallyWhenRowAndColumnAreBothDifferent()
        {
            var part2 = new Part2();

            var head = new Point(2, 5);
            var tail = new Point(0, 3);

            var actual = part2.MoveTail(head, tail);
            Assert.AreEqual(new Point(1, 4), actual);
        }

        [TestMethod]
        public void TailDoesNotMoveWhenTouching()
        {
            var part2 = new Part2();

            var head = new Point(2, 5);
            var tail = new Point(1, 4);

            var actual = part2.MoveTail(head, tail);
            Assert.AreEqual(new Point(1, 4), actual);
        }
    }
}