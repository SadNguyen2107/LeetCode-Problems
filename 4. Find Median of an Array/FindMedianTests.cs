using LeetCode;

namespace LeetCodeTests
{
    [TestClass]
    public class FindMedianTests
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
            int[] arr = { 12, 3, 6, 7, 4 };

            const double expected = 6;
            double actual = _solution.FindMedian(arr);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int[] arr = { 12, 3, 6, 7, 4, 19 };

            const double expected = 6.5;
            double actual = _solution.FindMedian(arr);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            int[] arr = { 42 };

            const double expected = 42;
            double actual = _solution.FindMedian(arr);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod4()
        {
            int[] arr = { 10, 20 };

            const double expected = 15;
            double actual = _solution.FindMedian(arr);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod5()
        {
            int[] arr = { 5, 3, 5, 3, 5 };

            const double expected = 5;
            double actual = _solution.FindMedian(arr);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod6()
        {
            int[] arr = { -5, -10, 0, 5, 10 };

            const double expected = 0;
            double actual = _solution.FindMedian(arr);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod7()
        {
            int[] arr = { 100, 1, 50, 25, 75, 10 };

            const double expected = 37.5;
            double actual = _solution.FindMedian(arr);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod8()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };

            const double expected = 4;
            double actual = _solution.FindMedian(arr);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod9()
        {
            int[] arr = { 7, 6, 5, 4, 3, 2, 1 };

            const double expected = 4;
            double actual = _solution.FindMedian(arr);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod10()
        {
            int[] arr = { 5, 5, 5, 5, 5, 5 };

            const double expected = 5;
            double actual = _solution.FindMedian(arr);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod11()
        {
            int[] arr = { 2, 2, 2, 2, 100, 100, 100 };

            const double expected = 2;
            double actual = _solution.FindMedian(arr);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod12()
        {
            int[] arr = { 100, 1, 99, 2, 98, 3, 97 };

            const double expected = 97;
            double actual = _solution.FindMedian(arr);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod13()
        {
            int[] arr = { -1000, 500, -200, 300, 0, 700, -50 };

            const double expected = 0;
            double actual = _solution.FindMedian(arr);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod14()
        {
            int[] arr = { 9, 1, 8, 2, 7, 3, 6, 4 };

            const double expected = 5;
            double actual = _solution.FindMedian(arr);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod15()
        {
            var rand = new Random(123);

            for (int t = 0; t < 1_000; t++)
            {
                int size = rand.Next(1, 50);
                int[] arr = Enumerable.Range(0, size)
                    .Select(_ => rand.Next(-1000, 1000))
                    .ToArray();

                int[] sorted = arr.OrderBy(x => x).ToArray();
                double expected = size % 2 == 1
                    ? sorted[size / 2]
                    : (sorted[size / 2 - 1] + sorted[size / 2]) / 2.0;

                double actual = _solution.FindMedian(arr);

                Assert.AreEqual(expected, actual);
            }
        }

    }
}
