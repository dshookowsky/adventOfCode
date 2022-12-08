using System.Text.RegularExpressions;

namespace Day07;

public class FileSystem
{
    public Dictionary<string, DirectoryInformation> Paths => m_paths;
    public DirectoryInformation Root;
    private readonly Dictionary<string, DirectoryInformation> m_paths;

    public FileSystem(IEnumerable<string> lines)
    {
        Root = new("/");

        m_paths = new() { { Root.Path, Root } };
        DirectoryInformation? currentDirectory = Root;

        Regex filePattern = new(@"^(\d+) (\S+)$");
        foreach (var line in lines)
        {
            // Because the input contains the result, we can ignore "$ ls "
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
                var subDirectory = currentDirectory.CreateSubDirectory(name);
                m_paths[subDirectory.Path] = subDirectory;
            }
        }
    } 
}
