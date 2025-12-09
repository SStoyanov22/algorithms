package main

import "testing"

func TestPart1Example(t *testing.T) {
	input := `L68
L30
R48
L5
R60
L55
L1
L99
R14
L82`
	expected := 3
	result := part1(input)

	if result != expected {
		t.Errorf("Expected %d, got %d", expected, result)
	}
}

func TestPart2Example(t *testing.T) {
	input := `L68
L30
R48
L5
R60
L55
L1
L99
R14
L82`
	expected := 6
	result := part2(input)

	if result != expected {
		t.Errorf("Expected %d, got %d", expected, result)
	}
}
