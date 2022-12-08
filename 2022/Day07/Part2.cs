namespace Day07;

public partial class Part2
{
    public int Solution(IEnumerable<string> lines)
    {
        var fileSystem = new FileSystem(lines);

        int DirectorySize(DirectoryInformation d)
        {
            return d.Files.Sum(f => f.Size) + d.Children.Sum(c => DirectorySize(c.Value));
        }

        int totalDriveSize = 70000000;
        int usedSpace = DirectorySize(fileSystem.Root);
        int availableDriveSpace = totalDriveSize - usedSpace;

        var candidates = fileSystem.Paths.Values
            .Select(v => new { Path = v.Path, Size = DirectorySize(v) })
            .Where(d => availableDriveSpace + d.Size >= 30000000).ToList();

        var directoryToDelete = candidates
            .OrderBy(x => x.Size)
            .First();
     
        return directoryToDelete.Size;
    }
}