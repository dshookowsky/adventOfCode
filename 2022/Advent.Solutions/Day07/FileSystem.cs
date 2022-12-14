namespace Advent.Solutions.Day07;
using System.Text.RegularExpressions;

public class FileSystem
{
    private readonly DirectoryInformation m_root;

    public FileSystem(IEnumerable<string> lines)
    {
        m_root = new ("/");

        DirectoryInformation currentDirectory = Root;

        Regex filePattern = new (@"^(\d+) (\S+)$");
        foreach (var line in lines)
        {
            // Because the input contains the result, we can ignore "$ ls"
            if (line.StartsWith("$ cd"))
            {
                if (line.EndsWith(".."))
                {
                    if (currentDirectory.Parent != null)
                    {
                        currentDirectory = currentDirectory.Parent;
                    }
                }
                else
                {
                    var directory = currentDirectory.ParseCd(line);
                    currentDirectory = directory;
                }
            }
            else if (filePattern.IsMatch(line))
            {
                var match = filePattern.Match(line);
                var size = Convert.ToInt32(match.Groups[1].Value);
                var name = match.Groups[2].Value;
                currentDirectory.Files.Add(new FileInformation(name, size));
            }
            else if (line.StartsWith("dir"))
            {
                var name = line.Split(' ')[1];
                currentDirectory.CreateSubDirectory(name);
            }
        }
    }

    public DirectoryInformation Root => m_root;

    public IEnumerable<DirectoryInformation> Children
    {
        get
        {
            yield return m_root;
            foreach (var child in m_root.Children)
            {
                yield return child;
            }
        }
    }
}