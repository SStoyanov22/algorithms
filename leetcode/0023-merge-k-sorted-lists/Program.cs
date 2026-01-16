namespace _0023_merge_k_sorted_lists;

class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();

        // Test Case 1: lists = [[1,4,5],[1,3,4],[2,6]]
        Console.WriteLine("Test Case 1:");
        ListNode[] lists1 = {
            CreateList(new int[] { 1, 4, 5 }),
            CreateList(new int[] { 1, 3, 4 }),
            CreateList(new int[] { 2, 6 })
        };
        Console.WriteLine("Input lists:");
        for (int i = 0; i < lists1.Length; i++)
        {
            Console.Write($"  List {i + 1}: ");
            PrintList(lists1[i]);
        }
        ListNode result1 = solution.MergeKLists(lists1);
        Console.Write("Merged: ");
        PrintList(result1);
        Console.WriteLine("Expected: [1,1,2,3,4,4,5,6]\n");

        // Test Case 2: lists = []
        Console.WriteLine("Test Case 2:");
        ListNode[] lists2 = { };
        Console.WriteLine("Input lists: []");
        ListNode result2 = solution.MergeKLists(lists2);
        Console.Write("Merged: ");
        PrintList(result2);
        Console.WriteLine("Expected: []\n");

        // Test Case 3: lists = [[]]
        Console.WriteLine("Test Case 3:");
        ListNode[] lists3 = { CreateList(new int[] { }) };
        Console.WriteLine("Input lists: [[]]");
        ListNode result3 = solution.MergeKLists(lists3);
        Console.Write("Merged: ");
        PrintList(result3);
        Console.WriteLine("Expected: []\n");

        // Test Case 4: lists = [[1],[2],[3]]
        Console.WriteLine("Test Case 4:");
        ListNode[] lists4 = {
            CreateList(new int[] { 1 }),
            CreateList(new int[] { 2 }),
            CreateList(new int[] { 3 })
        };
        Console.WriteLine("Input lists:");
        for (int i = 0; i < lists4.Length; i++)
        {
            Console.Write($"  List {i + 1}: ");
            PrintList(lists4[i]);
        }
        ListNode result4 = solution.MergeKLists(lists4);
        Console.Write("Merged: ");
        PrintList(result4);
        Console.WriteLine("Expected: [1,2,3]\n");

        // Test Case 5: lists = [[-2,-1,-1,-1],[]]
        Console.WriteLine("Test Case 5:");
        ListNode[] lists5 = {
            CreateList(new int[] { -2, -1, -1, -1 }),
            CreateList(new int[] { })
        };
        Console.WriteLine("Input lists:");
        for (int i = 0; i < lists5.Length; i++)
        {
            Console.Write($"  List {i + 1}: ");
            PrintList(lists5[i]);
        }
        ListNode result5 = solution.MergeKLists(lists5);
        Console.Write("Merged: ");
        PrintList(result5);
        Console.WriteLine("Expected: [-2,-1,-1,-1]\n");
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
    public ListNode MergeKLists(ListNode[] lists)
    {
        // TODO: Implement the solution
        if(lists == null || lists.Length == 0 )
            return null;
        
        // Devide and conquer: repeatedly merge pairs of lists
        // until only one list remains
        while (lists.Length > 1)
        {
            List<ListNode> mergedLists = new List<ListNode>();

            // Merge adjacent lists
            for(int i = 0; i < lists.Length; i += 2)
            {
                ListNode list1 = lists[i];
                ListNode list2 = (i + 1 < lists.Length) ? lists[i + 1] : null;

                // Merge the pair and add to next round
                mergedLists.Add(MergeTwoLists(list1, list2));
            }
            
            //Update lists array for next round
            lists = mergedLists.ToArray();
        }

        return lists[0];
    }

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
