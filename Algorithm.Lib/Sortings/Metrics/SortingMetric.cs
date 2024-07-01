namespace Algorithm.Lib;

public abstract class SortingMetric<T> : ISorting<T>
    where T : IComparable
{
    public long Swaps { get; private set; }
    public long Comparisons { get; private set; }

    public T[] Sort(T[] items)
    {
        Reset();
        return MetricSort(items);
    }

    public abstract T[] MetricSort(T[] items);

    protected void Reset()
    {
        Swaps = 0;
        Comparisons = 0;
    }

    protected void Swap(T[] items, int left, int right)
    {
        T temp = items[left];

        items[left] = items[right];
        items[right] = temp;

        Swaps++;
    }

    protected void Assign(T[] items, int index, T value)
    {
        items[index] = value;
        Swaps++;
    }

    protected int Compare(T left, T right)
    {
        Comparisons++;
        return left.CompareTo(right);
    }

    protected int Compare(T[] items, int left, int right)
    {
        return Compare(items[left], items[right]);
    }

    protected bool LessThan(T[] items, int left, int right)
    {
        return Compare(items, left, right) < 0;
    }

    protected bool GreaterThan(T[] items, int left, int right)
    {
        return Compare(items, left, right) > 0;
    }

    protected bool EqualTo(T[] items, int left, int right)
    {
        return Compare(items, left, right) == 0;
    }
}