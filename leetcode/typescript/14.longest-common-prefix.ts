/*
 * @lc app=leetcode id=14 lang=typescript
 *
 * [14] Longest Common Prefix
 */

// @lc code=start
function longestCommonPrefix(strs: string[]): string {
    let prefix = strs[0];
    for (let i = 1; i < strs.length; i++) {
        while(!strs[i].startsWith(prefix))
            prefix = prefix.slice(0,-1);

        if(prefix==="")
            return prefix
    }

    return prefix
};
// @lc code=end

