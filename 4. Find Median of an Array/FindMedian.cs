namespace LeetCode
{
    public class Solution
    {
        private readonly Random _random = new Random();

        private int?[]? _sortedArr;

        public double FindMedian(int[] arr)
        {
            int[] arrCopy = (int[])arr.Clone();

            double median = double.NaN;
            int n = arrCopy.Length;

            // If the array is odd --> Return the middle element
            if (n % 2 == 1)
            {
                median = QuickSelect(arrCopy, 0, n - 1, n / 2);
            }
            // If the array is even --> Return the average of 2 numbers in the middle
            else
            {
                _sortedArr = new int?[n];
                int leftMid = QuickSelect(arrCopy, 0, n - 1, n / 2 - 1);
                int rightMid = QuickSelect(arrCopy, 0, n - 1, n / 2);
                median = leftMid / 2.0 + rightMid / 2.0;
                _sortedArr = null;
            }
            return median;
        }

        private int QuickSelect(Span<int> arr, int left, int right, int k)
        {
            // Exception:
            if (left == right)
                return arr[left];

            // Try to get that value if it is equal to the k-th element we are looking for
            if (_sortedArr != null && _sortedArr[k].HasValue)
                return _sortedArr[k]!.Value;

            int pivotIndex = RandomPartition(arr, left, right);

            // If the dictionary hasn't contained that key
            // --> Add to the dictionary to later retrieve faster
            if (_sortedArr != null && !_sortedArr[pivotIndex].HasValue)
                _sortedArr[pivotIndex] = arr[pivotIndex];

            if (k == pivotIndex)
                return arr[pivotIndex];
            // Use right part
            else if (k > pivotIndex)
                return QuickSelect(arr, pivotIndex + 1, right, k);
            // Use left part
            else
                return QuickSelect(arr, left, pivotIndex - 1, k);
        }

        private int RandomPartition(Span<int> arr, int left, int right)
        {
            int randomPivotIndex = _random.Next(left, right + 1);
            int pivot = arr[randomPivotIndex];

            // Swap the end with the pivot
            Swap(arr, right, randomPivotIndex);
            int pivotIndex = Partition(arr, left, right, pivot);
            return pivotIndex;
        }

        private int Partition(Span<int> arr, int left, int right, int pivot)
        {
            int storeIndex = left;

            for (int i = left; i < right; i++)
            {
                if (arr[i] < pivot)
                {
                    Swap(arr, storeIndex, i);
                    storeIndex++;
                }
            }

            // Swap the storeIndex with the end of right (pivot)
            Swap(arr, storeIndex, right);
            return storeIndex;
        }

        private void Swap(Span<int> arr, int index1, int index2)
        {
            // No need to swap
            if (index1 == index2) return;

            (arr[index1], arr[index2]) = (arr[index2], arr[index1]);
        }
    }
}
