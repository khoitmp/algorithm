namespace Algorithm.Lib;

/// <summary>
/// - Time complexity
///     Best:    O(logn)
///     Worst:   O(logn)
///     Average: O(logn)
/// </summary>
public class BinarySearch
{
    public static int BinarySearchIterative<T>(T[] array, T target)
        where T : IComparable<T>
    {
        int left = 0;
        int right = array.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            int comparison = array[mid].CompareTo(target);
            if (comparison == 0)
            {
                return mid;
            }
            else if (comparison < 0)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        // Return -1 if the target is not found
        return -1;
    }

    public static int BinarySearchRecursive<T>(T[] array, T target, int left, int right)
        where T : IComparable<T>
    {
        if (left > right)
        {
            return -1;
        }

        int mid = left + (right - left) / 2;
        int comparison = array[mid].CompareTo(target);

        if (comparison == 0)
        {
            return mid;
        }
        else if (comparison < 0)
        {
            return BinarySearchRecursive(array, target, mid + 1, right);
        }
        else
        {
            return BinarySearchRecursive(array, target, left, mid - 1);
        }
    }
}