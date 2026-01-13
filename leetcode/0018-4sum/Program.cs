using System.IO.Pipelines;

namespace _0018_4sum;

public class Solution
{
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        Array.Sort(nums);
        int n = nums.Length;
        IList<IList<int>> result = new List<IList<int>>();
        for(var i = 0; i< n - 3; i++)
        {
            if (i>0 && nums[i] == nums[i-1])
                continue;
            
            // Early termination: minimum possible sum for this i
            long minSum = (long)nums[i] + nums[i+1] + nums[i+2] + nums[i+3];
            if (minSum > target) break;

            // Early skip: maximum possible sum for this i
            long maxSum = (long)nums[i] + nums[n-3] + nums[n-2] + nums[n-1];
            if (maxSum < target) continue;
            
            for(var j = i + 1; j < n - 2; j++)
            {
                if (j > i + 1 && nums[j] == nums[j-1])
                    continue;
                // Early termination for j loop
                long minSumJ = (long)nums[i] + nums[j] + nums[j+1] + nums[j+2];
                if (minSumJ > target) break;

                // Early skip for j loop
                long maxSumJ = (long)nums[i] + nums[j] + nums[n-2] + nums[n-1];
                if (maxSumJ < target) continue;

                var left = j + 1;
                var right = n - 1;
                var targetSum = (long)target - nums[i] - nums[j];
                while (left < right)
                {
                    var sum = (long)nums[left] + nums[right];
                    if (sum == targetSum)
                    {
                        result.Add([nums[i], nums[j], nums[left], nums[right]]);
                        while (left < right && nums[left] == nums[left + 1]) left++;
                        while (left < right && nums[right] == nums[right -1]) right--;
                        left++;
                        right--;
                    }
                    else if (sum < targetSum) left++;
                    else right--;
                }
            }
        }

        return result;
    }
}

class Program
{
    static void Main()
    {
        var solution = new Solution();

        // Test cases
        int[] nums1 = [1, 0, -1, 0, -2, 2];
        Console.WriteLine($"[1,0,-1,0,-2,2], target=0 -> {string.Join(", ", solution.FourSum(nums1, 0).Select(x => $"[{string.Join(",", x)}]"))}");
        // Expected: [[-2,-1,1,2],[-2,0,0,2],[-1,0,0,1]]

        int[] nums2 = [2, 2, 2, 2, 2];
        Console.WriteLine($"[2,2,2,2,2], target=8 -> {string.Join(", ", solution.FourSum(nums2, 8).Select(x => $"[{string.Join(",", x)}]"))}");
        // Expected: [[2,2,2,2]]
    }
}
