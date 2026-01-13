namespace _0015_3sum;

public class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        IList<IList<int>> output = new List<IList<int>>();

        // Sort the array first
        Array.Sort(nums);

        for (int i = 0; i < nums.Length - 2; i++)
        {
            // Skip duplicate values for i
            if (i > 0 && nums[i] == nums[i - 1])
                continue;

            int left = i + 1;
            int right = nums.Length - 1;

            while (left < right)
            {
                int sum = nums[i] + nums[left] + nums[right];

                if (sum == 0)
                {
                    output.Add(new List<int> { nums[i], nums[left], nums[right] });

                    // Skip duplicate values for left
                    while (left < right && nums[left] == nums[left + 1])
                        left++;

                    // Skip duplicate values for right
                    while (left < right && nums[right] == nums[right - 1])
                        right--;

                    left++;
                    right--;
                }
                else if (sum < 0)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
        }

        return output;
    }
}

class Program
{
    static void Main()
    {
        var solution = new Solution();

        // Test cases
        int[] nums1 = [-1, 0, 1, 2, -1, -4];
        Console.WriteLine($"[-1,0,1,2,-1,-4] -> {string.Join(", ", solution.ThreeSum(nums1).Select(x => $"[{string.Join(",", x)}]"))}");
        // Expected: [[-1,-1,2],[-1,0,1]]

        int[] nums2 = [0, 1, 1];
        Console.WriteLine($"[0,1,1] -> {string.Join(", ", solution.ThreeSum(nums2).Select(x => $"[{string.Join(",", x)}]"))}");
        // Expected: []

        int[] nums3 = [0, 0, 0];
        Console.WriteLine($"[0,0,0] -> {string.Join(", ", solution.ThreeSum(nums3).Select(x => $"[{string.Join(",", x)}]"))}");
        // Expected: [[0,0,0]]
    }
}
