namespace Algorithm.Test;

public class BaseSortTest<T>
    where T : SortingMetric<int>
{
    private Random _rng = new Random();

    public void PreSorted(T algorithm)
    {
        TestUtil.DemandSorted(algorithm.Sort(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }));
        TestUtil.DemandSorted(algorithm.Sort(new int[] { 1 }));
        TestUtil.DemandSorted(algorithm.Sort(new int[] { 1, 2 }));
        TestUtil.DemandSorted(algorithm.Sort(new int[] { }));
        TestUtil.DemandSorted(algorithm.Sort(new int[] { 1, 2, 3 }));
        TestUtil.DemandSorted(algorithm.Sort(new int[] { 1, 1 }));
        TestUtil.DemandSorted(algorithm.Sort(new int[] { 1, 1, 1 }));
    }

    public void Unsorted(T algorithm)
    {
        TestUtil.DemandSorted(algorithm.Sort(new int[] { 2, 1 }));
        TestUtil.DemandSorted(algorithm.Sort(new int[] { 2, 3, 1 }));
        TestUtil.DemandSorted(algorithm.Sort(new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 }));
        TestUtil.DemandSorted(algorithm.Sort(new int[] { 9, 8, 7, 6, 5, 4, 3, 1, 2 }));
    }

    public void Random(T algorithm, int length = 1000)
    {
        TestUtil.DemandSorted(algorithm.Sort(GetRandomArray(length)));
    }

    private int[] GetRandomArray(int length)
    {
        int[] data = new int[length];
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = _rng.Next();
        }
        return data;
    }
}