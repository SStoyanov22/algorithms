namespace _0027_remove_element;

class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();

        // Test Case 1: nums = [3,2,2,3], val = 3
        Console.WriteLine("Test Case 1:");
        int[] nums1 = { 3, 2, 2, 3 };
        Console.WriteLine($"Input: nums = [{string.Join(",", nums1)}], val = 3");
        int k1 = solution.RemoveElement(nums1, 3);
        Console.WriteLine($"Output: k = {k1}, nums = [{string.Join(",", nums1.Take(k1))}]");
        Console.WriteLine("Expected: k = 2, nums = [2,2]\n");

        // Test Case 2: nums = [0,1,2,2,3,0,4,2], val = 2
        Console.WriteLine("Test Case 2:");
        int[] nums2 = { 0, 1, 2, 2, 3, 0, 4, 2 };
        Console.WriteLine($"Input: nums = [{string.Join(",", nums2)}], val = 2");
        int k2 = solution.RemoveElement(nums2, 2);
        Console.WriteLine($"Output: k = {k2}, nums = [{string.Join(",", nums2.Take(k2))}]");
        Console.WriteLine("Expected: k = 5, nums = [0,1,3,0,4]\n");

        // Test Case 3: nums = [1], val = 1
        Console.WriteLine("Test Case 3:");
        int[] nums3 = { 1 };
        Console.WriteLine($"Input: nums = [{string.Join(",", nums3)}], val = 1");
        int k3 = solution.RemoveElement(nums3, 1);
        Console.WriteLine($"Output: k = {k3}, nums = [{string.Join(",", nums3.Take(k3))}]");
        Console.WriteLine("Expected: k = 0, nums = []\n");

        // Test Case 4: nums = [1], val = 2
        Console.WriteLine("Test Case 4:");
        int[] nums4 = { 1 };
        Console.WriteLine($"Input: nums = [{string.Join(",", nums4)}], val = 2");
        int k4 = solution.RemoveElement(nums4, 2);
        Console.WriteLine($"Output: k = {k4}, nums = [{string.Join(",", nums4.Take(k4))}]");
        Console.WriteLine("Expected: k = 1, nums = [1]\n");

        // Test Case 5: nums = [4,5], val = 4
        Console.WriteLine("Test Case 5:");
        int[] nums5 = { 4, 5 };
        Console.WriteLine($"Input: nums = [{string.Join(",", nums5)}], val = 4");
        int k5 = solution.RemoveElement(nums5, 4);
        Console.WriteLine($"Output: k = {k5}, nums = [{string.Join(",", nums5.Take(k5))}]");
        Console.WriteLine("Expected: k = 1, nums = [5]\n");

        // Test Case 6: nums = [1,2,3,4,5], val = 6
        Console.WriteLine("Test Case 6:");
        int[] nums6 = { 1, 2, 3, 4, 5 };
        Console.WriteLine($"Input: nums = [{string.Join(",", nums6)}], val = 6");
        int k6 = solution.RemoveElement(nums6, 6);
        Console.WriteLine($"Output: k = {k6}, nums = [{string.Join(",", nums6.Take(k6))}]");
        Console.WriteLine("Expected: k = 5, nums = [1,2,3,4,5]\n");
    }
}

public class Solution
{
    public int RemoveElement(int[] nums, int val)
    {
        if( nums.Length == 0 ) return 0;

        int j = 0;

        for(int i = 0; i< nums.Length; i++)
        {
            // If current element is NOT the target value   
            if(nums[i] != val)
            {
                nums[j] = nums[i]; // Keep it  
                j++;
            }
            // If nums[i] == val, skip it   
        }
        return j;  // j is the count of non-val elements  
    }
}
