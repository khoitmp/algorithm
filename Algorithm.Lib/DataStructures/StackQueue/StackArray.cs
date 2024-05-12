using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithm.Lib
{
    /// <summary>
    /// A Last In First Out (LIFO) collection implemented as an array
    /// </summary>
    public class StackArray<T> : IEnumerable<T>
    {
        private T[] _items = new T[0];
        private int _size;

        /// <summary>
        /// Add the specified item to the stack
        /// - Time complexity
        ///     Best: O(1)
        ///     Worst: O(2n) => In case the array is full
        ///     Average: O(1)
        /// </summary>
        public void Push(T item)
        {
            /*
                _size = 0 ... first push
                _size == length ... growth boundary
            */

            if (_size == _items.Length)
            {
                // Initial size of 4, otherwise double the current length
                int newLength = _size == 0 ? 4 : _size * 2;

                // Allocate, copy and assign the new array
                T[] newArray = new T[newLength];

                _items.CopyTo(newArray, 0);
                _items = newArray;
            }

            // Add the item to the stack array and increase the size
            _items[_size] = item;

            _size++;
        }

        /// <summary>
        /// Remove and return the top item from the stack
        /// - Time complexity
        ///     Best: O(1)
        ///     Worst: O(1)
        ///     Average: O(1)
        /// </summary>
        public T Pop()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            _size--;

            return _items[_size];
        }

        /// <summary>
        /// Return the top item from the stack without removing it from the stack
        /// </summary>
        public T Peek()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            return _items[_size - 1];
        }

        #region IEnumerable
        /// <summary>
        /// The current number of items in the stack
        /// </summary>
        public int Count => _size;

        /// <summary>
        /// Remove all items from the stack
        /// </summary>
        public void Clear()
        {
            _size = 0;
        }

        /// <summary>
        /// Enumerate each item in the stack in LIFO order. The stack remains unaltered
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _size - 1; i >= 0; i--)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}