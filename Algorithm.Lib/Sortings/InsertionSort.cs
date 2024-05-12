using System;

namespace Algorithm.Lib
{
    public class InsertionSort<T> : SortingMetric<T>
        where T : IComparable
    {

        /// <summary>
        /// - Time complexity
        ///     Best:    O(n) => The list already sorted, or nearly sorted
        ///     Worst:   O(n^2)
        ///     Average: O(n^2)
        /// - Space:     O(1)
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public override T[] MetricSort(T[] items)
        {
            for (int i = 1; i < items.Length; i++)
            {
                if (LessThan(items, i, i - 1))
                {
                    for (int p = i; p > 0; p--)
                    {
                        if (LessThan(items, p, p - 1))
                        {
                            Swap(items, p, p - 1);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            return items;
        }
    }
}