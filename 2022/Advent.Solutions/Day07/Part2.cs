namespace Advent.Solutions.Day07;

public partial class Part2
{
    public int Solution(IEnumerable<string> lines)
    {
        var fileSystem = new FileSystem(lines);

        const int totalDriveSize = 70000000;
        const int requiredSpace = 30000000;

        int usedSpace = fileSystem.Root.Size;
        int availableDriveSpace = totalDriveSize - usedSpace;

        return fileSystem.Children
            .Where(d => availableDriveSpace + d.Size >= requiredSpace).ToList()
            .OrderBy(x => x.Size)
            .First()
            .Size;
    }
}