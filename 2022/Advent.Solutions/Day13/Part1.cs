namespace Advent.Solutions.Day13;
using System.Diagnostics;
using System.Text.Json;

public class Part1
{
    public enum Result
    {
        Ordered,
        Unordered,
        Inconclusive
    }

    public Result AreOrdered(JsonElement left, JsonElement right)
    {
        Debug.WriteLine($"Comparing {left} and {right}");
        if (left.ValueKind == JsonValueKind.Number && right.ValueKind == JsonValueKind.Number)
        {
            var value1 = left.GetInt16();
            var value2 = right.GetInt16();

            var result = Result.Inconclusive;
            if (value1 < value2)
            {
                result = Result.Ordered;
            }
            else if (value2 < value1)
            {
                result = Result.Unordered;
            }

            Debug.WriteLine($"Comparing {value1} and {value2}. Result {result}");
            return result;
        }
        else if (left.ValueKind == JsonValueKind.Array && right.ValueKind == JsonValueKind.Array)
        {
            for (int i = 0; i < Math.Max(left.GetArrayLength(), right.GetArrayLength()); i++)
            {
                if (i >= left.GetArrayLength())
                {
                    Debug.WriteLine("Left side ran out of items");
                    return Result.Ordered;
                }
                else if (i >= right.GetArrayLength())
                {
                    Debug.WriteLine("Right side ran out of items");
                    return Result.Unordered;
                }

                var result = AreOrdered(left[i], right[i]);
                if (result != Result.Inconclusive)
                {
                    return result;
                }
            }
        }
        else
        {
            JsonElement newLeft = left.ValueKind == JsonValueKind.Array ? left : JsonDocument.Parse($"[{left}]").RootElement;
            JsonElement newRight = right.ValueKind == JsonValueKind.Array ? right : JsonDocument.Parse($"[{right}]").RootElement;
            return AreOrdered(newLeft, newRight);
        }

        return Result.Ordered;
    }

    public int Solution(string[] lines)
    {
        int total = 0;
        int lineIndex = 0;
        int pairIndex = 0;

        while (lineIndex + 2 < lines.Length)
        {
            pairIndex++;
            Debug.WriteLine($"Pair {pairIndex}");

            string left = lines[lineIndex++];
            string right = lines[lineIndex++];
            Debug.WriteLine(left);
            Debug.WriteLine(right);

            var packet1 = JsonDocument.Parse(left);
            var packet2 = JsonDocument.Parse(right);

            var result = AreOrdered(packet1.RootElement, packet2.RootElement);
            Debug.WriteLine(result);

            if (result == Result.Ordered)
            {
                total += pairIndex;
            }

            if (lineIndex < lines.Length)
            {
                lineIndex++; // consume blank line
            }
        }

        return total;
    }
}
