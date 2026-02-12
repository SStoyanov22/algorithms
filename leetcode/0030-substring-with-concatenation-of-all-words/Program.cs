namespace _0030_substring_with_concatenation_of_all_words;

class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();

        // Test Case 1: s = "barfoothefoobarman", words = ["foo","bar"]
        Console.WriteLine("Test Case 1:");
        string s1 = "barfoothefoobarman";
        string[] words1 = { "foo", "bar" };
        Console.WriteLine($"Input: s = \"{s1}\", words = [{string.Join(",", words1.Select(w => $"\"{w}\""))}]");
        IList<int> result1 = solution.FindSubstring(s1, words1);
        Console.WriteLine($"Output: [{string.Join(",", result1)}]");
        Console.WriteLine("Expected: [0,9]");
        Console.WriteLine("  Index 0: 'barfoo' = 'bar' + 'foo'");
        Console.WriteLine("  Index 9: 'foobar' = 'foo' + 'bar'\n");

        // Test Case 2: s = "wordgoodgoodgoodbestword", words = ["word","good","best","word"]
        Console.WriteLine("Test Case 2:");
        string s2 = "wordgoodgoodgoodbestword";
        string[] words2 = { "word", "good", "best", "word" };
        Console.WriteLine($"Input: s = \"{s2}\", words = [{string.Join(",", words2.Select(w => $"\"{w}\""))}]");
        IList<int> result2 = solution.FindSubstring(s2, words2);
        Console.WriteLine($"Output: [{string.Join(",", result2)}]");
        Console.WriteLine("Expected: []");
        Console.WriteLine("  (No valid concatenation exists)\n");

        // Test Case 3: s = "barfoofoobarthefoobarman", words = ["bar","foo","the"]
        Console.WriteLine("Test Case 3:");
        string s3 = "barfoofoobarthefoobarman";
        string[] words3 = { "bar", "foo", "the" };
        Console.WriteLine($"Input: s = \"{s3}\", words = [{string.Join(",", words3.Select(w => $"\"{w}\""))}]");
        IList<int> result3 = solution.FindSubstring(s3, words3);
        Console.WriteLine($"Output: [{string.Join(",", result3)}]");
        Console.WriteLine("Expected: [6,9,12]");
        Console.WriteLine("  Index 6: 'foobarthe' = 'foo' + 'bar' + 'the'");
        Console.WriteLine("  Index 9: 'barthefoo' = 'bar' + 'the' + 'foo'");
        Console.WriteLine("  Index 12: 'thefoobar' = 'the' + 'foo' + 'bar'\n");

        // Test Case 4: s = "wordgoodgoodgoodbestword", words = ["word","good","best","good"]
        Console.WriteLine("Test Case 4:");
        string s4 = "wordgoodgoodgoodbestword";
        string[] words4 = { "word", "good", "best", "good" };
        Console.WriteLine($"Input: s = \"{s4}\", words = [{string.Join(",", words4.Select(w => $"\"{w}\""))}]");
        IList<int> result4 = solution.FindSubstring(s4, words4);
        Console.WriteLine($"Output: [{string.Join(",", result4)}]");
        Console.WriteLine("Expected: [8]");
        Console.WriteLine("  Index 8: 'goodgoodgoodbestword' but only 16 chars = 'good' + 'good' + 'best' + 'word'\n");

        // Test Case 5: s = "a", words = ["a"]
        Console.WriteLine("Test Case 5:");
        string s5 = "a";
        string[] words5 = { "a" };
        Console.WriteLine($"Input: s = \"{s5}\", words = [{string.Join(",", words5.Select(w => $"\"{w}\""))}]");
        IList<int> result5 = solution.FindSubstring(s5, words5);
        Console.WriteLine($"Output: [{string.Join(",", result5)}]");
        Console.WriteLine("Expected: [0]\n");

        // Test Case 6: s = "lingmindraboofooowingdingbarrwingmonkeypoundcake", words = ["fooo","barr","wing","ding","wing"]
        Console.WriteLine("Test Case 6:");
        string s6 = "lingmindraboofooowingdingbarrwingmonkeypoundcake";
        string[] words6 = { "fooo", "barr", "wing", "ding", "wing" };
        Console.WriteLine($"Input: s = \"{s6}\"");
        Console.WriteLine($"       words = [{string.Join(",", words6.Select(w => $"\"{w}\""))}]");
        IList<int> result6 = solution.FindSubstring(s6, words6);
        Console.WriteLine($"Output: [{string.Join(",", result6)}]");
        Console.WriteLine("Expected: [13]");
        Console.WriteLine("  Index 13: 'fooowingdingbarrwing' = 'fooo' + 'wing' + 'ding' + 'barr' + 'wing'\n");
    }
}

public class Solution
{
    public IList<int> FindSubstring(string s, string[] words)
    {
        List<int> result = new List<int>();

        if(s.Length == 0 || words.Length == 0) 
            return result;
        int wordLen = words[0].Length;
        int wordCount = words.Length;
        int totalLen = wordLen * wordCount;

        if( s.Length < totalLen)
            return result;
        // Buld target word frequency map

        Dictionary<string, int> wordFreq = new Dictionary<string, int>();
        foreach(string word in words)
        {
            if(!wordFreq.ContainsKey(word))
               wordFreq[word] = 0;
            wordFreq[word]++;
        }
        return new List<int>();
    }
}

