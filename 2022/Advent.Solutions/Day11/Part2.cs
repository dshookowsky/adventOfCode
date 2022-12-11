using System.Diagnostics;

namespace Advent.Solutions.Day11;

public class Part2
{
    public long Solution(IEnumerable<string> lines)
    {
        const int totalRounds = 10000;
        const int itemsRow = 1;
        const int operationRow = 2;
        const int testRow = 3;
        const int trueRow = 4;
        const int falseRow = 5;

        List<Monkey> monkeys = new();
        for (int lineNumber = 0; lineNumber < lines.Count(); lineNumber += 7)
        {
            var monkeyShines = lines.Skip(lineNumber).Take(7).ToList();
            monkeys.Add(new Monkey(
                monkeyShines[itemsRow].Split(':')[1].Trim().Split(',').Select(x => int.Parse(x)).ToList(),
                monkeyShines[operationRow],
                monkeyShines[testRow],
                monkeyShines[trueRow],
                monkeyShines[falseRow]));
        }

        var lcm = 1;

        foreach (Monkey monkey in monkeys)
        {
            lcm *= monkey.Divisor;
        }

        for (int round = 0; round < totalRounds; round++)
        {
            foreach (Monkey monkey in monkeys)
            {
                while (monkey.WorryLevels.Count > 0)
                {
                    int worryLevel = monkey.RemoveItem();
                    long inspectionResult = monkey.Inspect(worryLevel) % lcm;

                    Debug.Assert(inspectionResult > 0 && inspectionResult < int.MaxValue);
                    worryLevel = (int)inspectionResult;
                    int nextMonkey = monkey.NextMonkey(worryLevel);

                    monkeys[nextMonkey].AddItem(worryLevel);
                }
            }
        }

        long result = 1;

        var monkeyBusiness = monkeys.OrderByDescending(m => m.InspectionCount).Take(2);
        foreach (var x in monkeyBusiness)
        {
            result *= x.InspectionCount;
        }

        return result;
    }

    private class Monkey
    {
        public int Divisor = 1;

        public long InspectionCount = 0;
        public List<int> WorryLevels;

        public Func<int, bool> Test;

        private readonly Func<int, long> Operation;

        public Func<int, int> NextMonkey;

        public Monkey(List<int> items, string operationDescription, string testDescription, string trueResultDescription, string falseResultDescription)
        {
            WorryLevels = items;
            Operation = ParseOperationDescription(operationDescription);
            Test = ParseTestDescription(testDescription);

            var trueResult = int.Parse(trueResultDescription.Split(' ').Last());
            var falseResult = int.Parse(falseResultDescription.Split(' ').Last());

            NextMonkey = (worryLevel) => Test(worryLevel) ? trueResult : falseResult;
        }

        public long Inspect(int worryLevel)
        {
            InspectionCount++;
            return Operation(worryLevel);
        }

        public void AddItem(int worryLevel)
        {
            WorryLevels.Add(worryLevel);
        }

        public int RemoveItem()
        {
            var item = WorryLevels.First();

            if (WorryLevels.Count > 1)
            {
                WorryLevels = WorryLevels.Skip(1).ToList();
            }
            else
            {
                WorryLevels.Clear();
            }

            return item;
        }

        private Func<int, bool> ParseTestDescription(string testDescription)
        {
            Divisor = int.Parse(testDescription.Split(' ').Last());
            return (x) => x % Divisor == 0;
        }

        private Func<int, long> ParseOperationDescription(string operationDescription)
        {
            // "Operation: new = old + 6"
            // "Operation: new = -->old + 6<--"
            var operation = operationDescription.Split('=')[1].Trim().Split(' ');

            int? operand2 = null;


            if (int.TryParse(operation[2], out int value))
            {
                operand2 = value;
            }

            return operation[1] switch
            {
                "*" => (old) => Multiply(old, operand2 ?? old),
                "+" => (old) => Add(old, operand2 ?? old),
                _ => throw new ArgumentException(null, nameof(operationDescription)),
            };
        }

        public long Multiply(int operand1, int operand2)
        {
            return (long)operand1 * (long)operand2;
        }

        public long Add(int operand1, int operand2)
        {
            return operand1 + operand2;
        }
    }
}
