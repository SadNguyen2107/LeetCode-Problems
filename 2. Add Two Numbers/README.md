# 2. Add Two Numbers

You are given two **non-empty linked lists** representing two non-negative integers. The digits are stored in **reverse order**, and each node contains a single digit.

Add the two numbers and return the sum as a linked list.

You may assume the two numbers do not contain any leading zero, except the number `0` itself.

---

## Examples

**Example 1:**

<img alt="" src="https://assets.leetcode.com/uploads/2020/10/02/addtwonumber1.jpg" style="width: 483px; height: 342px;">

```
Input:  l1 = [2,4,3], l2 = [5,6,4]
Output: [7,0,8]
Explanation: 342 + 465 = 807
```

**Example 2:**

```
Input:  l1 = [0], l2 = [0]
Output: [0]
```

**Example 3:**

```
Input:  l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
Output: [8,9,9,9,0,0,0,1]
```

---

## Linked List Node Definition

```csharp
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
```

### Explanation

* `val` stores a **single digit (0–9)**
* `next` points to the next node in the linked list
* The digits are stored in **reverse order** (ones place first)
* `ToString()` helps with debugging by printing the current value and next value

---

## Solution Approach

We simulate **manual addition** (like elementary math), digit by digit, while keeping track of a **carry**.

### Key Ideas

* Traverse both linked lists simultaneously
* Add corresponding digits plus a carry
* Store the result digit in a new linked list
* Continue until both lists are exhausted **and** there is no carry left

---

## C# Implementation

```csharp
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
            int currentL1Val = currentL1?.val ?? 0;
            int currentL2Val = currentL2?.val ?? 0;

            int sum = currentL1Val + currentL2Val + carry;
            carry = sum / 10;

            current.next = new ListNode(sum % 10);
            current = current.next;

            currentL1 = currentL1?.next;
            currentL2 = currentL2?.next;
        }

        return dummy.next;
    }
}
```

---

## Step-by-Step Explanation

1. Create a **dummy head node** to simplify list construction
2. Use `current` to build the result list
3. Use two pointers `currentL1` and `currentL2` to traverse both input lists
4. Initialize `carry = 0`

### Inside the Loop

* Continue while:

  * `l1` still has nodes, **or**
  * `l2` still has nodes, **or**
  * there is a remaining `carry`

* Safely get values using null-coalescing:

  ```csharp
  int currentL1Val = currentL1?.val ?? 0;
  int currentL2Val = currentL2?.val ?? 0;
  ```

* Add digits and carry:

  ```csharp
  int sum = currentL1Val + currentL2Val + carry;
  ```

* Update carry and digit:

  ```csharp
  carry = sum / 10;
  sum % 10
  ```

* Append the digit to the result list

* Move pointers forward

---

## Complexity Analysis

* **Time Complexity:** `O(max(n, m))`

  * `n` and `m` are the lengths of the two lists

* **Space Complexity:** `O(max(n, m))`

  * New linked list is created for the result

---

## Why Use a Dummy Node?

* Avoids special handling for the head node
* Makes list construction clean and safe
* Common best practice in linked list problems

---

✅ This solution correctly handles different list lengths and carry propagation.
