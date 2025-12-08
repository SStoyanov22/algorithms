package main

import (
	"fmt"
	"math"
	"strings"
)

func myAtoi(s string) int {
	// Step 1: Ignore leading whitespace
	s = strings.TrimLeft(s, " ")

	// Check if string is empty after trimming
	if len(s) == 0 {
		return 0
	}

	// Step 2: Determine the sign
	sign := 1
	index := 0
	if s[index] == '-' {
		sign = -1
		index++
	} else if s[index] == '+' {
		index++
	}

	// Step 3: Convert digits to integer
	result := 0
	for index < len(s) {
		char := s[index]

		if char < '0' || char > '9' {
			break
		}

		// Convert char to digit
		digit := int(char - '0')

		// Step 4: Check for overflow/ underflow before adding digit
		// Max int32: 2147483647, Min int32: -2148483648
		if result > math.MaxInt32/10 || (result == math.MaxInt32/10 && digit > 7) {
			if sign == -1 {
				return math.MinInt32
			}

			return math.MaxInt32
		}

		result = result*10 + digit
		index++
	}

	return result * sign
}

func main() {
	result := myAtoi("   -042")
	fmt.Println("The reversed number is : ", result)
}
