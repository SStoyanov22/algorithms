/***
DESCRIPTION (inspired by Leetcode.com)
Given an array heights where each element represents the height of a vertical line, pick two lines to form a container. Return the maximum area (amount of water) the container can hold.

What is area? Width × height, where width is the distance between walls, and height is the shorter wall (water overflows at the shorter wall).

Example 1:

max (21)
3
4
1
2
2
4
1
3
2
heights = [3, 4, 1, 2, 2, 4, 1, 3, 2]
Output:

21  # walls at indices 0 and 7 (both height 3): width=7, height=3, area=21
Example 2:

heights = [1, 2, 1]
Output:

2  # walls at indices 0 and 2: width=2, height=min(1,1)=1, area=2
 ***/
class Solution {
    max_area(heights: number[]): number {
        let left = 0;
        let right = heights.length - 1;
        let maxArea = 0 ;
        while(left < right)
        {
            let height = Math.min(heights[left], heights[right])
            let width = (right - left);
            if( height *  width > maxArea)
                maxArea =  height * width;
            
            Math.min(heights[left + 1], heights[right]) >= Math.min(heights[left], heights[right - 1]) ?
             left++ : right--;
        }

        return maxArea;
    }
}
let solution = new Solution();
console.log(solution.max_area([1,8,6,2,5,4,8,3,7]))