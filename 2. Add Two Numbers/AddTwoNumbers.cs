namespace LeetCode
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

        public override string ToString()
        {
            return $"Value: {val} || Next: {next?.val}";
        }
    }

    public class Solution
    {

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode dummy = new ListNode();
            ListNode current = dummy;

            ListNode? currentL1 = l1;
            ListNode? currentL2 = l2;

            int carry = 0;
            while (currentL1 != null || currentL2 != null || carry == 1)
            {
                // Try to add to each other
                int currentL1Val = currentL1?.val ?? 0;
                int currentL2Val = currentL2?.val ?? 0;

                int sum = currentL1Val + currentL2Val + carry;
                carry = sum / 10;

                current.next = new ListNode(sum % 10);
                current = current.next;

                // Move to the next node
                currentL1 = currentL1?.next;
                currentL2 = currentL2?.next;
            }

            return dummy.next;
        }
    }
}
