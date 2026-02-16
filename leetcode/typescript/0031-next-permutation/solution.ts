function nextPermutation(nums: number[]): void {
  // TODO: implement solution
}

// Test cases
const test1 = [1, 2, 3];
nextPermutation(test1);
console.log(test1); // Expected: [1, 3, 2]

const test2 = [3, 2, 1];
nextPermutation(test2);
console.log(test2); // Expected: [1, 2, 3]

const test3 = [1, 1, 5];
nextPermutation(test3);
console.log(test3); // Expected: [1, 5, 1]
