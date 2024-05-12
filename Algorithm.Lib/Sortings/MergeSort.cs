using System;

namespace Algorithm.Lib
{
    public class MergeSort<T> : SortingMetric<T>
        where T : IComparable
    {
        /// <summary>
        /// - Time complexity
        ///     Best:    O(nlogn)
        ///     Worst:   O(nlogn)
        ///     Average: O(nlogn)
        /// - Space:     O(n)
        /// </summary>
        public override T[] MetricSort(T[] items)
        {
            if (items.Length <= 1)
            {
                return items;
            }

            int leftSize = items.Length / 2;
            int rightSize = items.Length - leftSize;

            T[] left = new T[leftSize];
            T[] right = new T[rightSize];

            Array.Copy(items, 0, left, 0, leftSize);
            Array.Copy(items, leftSize, right, 0, rightSize);

            MetricSort(left);
            MetricSort(right);

            // Begin first merge when left=1 and right=1
            return Merge(items, left, right);
        }

        private T[] Merge(T[] items, T[] left, T[] right)
        {
            int leftIndex = 0;
            int rightIndex = 0;
            int targetIndex = 0;
            int remaining = left.Length + right.Length;

            while (remaining > 0)
            {
                // Left is out
                if (leftIndex >= left.Length)
                {
                    Assign(items, targetIndex, right[rightIndex++]);
                }
                // Right is out
                else if (rightIndex >= right.Length)
                {
                    Assign(items, targetIndex, left[leftIndex++]);
                }
                // Take 1 from left then move foward
                else if (Compare(left[leftIndex], right[rightIndex]) < 0)
                {
                    Assign(items, targetIndex, left[leftIndex++]);
                }
                // Take 1 from right then move forward
                else
                {
                    Assign(items, targetIndex, right[rightIndex++]);
                }

                targetIndex++;
                remaining--;
            }

            return items;
        }
    }
}