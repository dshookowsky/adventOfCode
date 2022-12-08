using System.ComponentModel;

namespace Day07;

public class DirectoryInformation
{
    private readonly string m_name;
    public string Name => m_name;
    public List<FileInformation> Files = new();
    public Dictionary<string, DirectoryInformation> Children = new();

    private readonly DirectoryInformation? m_parent;
    public DirectoryInformation? Parent => m_parent;

    public string Path {
        get
        {
            if (m_parent == null)
            {
                return "/";
            }
            else
            {
                return m_parent.Path + m_name + "/";
            }
        }
    }
    public DirectoryInformation(string name)
    {
        m_name = name;
    }

    public DirectoryInformation(DirectoryInformation parent, string name)
    {
        m_parent = parent;

        m_name = name;
    }

    public DirectoryInformation ParseCd(string line)
    {
        string targetPath = line.Split(' ')[2];
        if (targetPath == Path) return this;

        string path = line.Split(' ')[2];
        return Children[path];
    }

    public DirectoryInformation CreateSubDirectory(string directoryName)
    {
        Children[directoryName] = new DirectoryInformation(this, directoryName);
        return Children[directoryName];
    }

    public int Size => Files.Sum(f => f.Size) + Children.Sum(d => d.Value.Size);
}
