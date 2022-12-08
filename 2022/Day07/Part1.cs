namespace Day07;

public class Part1
{
    public int Solution(IEnumerable<string> lines)
    {
        var fileSystem = new FileSystem(lines);
        DirectoryInformation? currentDirectory = fileSystem.Root;
               
        int DirectorySize(DirectoryInformation d)
        {
            return d.Files.Sum(f => f.Size) + d.Children.Sum(c => DirectorySize(c.Value));
        }

        var directoriesUnder100K = fileSystem.Paths.Values
            .Select(v => new { v.Path, Size = DirectorySize(v) })
            .Where(d => d.Size < 100000)
            .ToList();

        return directoriesUnder100K.Sum(d => d.Size); ;
    }
}
