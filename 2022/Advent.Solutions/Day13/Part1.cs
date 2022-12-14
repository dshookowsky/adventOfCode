﻿namespace Advent.Solutions.Day13;
using System.Diagnostics;
using System.Text.Json;

public class Part1
{
    public int Solution(string[] lines)
    {
        int lineIndex = 0;
        int total = 0;
        int pairIndex = 0;

        while (lineIndex + 2 <= lines.Length)
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

            if (result < 0)
            {
                total += pairIndex;
            }

            lineIndex++;
        }

        return total;
    }

    private int AreOrdered(JsonElement left, JsonElement right)
    {
        switch (left.ValueKind, right.ValueKind)
        {
            case (JsonValueKind.Number, JsonValueKind.Number):
                return left.GetInt16().CompareTo(right.GetInt16());
            case (JsonValueKind.Number, JsonValueKind.Array):
                left = JsonDocument.Parse($"[{left}]").RootElement;
                return AreOrdered(left, right);
            case (JsonValueKind.Array, JsonValueKind.Number):
                right = JsonDocument.Parse($"[{right}]").RootElement;
                return AreOrdered(left, right);
            case (JsonValueKind.Array, JsonValueKind.Array):
                for (int i = 0; i < Math.Min(left.GetArrayLength(), right.GetArrayLength()); i++)
                {
                    var result = AreOrdered(left[i], right[i]);
                    if (result != 0)
                    {
                        return result;
                    }
                }

                return left.GetArrayLength().CompareTo(right.GetArrayLength());

            default: return 0;
        }
    }
}
