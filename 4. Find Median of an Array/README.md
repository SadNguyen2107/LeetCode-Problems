# 4. Find Median of an Array

Given an array **arr[]**, the task is to find the median of this array. The median of an array of size n is defined as the middle element when n is odd and the average of the middle two elements when n is even.

## Examples

**Input:** arr[] = [12, 3, 5, 7, 4, 19, 26]  
**Output:** 7  
**Explanation:** Sorted sequence of given array arr[] = [3, 4, 5, 7, 12, 19, 26]. Since the number of elements is odd, the median is 4th element in the sorted sequence of given array arr[], which is 7

**Input:** arr[] = [12, 3, 5, 7, 4, 26]  
**Output:** 6  
**Explanation:** Since number of elements are even, median is average of 3rd and 4th element in sorted sequence of given array arr[], which means (5 + 7)/2 = 6

## Solution Approach

This solution uses the **QuickSelect algorithm** to find the median efficiently without fully sorting the array.

### Algorithm: QuickSelect

QuickSelect is a selection algorithm to find the k-th smallest element in an unordered list. It's related to QuickSort but only recurses into one partition instead of both, giving it an average time complexity of **O(n)** instead of O(n log n).

### Time Complexity
- **Average Case**: O(n)
- **Worst Case**: O(n²) - rare with random pivot selection
- **Space Complexity**: O(log n) for recursion stack + O(n) for caching optimization

### How It Works

1. **Clone the input array** to avoid modifying the original
2. **Determine odd or even length**:
   - **Odd**: Find the single middle element at index `n/2`
   - **Even**: Find two middle elements at indices `n/2 - 1` and `n/2`, then average them

3. **QuickSelect Process**:
   - Choose a random pivot and partition the array
   - Elements less than pivot go to the left, greater go to the right
   - The pivot ends up at its final sorted position
   - Recursively search only the partition containing our target index

4. **Caching Optimization** (for even-length arrays):
   - Store pivot positions found during the first QuickSelect
   - If the second QuickSelect needs an already-found position, return it immediately
   - This can save an entire recursive call when lucky

### Key Implementation Details

**Overflow Prevention**:
```csharp
median = leftMid / 2.0 + rightMid / 2.0;
```
Instead of `(leftMid + rightMid) / 2.0` to avoid integer overflow with large values.

**Random Pivot Selection**:
```csharp
int randomPivotIndex = _random.Next(left, right + 1);
```
Randomization helps avoid worst-case O(n²) performance on already-sorted or special-case inputs.

**Span<int> Usage**:
The `Span<int>` parameter allows efficient array slicing without copying data, improving performance.

### Example Walkthrough

**Input**: `[12, 3, 5, 7, 4, 19, 26]` (odd length = 7)
- Target: Find element at index 3 (0-indexed middle)
- Pick random pivot, say 7
- Partition: `[3, 5, 4] | 7 | [12, 19, 26]`
- Pivot lands at index 3 ✓
- Return 7

**Input**: `[12, 3, 5, 7, 4, 26]` (even length = 6)
- Target: Find elements at indices 2 and 3
- First QuickSelect finds element at index 2 → 5
- During partitioning, we might cache positions like index 3
- Second QuickSelect checks cache first, might find index 3 → 7
- Return `(5 + 7) / 2 = 6`

### Why QuickSelect Over Sorting?

- **Sorting** (Array.Sort): O(n log n) - finds ALL positions
- **QuickSelect**: O(n) average - finds only the position(s) we need
- For finding median, we only need 1-2 specific positions, making QuickSelect more efficient
