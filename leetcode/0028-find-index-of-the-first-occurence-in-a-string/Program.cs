namespace _0028_find_index_of_the_first_occurence_in_a_string;

class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();

        // Test Case 1: haystack = "sadbutsad", needle = "sad"
        Console.WriteLine("Test Case 1:");
        string haystack1 = "sadbutsad";
        string needle1 = "sad";
        Console.WriteLine($"Input: haystack = \"{haystack1}\", needle = \"{needle1}\"");
        int result1 = solution.StrStr(haystack1, needle1);
        Console.WriteLine($"Output: {result1}");
        Console.WriteLine("Expected: 0 (first occurrence at index 0)\n");

        // Test Case 2: haystack = "leetcode", needle = "leeto"
        Console.WriteLine("Test Case 2:");
        string haystack2 = "leetcode";
        string needle2 = "leeto";
        Console.WriteLine($"Input: haystack = \"{haystack2}\", needle = \"{needle2}\"");
        int result2 = solution.StrStr(haystack2, needle2);
        Console.WriteLine($"Output: {result2}");
        Console.WriteLine("Expected: -1 (not found)\n");

        // Test Case 3: haystack = "hello", needle = ""
        Console.WriteLine("Test Case 3:");
        string haystack3 = "hello";
        string needle3 = "";
        Console.WriteLine($"Input: haystack = \"{haystack3}\", needle = \"{needle3}\"");
        int result3 = solution.StrStr(haystack3, needle3);
        Console.WriteLine($"Output: {result3}");
        Console.WriteLine("Expected: 0 (empty needle returns 0)\n");

        // Test Case 4: haystack = "a", needle = "a"
        Console.WriteLine("Test Case 4:");
        string haystack4 = "a";
        string needle4 = "a";
        Console.WriteLine($"Input: haystack = \"{haystack4}\", needle = \"{needle4}\"");
        int result4 = solution.StrStr(haystack4, needle4);
        Console.WriteLine($"Output: {result4}");
        Console.WriteLine("Expected: 0\n");

        // Test Case 5: haystack = "mississippi", needle = "issip"
        Console.WriteLine("Test Case 5:");
        string haystack5 = "mississippi";
        string needle5 = "issip";
        Console.WriteLine($"Input: haystack = \"{haystack5}\", needle = \"{needle5}\"");
        int result5 = solution.StrStr(haystack5, needle5);
        Console.WriteLine($"Output: {result5}");
        Console.WriteLine("Expected: 4\n");

        // Test Case 6: haystack = "aaa", needle = "aaaa"
        Console.WriteLine("Test Case 6:");
        string haystack6 = "aaa";
        string needle6 = "aaaa";
        Console.WriteLine($"Input: haystack = \"{haystack6}\", needle = \"{needle6}\"");
        int result6 = solution.StrStr(haystack6, needle6);
        Console.WriteLine($"Output: {result6}");
        Console.WriteLine("Expected: -1 (needle longer than haystack)\n");

        // Test Case 7: haystack = "abc", needle = "c"
        Console.WriteLine("Test Case 7:");
        string haystack7 = "abc";
        string needle7 = "c";
        Console.WriteLine($"Input: haystack = \"{haystack7}\", needle = \"{needle7}\"");
        int result7 = solution.StrStr(haystack7, needle7);
        Console.WriteLine($"Output: {result7}");
        Console.WriteLine("Expected: 2 (needle at end)\n");
    }
}

public class Solution
{
    public int StrStr(string haystack, string needle)
    {
        if(needle.Length == 0) return 0;

        for(int i = 0; i  <= haystack.Length - needle.Length; i++)
        {
            int j = 0;

            while(j<needle.Length && haystack[i+j] == needle[j]){
                j++;
            }

            if(j == needle.Length){
                return i;
            }
        }

        return -1;
    }
}
