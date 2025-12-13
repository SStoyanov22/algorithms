package main

import "testing"

func TestPart1Example(t *testing.T) {
	input := `987654321111111
811111111111119
234234234234278
818181911112111`
	expected := 357
	result := part1(input)

	if result != expected {
		t.Errorf("Expected %d, got %d", expected, result)
	}
}

func TestPart2Example(t *testing.T) {
	input := `987654321111111
811111111111119
234234234234278
818181911112111`
	expected := 3121910778619
	result := part2(input)

	if result != expected {
		t.Errorf("Expected %d, got %d", expected, result)
	}
}
