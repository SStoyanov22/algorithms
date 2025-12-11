package main

import (
	"flag"
	"fmt"
	"log"
	"math"
	"strconv"
	"strings"

	"github.com/SStoyanov22/algorithms/advent_of_code/aocutil"
)

const (
	year = 2025
	day  = 2
)

type IdRange struct {
	Start int
	End   int
}

func parseRanges(input string) []IdRange {
	var idRanges []IdRange
	for _, rangeStr := range strings.Split(input, ",") {
		rangeStr = strings.TrimSpace(rangeStr)
		parts := strings.Split(rangeStr, "-")
		if len(parts) == 2 {
			start, _ := strconv.Atoi(parts[0])
			end, _ := strconv.Atoi(parts[1])
			idRanges = append(idRanges, IdRange{Start: start, End: end})
		}
	}
	return idRanges
}

func hasEqualParts(id int, split int) bool {
	digitCount := len(strconv.Itoa(id))
	if digitCount%split == 0 {

		// Check if the number can be evenly split
		if digitCount%split != 0 {
			return false
		}

		// Calculate divisor for extracting parts (10^partSize)
		divisor := int(math.Pow(10, float64(digitCount/split)))

		// Extract the first part (rightmost part)
		firstPart := id % divisor

		// Check if all parts are equal
		remaining := id
		for range split {
			part := remaining % divisor
			if part != firstPart {
				return false
			}
			remaining /= divisor
		}

		return true
	}

	return false

}

func part1(input string) int {
	idRanges := parseRanges(input)
	sum := 0
	for _, idRange := range idRanges {
		for id := idRange.Start; id <= idRange.End; id++ {
			if hasEqualParts(id, 2) {
				sum += id
			}
		}
	}

	return sum
}

func part2(input string) int {
	idRanges := parseRanges(input)
	sum := 0
	splits := []int{2, 3, 4, 5, 6, 7, 8, 9, 10}
	for _, idRange := range idRanges {
		for id := idRange.Start; id <= idRange.End; id++ {
			for _, split := range splits {
				if hasEqualParts(id, split) {
					sum += id
					break
				}
			}
		}
	}

	return sum
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
			// Only return if incorrect (not if already completed)
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
