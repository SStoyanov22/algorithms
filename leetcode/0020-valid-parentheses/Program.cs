namespace _0020_valid_parentheses;

class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();

        // Test cases
        string[] testCases = {
            "()",        // Expected: true
            "()[]{}",    // Expected: true
            "(]",        // Expected: false
            "([)]",      // Expected: false
            "{[]}",      // Expected: true
            "(((",       // Expected: false
            ")}",        // Expected: false
        };

        foreach (string test in testCases)
        {
            bool result = solution.IsValid(test);
            Console.WriteLine($"Input: \"{test}\" -> Result: {result}");
        }
    }
}

public class Solution {
    public bool IsValid(string s) {
        var stack = new Stack<char>();
        foreach(char c in s)
        {
            if(c == '(' || c == '[' || c == '{')
            {
                // Pushing opening brackets to stack
                stack.Push(c);
            }
            else
            {
                // Checking if closing bracket matches bracket on top of stack

                if (stack.Count == 0) // No opening brackets to match
                    return false;
                
                char top = stack.Pop();
                if(c == ')' && top != '(') return false;
                if(c == '}' && top != '{') return false;
                if(c == ']' && top != '[') return false;
            }
        }

        return stack.Count == 0;
    }
}