using System.Text.RegularExpressions;

namespace Advent.Solutions.Day05;

public class Part1
{  
    public int Solution(IEnumerable<string> lines)
    {
        var rules = new IRule[]
        {
            new ForbiddenStringsRule(),
            new DoubleLetterRule(),
            new VowelRule()
        };

        var sum = 0;

        foreach (var line in lines) {
            if ( rules.All(r => r.IsNice(line)) ) sum++;
        }

        return sum;
    }

    public class ForbiddenStringsRule: IRule
    {
        public int Priority => 0;

        public bool IsNice(string line)
        {
            if (line.Contains("ab") || line.Contains("cd") || line.Contains("pq") || line.Contains("xy")) return false;
            return true;
        } 

    }

    public class DoubleLetterRule : IRule
    {
        public int Priority => 1;

        public bool IsNice(string line) => line.ToCharArray().GroupBy(c => c).Where(g => g.Count() > 1).Count() > 0;
         
    }

    public class VowelRule : IRule
    {
        public int Priority => 1;
        private readonly Regex m_vowelRegex;

        public VowelRule()
        {
            m_vowelRegex = new Regex("[aeiou]");

        }
        public bool IsNice(string line) => m_vowelRegex.Matches(line).Count >= 3;
    }


    private interface IRule
    {
        int Priority { get; }
        bool IsNice(string line);
    }
}
