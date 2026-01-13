namespace _0013_roman_to_integer;

public class Solution
{
    public int RomanToInt(string s)
    {
        var romanNumerals = new Dictionary<string, int>
        {
            { "M", 1000 },
            { "CM", 900 },
            { "D", 500 },
            { "CD", 400 },
            { "C", 100 },
            { "XC", 90 },
            { "L", 50 },
            { "XL", 40 },
            { "X", 10 },
            { "IX", 9 },
            { "V", 5 },
            { "IV", 4 },
            { "I", 1 }
        };
        var total = 0;
        for(int i = 0; i<s.Length; i++)
        {
            int currentValue = romanNumerals[s[i].ToString()];
            
            if (i+1 < s.Length && currentValue<romanNumerals[s[i+1].ToString()])
            {
                total -= currentValue;
            }
            else
            {
                total += currentValue;
            }
            
        }
        
        return total;
    }
}

class Program
{
    static void Main()
    {
        var solution = new Solution();

        // Test cases
        Console.WriteLine($"III -> {solution.RomanToInt("III")}"); // Expected: 3
        Console.WriteLine($"LVIII -> {solution.RomanToInt("LVIII")}"); // Expected: 58
        Console.WriteLine($"MCMXCIV -> {solution.RomanToInt("MCMXCIV")}"); // Expected: 1994
    }
}
