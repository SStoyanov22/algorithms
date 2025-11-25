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