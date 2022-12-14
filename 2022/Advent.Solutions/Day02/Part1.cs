namespace Advent.Solutions.Day02;

public class Part1
{
#pragma warning disable SA1303 // Const field names should begin with upper-case letter
    private const int rock = 1;
    private const int paper = 2;
    private const int scissors = 3;

    private const int win = 6;
    private const int lose = 0;
    private const int draw = 3;
#pragma warning restore SA1303 // Const field names should begin with upper-case letter

    public int Solution(IEnumerable<string> lines)
    {
        int score = 0;

        Dictionary<string, Func<string, int>> moves = new ()
    {
        { "A", Rock },
        { "B", Paper },
        { "C", Scissors }
    };

        foreach (var line in lines)
        {
            var round = line.Split(" ");

            score += moves[round[0]].Invoke(round[1]); ;
        }

        return score;
    }

    private int Rock(string versus)
    {
        return versus switch
        {
            "X" => rock + draw,
            "Y" => paper + win,
            "Z" => scissors + lose,
            _ => 0
        };
    }

    private int Paper(string versus)
    {
        return versus switch
        {
            "X" => rock + lose,
            "Y" => paper + draw,
            "Z" => scissors + win,
            _ => 0
        };
    }

    private int Scissors(string versus)
    {
        return versus switch
        {
            "X" => rock + win,
            "Y" => paper + lose,
            "Z" => scissors + draw,
            _ => 0
        };
    }
}