using LeetCode;

namespace LeetCodeTests
{
    [TestClass]
    public class LongestSubstringWithoutRepeatingCharactersTests
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
            const string s = "abcabcbb";

            const int expected = 3;
            int actual = _solution.LengthOfLongestSubstring(s);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string s = "bbbbb";

            const int expected = 1;
            int actual = _solution.LengthOfLongestSubstring(s);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string s = "pwwkew";

            const int expected = 3;
            int actual = _solution.LengthOfLongestSubstring(s);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod4()
        {
            const string s = "dvdf";

            const int expected = 3;
            int actual = _solution.LengthOfLongestSubstring(s);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod5()
        {
            const string s = "abba";

            const int expected = 2;
            int actual = _solution.LengthOfLongestSubstring(s);

            Assert.AreEqual(expected, actual);
        }
    }
} 
