package main

import (
	"fmt"
	"math"
)

func reverse(x int) int {
	result := 0
	for x != 0 {
		// Get the last figit
		digit := x % 10
		x /= 10
		// Max int32: 2147483647, Min int32: -2148483648
		if result > math.MaxInt32/10 || (result == math.MaxInt32/10 && digit > 7) {
			return 0
		}

		if result < math.MinInt32/10 || (result == math.MinInt32/10 && digit < -8) {
			return 0
		}

		// Build reversed number
		result = result*10 + digit
	}

	return result
}

func main() {
	result := reverse(1534236469)
	fmt.Println("The reversed number is : ", result)
}
