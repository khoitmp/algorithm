using System;
using Algorithm.Lib;

namespace Algorithm.Test
{
    [TestClass]
    public class SortedListTest
    {
        [TestMethod]
        public void InitalizeEmptyTest()
        {
            var items = new SortedList<int>();

            Assert.AreEqual(0, items.Count);
        }

        [TestMethod]
        public void AddTest()
        {
            var items = new SortedList<int>();

            for (int i = 1; i <= 5; i++)
            {
                items.Add(i);
                Assert.AreEqual(i, items.Count);
            }

            int expected = 1;
            foreach (int i in items)
            {
                Assert.AreEqual(expected++, i);
            }
        }

        [TestMethod]
        public void RemoveTest()
        {
            var remove1to10 = InitItems(1, 10);

            Assert.AreEqual(10, remove1to10.Count);

            for (int i = 1; i <= 10; i++)
            {
                Assert.IsTrue(remove1to10.Remove(i));
                Assert.IsFalse(remove1to10.Remove(i));
            }

            Assert.AreEqual(0, remove1to10.Count);

            var remove10to1 = InitItems(1, 10);
            Assert.AreEqual(10, remove10to1.Count);

            for (int i = 10; i >= 1; i--)
            {
                Assert.IsTrue(remove10to1.Remove(i));
                Assert.IsFalse(remove10to1.Remove(i));
            }

            Assert.AreEqual(0, remove10to1.Count);
        }

        [TestMethod]
        public void ContainsTest()
        {
            var items = InitItems(1, 10);

            for (int i = 1; i <= 10; i++)
            {
                Assert.IsTrue(items.Contains(i));
            }

            Assert.IsFalse(items.Contains(0));
            Assert.IsFalse(items.Contains(11));
        }

        [TestMethod]
        public void ReverseIteratorTest()
        {
            var items = InitItems(1, 10);

            int expected = 10;
            foreach (int i in items.GetReverseEnumerator())
            {
                Assert.AreEqual(expected--, i);
            }
        }

        [TestMethod]
        public void RandomIsSortedTest()
        {
            var randoms = new SortedList<int>();
            Random rng = new Random();

            for (int i = 0; i < 100; i++)
            {
                randoms.Add(rng.Next());
            }

            Assert.AreEqual(100, randoms.Count, "There should be 100");

            int prev = int.MinValue;
            foreach (int r in randoms)
            {
                Assert.IsTrue(prev <= r, "Sort order is wrong");
            }
        }

        private SortedList<int> InitItems(int start, int end)
        {
            var items = new SortedList<int>();
            for (int i = start; i <= end; i++)
            {
                items.Add(i);
            }
            return items;
        }
    }
}