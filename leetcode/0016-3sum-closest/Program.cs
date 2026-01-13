namespace _0016_3sum_closest;

public class Solution
{
    public int ThreeSumClosest(int[] nums, int target) {
        Array.Sort(nums);
        int n = nums.Length, closestSum = nums[0] + nums[1] + nums[2];

        for (int i = 0; i < n - 2; i++) {
            if (i > 0 && nums[i - 1] == nums[i]) continue;

            int minSum = nums[i] + nums[i + 1] + nums[i + 2];
            if (minSum >= target) {
                if (Math.Abs(minSum - target) < Math.Abs(closestSum - target)) closestSum = minSum;
                break;
            }

            int maxSum = nums[i] + nums[n - 2] + nums[n - 1];
            if (maxSum <= target) {
                if (Math.Abs(maxSum - target) < Math.Abs(closestSum - target)) closestSum = maxSum;
                continue;
            }

            int left = i + 1, right = n - 1;
            while (left < right) {
                int sum = nums[i] + nums[left] + nums[right];

                if (Math.Abs(target - sum) < Math.Abs(target - closestSum))
                    closestSum = sum;

                if (sum == target) return target;
                else if (sum < target) left++;
                else right--;
            }
        }

        return closestSum;
    }
}

class Program
{
    static void Main()
    {
        var solution = new Solution();

        // Test cases
        int[] nums1 = [-1, 2, 1, -4];
        Console.WriteLine($"[-1,2,1,-4], target=1 -> {solution.ThreeSumClosest(nums1, 1)}"); // Expected: 2

        int[] nums2 = [0, 0, 0];
        Console.WriteLine($"[0,0,0], target=1 -> {solution.ThreeSumClosest(nums2, 1)}"); // Expected: 0
    }
}
