using Algorithm.Lib;

namespace Algorithm.Test
{
    [TestClass]
    public class QuickSortTest
    {
        private BaseSortTest<QuickSort<int>> _testor = new BaseSortTest<QuickSort<int>>();
        private QuickSort<int> _sorter = new QuickSort<int>();

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

        // [TestMethod]
        // public void Random50kTest()
        // {
        //     _testor.Random(_sorter, 50000);
        // }
    }
}