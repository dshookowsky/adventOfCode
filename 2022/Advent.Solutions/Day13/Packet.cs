namespace Advent.Solutions.Day13;
using System.Text.Json;

public class Packet : IComparable<Packet>
{
    private readonly JsonElement m_jsonElement;

    public Packet(string packetData)
    {
        m_jsonElement = JsonDocument.Parse(packetData).RootElement;
    }

    public int CompareTo(Packet? other)
    {
        if (other == null)
        {
            return -1;
        }

        return AreOrdered(m_jsonElement, other.m_jsonElement);
    }

    public override string ToString()
    {
        return m_jsonElement.ToString();
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
