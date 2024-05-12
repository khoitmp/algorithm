using Algorithm.Lib;

namespace Algorithm.Test
{
    [TestClass]
    public class BubbleSortTest
    {
        private BaseSortTest<BubbleSort<int>> _testor = new BaseSortTest<BubbleSort<int>>();
        private BubbleSort<int> _sorter = new BubbleSort<int>();

        [TestMethod]
        public void PreSortedTest()
        {
            _testor.PreSorted(_sorter);
        }

        [TestMethod]
        public void UnsortedTest()
        {
            _testor.Unsorted(_sorter);
        }

        [TestMethod]
        public void RandomTest()
        {
            _testor.Random(_sorter);
        }
    }
}