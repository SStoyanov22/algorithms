package main

import (
	"fmt"
	"math"
)

func findMedianSortedArrays(nums1 []int, nums2 []int) float64 {
	A, B := nums1, nums2
	total := len(nums1) + len(nums2)
	half := total / 2
	if len(A) > len(B) {
		A, B = B, A
	}

	l, r := 0, len(A)-1
	for {
		i := (l + r) / 2  // A
		j := half - i - 2 // B
		Aleft := math.Inf(-1)
		if i >= 0 {
			Aleft = float64(A[i])
		}

		Aright := math.Inf(1)
		if i+1 < len(A) {
			Aright = float64(A[i+1])
		}

		Bleft := math.Inf(-1)
		if j >= 0 {
			Bleft = float64(B[j])
		}

		Bright := math.Inf(1)
		if j+1 < len(B) {
			Bright = float64(B[j+1])
		}

		// partition is correct
		if Aleft <= Bright && Bleft <= Aright {
			// even total length
			if total%2 == 0 {
				return (max(Aleft, Bleft) + min(Aright, Bright)) / 2
			}
			// odd total length
			return max(Aleft, Bleft)
		} else if Aleft > Bright {
			r = i - 1
		} else {
			l = i + 1
		}
	}

}

func main() {
	nums1 := []int{1, 3}
	nums2 := []int{2}
	result := findMedianSortedArrays(nums1, nums2)
	fmt.Println("Median of [1,3] and [2]:", result)

	nums3 := []int{1, 2}
	nums4 := []int{3, 4}
	result2 := findMedianSortedArrays(nums3, nums4)
	fmt.Println("Median of [1,2] and [3,4]:", result2)
}
