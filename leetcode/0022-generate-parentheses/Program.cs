namespace _0022_generate_parentheses;

class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();

        // Test Case 1: n = 3
        Console.WriteLine("Test Case 1: n = 3");
        var result1 = solution.GenerateParenthesis(3);
        Console.WriteLine($"Result: [{string.Join(", ", result1.Select(s => $"\"{s}\""))}]");
        Console.WriteLine("Expected: [\"((()))\",\"(()())\",\"(())()\",\"()(())\",\"()()()\"]");
        Console.WriteLine($"Count: {result1.Count} (expected: 5)\n");

        // Test Case 2: n = 1
        Console.WriteLine("Test Case 2: n = 1");
        var result2 = solution.GenerateParenthesis(1);
        Console.WriteLine($"Result: [{string.Join(", ", result2.Select(s => $"\"{s}\""))}]");
        Console.WriteLine("Expected: [\"()\"]");
        Console.WriteLine($"Count: {result2.Count} (expected: 1)\n");

        // Test Case 3: n = 2
        Console.WriteLine("Test Case 3: n = 2");
        var result3 = solution.GenerateParenthesis(2);
        Console.WriteLine($"Result: [{string.Join(", ", result3.Select(s => $"\"{s}\""))}]");
        Console.WriteLine("Expected: [\"(())\",\"()()\"]");
        Console.WriteLine($"Count: {result3.Count} (expected: 2)\n");

        // Test Case 4: n = 4
        Console.WriteLine("Test Case 4: n = 4");
        var result4 = solution.GenerateParenthesis(4);
        Console.WriteLine($"Result: [{string.Join(", ", result4.Select(s => $"\"{s}\""))}]");
        Console.WriteLine($"Count: {result4.Count} (expected: 14)\n");
    }
}

public class Solution
{
    public IList<string> GenerateParenthesis(int n)
    {
        // Keep track of open and close parentheses count
        var result = new List<string>();

        Backtrack(result, "", 0, 0, n);

        return result;
    }

    private void Backtrack(IList<string> result, string current, int open, int close, int max)
    {
        // Bottom of the recursion
        if(current.Length == max * 2)
        {
            result.Add(current);

            return;
        }

        if(open < max)
        {
            Backtrack(result, current + "(", open + 1, close, max);
        }

        if(close < open)
        {
            Backtrack(result, current + ")", open, close + 1, max);
        }
    }
}
