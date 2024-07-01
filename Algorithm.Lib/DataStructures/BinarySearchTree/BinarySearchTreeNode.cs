namespace Algorithm.Lib;

/// <summary>
/// A binary tree node class - encapsulates the value and left/right pointers
/// </summary>
public class BinarySearchTreeNode<T> : IComparable<T>
    where T : IComparable<T>
{
    public T Value { get; private set; }
    public BinarySearchTreeNode<T> Left { get; set; }
    public BinarySearchTreeNode<T> Right { get; set; }

    public BinarySearchTreeNode(T value)
    {
        Value = value;
    }

    /// <summary>
    /// Compare the current node to other node
    /// </summary>
    /// <param name="other">The node value to compare to</param>
    /// <returns>1 if the instance value is greater than the provided value, -1 if less or 0 if equal</returns>
    public int CompareTo(T other)
    {
        return Value.CompareTo(other);
    }
}