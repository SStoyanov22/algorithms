package main

import "fmt"

func lengthOfLongestSubstring(s string) int {
	currentMax := 0
	current := 0
	startIndex := 0
	indexMap := map[byte]int{}
	for i := 0; i < len(s); i++ {
		if lastIndex, exists := indexMap[s[i]]; exists && lastIndex >= startIndex {
			if current > currentMax {
				currentMax = current
			}
			startIndex = lastIndex + 1
			current = i - startIndex
		}
		indexMap[s[i]] = i
		current++
	}

	return max(currentMax, current)
}

func main() {
	result := lengthOfLongestSubstring("abcabcbb")
	fmt.Println("Length of longest substring:", result)
}
