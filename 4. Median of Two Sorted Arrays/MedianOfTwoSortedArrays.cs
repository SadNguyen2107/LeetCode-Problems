namespace LeetCode
{
    public class Solution
    {
        enum Direction
        {
            Left,
            Right,
        }

        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            double median = double.NaN;

            int n1 = nums1.Length;
            int n2 = nums2.Length;

            // Ensure nums1 is the smaller array
            int[] smallerArr = n1 <= n2 ? nums1 : nums2;
            int[] biggerArr = n1 <= n2 ? nums2 : nums1;

            // Handle edge case
            if (smallerArr.Length == 0)
                return GetMedian(biggerArr);

            int totalLength = n1 + n2;
            bool isOdd = totalLength % 2 == 1;

            // Define the Binary Search Range
            int leftX = 0;
            int rightX = smallerArr.Length;

            while (leftX <= rightX)
            {
                // Get Partition Points
                int partitionX = leftX + (rightX - leftX) / 2;
                int partitionY = (smallerArr.Length + biggerArr.Length + 1) / 2 - partitionX;

                // Get Boundary Elements
                int maxLeftX = GetPartitionBoundaryValue(smallerArr, partitionX, Direction.Left);
                int minRightX = GetPartitionBoundaryValue(smallerArr, partitionX, Direction.Right);
                int maxLeftY = GetPartitionBoundaryValue(biggerArr, partitionY, Direction.Left);
                int minRightY = GetPartitionBoundaryValue(biggerArr, partitionY, Direction.Right);

                // Check if Partition is Correct and Adjust
                if (maxLeftX > minRightY)
                {
                    // Move X to left
                    rightX = partitionX - 1;
                }
                else if (maxLeftY > minRightX)
                {
                    // Move X to right
                    leftX = partitionX + 1;
                }
                else
                {
                    int maxLeft = Math.Max(maxLeftX, maxLeftY);
                    int minRight = Math.Min(minRightX, minRightY);
                    median = CalculateMedianFromPartitions(isOdd, maxLeft, minRight);
                    break;
                }
            }

            return median;
        }

        private double CalculateMedianFromPartitions(bool isOdd, int maxLeft, int minRight)
        {
            if (isOdd)
                return maxLeft;
            else
                return maxLeft / 2.0 + minRight / 2.0;
        }

        private int GetPartitionBoundaryValue(int[] arr, int partitionPoint, Direction dir)
        {
            bool isAtStart = partitionPoint == 0;
            bool isAtEnd = partitionPoint == arr.Length;

            return dir switch
            {
                Direction.Left when isAtStart => int.MinValue,
                Direction.Left => arr[partitionPoint - 1],
                Direction.Right when isAtEnd => int.MaxValue,
                Direction.Right => arr[partitionPoint],
                _ => throw new ArgumentException("Invalid direction"),
            };
        }

        private double GetMedian(int[] arr)
        {
            double median;

            int n = arr.Length;
            if (n % 2 == 1)
                median = arr[n / 2];
            else
            {
                int leftMid = arr[n / 2 - 1];
                int rightMid = arr[n / 2];
                median = leftMid / 2.0 + rightMid / 2.0;
            }

            return median;
        }
    }
}
