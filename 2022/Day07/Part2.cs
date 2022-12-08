namespace Day07;

public partial class Part2
{
    public int Solution(IEnumerable<string> lines)
    {
        var fileSystem = new FileSystem(lines);

        int totalDriveSize = 70000000;
        int usedSpace = fileSystem.Root.Size;
        int availableDriveSpace = totalDriveSize - usedSpace;

        var candidates = fileSystem.Paths.Values
            .Select(v => new { v.Path, v.Size })
            .Where(d => availableDriveSpace + d.Size >= 30000000).ToList();

        var directoryToDelete = candidates
            .OrderBy(x => x.Size)
            .First();
     
        return directoryToDelete.Size;
    }
}