using System.Text;

namespace _0012_integer_to_roman;

public class Solution {
    public string IntToRoman(int num) {
        var romanNumerals = new List<(int value, string symbol)>
        {
            (1000, "M"),
            (900, "CM"),
            (500, "D"),
            (400, "CD"),
            (100, "C"),
            (90, "XC"),
            (50, "L"),
            (40, "XL"),
            (10, "X"),
            (9, "IX"),
            (5, "V"),
            (4, "IV"),
            (1, "I")
        };
        var result = new StringBuilder();
        foreach (var (value, symbol) in romanNumerals)
        {
            while (value <= num)
            {
                result.Append(symbol);
                num -= value;
            }
        }

        return result.ToString();
    }
}

class Program
{
    static void Main()
    {
        var solution = new Solution();

        // Test cases
        Console.WriteLine($"3 -> {solution.IntToRoman(3)}"); // Expected: III
        Console.WriteLine($"58 -> {solution.IntToRoman(58)}"); // Expected: LVIII
        Console.WriteLine($"1994 -> {solution.IntToRoman(1994)}"); // Expected: MCMXCIV
    }
}
