package main

import (
	"flag"
	"fmt"
	"log"
	"strings"

	"github.com/SStoyanov22/algorithms/advent_of_code/aocutil"
)

const (
	year = 2025
	day  = 4
)

func parseGrid(input string) [][]rune {
	lines := strings.Split(strings.TrimSpace(input), "\n")
	grid := make([][]rune, len(lines))

	for i, line := range lines {
		grid[i] = []rune(line)
	}

	return grid
}

func isForkable(row int, col int, grid [][]rune) bool {
	if grid[row][col] != '@' {
		return false
	}
	count := 0
	rows := len(grid)
	cols := len(grid[0])

	// Only 4 directions: up, down, left, right
	directions := [][]int{
		{-1, 0},  // up
		{1, 0},   // down
		{0, -1},  // left
		{0, 1},   // right
		{-1, -1}, // up-left
		{-1, 1},  // up-right
		{1, -1},  //down-left
		{1, 1},   //down-right
	}

	for _, dir := range directions {
		newX := row + dir[0]
		newY := col + dir[1]

		if newX >= 0 && newX < rows && newY >= 0 && newY < cols {
			if grid[newX][newY] == '@' {
				count++
			}
		}
	}

	return count < 4
}

func updateGrid(grid [][]rune, forkableItems [][2]int) [][]rune {
	// Create a deep copy of the grid
	modifiedGrid := make([][]rune, len(grid))
	for i := range grid {
		modifiedGrid[i] = make([]rune, len(grid[i]))
		copy(modifiedGrid[i], grid[i])
	}

	// Modify the copy
	for _, item := range forkableItems {
		row := item[0]
		col := item[1]
		modifiedGrid[row][col] = '.'
	}

	return modifiedGrid
}

func part1(input string) int {
	grid := parseGrid(input)
	forkableCount := 0
	for row := 0; row < len(grid); row++ {
		for col := 0; col < len(grid[0]); col++ {
			if isForkable(row, col, grid) {
				forkableCount++
			}
		}
	}
	return forkableCount
}

func part2(input string) int {
	grid := parseGrid(input)
	totalRemoved := 0
	for {
		// Find all forkable items in current grid state
		forkableItems := [][2]int{}
		for row := 0; row < len(grid); row++ {
			for col := 0; col < len(grid[0]); col++ {
				if isForkable(row, col, grid) {
					forkableItems = append(forkableItems, [2]int{row, col})
				}
			}
		}

		// If no forkable items found, we're done
		if len(forkableItems) == 0 {
			break
		}

		// Update the grid by removing forkable items
		grid = updateGrid(grid, forkableItems)

		// Track total removed
		totalRemoved += len(forkableItems)
	}

	return totalRemoved
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
