namespace _0019_remove_nth_node_from_end_of_list;



  /// <summary>
  /// Definition for singly-linked list.
  /// </summary>
  public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int val=0, ListNode next=null) {
          this.val = val;
          this.next = next;
      }
  }
 
public class Solution
{
    public ListNode RemoveNthFromEnd(ListNode head, int n) {

        // Use a dummy node to handle edge cases (e.g., removing head)                                                                                 
        ListNode dummy = new ListNode(0);                                                                                                              
        dummy.next = head;                                                                                                                             
                                                                                                                                                        
        ListNode fast = dummy;                                                                                                                         
        ListNode slow = dummy;   
        
        // Move fast pointer n+1 steps ahead
        // This creates a gap of n nodes between slow and fast
        for (int i = 0; i <= n; i++) {
            fast = fast.next;
        }                                                                                                                                              
                                                                                                                                                        
        // Move both pointers until fast reaches the end                                                                                               
        // When fast is at null, slow will be at the node BEFORE the one to remove                                                                     
        while (fast != null) {                                                                                                                         
            fast = fast.next;                                                                                                                          
            slow = slow.next;                                                                                                                          
        }                                                                                                                                              
                                                                                                                                                        
        // Remove the nth node by skipping it
        slow.next = slow.next.next;

        return dummy.next;     
    }
}