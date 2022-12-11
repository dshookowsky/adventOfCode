namespace Advent.Solutions.Day11;

public partial class Part1
{
    private class Monkey
    {
        public int InspectionCount = 0;
        public List<int> WorryLevels;

        public Func<int, bool> Test;
        public Func<int, int> NextMonkey;

        private readonly Func<int, int> Operation;

        public Monkey(List<int> items, string operationDescription, string testDescription, string trueResultDescription, string falseResultDescription)
        {
            WorryLevels = items;
            Operation = ParseOperationDescription(operationDescription);
            Test = ParseTestDescription(testDescription);

            var trueResult = int.Parse(trueResultDescription.Split(' ').Last());
            var falseResult = int.Parse(falseResultDescription.Split(' ').Last());


            NextMonkey = (worryLevel) => Test(worryLevel) ? trueResult : falseResult;
        }

        public int Inspect(int worryLevel)
        {
            InspectionCount++;
            return Operation(worryLevel);
        }

        public void AddItem(int worryLevel)
        {
            WorryLevels.Add(worryLevel);
        }

        public int RemoveItem() {

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

            switch (operation[1])
            {
                case "*":
                    return (old) => Multiply(old, operand2 ?? old);
                case "+":
                    return (old) => Add(old, operand2 ?? old);
                default:
                    throw new ArgumentException(null, nameof(operationDescription));
            }
        }

        public int Multiply(int operand1, int operand2)
        {
            return operand1 * operand2;
        }

        public int Add(int operand1, int operand2)
        {
            return operand1 + operand2;
        }
    }
}
