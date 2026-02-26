/*
 * @lc app=leetcode id=31 lang=typescript
 *
 * [31] Next Permutation
 */

// @lc code=start
/**
 Do not return anything, modify nums in-place instead.
 */
function nextPermutation(nums: number[]): void {
    let pivot = -1;
    for (let i = nums.length-2; i>=0 ; i--) {
        if(nums[i]<nums[i+1]){
            pivot = i;
            break;
        }
    }

    if(pivot === -1) {
        return reverse(nums, 0, nums.length -1)
    }
};

function reverse(nums: number[], left: number, right: number): void {
    while(left<right) {
        swap(nums, left,right);
        left++;
        right--;
    }
}

function swap(nums: number[], left: number, right: number) {
    nums[left], nums[right] = nums[right], nums[left];
}
// @lc code=end

