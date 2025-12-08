# Script to create a new Advent of Code day structure
# Usage: .\newday.ps1 <year> <day>
# Example: .\newday.ps1 2025 2

param(
    [Parameter(Mandatory=$true)]
    [int]$Year,

    [Parameter(Mandatory=$true)]
    [int]$Day
)

$DayPadded = "{0:D2}" -f $Day
$DayDir = "$Year\day$DayPadded"

if (Test-Path $DayDir) {
    Write-Error "Error: Directory $DayDir already exists"
    exit 1
}

Write-Host "Creating structure for Year $Year, Day $Day..." -ForegroundColor Green

New-Item -ItemType Directory -Path $DayDir -Force | Out-Null

$mainGo = @"
package main

import (
	"flag"
	"fmt"
	"log"

	"github.com/SStoyanov22/algorithms/advent_of_code/aocutil"
)

const (
	year = $Year
	day  = $Day
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
"@

$testGo = @"
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
"@

Set-Content -Path "$DayDir\main.go" -Value $mainGo
Set-Content -Path "$DayDir\main_test.go" -Value $testGo

Write-Host "✓ Created $DayDir\main.go" -ForegroundColor Green
Write-Host "✓ Created $DayDir\main_test.go" -ForegroundColor Green

Write-Host ""
Write-Host "Next steps:" -ForegroundColor Yellow
Write-Host "  1. cd $DayDir"
Write-Host "  2. go run main.go           # Fetches README.md and input.txt automatically"
Write-Host "  3. Read README.md for the problem description"
Write-Host "  4. Implement part1() and part2() functions"
Write-Host "  5. go run main.go           # Test locally"
Write-Host "  6. go run main.go -submit   # Submit answers"
