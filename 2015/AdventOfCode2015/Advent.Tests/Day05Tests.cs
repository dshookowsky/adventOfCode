using Advent.Solutions.Day05;

namespace Advent.Tests;

[TestClass]
public class Day05Tests
{
    [TestMethod]
    public void Part1ReturnsKnownSolution()
    {
        var naughtyNice = new Dictionary<string, bool>()
        {
            //{ "ugknbfddgicrmopn", true },
            { "aaa", true },
            { "jchzalrnumimnmhp", false },
            { "haegwjzuvuyypxyu", false },
            { "dvszwmarrgswjxmb", false }
        };

        var part1 = new Part1();

        foreach (var keyValue in naughtyNice)
        {
            Assert.AreEqual(keyValue.Value ? 1 : 0, part1.Solution(new string[] { keyValue.Key }));
        }
    }

    [TestMethod]
    public void DoubleLetterRuleReturnsCorrectValues()
    {
        var rule = new Part1.DoubleLetterRule();
        Assert.IsTrue(rule.IsNice("aaa"));
        Assert.IsFalse(rule.IsNice("abc"));
    }

    [TestMethod]
    public void VowelRuleReturnsCorrectValues()
    {
        var rule = new Part1.VowelRule();
        Assert.IsTrue(rule.IsNice("aaa"));
        Assert.IsFalse(rule.IsNice("bcd"));
    }
}
