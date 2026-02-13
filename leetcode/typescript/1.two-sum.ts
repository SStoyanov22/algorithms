/*
 * @lc app=leetcode id=1 lang=typescript
 *
 * [1] Two Sum
 */

function twoSum(nums: number[], target: number): number[] {
  const indexMap = new Map<number, number>();
  for (let i = 0; i < nums.length; i++) {
    const complement = target - nums[i];
    if (indexMap.has(complement)) {
      return [indexMap.get(complement)!, i];
    }
    indexMap.set(nums[i], i);
  }
  return [];
}

// @lc code=end


console.log(twoSum([2, 7, 11, 15], 9)); // [0, 1]
console.log(twoSum([3, 2, 4], 6));       // [1, 2]
console.log(twoSum([3, 3], 6));           // [0, 1]