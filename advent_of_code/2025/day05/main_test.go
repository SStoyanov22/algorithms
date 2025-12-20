package main

import "testing"

func TestPart1Example(t *testing.T) {
	input := `3-5
10-14
16-20
12-18

1
5
8
11
17
32
`
	expected := 3
	result := part1(input)

	if result != expected {
		t.Errorf("Expected %d, got %d", expected, result)
	}
}

func TestPart2Example(t *testing.T) {
	input := `3-5
10-14
16-20
12-18

1
5
8
11
17
32
`
	expected := 14
	result := part2(input)

	if result != expected {
		t.Errorf("Expected %d, got %d", expected, result)
	}
}
