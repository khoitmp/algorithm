using System;
using System.Collections.Generic;

namespace Algorithm.Lib
{
    /// <summary>
    /// The fixed size array of the nodes in the hash table
    /// </summary>
    /// <typeparam name="TKey">The key type of the hash table</typeparam>
    /// <typeparam name="TValue">The value type of the hash table</typeparam>
    internal class HashTableArray<TKey, TValue>
    {
        HashTableArrayNode<TKey, TValue>[] _array;

        /// <summary>
        /// The capacity of the hash table array
        /// </summary>
        public int Capacity
        {
            get
            {
                return _array.Length;
            }
        }

        /// <summary>
        /// Return an enumerator for all of the values in the node array
        /// </summary>
        public IEnumerable<TValue> Values
        {
            get
            {
                foreach (HashTableArrayNode<TKey, TValue> node in _array)
                {
                    foreach (TValue value in node.Values)
                    {
                        yield return value;
                    }
                }
            }
        }

        /// <summary>
        /// Return an enumerator for all of the keys in the node array
        /// </summary>
        public IEnumerable<TKey> Keys
        {
            get
            {
                foreach (HashTableArrayNode<TKey, TValue> node in _array)
                {
                    foreach (TKey key in node.Keys)
                    {
                        yield return key;
                    }
                }
            }
        }

        /// <summary>
        /// Return an enumerator for all of the items in the node array
        /// </summary>
        public IEnumerable<HashTableNodePair<TKey, TValue>> Items
        {
            get
            {
                foreach (HashTableArrayNode<TKey, TValue> node in _array)
                {
                    foreach (HashTableNodePair<TKey, TValue> pair in node.Items)
                    {
                        yield return pair;
                    }
                }
            }
        }

        /// <summary>
        /// Construct a new hash table array with the specified capacity
        /// </summary>
        /// <param name="capacity">The capacity of the array</param>
        public HashTableArray(int capacity)
        {
            _array = new HashTableArrayNode<TKey, TValue>[capacity];
            for (int i = 0; i < capacity; i++)
            {
                _array[i] = new HashTableArrayNode<TKey, TValue>();
            }
        }

        /// <summary>
        /// Add the key/value pair to the node. If the key already exists in the
        /// node array an ArgumentException will be thrown
        /// </summary>
        /// <param name="key">The key of the item being added</param>
        /// <param name="value">The value of the item being added</param>
        public void Add(TKey key, TValue value)
        {
            _array[GetIndex(key)].Add(key, value);
        }

        /// <summary>
        /// Update the value of the existing key/value pair in the node array.
        /// If the key does not exist in the array an ArgumentException
        /// will be thrown
        /// </summary>
        /// <param name="key">The key of the item being updated</param>
        /// <param name="value">The updated value</param>
        public void Update(TKey key, TValue value)
        {
            _array[GetIndex(key)].Update(key, value);
        }

        /// <summary>
        /// Remove the item from the node array whose key matches
        /// the specified key
        /// </summary>
        /// <param name="key">The key of the item to remove</param>
        /// <returns>true if the item was removed, false otherwise</returns>
        public bool Remove(TKey key)
        {
            return _array[GetIndex(key)].Remove(key);
        }

        /// <summary>
        /// Find and return the value for the specified key
        /// </summary>
        /// <param name="key">The key whose value is sought</param>
        /// <param name="value">The value associated with the specified key</param>
        /// <returns>true if the value was found, false otherwise</returns>
        public bool TryGetValue(TKey key, out TValue value)
        {
            return _array[GetIndex(key)].TryGetValue(key, out value);
        }

        /// <summary>
        /// Remove every item from the hash table array
        /// </summary>
        public void Clear()
        {
            foreach (HashTableArrayNode<TKey, TValue> node in _array)
            {
                node.Clear();
            }
        }

        // Map a key to the array index based on hash code
        private int GetIndex(TKey key)
        {
            return Math.Abs(key.GetHashCode() % Capacity);
        }
    }
}