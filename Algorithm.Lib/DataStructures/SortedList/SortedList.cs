namespace Algorithm.Lib;

public class SortedList<T> : IEnumerable<T>
    where T : IComparable<T>
{
    #region Node
    class SortedListNode<TNode>
        where TNode : IComparable<TNode>
    {
        public TNode Value;
        public SortedListNode<TNode> Prev;
        public SortedListNode<TNode> Next;

        public SortedListNode(
            TNode value,
            SortedListNode<TNode> prev = null,
            SortedListNode<TNode> next = null)
        {
            Value = value;
            Prev = prev;
            Next = next;
        }
    }
    #endregion

    private SortedListNode<T> _head = null;
    private SortedListNode<T> _tail = null;

    public int Count { get; private set; }

    /// <summary>
    /// Add the specified value to the list
    /// - Time complexity
    ///     Best: O(1)
    ///     Worst: O(n)
    ///     Average: O(n)
    /// </summary>
    public void Add(T value)
    {
        // Empty list
        if (_head == null)
        {
            _head = new SortedListNode<T>(value);
            _tail = _head;
        }
        // Adding at head
        else if (_head.Value.CompareTo(value) >= 0)
        {
            SortedListNode<T> newHead = new SortedListNode<T>(value);

            newHead.Next = _head;
            _head.Prev = newHead;
            _head = newHead;
        }
        // Adding at tail
        else if (_tail.Value.CompareTo(value) < 0)
        {
            SortedListNode<T> newtail = new SortedListNode<T>(value);

            newtail.Prev = _tail;
            _tail.Next = newtail;
            _tail = newtail;
        }
        // Adding middle, find the insertion point
        else
        {
            SortedListNode<T> insertBefore = _head;

            while (insertBefore.Value.CompareTo(value) < 0)
            {
                insertBefore = insertBefore.Next;
            }

            // Insert the node
            SortedListNode<T> newNode = new SortedListNode<T>(value);

            newNode.Next = insertBefore;
            newNode.Prev = insertBefore.Prev;
            insertBefore.Prev.Next = newNode;
            insertBefore.Prev = newNode;
        }

        Count++;
    }

    /// <summary>
    /// Remove the specified value from the list
    /// - Time complexity
    ///     Best: O(1)
    ///     Worst: O(n)
    ///     Average: O(n)
    /// </summary>
    public bool Remove(T value)
    {
        SortedListNode<T> toRemove = FindNode(value);

        if (toRemove == null)
        {
            return false;
        }

        SortedListNode<T> prev = toRemove.Prev;
        SortedListNode<T> next = toRemove.Next;

        // Single node
        if (prev == null && next == null)
        {
            _head = null;
            _tail = null;
        }
        // Middle node
        else if (prev != null && next != null)
        {
            prev.Next = next;
            next.Prev = prev;
        }
        // Tail
        else if (prev != null && next == null)
        {
            prev.Next = null;
            _tail = prev;
        }
        // Head
        else
        {
            next.Prev = null;
            _head = next;
        }

        Count--;
        return true;
    }

    private SortedListNode<T> FindNode(T value)
    {
        SortedListNode<T> current = _head;

        while (current != null)
        {
            if (current.Value.Equals(value))
            {
                return current;
            }

            current = current.Next;
        }

        return null;
    }

    public bool Find(T value, out T found)
    {
        SortedListNode<T> node = FindNode(value);

        if (node != null)
        {
            found = node.Value;
            return true;
        }

        found = default(T);

        return false;
    }

    public bool Contains(T value)
    {
        return FindNode(value) != null;
    }
    #region IEnumerable
    public IEnumerator<T> GetEnumerator()
    {
        SortedListNode<T> current = _head;

        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerable<T> GetReverseEnumerator()
    {
        return new ReverseEnumerator(_tail);
    }

    class ReverseEnumerator : IEnumerable<T>
    {
        private SortedListNode<T> _tail;

        public ReverseEnumerator(SortedListNode<T> tail)
        {
            _tail = tail;
        }

        public IEnumerator<T> GetEnumerator()
        {
            SortedListNode<T> current = _tail;
            while (current != null)
            {
                yield return current.Value;
                current = current.Prev;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    #endregion
}