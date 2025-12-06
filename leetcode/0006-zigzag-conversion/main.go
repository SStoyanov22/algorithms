package main

import (
	"fmt"
	"strings"
)

func convert(s string, numRows int) string {
	// Edge cases
	if numRows >= len(s) || numRows == 1 {
		return s
	}

	rows := make([]strings.Builder, numRows)

	currentRow := 0
	goingDown := false

	for _, char := range s {
		// Add character to current row
		rows[currentRow].WriteRune(char)

		// Change direction at top or bottom row
		if currentRow == 0 || currentRow == numRows-1 {
			goingDown = !goingDown
		}

		// Moving to next row
		if goingDown {
			currentRow++
		} else {
			currentRow--
		}
	}

	// Concatenate all rows
	var result strings.Builder
	for _, row := range rows {
		result.WriteString(row.String())
	}

	return result.String()
}

func main() {
	result := convert("PAYPALISHIRING", 3)
	fmt.Println("The converted string is : ", result)
}
