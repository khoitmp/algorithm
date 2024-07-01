namespace Algorithm.Lib;

public class DoublyLinkedList<T> : ICollection<T>
{
    /// <summary>
    /// The first node in the list (null if empty)
    /// </summary>
    public DoublyLinkedListNode<T> Head
    {
        get;
        private set;
    }

    /// <summary>
    /// The last node in the list (null if empty)
    /// </summary>
    public DoublyLinkedListNode<T> Tail
    {
        get;
        private set;
    }

    /// <summary>
    /// Add the specified value to the beginning of the list
    /// - Time complexity
    ///     Best:    O(1)
    ///     Worst:   O(1)
    ///     Average: O(1)
    /// </summary>
    public void AddHead(T value)
    {
        AddHead(new DoublyLinkedListNode<T>(value));
    }

    private void AddHead(DoublyLinkedListNode<T> node)
    {
        // Save off the head node so we don't lose it
        DoublyLinkedListNode<T> temp = Head;

        // Point head to the new node
        Head = node;

        // Insert the rest of the list behind the head
        Head.Next = temp;

        if (Count == 0)
        {
            // If the list was empty then Head and Tail should both point to the new node
            Tail = Head;
        }
        else
        {
            /*
                Before: Head -------> 5 <-> 7 -> null
                After:  Head -> 3 <-> 5 <-> 7 -> null

                temp.Previous was null, now Head
            */

            temp.Previous = Head;
        }

        Count++;
    }

    /// <summary>
    /// Add the value to the end of the list
    /// - Time complexity
    ///     Best:    O(1)
    ///     Worst:   O(1)
    ///     Average: O(1)
    /// </summary>
    /// <param name="value">The value to add</param>
    public void AddTail(T value)
    {
        AddTail(new DoublyLinkedListNode<T>(value));
    }

    private void AddTail(DoublyLinkedListNode<T> node)
    {
        if (Count == 0)
        {
            Head = node;
        }
        else
        {
            Tail.Next = node;

            /*
                Before: Head -> 3 <-> 5 -> null
                After:  Head -> 3 <-> 5 <-> 7 -> null
            */

            node.Previous = Tail;
        }

        Tail = node;

        Count++;
    }

    /// <summary>
    /// Remove the first node from the list
    /// - Time complexity
    ///     Best:    O(1)
    ///     Worst:   O(1)
    ///     Average: O(1)
    /// </summary>
    public void RemoveHead()
    {
        if (Count == 0)
        {
            return;
        }

        /*
            Before: Head -> 3 <-> 5
            After:  Head -------> 5

            Head -> 3 -> null
            Head ------> null
        */

        Head = Head.Next;

        Count--;

        if (Count == 0)
        {
            Tail = null;
        }
        else
        {
            // 5.Previous was 3, now null
            Head.Previous = null;
        }
    }

    /// <summary>
    /// Remove the last node from the list
    /// - Time complexity
    ///     Best:    O(1)
    ///     Worst:   O(1)
    ///     Average: O(1)
    /// </summary>
    public void RemoveTail()
    {
        if (Count == 0)
        {
            return;
        }

        if (Count == 1)
        {
            Head = null;
            Tail = null;
        }
        else
        {
            /*
                Before: Head --> 3 --> 5 --> 7
                        Tail = 7
                After:  Head --> 3 --> 5 --> null
                        Tail = 5

                Null out 5's Next pointer
            */

            Tail.Previous.Next = null;
            Tail = Tail.Previous;
        }

        Count--;
    }

    public bool GetHead(out T value)
    {
        if (Count > 0)
        {
            value = Head.Value;
            return true;
        }

        value = default(T);

        return false;
    }

    public bool GetTail(out T value)
    {
        if (Count > 0)
        {
            value = Tail.Value;
            return true;
        }

        value = default(T);

        return false;
    }

    #region ICollection
    public int Count { get; private set; }
    public bool IsReadOnly => false;

    /// <summary>
    /// Add the specified value to the beginning of the list
    /// </summary>
    /// <param name="item">The value to add</param>
    public void Add(T item)
    {
        AddHead(item);
    }

    /// <summary>
    /// Remove the first occurance of the item from the list (searching from head to tail)
    /// - Time complexity
    ///     Best:    O(1)
    ///     Worst:   O(n)
    ///     Average: O(n)        
    /// </summary>
    public bool Remove(T item)
    {
        DoublyLinkedListNode<T> found = Find(item);

        if (found == null)
        {
            return false;
        }

        DoublyLinkedListNode<T> previous = found.Previous;
        DoublyLinkedListNode<T> next = found.Next;

        // Removing the head node
        if (previous == null)
        {
            RemoveHead();
        }
        // Removing the tail
        else if (next == null)
        {
            RemoveTail();
        }
        // Removing middle node
        else
        {
            previous.Next = next;
            next.Previous = previous;

            Count--;
        }

        return true;
    }

    /// <summary>
    /// Find a specified item from the list
    /// - Time complexity
    ///     Best:    O(n)
    ///     Worst:   O(n)
    ///     Average: O(n)
    /// </summary>
    public DoublyLinkedListNode<T> Find(T item)
    {
        DoublyLinkedListNode<T> current = Head;

        while (current != null)
        {
            if (current.Value.Equals(item))
            {
                return current;
            }

            current = current.Next;
        }

        return null;
    }

    /// <summary>
    /// Check if the specified item in the list
    /// </summary>
    public bool Contains(T item)
    {
        return Find(item) != null;
    }

    /// <summary>
    /// Copy the list values into the specified array
    /// - Time complexity
    ///     Best:    O(n)
    ///     Worst:   O(n)
    ///     Average: O(n)        
    /// </summary>
    public void CopyTo(T[] array, int arrayIndex)
    {
        DoublyLinkedListNode<T> current = Head;

        while (current != null)
        {
            array[arrayIndex++] = current.Value;
            current = current.Next;
        }
    }

    /// <summary>
    /// Remove all the nodes from the list
    /// </summary>
    public void Clear()
    {
        Head = null;
        Tail = null;
        Count = 0;
    }

    /// <summary>
    /// Enumerate over the list values from head to tail
    /// </summary>
    public IEnumerator<T> GetEnumerator()
    {
        DoublyLinkedListNode<T> current = Head;

        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    public IEnumerable<T> GetReverseEnumerator()
    {
        DoublyLinkedListNode<T> current = Tail;

        while (current != null)
        {
            yield return current.Value;
            current = current.Previous;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    #endregion
}