class Solution {
    threeSum(nums: number[]): number[][] {
        nums.sort((a, b) => a - b);
        const result: number[][] = [];
        for (let i = 0; i < nums.length - 2; i++) {
            const num = nums[i];
            // Skip duplicate values for the first element to avoid duplicate triplets
            if (i > 0 && nums[i] === nums[i - 1]) {
                continue;
            }
            // Initialize two pointers for the remaining subarray
            let left = i + 1;
            let right = nums.length - 1;
            
            while (left < right) {
                const total = nums[i] + nums[left] + nums[right];
                if(total > 0 ) {
                    right--;
                } else if (total < 0) {
                    left++;
                } else {
                    result.push([nums[i], nums[left], nums[right]]);
                    while(left<right && nums[left] === nums[right]){
                        left++;
                    }

                    while(left<right && nums[right-1] === nums[right]){
                        right--;
                    }
                    left++;
                    right--;
                }
            }
            
        }
        return result;
    }
}