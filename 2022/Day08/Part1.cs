using System.Linq.Expressions;

namespace Day08;

public class Part1
{
    private readonly List<int[]> m_forest = new();

    public bool IsVisible(int row, int column, int xDirection, int yDirection, int height)
    {
        if (row == 0 || row == m_forest.Count -1 || column == 0 || column == m_forest[0].Length - 1)
        {
            return true;
        }

        if (height <= m_forest[row + xDirection][column + yDirection])
        {
            return false;
        }

        return IsVisible(row + xDirection, column + yDirection, xDirection, yDirection, height);
    }

    public int Solution(IEnumerable<string> lines)
    {
        foreach (var line in lines)
        {
            m_forest.Add(line.ToCharArray().Select(c => c - '0').ToArray());
        }

        int width = m_forest[0].Length;

        int visibleTrees = 0;

        for (int row = 0; row < m_forest.Count; row++)
        {
            for (int column = 0; column < width; column++)
            {
                int height = m_forest[row][column];
                if (IsVisible(row, column, -1, 0, height) ||
                    IsVisible(row, column, 1, 0, height)  ||
                    IsVisible(row, column, 0, 1, height) ||
                    IsVisible(row, column, 0, -1, height)) {
                    visibleTrees++;
                }
            }
        }

        return visibleTrees;
    }
}
