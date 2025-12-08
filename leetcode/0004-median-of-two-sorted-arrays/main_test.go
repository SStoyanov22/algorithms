package main

import (
	"testing"
)

func TestFindMedianSortedArrays(t *testing.T) {
	tests := []struct {
		name     string
		nums1    []int
		nums2    []int
		expected float64
	}{
		{
			name:     "Example 1: Even total length",
			nums1:    []int{1, 3},
			nums2:    []int{2},
			expected: 2.0,
		},
		{
			name:     "Example 2: Odd total length",
			nums1:    []int{1, 2},
			nums2:    []int{3, 4},
			expected: 2.5,
		},
		{
			name:     "One empty array",
			nums1:    []int{},
			nums2:    []int{1},
			expected: 1.0,
		},
		{
			name:     "Both arrays with single element",
			nums1:    []int{1},
			nums2:    []int{2},
			expected: 1.5,
		},
		{
			name:     "Larger arrays",
			nums1:    []int{1, 3, 8, 9, 15},
			nums2:    []int{7, 11, 18, 19, 21, 25},
			expected: 11.0,
		},
		{
			name:     "Arrays with negative numbers",
			nums1:    []int{-2, 0, 2},
			nums2:    []int{-1, 1, 3},
			expected: 0.5,
		},
		{
			name:     "Duplicate values",
			nums1:    []int{1, 1, 1},
			nums2:    []int{1, 1, 1},
			expected: 1.0,
		},
	}

	for _, tt := range tests {
		t.Run(tt.name, func(t *testing.T) {
			result := findMedianSortedArrays(tt.nums1, tt.nums2)
			if result != tt.expected {
				t.Errorf("got %v, want %v", result, tt.expected)
			}
		})
	}
}
