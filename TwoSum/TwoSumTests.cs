using LeetCode;

namespace LeetCodeTests
{
    [TestClass]
    public sealed class TwoSumTests
    {
        private Solution twoSum;

        [TestInitialize]
        public void Init()
        {
            twoSum = new Solution();
        }

        [TestMethod]
        public void Test1()
        {
            int[] nums = { 2, 7, 11, 15 };
            int target = 9;

            int[] expectedResult = { 0, 1 };
            int[] result = twoSum.TwoSum(nums, target);
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Test2()
        {
            int[] nums = { 3, 2, 4 };
            int target = 6;

            int[] expectedResult = { 1, 2 };
            int[] result = twoSum.TwoSum(nums, target);
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Test3()
        {
            int[] nums = { 3, 3 };
            int target = 6;

            int[] expectedResult = { 0, 1 };
            int[] result = twoSum.TwoSum(nums, target);
            CollectionAssert.AreEqual(expectedResult, result);
        }
    }
}
