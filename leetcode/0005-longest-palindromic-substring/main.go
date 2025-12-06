package main

import "fmt"

func longestPalindrome(s string) string {
	if len(s) <= 1 {
		return s
	}

	expandFromCenter := func(left, right int) string {
		for left >= 0 && right < len(s) && s[left] == s[right] {
			left--
			right++
		}
		return s[left+1 : right]
	}

	maxStr := string(s[0])

	for i := 0; i < len(s)-1; i++ {
		odd := expandFromCenter(i, i)
		even := expandFromCenter(i, i+1)

		if len(odd) > len(maxStr) {
			maxStr = odd
		}
		if len(even) > len(maxStr) {
			maxStr = even
		}
	}

	return maxStr
}

func main() {
	result := longestPalindrome("babad")
	fmt.Println("Longest Palindromic Substring:", result)
}
