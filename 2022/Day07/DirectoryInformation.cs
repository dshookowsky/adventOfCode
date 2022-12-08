using System.ComponentModel;

namespace Day07;

public class DirectoryInformation
{
    private readonly string m_name;
    public string Name => m_name;
    public List<FileInformation> Files = new();

    private Dictionary<string, DirectoryInformation> m_children = new();

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
        return m_children[path];
    }

    public IEnumerable<DirectoryInformation> Children
    {
        get
        {
            foreach (var child in m_children.Values)
            {
                yield return child;
                foreach (var subdirectory in child.Children)
                {
                    yield return subdirectory;
                }
            }
        }
    }
    public DirectoryInformation CreateSubDirectory(string directoryName)
    {
        m_children[directoryName] = new DirectoryInformation(this, directoryName);
        return m_children[directoryName];
    }

    public int Size {
        get
        {
            var size = Files.Sum(f => f.Size);
            foreach (var child in m_children.Values)
            {
                size += child.Size;
            }
            return size;
        }
    }
}
