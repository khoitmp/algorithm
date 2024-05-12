using System;

namespace Algorithm.Lib
{
    public class QuickSort<T> : SortingMetric<T>
        where T : IComparable
    {
        private Random _pivotRng = new Random();

        /// <summary>
        /// - Time complexity
        ///     Best:    O(nlogn)
        ///     Worst:   O(n2) => The list already sorted (1st fixed pivot)
        ///     Average: O(nlogn)
        /// - Space:     O(logn)
        /// </summary>
        public override T[] MetricSort(T[] items)
        {
            return Sort(items, 0, items.Length - 1);
        }

        private T[] Sort(T[] items, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = _pivotRng.Next(left, right);
                int newPivot = Partition(items, left, right, pivotIndex);

                Sort(items, left, newPivot - 1);
                Sort(items, newPivot + 1, right);
            }

            return items;
        }

        private int Partition(T[] items, int left, int right, int pivotIndex)
        {
            T pivotValue = items[pivotIndex];

            // Save pivot value to the end so we don't miss it
            Swap(items, pivotIndex, right);

            int storeIndex = left;

            for (int i = left; i < right; i++)
            {
                if (Compare(items[i], pivotValue) < 0)
                {
                    Swap(items, i, storeIndex);
                    storeIndex += 1;
                }
            }

            // Send back pivot value to where it should be
            Swap(items, storeIndex, right);

            return storeIndex;
        }
    }
}