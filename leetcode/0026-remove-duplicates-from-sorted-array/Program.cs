namespace _0026_remove_duplicates_from_sorted_array;

class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();

        // Test Case 1: nums = [1,1,2]
        Console.WriteLine("Test Case 1:");
        int[] nums1 = { 1, 1, 2 };
        Console.WriteLine($"Input: nums = [{string.Join(",", nums1)}]");
        int k1 = solution.RemoveDuplicates(nums1);
        Console.WriteLine($"Output: k = {k1}, nums = [{string.Join(",", nums1.Take(k1))}]");
        Console.WriteLine("Expected: k = 2, nums = [1,2]\n");

        // Test Case 2: nums = [0,0,1,1,1,2,2,3,3,4]
        Console.WriteLine("Test Case 2:");
        int[] nums2 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
        Console.WriteLine($"Input: nums = [{string.Join(",", nums2)}]");
        int k2 = solution.RemoveDuplicates(nums2);
        Console.WriteLine($"Output: k = {k2}, nums = [{string.Join(",", nums2.Take(k2))}]");
        Console.WriteLine("Expected: k = 5, nums = [0,1,2,3,4]\n");

        // Test Case 3: nums = [1]
        Console.WriteLine("Test Case 3:");
        int[] nums3 = { 1 };
        Console.WriteLine($"Input: nums = [{string.Join(",", nums3)}]");
        int k3 = solution.RemoveDuplicates(nums3);
        Console.WriteLine($"Output: k = {k3}, nums = [{string.Join(",", nums3.Take(k3))}]");
        Console.WriteLine("Expected: k = 1, nums = [1]\n");

        // Test Case 4: nums = [1,2,3,4,5]
        Console.WriteLine("Test Case 4:");
        int[] nums4 = { 1, 2, 3, 4, 5 };
        Console.WriteLine($"Input: nums = [{string.Join(",", nums4)}]");
        int k4 = solution.RemoveDuplicates(nums4);
        Console.WriteLine($"Output: k = {k4}, nums = [{string.Join(",", nums4.Take(k4))}]");
        Console.WriteLine("Expected: k = 5, nums = [1,2,3,4,5]\n");

        // Test Case 5: nums = [1,1,1,1,1]
        Console.WriteLine("Test Case 5:");
        int[] nums5 = { 1, 1, 1, 1, 1 };
        Console.WriteLine($"Input: nums = [{string.Join(",", nums5)}]");
        int k5 = solution.RemoveDuplicates(nums5);
        Console.WriteLine($"Output: k = {k5}, nums = [{string.Join(",", nums5.Take(k5))}]");
        Console.WriteLine("Expected: k = 1, nums = [1]\n");

        // Test Case 6: nums = [-1,0,0,0,3,3]
        Console.WriteLine("Test Case 6:");
        int[] nums6 = { -1, 0, 0, 0, 3, 3 };
        Console.WriteLine($"Input: nums = [{string.Join(",", nums6)}]");
        int k6 = solution.RemoveDuplicates(nums6);
        Console.WriteLine($"Output: k = {k6}, nums = [{string.Join(",", nums6.Take(k6))}]");
        Console.WriteLine("Expected: k = 3, nums = [-1,0,3]\n");
    }
}

public class Solution
{
    public int RemoveDuplicates(int[] nums)
    {
        // Edge cases: empty array
        if (nums.Length == 0) return 0;

        // Two pointers:
        // i - tracks position of the last unique element
        // j - iterates through the array to find new unique elements
        int j = 0;
        for(int i = 1; i < nums.Length; i++)
        {
            // If we find a new unique element
            if(nums[i] != nums[j])
            {
                j++;               // Move to next position
                nums[j] = nums[i]; // Place the unique element
            }
        }
        
        return  j + 1;
    }
}
