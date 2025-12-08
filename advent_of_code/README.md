# Advent of Code Solutions

This folder contains solutions for Advent of Code challenges.

## Setup

### Getting Your Session Cookie

1. Log in to [Advent of Code](https://adventofcode.com)
2. Open your browser's Developer Tools (F12)
3. Go to the Application/Storage tab
4. Find Cookies → `https://adventofcode.com`
5. Copy the value of the `session` cookie

### Setting Up Environment

Set your session cookie as an environment variable:

**Windows (PowerShell):**
```powershell
$env:AOC_SESSION="your_session_cookie_here"
```

**Windows (CMD):**
```cmd
set AOC_SESSION=your_session_cookie_here
```

**Linux/Mac:**
```bash
export AOC_SESSION="your_session_cookie_here"
```

For permanent setup, add it to your shell profile or `.env` file.

## Usage

### Creating a New Day

Use the provided script to automatically generate the day structure:

**Windows (PowerShell):**
```powershell
cd advent_of_code
.\newday.ps1 2025 2
```

**Linux/Mac/Git Bash:**
```bash
cd advent_of_code
./newday.sh 2025 2
```

This creates the complete folder structure with template files.

<details>
<summary>Manual Setup (click to expand)</summary>

If you prefer to create the structure manually:

1. Create a new folder for the day (e.g., `2025/day02`)
2. Create a `main.go` file with the following structure:

```go
package main

import (
	"flag"
	"fmt"
	"log"

	"github.com/SStoyanov22/algorithms/advent_of_code/aocutil"
)

const (
	year = 2025
	day  = 2
)

func part1(input string) int {
	// Your solution here
	return 0
}

func part2(input string) int {
	// Your solution here
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
```

</details>

### Running Solutions

Navigate to the day's folder and run:

**First run (fetches both README.md and input.txt):**
```bash
cd 2025/day01
go run main.go
```

This automatically:
- Fetches and caches the problem description in `README.md`
- Fetches and caches your input in `input.txt`
- Runs your solution

**After implementing your solution:**
```bash
go run main.go        # Test locally
go run main.go -submit # Submit to Advent of Code
```

### How Submission Works

When you run with the `-submit` flag:
1. Part 1 is submitted automatically
2. If Part 1 is correct, Part 2 is then submitted
3. If Part 1 is incorrect or rate-limited, submission stops
4. You'll see clear feedback:
   - "Correct! ⭐" - Answer accepted
   - "Incorrect - answer is too high/low" - Try again
   - "Rate limited - please wait X" - Wait before resubmitting
   - "Already completed this part" - You've solved it before

## How It Works

The `aocutil` package provides functions to:
- Automatically fetch puzzle inputs from adventofcode.com
- Cache inputs locally in `input.txt` files
- Reuse cached inputs on subsequent runs
- Submit answers directly to Advent of Code
- Parse submission responses and provide clear feedback

### Input Fetching

The first time you run a solution, it will:
1. Check if `input.txt` exists in the day's folder
2. If not, fetch it from AoC using your session cookie
3. Save it to `input.txt` for future runs
4. Return the input to your solution code

### Answer Submission

When you use the `-submit` flag:
1. Your solution runs and calculates answers for both parts
2. Part 1 answer is submitted via HTTP POST to AoC
3. The HTML response is parsed to determine if the answer is correct
4. If Part 1 is correct, Part 2 is automatically submitted
5. Clear feedback is provided for each submission

## How It All Works Together

When you run `go run main.go` for the first time in a day's folder, it automatically:

1. **Fetches the problem description** - Creates `README.md` with the puzzle description in markdown
2. **Fetches your input** - Downloads and caches your personalized input in `input.txt`
3. **Runs your solution** - Executes part1() and part2() with your input

All files are cached, so subsequent runs use the local files instead of fetching again.

## Structure

```
advent_of_code/
├── aocutil/
│   └── input.go          # Input fetching, problem fetching, and submission utilities
├── newday.sh             # Bash script to create new day
├── newday.ps1            # PowerShell script to create new day
├── 2025/
│   ├── day01/
│   │   ├── README.md     # Problem description (auto-generated)
│   │   ├── main.go       # Solution code
│   │   ├── main_test.go  # Test file
│   │   └── input.txt     # Cached input (auto-generated)
│   ├── day02/
│   │   └── ...
│   └── ...
└── README.md
```
