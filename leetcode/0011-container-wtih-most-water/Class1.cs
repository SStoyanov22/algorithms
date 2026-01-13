namespace _0011_container_wtih_most_water;

public class Solution
{
    public int MaxArea(int[] height)
    {
        int maxArea = 0;
        int left = 0;
        int right = height.Length - 1;

        while (left < right)
        {
            int currentHeight = Math.Min(height[left], height[right]);
            int currentWidth = right - left;
            int currentArea = currentHeight * currentWidth;

            maxArea = Math.Max(maxArea, currentArea);

            // Move the pointer with smaller height
            if (height[left] < height[right])
            {
                left++;
            }
            else
            {
                right--;
            }
        }

        return maxArea;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var solution = new Solution();

        // Test case 1
        int[] height1 = [1, 8, 6, 2, 5, 4, 8, 3, 7];
        Console.WriteLine($"Test 1: {solution.MaxArea(height1)}"); // Expected: 49

        // Test case 2
        int[] height2 = [1, 1];
        Console.WriteLine($"Test 2: {solution.MaxArea(height2)}"); // Expected: 1

        // Test case 3
        int[] height3 = [4, 3, 2, 1, 4];
        Console.WriteLine($"Test 3: {solution.MaxArea(height3)}"); // Expected: 16

        // Test case 4
        int[] height4 = [1, 2, 1];
        Console.WriteLine($"Test 4: {solution.MaxArea(height4)}"); // Expected: 2
    }
}
