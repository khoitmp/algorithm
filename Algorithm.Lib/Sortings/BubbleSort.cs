using System;

namespace Algorithm.Lib
{
    public class BubbleSort<T> : SortingMetric<T>
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
            bool again;

            do
            {
                again = false;

                for (int i = 1; i < items.Length; i++)
                {
                    if (GreaterThan(items, i - 1, i))
                    {
                        Swap(items, i - 1, i);
                        again = true;
                    }
                }
            } while (again);

            return items;
        }
    }
}