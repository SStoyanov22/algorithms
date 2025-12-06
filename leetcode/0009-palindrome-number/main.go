package main

import "fmt"

func isPalindrome(x int) bool {
	if x < 0 || (x%10 == 0 && x != 0) {
		return false
	}

	// Reverse half of the number and compare
	reversedHalf := 0

	for x > reversedHalf {
		// Extract last digit and add to reversed half
		reversedHalf = reversedHalf*10 + x%10
		x = x / 10
	}

	return x == reversedHalf || x == reversedHalf/10
}

func main() {
	result := isPalindrome(123321)
	fmt.Println(result)
}
