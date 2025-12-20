package main

import (
	"flag"
	"fmt"
	"log"
	"sort"
	"strconv"
	"strings"

	"github.com/SStoyanov22/algorithms/advent_of_code/aocutil"
)

const (
	year = 2025
	day  = 5
)

func parseInput(input string) ([][2]int, []int) {
	parts := strings.Split(strings.Trim(input, "\n"), "\n\n")
	freshRanges := strings.Split(parts[0], "\n")
	fresh := make([][2]int, len(freshRanges))

	for i, freshRange := range freshRanges {
		freshParts := strings.Split(freshRange, "-")
		fresh[i][0], _ = strconv.Atoi(freshParts[0])
		fresh[i][1], _ = strconv.Atoi(freshParts[1])
	}
	ingredientsStr := strings.Split(parts[1], "\n")
	ingredients := make([]int, len(ingredientsStr))
	for i, ingredientStr := range ingredientsStr {
		ingredients[i], _ = strconv.Atoi(ingredientStr)
	}

	return fresh, ingredients
}

func countFreshIngredients(fresh [][2]int, ingredients []int) int {
	count := 0
	for _, ingredient := range ingredients {
		for _, f := range fresh {
			if ingredient >= f[0] && ingredient <= f[1] {
				count++
				break
			}
		}
	}

	return count
}

func part1(input string) int {
	fresh, ingredients := parseInput(input)
	count := countFreshIngredients(fresh, ingredients)
	return count
}

func part2(input string) int {
	fresh, _ := parseInput(input)

	// Sort ranges by start position
	sort.Slice(fresh, func(i, j int) bool {
		return fresh[i][0] < fresh[j][0]
	})
	// Merge overlapping ranges and count total coverage
	if len(fresh) == 0 {
		return 0
	}

	totalFresh := 0
	currentStart := fresh[0][0]
	currentEnd := fresh[0][1]

	for i := 1; i < len(fresh); i++ {
		start := fresh[i][0]
		end := fresh[i][1]

		if start <= currentEnd+1 {
			// Ranges overlap or are adjacent, merge them
			if end > currentEnd {
				currentEnd = end
			}
		} else {
			// No overlap, count current range and start a new one
			totalFresh += currentEnd - currentStart + 1
			currentStart = start
			currentEnd = end
		}
	}

	// Don't forget to count the last range
	totalFresh += currentEnd - currentStart + 1

	return totalFresh
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
