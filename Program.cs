namespace Assignment_12._1._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
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
    }

    public class ListNode
    {
        public int val { get; set; }
        public ListNode? next { get; set; } = null;
    }
}
