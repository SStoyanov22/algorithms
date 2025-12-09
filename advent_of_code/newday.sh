#!/bin/bash

# Script to create a new Advent of Code day structure
# Usage: ./newday.sh <year> <day>
# Example: ./newday.sh 2025 2

if [ $# -ne 2 ]; then
    echo "Usage: $0 <year> <day>"
    echo "Example: $0 2025 2"
    exit 1
fi

YEAR=$1
DAY=$2
DAY_PADDED=$(printf "%02d" $DAY)
DAY_DIR="$YEAR/day$DAY_PADDED"

if [ -d "$DAY_DIR" ]; then
    echo "Error: Directory $DAY_DIR already exists"
    exit 1
fi

echo "Creating structure for Year $YEAR, Day $DAY..."

mkdir -p "$DAY_DIR"

cat > "$DAY_DIR/main.go" << 'EOF'
package main

import (
	"flag"
	"fmt"
	"log"
	"strings"

	"github.com/SStoyanov22/algorithms/advent_of_code/aocutil"
)

const (
	year = YEAR_PLACEHOLDER
	day  = DAY_PLACEHOLDER
)

func part1(input string) int {
	// TODO: Implement part 1
	return 0
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
EOF

# Replace placeholders
sed -i "s/YEAR_PLACEHOLDER/$YEAR/g" "$DAY_DIR/main.go"
sed -i "s/DAY_PLACEHOLDER/$DAY/g" "$DAY_DIR/main.go"

cat > "$DAY_DIR/main_test.go" << 'EOF'
package main

import "testing"

func TestPart1Example(t *testing.T) {
	input := ""
	expected := 0
	result := part1(input)

	if result != expected {
		t.Errorf("Expected %d, got %d", expected, result)
	}
}

func TestPart2Example(t *testing.T) {
	input := ""
	expected := 0
	result := part2(input)

	if result != expected {
		t.Errorf("Expected %d, got %d", expected, result)
	}
}
EOF

echo "✓ Created $DAY_DIR/main.go"
echo "✓ Created $DAY_DIR/main_test.go"

echo ""
echo "Next steps:"
echo "  1. cd $DAY_DIR"
echo "  2. go run main.go           # Fetches README.md and input.txt automatically"
echo "  3. Read README.md for the problem description"
echo "  4. Implement part1() and part2() functions"
echo "  5. go run main.go           # Test locally"
echo "  6. go run main.go -submit   # Submit answers"
