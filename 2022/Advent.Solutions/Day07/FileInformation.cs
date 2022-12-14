namespace Advent.Solutions.Day07;

public class FileInformation
{
    public FileInformation(string name, int size)
    {
        Name = name;
        Size = size;
    }

    public string Name { get; set; }

    public int Size { get; set; }
}