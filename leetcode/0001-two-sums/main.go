package main

import "fmt"

func twoSum(nums []int, target int) []int {
	indexMap := map[int]int{}
	for index, value := range nums {
		if _, exists := indexMap[target-value]; exists {
			return []int{indexMap[target-value], index}
		}
		indexMap[value] = index
	}

	return []int{}
}

func main() {
	result := twoSum([]int{2, 7, 11, 15}, 9)
	fmt.Println("Two sum indices:", result)
}
