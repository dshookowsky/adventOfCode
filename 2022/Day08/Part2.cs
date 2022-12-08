namespace Day08;

public class Part2
{
    private readonly List<int[]> m_forest = new();

    public int ScenicScore(int row, int column, int xDirection, int yDirection, int height)
    {
        if (row == 0 || row == m_forest.Count - 1 || column == 0 || column == m_forest[0].Length - 1)
        {
            return 0;
        }

        if (height <= m_forest[row + xDirection][column + yDirection])
        {
            return 1;
        }

        return ScenicScore(row + xDirection, column + yDirection, xDirection, yDirection, height) + 1;
    }

    public int Solution(string[] lines)
    {
        foreach (var line in lines)
        {
            m_forest.Add(line.ToCharArray().Select(c => c - '0').ToArray());
        }

        int width = m_forest[0].Length;

        int highScore = 0;

        for (int row = 0; row < m_forest.Count; row++)
        {
            for (int column = 0; column < width; column++)
            {
                int height = m_forest[row][column];
                var currentScore = ScenicScore(row, column, -1, 0, height) *
                    ScenicScore(row, column, 1, 0, height) *
                    ScenicScore(row, column, 0, 1, height) *
                    ScenicScore(row, column, 0, -1, height);
                
                highScore = Math.Max(highScore, currentScore);
            }
        }

        return highScore;
    }
}
