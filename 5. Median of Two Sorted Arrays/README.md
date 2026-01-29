# 5. Median of Two Sorted Arrays

## Problem Description

Given two sorted arrays `nums1` and `nums2` of size `m` and `n` respectively, return **the median** of the two sorted arrays.

The overall run time complexity should be `O(log (m+n))`.

---

## Examples

### Example 1:
```
Input: nums1 = [1,3], nums2 = [2]
Output: 2.00000
Explanation: merged array = [1,2,3] and median is 2.
```

### Example 2:
```
Input: nums1 = [1,2], nums2 = [3,4]
Output: 2.50000
Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.
```

---

## Constraints

- `nums1.length == m`
- `nums2.length == n`
- `0 <= m <= 1000`
- `0 <= n <= 1000`
- `1 <= m + n <= 2000`
- `-10^6 <= nums1[i], nums2[i] <= 10^6`

---

## Solution Approach

### Algorithm: Binary Search on Partitions

Instead of merging the arrays (which would be O(m+n)), we use binary search to find the correct partition point that divides both arrays such that:
1. All elements on the left side are smaller than all elements on the right side
2. The left and right sides have equal elements (or left has one extra for odd total length)

### Key Insight

If we partition both arrays correctly:
```
smallerArr:  [... maxLeftX | minRightX ...]
biggerArr:   [... maxLeftY | minRightY ...]
```

The median is either:
- **Odd total length**: The maximum of the left side
- **Even total length**: Average of max(left side) and min(right side)

---

## Code Explanation

```csharp
namespace LeetCode
{
    public class MedianOfTwoSortedArraysSolution
    {
        // Enum to specify which side of the partition we want
        enum Direction
        {
            Left,   // Get element on left side of partition
            Right,  // Get element on right side of partition
        }

        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            double median = double.NaN;
            int n1 = nums1.Length;
            int n2 = nums2.Length;

            // STEP 1: Ensure we binary search on the smaller array
            // This optimizes the search to O(log(min(m,n)))
            int[] smallerArr = n1 <= n2 ? nums1 : nums2;
            int[] biggerArr = n1 <= n2 ? nums2 : nums1;

            // STEP 2: Handle edge case where one array is empty
            if (smallerArr.Length == 0)
                return GetMedian(biggerArr);

            int totalLength = n1 + n2;
            bool isOdd = totalLength % 2 == 1;

            // STEP 3: Initialize binary search bounds on the smaller array
            // We search for the correct partition position (0 to length inclusive)
            int leftX = 0;
            int rightX = smallerArr.Length;

            while (leftX <= rightX)
            {
                // STEP 4: Calculate partition positions
                // partitionX: position in smaller array
                int partitionX = leftX + (rightX - leftX) / 2;
                
                // partitionY: corresponding position in bigger array
                // Formula ensures left half has (total+1)/2 elements
                int partitionY = (smallerArr.Length + biggerArr.Length + 1) / 2 - partitionX;

                // STEP 5: Get the boundary values around partitions
                // maxLeftX: largest element on left side of partition in smallerArr
                // minRightX: smallest element on right side of partition in smallerArr
                // maxLeftY: largest element on left side of partition in biggerArr
                // minRightY: smallest element on right side of partition in biggerArr
                int maxLeftX = GetPartitionBoundaryValue(smallerArr, partitionX, Direction.Left);
                int minRightX = GetPartitionBoundaryValue(smallerArr, partitionX, Direction.Right);
                int maxLeftY = GetPartitionBoundaryValue(biggerArr, partitionY, Direction.Left);
                int minRightY = GetPartitionBoundaryValue(biggerArr, partitionY, Direction.Right);

                // STEP 6: Check if partition is valid
                // Valid partition: all left elements <= all right elements
                if (maxLeftX > minRightY)
                {
                    // partitionX is too far right, move it left
                    rightX = partitionX - 1;
                }
                else if (maxLeftY > minRightX)
                {
                    // partitionX is too far left, move it right
                    leftX = partitionX + 1;
                }
                else
                {
                    // STEP 7: Found the correct partition!
                    // Calculate median from the boundary values
                    int maxLeft = Math.Max(maxLeftX, maxLeftY);
                    int minRight = Math.Min(minRightX, minRightY);
                    median = CalculateMedianFromPartitions(isOdd, maxLeft, minRight);
                    break;
                }
            }

            return median;
        }

        /// <summary>
        /// Calculates the median based on the partition boundary values
        /// </summary>
        /// <param name="isOdd">Whether total length is odd</param>
        /// <param name="maxLeft">Maximum value on the left side of partition</param>
        /// <param name="minRight">Minimum value on the right side of partition</param>
        /// <returns>The median value</returns>
        private double CalculateMedianFromPartitions(bool isOdd, int maxLeft, int minRight)
        {
            if (isOdd)
                // For odd length, median is the max of left side
                return maxLeft;
            else
                // For even length, median is average of max(left) and min(right)
                // Divide each by 2.0 first to avoid integer overflow
                return maxLeft / 2.0 + minRight / 2.0;
        }

        /// <summary>
        /// Gets the boundary element at a partition point
        /// Handles edge cases when partition is at array boundaries
        /// </summary>
        /// <param name="arr">The array to get boundary from</param>
        /// <param name="partitionPoint">The partition index (0 to arr.Length inclusive)</param>
        /// <param name="dir">Whether to get left or right boundary</param>
        /// <returns>
        /// - Left: Element just before partition (or int.MinValue if at start)
        /// - Right: Element at partition (or int.MaxValue if at end)
        /// </returns>
        private int GetPartitionBoundaryValue(int[] arr, int partitionPoint, Direction dir)
        {
            bool isAtStart = partitionPoint == 0;
            bool isAtEnd = partitionPoint == arr.Length;

            return dir switch
            {
                // Left boundary: element before the partition
                Direction.Left when isAtStart => int.MinValue,  // No elements on left
                Direction.Left => arr[partitionPoint - 1],

                // Right boundary: element at the partition
                Direction.Right when isAtEnd => int.MaxValue,   // No elements on right
                Direction.Right => arr[partitionPoint],

                _ => throw new ArgumentException("Invalid direction"),
            };
        }

        /// <summary>
        /// Helper method to find median of a single sorted array
        /// Used when one of the input arrays is empty
        /// </summary>
        private double GetMedian(int[] arr)
        {
            int n = arr.Length;
            
            if (n % 2 == 1)
                // Odd length: return middle element
                return arr[n / 2];
            else
            {
                // Even length: return average of two middle elements
                int leftMid = arr[n / 2 - 1];
                int rightMid = arr[n / 2];
                return leftMid / 2.0 + rightMid / 2.0;
            }
        }
    }
}
```

---

## Algorithm Walkthrough

### Example: `nums1 = [1,3]`, `nums2 = [2]`

1. **Setup**: smallerArr = [1,3], biggerArr = [2], total = 3 (odd)
2. **Binary Search**: leftX = 0, rightX = 2
3. **Iteration 1**:
   - partitionX = 1 → left: [1], right: [3]
   - partitionY = 1 → left: [2], right: []
   - maxLeftX = 1, minRightX = 3
   - maxLeftY = 2, minRightY = ∞
   - Check: 1 ≤ ∞ ✓ and 2 ≤ 3 ✓ → Valid partition!
   - Median = max(1, 2) = **2.0**

### Example: `nums1 = [1,2]`, `nums2 = [3,4]`

1. **Setup**: smallerArr = [1,2], biggerArr = [3,4], total = 4 (even)
2. **Binary Search**: leftX = 0, rightX = 2
3. **Iteration 1**:
   - partitionX = 1 → left: [1], right: [2]
   - partitionY = 1 → left: [3], right: [4]
   - maxLeftX = 1, minRightX = 2
   - maxLeftY = 3, minRightY = 4
   - Check: 1 ≤ 4 ✓ but 3 > 2 ✗ → Move partitionX right
4. **Iteration 2**:
   - partitionX = 2 → left: [1,2], right: []
   - partitionY = 0 → left: [], right: [3,4]
   - maxLeftX = 2, minRightX = ∞
   - maxLeftY = -∞, minRightY = 3
   - Check: 2 ≤ 3 ✓ and -∞ ≤ ∞ ✓ → Valid partition!
   - Median = (max(2, -∞) + min(∞, 3)) / 2 = (2 + 3) / 2 = **2.5**

---

## Complexity Analysis

- **Time Complexity**: `O(log(min(m, n)))`
  - Binary search on the smaller array
  
- **Space Complexity**: `O(1)`
  - Only using constant extra space for variables

---

## Key Takeaways

1. **Binary search on partitions** rather than merging arrays
2. **Always search on the smaller array** for optimization
3. **Use int.MinValue/MaxValue** to handle edge cases elegantly
4. **The partition divides arrays** such that left side ≤ right side
5. **Median comes from boundary values** at the correct partition
