package main

import (
	"flag"
	"fmt"
	"log"
	"math"
	"strings"

	"github.com/SStoyanov22/algorithms/advent_of_code/aocutil"
)

const (
	year = 2025
	day  = 3
)

func getHighestBatteryJoltage(startIndex int, endIndex int, input string) (int, int) {
	maxValue := int(input[startIndex] - '0')
	maxIndex := int(startIndex)
	for i := startIndex + 1; i <= endIndex; i++ {
		currentValue := int(input[i] - '0') // Convert ASCII digit to int
		if currentValue > maxValue {
			maxValue = currentValue
			maxIndex = i
		}
	}

	return maxValue, maxIndex
}

func getHighestBankJoltage(bank string, size int) int {
	joltage := 0
	startIndex := 0
	endIndex := len(bank) - size
	for i := range size {
		value, index := getHighestBatteryJoltage(startIndex, endIndex, bank)
		startIndex = index + 1
		endIndex = len(bank) - size + i + 1
		joltage += int(math.Pow(10, float64(size-i-1))) * value
	}

	return joltage
}

func part1(input string) int {
	size := 2
	totalJoltage := 0
	banks := strings.Split(strings.Trim(input, "\n"), "\n")
	for _, bank := range banks {
		totalJoltage += getHighestBankJoltage(bank, size)
	}
	return totalJoltage
}

func part2(input string) int {
	size := 12
	totalJoltage := 0
	banks := strings.Split(strings.Trim(input, "\n"), "\n")
	for _, bank := range banks {
		totalJoltage += getHighestBankJoltage(bank, size)
	}
	return totalJoltage
}

func main() {
	var submit bool
	flag.BoolVar(&submit, "submit", false, "Submit answers to Advent of Code")
	flag.Parse()

	// Fetch problem description if it doesn't exist
	if _, err := aocutil.GetProblem(year, day); err != nil {
		log.Printf("Note: Could not fetch problem description: %v", err)
	}

	input, err := aocutil.GetInput(year, day)
	if err != nil {
		log.Fatalf("Failed to get input: %v", err)
	}

	answer1 := part1(input)
	fmt.Printf("Part 1: %d\n", answer1)

	if submit {
		fmt.Println("Submitting Part 1...")
		resp, err := aocutil.SubmitAnswer(year, day, 1, fmt.Sprintf("%d", answer1))
		if err != nil {
			log.Printf("Failed to submit Part 1: %v", err)
		} else {
			fmt.Printf("Part 1 result: %s\n", resp.Message)
			// Only return if wrong answer, not if already completed
			if !resp.Correct && !strings.Contains(resp.Message, "Already completed") {
				return
			}
		}
	}

	answer2 := part2(input)
	fmt.Printf("Part 2: %d\n", answer2)

	if submit {
		fmt.Println("Submitting Part 2...")
		resp, err := aocutil.SubmitAnswer(year, day, 2, fmt.Sprintf("%d", answer2))
		if err != nil {
			log.Printf("Failed to submit Part 2: %v", err)
		} else {
			fmt.Printf("Part 2 result: %s\n", resp.Message)
		}
	}
}
