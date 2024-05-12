using System.Collections;
using System.Collections.Generic;

namespace Algorithm.Lib
{
    public class LinkedList<T> : ICollection<T>
    {
        private LinkedListNode<T> _head;
        private LinkedListNode<T> _tail;
        public T Head => _head.Value;
        public T Tail => _tail.Value;

        /// <summary>
        /// Add the specified value to the beginning of the list
        /// - Time complexity
        ///     Best: O(1)
        ///     Worst: O(1)
        ///     Average: O(1)
        /// </summary>
        public void AddHead(T value)
        {
            AddHead(new LinkedListNode<T>(value));
        }

        private void AddHead(LinkedListNode<T> node)
        {
            // Save the head so we don't lose it
            LinkedListNode<T> temp = _head;

            _head = node;

            // Insert the rest of the list behide the head
            _head.Next = temp;

            Count++;

            // If the list was empty then head and tail should point to the new node
            if (Count == 1)
            {
                _tail = _head;
            }
        }

        /// <summary>
        /// Add the specified value to the end of the list
        /// - Time complexity
        ///     Best: O(1)
        ///     Worst: O(1)
        ///     Average: O(1)
        /// </summary>
        public void AddTail(T value)
        {
            AddTail(new LinkedListNode<T>(value));
        }

        private void AddTail(LinkedListNode<T> node)
        {
            if (Count == 0)
            {
                _head = node;
            }
            else
            {
                _tail.Next = node;
            }

            _tail = node;

            Count++;
        }

        /// <summary>
        /// Remove the first node from the list
        /// - Time complexity
        ///     Best: O(1)
        ///     Worst: O(1)
        ///     Average: O(1)
        /// </summary>
        public void RemoveFirst()
        {
            if (Count == 0)
            {
                return;
            }

            /*
                Before: Head -> 3 -> 5
                After:  Head ------> 5
                
                Before: Head -> 3 -> null
                After:  Head ------> null
            */

            _head = _head.Next;

            Count--;

            if (Count == 0)
            {
                _tail = null;
            }
        }

        /// <summary>
        /// Remove the last node from the list
        /// - Time complexity
        ///     Best: O(1)
        ///     Worst: O(n)
        ///     Average: O(n)
        /// </summary>
        public void RemoveLast()
        {
            if (Count == 0)
            {
                return;
            }

            if (Count == 1)
            {
                _head = null;
                _tail = null;
            }
            else
            {
                /*
                    Before: Head --> 3 --> 5 --> 7
                            Tail = 7
                    After:  Head --> 3 --> 5 --> null
                            Tail = 5
                */

                LinkedListNode<T> current = _head;

                while (current.Next != _tail)
                {
                    current = current.Next;
                }

                // Stop pointing to the old tail
                current.Next = null;

                _tail = current;
            }

            Count--;
        }

        #region ICollection
        public int Count { get; private set; }
        public bool IsReadOnly => false;

        /// <summary>
        /// Add the specified value to the beginning of the list
        /// </summary>
        public void Add(T item)
        {
            AddHead(item);
        }

        /// <summary>
        /// Remove the first occurance of the item from the list (searching from head to tail)
        /// - Time complexity
        ///     Best: O(1)
        ///     Worst: O(n)
        ///     Average: O(n)
        /// </summary>
        public bool Remove(T item)
        {
            /*
                1. Single node
                2. Many nodes
                    a. Node to remove is the first node
                    b. Node to remove is the middle or last
            */

            LinkedListNode<T> previous = null;
            LinkedListNode<T> current = _head;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    // Case 2b
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        // It's was the end then update tail
                        if (current.Next == null)
                        {
                            _tail = previous;
                        }

                        Count--;
                    }
                    // Case 1 or 2a
                    else
                    {
                        RemoveFirst();
                    }

                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        /// <summary>
        /// Check if the list contains specified item
        /// - Time complexity
        ///     Best: O(1)
        ///     Worst: O(n)
        ///     Average: O(n)
        /// </summary>
        public bool Contains(T item)
        {
            LinkedListNode<T> current = _head;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        /// <summary>
        /// Copy the node values into the specified array
        /// </summary>
        public void CopyTo(T[] array, int arrayIndex)
        {
            LinkedListNode<T> current = _head;

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
            _head = null;
            _tail = null;
            Count = 0;
        }

        /// <summary>
        /// Enumerate over the list values from head to tail
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = _head;
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
        #endregion
    }
}