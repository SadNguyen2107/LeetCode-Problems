# 3. Longest Substring Without Repeating Characters

Given a string `s`, find the length of the **longest substring** without repeating characters.

A **substring** is a contiguous sequence of characters within the string.

---

## Examples

**Example 1:**

```
Input:  s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with length 3.
```

**Example 2:**

```
Input:  s = "bbbbb"
Output: 1
Explanation: The answer is "b", with length 1.
```

**Example 3:**

```
Input:  s = "pwwkew"
Output: 3
Explanation: The answer is "wke".
Note: "pwke" is a subsequence, not a substring.
```

---

## Constraints

* `0 <= s.length <= 5 * 10^4`
* `s` consists of English letters, digits, symbols, and spaces

---

## Solution Approach (Sliding Window)

This problem is solved efficiently using the **sliding window** technique combined with a **hash map (dictionary)**.

### Core Idea

* Maintain a window `[left, right]` that always contains **unique characters**
* Expand the window by moving `right`
* If a duplicate character is found, move `left` forward to remove the duplicate
* Track the maximum window size seen so far

---

## C# Implementation

```csharp
namespace LeetCode
{
    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            int longestLength = 0;
            Dictionary<char, int> dict = new Dictionary<char, int>();

            int left = 0;
            for (int right = 0; right < s.Length; right++)
            {
                char c = s[right];

                if (dict.TryGetValue(c, out int i))
                {
                    left = Math.Max(left, i + 1);

                    // Early exit optimization
                    if (longestLength >= s.Length - left)
                        break;
                }

                dict[c] = right;
                longestLength = Math.Max(longestLength, right - left + 1);
            }
            return longestLength;
        }
    }
}
```

---

## Step-by-Step Explanation

1. If the string is empty, return `0`

2. Use a dictionary to store:

   * **Key**   → character
   * **Value** → most recent index of that character

3. Initialize two pointers:

   * `left`  → start of the sliding window
   * `right` → end of the sliding window

---

### Handling Each Character

* Read the character at position `right`
* If it already exists in the dictionary:

  * Move `left` to `max(left, lastIndex + 1)`
  * This guarantees no duplicates in the window

```csharp
left = Math.Max(left, i + 1);
```

This prevents `left` from ever moving backwards.

---

### Updating the Window

* Store/update the character’s latest index
* Compute the current window size:

```csharp
right - left + 1
```

* Update the maximum length found so far

---

## Early Exit Optimization

```csharp
if (longestLength >= s.Length - left)
    break;
```

* If the remaining characters cannot produce a longer substring
* We exit early to save time

This is an **optional micro-optimization**, not required for correctness.

---

## Complexity Analysis

* **Time Complexity:** `O(n)`

  * Each character is visited at most twice

* **Space Complexity:** `O(min(n, charset))`

  * Dictionary stores at most one entry per character

---

## Why Sliding Window Works Well Here

* Avoids checking all substrings (`O(n^2)`)
* Maintains validity incrementally
* Ideal for problems involving **contiguous ranges**

---

✅ This solution efficiently handles large inputs and meets all constraints.
