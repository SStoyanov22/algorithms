/*
 * @lc app=leetcode id=29 lang=typescript
 *
 * [29] Divide Two Integers
 */

// @lc code=start
function divide(dividend: number, divisor: number): number {
    const negative = (dividend < 0) != (divisor < 0)
    if(dividend == -(2**31) && divisor == -1)
        return 2**31-1
    let absDividend = Math.abs(dividend)
    let absDivisor = Math.abs(divisor)
    
    let quotient = 0
    while (absDividend >= absDivisor)
    {
        let multiple = 1
        let tmpDivisor = absDivisor;
       // Double until we exceed dividend
        while (absDividend >= tmpDivisor + tmpDivisor) {
            tmpDivisor += tmpDivisor;
            multiple += multiple;
        }

        absDividend -= tmpDivisor;
        quotient += multiple;

    }

    return negative ? - quotient : quotient;
};

// Test cases
console.log(divide(100, 10));         // 10
console.log(divide(10, 3));           // 3
console.log(divide(7, -3));           // -2
console.log(divide(-2147483648, -1)); // 2147483647
console.log(divide(2147483647, 2)); // 2147483647
console.log(divide(1, 1));            // 1
// @lc code=end

