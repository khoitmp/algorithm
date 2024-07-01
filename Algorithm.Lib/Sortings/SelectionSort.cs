namespace Algorithm.Lib;

public class SelectionSort<T> : SortingMetric<T>
    where T : IComparable
{
    /// <summary>
    /// - Time complexity
    ///     Best:    O(n) => The list already sorted, or nearly sorted
    ///     Worst:   O(n^2)
    ///     Average: O(n^2)
    /// - Space:     O(1)
    /// </summary>
    public override T[] MetricSort(T[] items)
    {
        int n = items.Length;

        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;

            for (int j = i + 1; j < n; j++)
            {
                if (LessThan(items, j, minIndex))
                {
                    minIndex = j;
                }
            }

            if (minIndex != i)
            {
                Swap(items, i, minIndex);
            }
        }

        return items;
    }
}