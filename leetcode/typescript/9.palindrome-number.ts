/*
 * @lc app=leetcode id=9 lang=typescript
 *
 * [9] Palindrome Number
 */

// @lc code=start
function isPalindrome(x: number): boolean {
    if(x<0 || (x%10==0 && x != 0))
        return false

    let reversedHalf = 0

    while (x > reversedHalf) {
        reversedHalf = reversedHalf * 10 + x % 10
        x = Math.floor(x / 10)
    }

    return reversedHalf == x || Math.floor(reversedHalf / 10) == x
};
// @lc code=end

// 123454321