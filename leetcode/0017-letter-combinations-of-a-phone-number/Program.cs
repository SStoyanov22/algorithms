namespace _0017_letter_combinations_of_a_phone_number;

public class Solution {
    private Dictionary<char, string> phoneMap = new Dictionary<char, string>
        {
            { '2', "abc" },
            { '3', "def" },
            { '4', "ghi" },
            { '5', "jkl" },
            { '6', "mno" },
            { '7', "pqrs" },
            { '8', "tuv" },
            { '9', "wxyz" }
        };

    private List<string> output;

    public IList<string> LetterCombinations(string digits)
    {
        output = new List<string>();

        // Return empty list for empty input
        if (string.IsNullOrEmpty(digits)) {
            return output;
        }

        // Start the backtracking process with empty combination
        Backtrack("", digits);
        return output;
    }

    // Recursive backtracking method to build combinations
    private void Backtrack(string combination, string nextDigits)
    {
        // Base case: when no more digits to process
        // Add the current combination to results
        if (nextDigits.Length == 0)
            output.Add(combination);
        else
        {   
            // Get the letters corresponding to the first digit
            // For each letter in the mapped string
            foreach(var letter in phoneMap[nextDigits[0]])
            {
                // Add current letter to combination and process remaining digits
                // nextDigits.Substring(1) removes the first digit for next recursion
                Backtrack(combination + letter, nextDigits.Substring(1));
            }
        }
    }
}

class Program
{
    static void Main()
    {
        var solution = new Solution();

        // Test cases
        Console.WriteLine($"\"23\" -> [{string.Join(", ", solution.LetterCombinations("23").Select(x => $"\"{x}\""))}]");
        // Expected: ["ad","ae","af","bd","be","bf","cd","ce","cf"]

        Console.WriteLine($"\"\" -> [{string.Join(", ", solution.LetterCombinations("").Select(x => $"\"{x}\""))}]");
        // Expected: []

        Console.WriteLine($"\"2\" -> [{string.Join(", ", solution.LetterCombinations("2").Select(x => $"\"{x}\""))}]");
        // Expected: ["a","b","c"]
    }
}
