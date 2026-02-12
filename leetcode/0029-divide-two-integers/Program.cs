namespace _0029_divide_two_integers;

class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();

        // Test Case 1: dividend = 10, divisor = 3
        Console.WriteLine("Test Case 1:");
        int dividend1 = 10;
        int divisor1 = 3;
        Console.WriteLine($"Input: dividend = {dividend1}, divisor = {divisor1}");
        int result1 = solution.Divide(dividend1, divisor1);
        Console.WriteLine($"Output: {result1}");
        Console.WriteLine("Expected: 3 (10/3 = 3.33.. truncated to 3)\n");

        // Test Case 2: dividend = 7, divisor = -3
        Console.WriteLine("Test Case 2:");
        int dividend2 = 7;
        int divisor2 = -3;
        Console.WriteLine($"Input: dividend = {dividend2}, divisor = {divisor2}");
        int result2 = solution.Divide(dividend2, divisor2);
        Console.WriteLine($"Output: {result2}");
        Console.WriteLine("Expected: -2 (7/-3 = -2.33.. truncated to -2)\n");

        // Test Case 3: dividend = 1, divisor = 1
        Console.WriteLine("Test Case 3:");
        int dividend3 = 1;
        int divisor3 = 1;
        Console.WriteLine($"Input: dividend = {dividend3}, divisor = {divisor3}");
        int result3 = solution.Divide(dividend3, divisor3);
        Console.WriteLine($"Output: {result3}");
        Console.WriteLine("Expected: 1\n");

        // Test Case 4: dividend = -2147483648 (int.MinValue), divisor = -1
        Console.WriteLine("Test Case 4:");
        int dividend4 = int.MinValue;
        int divisor4 = -1;
        Console.WriteLine($"Input: dividend = {dividend4}, divisor = {divisor4}");
        int result4 = solution.Divide(dividend4, divisor4);
        Console.WriteLine($"Output: {result4}");
        Console.WriteLine($"Expected: {int.MaxValue} (overflow case, clamp to int.MaxValue)\n");

        // Test Case 5: dividend = -2147483648 (int.MinValue), divisor = 1
        Console.WriteLine("Test Case 5:");
        int dividend5 = int.MinValue;
        int divisor5 = 1;
        Console.WriteLine($"Input: dividend = {dividend5}, divisor = {divisor5}");
        int result5 = solution.Divide(dividend5, divisor5);
        Console.WriteLine($"Output: {result5}");
        Console.WriteLine($"Expected: {int.MinValue}\n");

        // Test Case 6: dividend = 0, divisor = 1
        Console.WriteLine("Test Case 6:");
        int dividend6 = 0;
        int divisor6 = 1;
        Console.WriteLine($"Input: dividend = {dividend6}, divisor = {divisor6}");
        int result6 = solution.Divide(dividend6, divisor6);
        Console.WriteLine($"Output: {result6}");
        Console.WriteLine("Expected: 0\n");

        // Test Case 7: dividend = 100, divisor = 10
        Console.WriteLine("Test Case 7:");
        int dividend7 = 100;
        int divisor7 = 10;
        Console.WriteLine($"Input: dividend = {dividend7}, divisor = {divisor7}");
        int result7 = solution.Divide(dividend7, divisor7);
        Console.WriteLine($"Output: {result7}");
        Console.WriteLine("Expected: 10\n");

        // Test Case 8: dividend = -1, divisor = 1
        Console.WriteLine("Test Case 8:");
        int dividend8 = -1;
        int divisor8 = 1;
        Console.WriteLine($"Input: dividend = {dividend8}, divisor = {divisor8}");
        int result8 = solution.Divide(dividend8, divisor8);
        Console.WriteLine($"Output: {result8}");
        Console.WriteLine("Expected: -1\n");
    }
}

public class Solution
{
    public int Divide(int dividend, int divisor)
    {
        // TODO: Implement the solution
        // Constraints:
        // - Cannot use multiplication, division, or mod operator
        // - Must handle overflow (if result > int.MaxValue, return int.MaxValue)
        // - Truncate result towards zero

        // Hint: Use bit shifting and repeated subtraction
        return 0;
    }
}