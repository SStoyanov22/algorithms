package main

import (
	"flag"
	"fmt"
	"log"
	"strconv"
	"strings"

	"github.com/SStoyanov22/algorithms/advent_of_code/aocutil"
)

const (
	year = 2025
	day  = 1
)

func part1(input string) int {
	rotations := strings.Split(input, "\n")
	dialPos := 50
	zeroCount := 0
	rotate := func(d byte, r int) {
		if d == 'L' {
			dialPos -= r
		} else {
			dialPos += r
		}

		dialPos = dialPos % 100
	}

	for _, value := range rotations {
		if len(value) == 0 {
			continue
		}
		direction := value[0]
		rotationCount, err := strconv.Atoi(value[1:])
		if err == nil {
			rotate(direction, rotationCount)
			if dialPos == 0 {
				zeroCount++
			}
		}
	}
	return zeroCount
}

func part2(input string) int {
	// TODO: Implement part 2
	return 0
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
			if !resp.Correct {
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
