using Algorithm.Lib;

namespace Algorithm.Test
{
    [TestClass]
    public class InsertionSortTest
    {
        private BaseSortTest<InsertionSort<int>> _testor = new BaseSortTest<InsertionSort<int>>();
        private InsertionSort<int> _sorter = new InsertionSort<int>();

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