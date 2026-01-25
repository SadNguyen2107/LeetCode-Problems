# 1. Two Sum

Given an array of integers `nums` and an integer `target`, return *indices of the two numbers such that they add up to `target`*.

You may assume that each input would have **exactly one solution**, and you may not use the *same* element twice.

You can return the answer in any order.

---

## Examples

**Example 1:**

```
Input: nums = [2,7,11,15], target = 9
Output: [0,1]
Explanation: nums[0] + nums[1] == 9
```

**Example 2:**

```
Input: nums = [3,2,4], target = 6
Output: [1,2]
```

**Example 3:**

```
Input: nums = [3,3], target = 6
Output: [0,1]
```

---

## Constraints

* `2 <= nums.length <= 10^4`
* `-10^9 <= nums[i] <= 10^9`
* `-10^9 <= target <= 10^9`
* **Only one valid answer exists**

---

## Solution Approach (Hash Map / Dictionary)

To solve this problem efficiently, we use a **Dictionary** (hash map) to store numbers we have already seen along with their indices.

### Key Idea

For each number `nums[i]`, we calculate its **complement**:

```
complement = target - nums[i]
```

If this complement already exists in the dictionary, we have found two numbers that add up to `target`.

---

## C# Implementation

```csharp
namespace LeetCode
{
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];

                // If the complement already exists,
                // we found the two indices
                if (map.ContainsKey(complement))
                {
                    return new int[] { map[complement], i };
                }

                // Store the current number with its index
                map[nums[i]] = i;
            }

            // Problem guarantees one solution, so this line is unreachable
            return new int[0];
        }
    }
}
```

---

## Step-by-Step Explanation

1. Create an empty dictionary `map` where:

   * **Key**   → number value
   * **Value** → index of that number

2. Loop through the array using index `i`.

3. For each number:

   * Compute `complement = target - nums[i]`
   * Check if `complement` already exists in the dictionary

4. If it exists:

   * We have found the solution
   * Return the stored index and the current index `i`

5. If it does not exist:

   * Add the current number and its index to the dictionary

6. Continue until the solution is found.

---

## Complexity Analysis

* **Time Complexity:** `O(n)`

  * Each element is processed once
  * Dictionary lookups are `O(1)` on average

* **Space Complexity:** `O(n)`

  * Extra space used to store the dictionary

---

## Why This Is Better Than Brute Force

* Brute force checks all pairs → `O(n^2)`
* Hash map approach finds the answer in **one pass**
* Much faster and scalable for large inputs

---

✅ This solution satisfies the follow-up requirement of being **faster than O(n²)**.
