namespace Advent.Solutions.Day11;

public partial class Part1
{
    public int Solution(IEnumerable<string> lines)
    {
        const int totalRounds = 20;

        List<Monkey> monkeys = new();
        for (int lineNumber = 0; lineNumber < lines.Count(); lineNumber+=7 )
        {
            var monkeyShines = lines.Skip(lineNumber).Take(7).ToList();
            monkeys.Add(new Monkey(
                monkeyShines[1].Split(':')[1].Trim().Split(',').Select(x => int.Parse(x)).ToList(),
                monkeyShines[2],
                monkeyShines[3],
                monkeyShines[4],
                monkeyShines[5]));
        }

        for (int round = 0; round < totalRounds; round++)
        {
            foreach(Monkey monkey in monkeys)
            {
                while (monkey.WorryLevels.Count > 0)
                {
                    int worryLevel = monkey.RemoveItem();
                    int newWorryLevel = monkey.Inspect(worryLevel);
                    newWorryLevel /= 3;
                    var newMonkey = monkey.NextMonkey(newWorryLevel);

                    monkeys[newMonkey].AddItem(newWorryLevel);
                }
            }
        }

        var result = 1;

        var monkeyBusiness = monkeys.OrderByDescending(m => m.InspectionCount).Take(2);
        foreach (var x in monkeyBusiness)
        {
            result *= x.InspectionCount;
        }

        return result;
    }
}
