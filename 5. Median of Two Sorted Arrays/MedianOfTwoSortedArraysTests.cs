using LeetCode;

namespace LeetCodeTests
{
    [TestClass]
    public class MedianOfTwoSortedArraysTests
    {
        private Solution _solution;

        [TestInitialize]
        public void Init()
        {
            _solution = new Solution();
        }

        [TestMethod]
        public void TestMethod1()
        {
            int[] nums1 = { 1, 3 };
            int[] nums2 = { 2 };

            const double expected = 2;
            double actual = _solution.FindMedianSortedArrays(nums1, nums2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int[] nums1 = { 1, 2 };
            int[] nums2 = { 3, 4 };

            const double expected = 2.5;
            double actual = _solution.FindMedianSortedArrays(nums1, nums2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            int[] nums1 = { 1, 2, 3, 4, 5 };
            int[] nums2 = { 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            const double expected = 9.00000;
            double actual = _solution.FindMedianSortedArrays(nums1, nums2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod4()
        {
            int[] nums1 = { -10, -9, -8 };
            int[] nums2 = { 1, 2 };

            const double expected = -8;
            double actual = _solution.FindMedianSortedArrays(nums1, nums2);
            Assert.AreEqual(expected, actual);
        }
    }
}
