namespace _0025_reverse_nodes_in_k_group;

class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();

        // Test Case 1: head = [1,2,3,4,5], k = 2
        Console.WriteLine("Test Case 1:");
        ListNode list1 = CreateList(new int[] { 1, 2, 3, 4, 5 });
        Console.Write("Input:  ");
        PrintList(list1);
        Console.WriteLine("k = 2");
        ListNode result1 = solution.ReverseKGroup(list1, 2);
        Console.Write("Output: ");
        PrintList(result1);
        Console.WriteLine("Expected: [2,1,4,3,5]\n");

        // Test Case 2: head = [1,2,3,4,5], k = 3
        Console.WriteLine("Test Case 2:");
        ListNode list2 = CreateList(new int[] { 1, 2, 3, 4, 5 });
        Console.Write("Input:  ");
        PrintList(list2);
        Console.WriteLine("k = 3");
        ListNode result2 = solution.ReverseKGroup(list2, 3);
        Console.Write("Output: ");
        PrintList(result2);
        Console.WriteLine("Expected: [3,2,1,4,5]\n");

        // Test Case 3: head = [1,2,3,4,5], k = 1
        Console.WriteLine("Test Case 3:");
        ListNode list3 = CreateList(new int[] { 1, 2, 3, 4, 5 });
        Console.Write("Input:  ");
        PrintList(list3);
        Console.WriteLine("k = 1");
        ListNode result3 = solution.ReverseKGroup(list3, 1);
        Console.Write("Output: ");
        PrintList(result3);
        Console.WriteLine("Expected: [1,2,3,4,5]\n");

        // Test Case 4: head = [1], k = 1
        Console.WriteLine("Test Case 4:");
        ListNode list4 = CreateList(new int[] { 1 });
        Console.Write("Input:  ");
        PrintList(list4);
        Console.WriteLine("k = 1");
        ListNode result4 = solution.ReverseKGroup(list4, 1);
        Console.Write("Output: ");
        PrintList(result4);
        Console.WriteLine("Expected: [1]\n");

        // Test Case 5: head = [1,2,3,4,5,6,7,8], k = 3
        Console.WriteLine("Test Case 5:");
        ListNode list5 = CreateList(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 });
        Console.Write("Input:  ");
        PrintList(list5);
        Console.WriteLine("k = 3");
        ListNode result5 = solution.ReverseKGroup(list5, 3);
        Console.Write("Output: ");
        PrintList(result5);
        Console.WriteLine("Expected: [3,2,1,6,5,4,7,8]\n");

        // Test Case 6: head = [1,2], k = 2
        Console.WriteLine("Test Case 6:");
        ListNode list6 = CreateList(new int[] { 1, 2 });
        Console.Write("Input:  ");
        PrintList(list6);
        Console.WriteLine("k = 2");
        ListNode result6 = solution.ReverseKGroup(list6, 2);
        Console.Write("Output: ");
        PrintList(result6);
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
    public ListNode ReverseKGroup(ListNode head, int k)
    {
        // TODO: Implement the solution
        // Hint:
        // 1. Count if we have k nodes ahead
        // 2. If yes, reverse those k nodes
        // 3. Connect the reversed group with previous and next parts
        // 4. Repeat for next group
        return head;
    }
}
