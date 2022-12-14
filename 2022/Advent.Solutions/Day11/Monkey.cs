namespace Advent.Solutions.Day11;

public partial class Part1
{
    private class Monkey
    {
        public Monkey(List<int> items, string operationDescription, string testDescription, string trueResultDescription, string falseResultDescription)
        {
            WorryLevels = items;
            Operation = ParseOperationDescription(operationDescription);
            Test = ParseTestDescription(testDescription);

            var trueResult = int.Parse(trueResultDescription.Split(' ').Last());
            var falseResult = int.Parse(falseResultDescription.Split(' ').Last());

            NextMonkey = (worryLevel) => Test(worryLevel) ? trueResult : falseResult;
        }

        public int InspectionCount { get; private set; } = 0;

        public List<int> WorryLevels { get; set; }

        public Func<int, bool> Test { get; private set; }

        public Func<int, int> NextMonkey { get; private set; }

        private Func<int, int> Operation { get; set; }

        public int Inspect(int worryLevel)
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

        public int Multiply(int operand1, int operand2)
        {
            return operand1 * operand2;
        }

        public int Add(int operand1, int operand2)
        {
            return operand1 + operand2;
        }

        private Func<int, bool> ParseTestDescription(string testDescription)
        {
            var divisor = int.Parse(testDescription.Split(' ').Last());
            return (x) => x % divisor == 0;
        }

        private Func<int, int> ParseOperationDescription(string operationDescription)
        {
            // Operation: new = -->old + 6<--
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
    }
}
