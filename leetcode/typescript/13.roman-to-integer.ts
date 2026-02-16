/*
 * @lc app=leetcode id=13 lang=typescript
 *
 * [13] Roman to Integer
 */

// @lc code=start
function romanToInt(s: string): number {
    const values = new Map<string, number>([                                                                  
              ["I", 1], ["V", 5], ["X", 10], ["L", 50],                                                             
              ["C", 100], ["D", 500], ["M", 1000],                                                                  
          ]);  
        let result = 0
        for (let i = 0; i < s.length; i++) {
            const curr = values.get(s[i])!;
            const next = values.get(s[i]) ?? 0;
            if(curr<next)
                result -= curr
            else
                result += curr
        }

        return result
};
// @lc code=end

