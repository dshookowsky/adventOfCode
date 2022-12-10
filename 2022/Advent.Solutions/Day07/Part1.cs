namespace Advent.Solutions.Day07;

public class Part1
{
    public int Solution(IEnumerable<string> lines)
    {
        var fileSystem = new FileSystem(lines);

        return fileSystem.Children
            .Where(d => d.Size < 100000)
            .Sum(d => d.Size);
    }
}