using LeetCode;

namespace LeetCodeTests
{
    [TestClass]
    public class AddTwoNumberTests
    {
        private Solution _solution;

        [TestInitialize]
        public void Init()
        {
            _solution = new Solution();
        }

        private ListNode? CreateLinkedList(params int[] vals)
        {
            if (vals.Length == 0) return null;

            ListNode result = new ListNode(vals[0]);
            ListNode node = result;
            for (int i = 1; i < vals.Length; i++)
            {
                ListNode nextNode = new ListNode(vals[i]);
                node.next = nextNode;
                node = node.next;
            }

            return result;
        }

        private void CheckTwoLinkedListSame(ListNode expected, ListNode actual)
        {
            ListNode expectedCurrentNode = expected;
            ListNode actualCurrentNode = actual;
            while (expectedCurrentNode != null && actualCurrentNode != null)
            {
                // 2 Node must be equal in val
                Assert.AreEqual(expectedCurrentNode.val, actualCurrentNode.val);

                // Move to the next node
                expectedCurrentNode = expectedCurrentNode.next;
                actualCurrentNode = actualCurrentNode.next;
            }

            // If there is still node left on the expected
            // The actual is shorter
            if (expectedCurrentNode != null)
            {
                Assert.AreEqual(expectedCurrentNode, actualCurrentNode);
            }

            // If there is still node on the actual linked list
            // But on the expected there is none
            if (actualCurrentNode != null)
            {
                Assert.AreEqual(null, actualCurrentNode);
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            // 1st Linked List
            ListNode? l1 = CreateLinkedList(2, 4, 3);

            // 2nd Linked List
            ListNode? l2 = CreateLinkedList(5, 6, 4);

            // Expected Result
            ListNode? expectedResult = CreateLinkedList(7, 0, 8);

            ListNode result = _solution.AddTwoNumbers(l1, l2);
            CheckTwoLinkedListSame(expectedResult, result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            // 1st Linked List
            ListNode? l1 = CreateLinkedList(0);

            // 2nd Linked List
            ListNode? l2 = CreateLinkedList(0);

            // Expected Result
            ListNode? expectedResult = CreateLinkedList(0);

            ListNode result = _solution.AddTwoNumbers(l1, l2);
            CheckTwoLinkedListSame(expectedResult, result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            // 1st Linked List
            ListNode? l1 = CreateLinkedList(9, 9, 9, 9, 9, 9, 9);

            // 2nd Linked List
            ListNode? l2 = CreateLinkedList(9, 9, 9, 9);

            // Expected Result
            ListNode? expectedResult = CreateLinkedList(8, 9, 9, 9, 0, 0, 0, 1);

            ListNode result = _solution.AddTwoNumbers(l1, l2);
            CheckTwoLinkedListSame(expectedResult, result);
        }
    }
}
