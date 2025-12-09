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

	for _, value := range rotations {
		if len(value) == 0 {
			continue
		}
		direction := value[0]
		rotationCount, _ := strconv.Atoi(value[1:])
		if direction == 'L' {
			// Moving dial position counter-clockwise
			dialPos -= rotationCount
			if dialPos < 0 {
				dialPos = 100 + dialPos
			}
		} else {
			// Moving dial position clockwise
			dialPos += rotationCount
			if dialPos > 99 {
				dialPos = dialPos - 100
			}
		}
		// Check if we dial is on 0
		if dialPos == 0 {
			zeroCount++
		}
	}
	return zeroCount
}

func part2(input string) int {
	rotations := strings.Split(input, "\n")
	dialPos := 50
	zeroClicks := 0

	for _, value := range rotations {
		if len(value) == 0 {
			continue
		}
		direction := value[0]
		rotationCount, _ := strconv.Atoi(value[1:])
		// Calculate how many times we cross or land on 0
		if direction == 'L' {
			// Moving counter-clockwise (decreasing position)
			if dialPos == 0 {
				// Starting at 0, count how many complete cycles back to 0
				zeroClicks += rotationCount / 100
			} else {
				// Count times we cross 0
				// Distance to reach 0 going left: dialPos steps
				if rotationCount >= dialPos {
					remaining := rotationCount - dialPos
					// We crossed 0 once, plus every 100 steps after
					zeroClicks += 1 + (remaining / 100)
				}
			}

			// Update position
			dialPos = (dialPos - rotationCount) % 100
			if dialPos < 0 {
				dialPos += 100
			}
		} else {
			// Moving clockwise (increasing position)
			if dialPos == 0 {
				// Starting at 0, count how many complete cycles back to 0
				zeroClicks += rotationCount / 100
			} else {
				// Count times we cross 0
				// Distance to 0 going right: (100 - dialPos)
				distanceTo0 := 100 - dialPos
				if rotationCount >= distanceTo0 {
					remaining := rotationCount - distanceTo0
					// We crossed 0 once, plus every 100 steps after
					zeroClicks += 1 + (remaining / 100)
				}
			}

			// Update position
			dialPos = (dialPos + rotationCount) % 100
		}
	}
	return zeroClicks
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
