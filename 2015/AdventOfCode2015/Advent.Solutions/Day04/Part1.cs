using System.Security.Cryptography;

namespace Advent.Solutions.Day04;

public class Part1
{
    public int Solution(string key)
    {
        int index = 0;

        string hash = string.Empty;
        do {
           hash = Hash($"{key}{index++}");
        } while (!hash.StartsWith("00000"));

        return index-1;
    }

    private string Hash(string stringToHash)
    {
        // Use input string to calculate MD5 hash
        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(stringToHash);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes); // .NET 5 +
        }
    }
}
