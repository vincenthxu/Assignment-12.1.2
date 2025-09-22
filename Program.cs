namespace Assignment_12._1._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int[]> arrays =
            [
                [1,2,2,1],
                [1,2],
                [1],
                [],
                [1,3,2,1],
                [1,2,1]
            ];

            var testCases = arrays.Select(array => CreateLinkedList(array));

            foreach (var head in testCases)
            {
                PrintLinkedList(head);
                Console.WriteLine($"IsPalindrome: {IsPalindrome(head)} {IsPalindromeV2(head)}");
            }
        }

        static void PrintLinkedList(ListNode? head)
        {
            ListNode? curr = head;
            Console.Write("[ ");
            while (curr != null)
            {
                Console.Write(curr.val + $"{(curr.next == null ? "" : " => ")}");
                curr = curr.next;
            }
            Console.WriteLine(" ]");
        }

        static ListNode? CreateLinkedList(int[] values)
        {
            if (values.Length == 0) return null;

            ListNode head = new();
            ListNode curr = head;

            int i = 0;
            foreach (int value in values)
            {
                curr.val = value;
                if (i++ < values.Length - 1)
                    curr.next = new();
                curr = curr.next;
            }

            return head;
        }

        static bool IsPalindrome(ListNode head)
        {
            // FIXME: using redundant space
            Stack<int> stack = new();
            Queue<int> queue = new();

            ListNode curr = head;
            while(curr != null)
            {
                stack.Push(curr.val);
                queue.Enqueue(curr.val);
                curr = curr.next;
            }

            while(stack.Count > 0 && queue.Count > 0)
            {
                if(stack.Pop() != queue.Dequeue())
                {
                    return false;
                }
            }

            return true;
        }

        static bool IsPalindromeV2(ListNode head)
        {
            int numElements = 0;
            Stack<int> stack = new();

            ListNode curr = head;
            while(curr != null)
            {
                stack.Push(curr.val);
                curr = curr.next;
                numElements++;
            }

            curr = head;
            for(int count = 0; count < numElements / 2; count++)
            {
                if (stack.Pop() != curr.val) return false;
                curr = curr.next;
            }

            return true;
        }
    }

    public class ListNode
    {
        public int val { get; set; }
        public ListNode? next { get; set; } = null;
    }
}
