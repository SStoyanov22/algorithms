/**
 * Definition for singly-linked list.
 * type ListNode struct {
 *     Val int
 *     Next *ListNode
 * }
 */
func addTwoNumbers(l1 *ListNode, l2 *ListNode) *ListNode {
	head := &ListNode{}
	current := head
	carry := 0
	for {
		l1_val := 0
		if l1 != nil {
			l1_val = l1.Val
		}
		l2_val := 0
		if l2 != nil {
			l2_val = l2.Val
		}
		total := l1_val + l2_val + carry
		current.Next = &ListNode{Val: total % 10}
		carry = total / 10

		// Move list pointers forward
        if l1 != nil {
            l1 = l1.Next
        }
        if l2 != nil {
            l2 = l2.Next
        }

		current = current.Next

		// Break condition
		if l1 == nil && l2 == nil && carry == 0 {
			break
		}
	}

	return head.Next
}