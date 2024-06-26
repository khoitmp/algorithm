namespace Algorithm.Test;

[TestClass]
public class SelectionSortTest
{
    private BaseSortTest<SelectionSort<int>> _testor = new BaseSortTest<SelectionSort<int>>();
    private SelectionSort<int> _sorter = new SelectionSort<int>();

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