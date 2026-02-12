// Definition for singly-linked list.
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution {
    public ListNode ReverseKGroup(ListNode head, int k) {
        if(k == 1) return head;

        ListNode dummy = new ListNode(0);
        dummy.next = head;
        ListNode prevGroup = dummy;

        while (true)
        {
            // ===== PHASE 1: CHECK IF WE HAVE K NODES =====   
            ListNode checker = prevGroup.next;
            int count = 0;
            while(checker != null && count < k)
            {
                checker = checker.next;
                count++;
            }

            // If we don't have k nodes, stop                                                                                                              
            if (count < k)                                                                                                                                 
                break;                                                                                                                                     

            // ===== PHASE 2: REVERSE K NODES ===== 
            ListNode curr = prevGroup.next;  // First node of group                                                                                        
            ListNode tail = curr;            // Will be last after reversal   

            // Move k-1 nodes to the front, one by one          
            for(int i = 0; i < k - 1; i++)
            {
                ListNode next = curr.next;   // Save next node
                curr.next = next.next;       // Skip over next    
                next.next = prevGroup.next;  // Move next to front
                prevGroup.next = next;       // Connect prev to next      
            }

            prevGroup = tail; // Move to end of this group for next iteration           
        }

        return dummy.next;
    }
}