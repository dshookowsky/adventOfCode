namespace Advent.Solutions.Day07;

public class DirectoryInformation
{
    private readonly List<FileInformation> m_files = new ();
    private readonly string m_name;
    private readonly DirectoryInformation? m_parent;
    private readonly Dictionary<string, DirectoryInformation> m_children = new ();

    public DirectoryInformation(DirectoryInformation parent, string name)
    {
        m_parent = parent;

        m_name = name;
    }

    public DirectoryInformation(string name)
    {
        m_name = name;
    }

    public List<FileInformation> Files => m_files;

    public string Name => m_name;

    public DirectoryInformation? Parent => m_parent;

    public string Path
    {
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

    public int Size
    {
        get
        {
            var size = m_files.Sum(f => f.Size);
            foreach (var child in m_children.Values)
            {
                size += child.Size;
            }

            return size;
        }
    }

    public DirectoryInformation ParseCd(string line)
    {
        string directoryName = line.Split(' ')[2];
        if (directoryName == Path)
        {
            return this;
        }

        return m_children[directoryName];
    }

    public DirectoryInformation CreateSubDirectory(string directoryName)
    {
        m_children[directoryName] = new DirectoryInformation(this, directoryName);
        return m_children[directoryName];
    }
}