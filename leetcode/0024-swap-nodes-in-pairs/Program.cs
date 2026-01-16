using Microsoft.Win32;

namespace _0024_swap_nodes_in_pairs;

class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();

        // Test Case 1: head = [1,2,3,4]
        Console.WriteLine("Test Case 1:");
        ListNode list1 = CreateList(new int[] { 1, 2, 3, 4 });
        Console.Write("Input:  ");
        PrintList(list1);
        ListNode result1 = solution.SwapPairs(list1);
        Console.Write("Output: ");
        PrintList(result1);
        Console.WriteLine("Expected: [2,1,4,3]\n");

        // Test Case 2: head = []
        Console.WriteLine("Test Case 2:");
        ListNode list2 = CreateList(new int[] { });
        Console.Write("Input:  ");
        PrintList(list2);
        ListNode result2 = solution.SwapPairs(list2);
        Console.Write("Output: ");
        PrintList(result2);
        Console.WriteLine("Expected: []\n");

        // Test Case 3: head = [1]
        Console.WriteLine("Test Case 3:");
        ListNode list3 = CreateList(new int[] { 1 });
        Console.Write("Input:  ");
        PrintList(list3);
        ListNode result3 = solution.SwapPairs(list3);
        Console.Write("Output: ");
        PrintList(result3);
        Console.WriteLine("Expected: [1]\n");

        // Test Case 4: head = [1,2,3,4,5]
        Console.WriteLine("Test Case 4:");
        ListNode list4 = CreateList(new int[] { 1, 2, 3, 4, 5 });
        Console.Write("Input:  ");
        PrintList(list4);
        ListNode result4 = solution.SwapPairs(list4);
        Console.Write("Output: ");
        PrintList(result4);
        Console.WriteLine("Expected: [2,1,4,3,5]\n");

        // Test Case 5: head = [1,2]
        Console.WriteLine("Test Case 5:");
        ListNode list5 = CreateList(new int[] { 1, 2 });
        Console.Write("Input:  ");
        PrintList(list5);
        ListNode result5 = solution.SwapPairs(list5);
        Console.Write("Output: ");
        PrintList(result5);
        Console.WriteLine("Expected: [2,1]\n");
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

public class Solution
{
    public ListNode SwapPairs(ListNode head)
    {
        ListNode dummy = new ListNode(0);
        dummy.next = head;
        ListNode prev = dummy;

        while(prev.next != null && prev.next.next != null)
        {
            // Identify pair
            ListNode first = prev.next;
            ListNode second = prev.next.next;

            // Swap pair
            first.next = second.next; // 1 -> 3
            second.next = first;      // 2 -> 1
            prev.next = second;       // dummy/prev -> 2

            // Move prev to first (now after swap)
            prev = first;
        }
        
        return dummy.next;
    }
}
