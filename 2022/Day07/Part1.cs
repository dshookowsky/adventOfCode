namespace Day07;

public class Part1
{
    public int Solution(IEnumerable<string> lines)
    {
        var fileSystem = new FileSystem(lines);

        var directoriesUnder100K = fileSystem.Paths.Values
            .Select(v => new { v.Path, v.Size })
            .Where(d => d.Size < 100000)
            .ToList();

        return directoriesUnder100K.Sum(d => d.Size); ;
    }
}
