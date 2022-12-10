namespace Advent.Solutions.Day07;

public class FileInformation
{
    public string Name { get; set; }
    public int Size { get; set; }

    public FileInformation(string name, int size)
    {
        Name = name;
        Size = size;
    }
}