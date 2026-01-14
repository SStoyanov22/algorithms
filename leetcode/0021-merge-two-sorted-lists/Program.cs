namespace __0021_merge_two_sorted_lists;

class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();

        // Test Case 1: list1 = [1,2,4], list2 = [1,3,4]
        Console.WriteLine("Test Case 1:");
        ListNode list1 = CreateList(new int[] { 1, 2, 4 });
        ListNode list2 = CreateList(new int[] { 1, 3, 4 });
        Console.Write("list1: "); PrintList(list1);
        Console.Write("list2: "); PrintList(list2);
        ListNode result1 = solution.MergeTwoLists(list1, list2);
        Console.Write("Merged: "); PrintList(result1);
        Console.WriteLine("Expected: [1,1,2,3,4,4]\n");

        // Test Case 2: list1 = [], list2 = []
        Console.WriteLine("Test Case 2:");
        ListNode list3 = CreateList(new int[] { });
        ListNode list4 = CreateList(new int[] { });
        Console.Write("list1: "); PrintList(list3);
        Console.Write("list2: "); PrintList(list4);
        ListNode result2 = solution.MergeTwoLists(list3, list4);
        Console.Write("Merged: "); PrintList(result2);
        Console.WriteLine("Expected: []\n");

        // Test Case 3: list1 = [], list2 = [0]
        Console.WriteLine("Test Case 3:");
        ListNode list5 = CreateList(new int[] { });
        ListNode list6 = CreateList(new int[] { 0 });
        Console.Write("list1: "); PrintList(list5);
        Console.Write("list2: "); PrintList(list6);
        ListNode result3 = solution.MergeTwoLists(list5, list6);
        Console.Write("Merged: "); PrintList(result3);
        Console.WriteLine("Expected: [0]\n");

        // Test Case 4: list1 = [5], list2 = [1,2,4]
        Console.WriteLine("Test Case 4:");
        ListNode list7 = CreateList(new int[] { 5 });
        ListNode list8 = CreateList(new int[] { 1, 2, 4 });
        Console.Write("list1: "); PrintList(list7);
        Console.Write("list2: "); PrintList(list8);
        ListNode result4 = solution.MergeTwoLists(list7, list8);
        Console.Write("Merged: "); PrintList(result4);
        Console.WriteLine("Expected: [1,2,4,5]\n");
    }

    // Helper: Create linked list from array
    static ListNode CreateList(int[] values)
    {
        if (values.Length == 0) return null;

        ListNode head = new ListNode(values[0]);
        ListNode current = head;

        for (int i = 1; i < values.Length; i++)
        {
            current.next = new ListNode(values[i]);
            current = current.next;
        }

        return head;
    }

    // Helper: Print linked list
    static void PrintList(ListNode head)
    {
        if (head == null)
        {
            Console.WriteLine("[]");
            return;
        }

        Console.Write("[");
        ListNode current = head;
        while (current != null)
        {
            Console.Write(current.val);
            if (current.next != null) Console.Write(",");
            current = current.next;
        }
        Console.WriteLine("]");
    }
}

// Definition for singly-linked list.
public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
}

public class Solution {
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        ListNode dummy = new ListNode(0);
        ListNode current = dummy;
        while(list1 != null && list2 != null)
        {
            if(list1.val <= list2.val)
            {
                //Attach list1's node
                current.next = list1;
                list1 = list1.next;
            }
            else
            {
                //Attach list2's node
                current.next = list2;
                list2 = list2.next;
            }

            // Move current forward                                                                                                                    
            current = current.next;   
        }

        // Attach remaining nodes (one list is empty)                                                                                                  
        if (list1 != null) {                                                                                                                           
            current.next = list1;                                                                                                                      
        } else {                                                                                                                                       
            current.next = list2;                                                                                                                      
        }                                                                                                                                              
                                                                                                                                                        
        // Return head (skip dummy node)                                                                                                               
        return dummy.next;      
    }
}