namespace Algorithm.Lib;

/// <summary>
/// A key/value associative collection
/// </summary>
/// <typeparam name="TKey">The key type of the key/value pair</typeparam>
/// <typeparam name="TValue">The value type of the key/value pair</typeparam>
public class HashTable<TKey, TValue>
{
    // If the array exceeds this fill percentage it will grow
    // In this example the fill factor is the total number of items
    // regardless of whether they are collisions or not
    private const double _fillFactor = 0.75;

    // The maximum number of items to store before growing.
    // This is just a cached value of the fill factor calculation
    private int _maxItemsAtCurrentSize;

    // The number of items in the hash table
    private int _count;

    // The array where the items are stored
    private HashTableArray<TKey, TValue> _array;

    /// <summary>
    /// The number of items currently in the hash table
    /// </summary>
    public int Count
    {
        get
        {
            return _count;
        }
    }

    /// <summary>
    /// Get and set the value with the specified key. ArgumentException is
    /// thrown if the key does not already exist in the hash table
    /// - Time complexity
    ///     Best:    O(1)
    ///     Worst:   O(1)
    ///     Average: O(1)
    /// </summary>
    /// <param name="key">The key of the value to retrieve</param>
    /// <returns>The value associated with the specified key</returns>
    public TValue this[TKey key]
    {
        get
        {
            TValue value;
            if (!_array.TryGetValue(key, out value))
            {
                throw new ArgumentException(nameof(key));
            }
            return value;
        }
        set
        {
            _array.Update(key, value);
        }
    }

    /// <summary>
    /// Return an enumerator for all of the keys in the hash table
    /// </summary>
    public IEnumerable<TKey> Keys
    {
        get
        {
            foreach (TKey key in _array.Keys)
            {
                yield return key;
            }
        }
    }

    /// <summary>
    /// Return an enumerator for all of the values in the hash table
    /// </summary>
    public IEnumerable<TValue> Values
    {
        get
        {
            foreach (TValue value in _array.Values)
            {
                yield return value;
            }
        }
    }

    /// <summary>
    /// Construct a hash table with the default capacity
    /// </summary>
    public HashTable()
        : this(1000)
    {
    }

    /// <summary>
    /// Construct a hash table with the specified capacity
    /// </summary>
    public HashTable(int initialCapacity)
    {
        if (initialCapacity < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(initialCapacity));
        }

        _array = new HashTableArray<TKey, TValue>(initialCapacity);

        // When the count exceeds this value, the next add will cause the
        // array to grow
        _maxItemsAtCurrentSize = (int)(initialCapacity * _fillFactor) + 1;
    }

    /// <summary>
    /// Add the key/value pair to the hash table. If the key already exists in the
    /// hash table an ArgumentException will be thrown
    /// - Time complexity
    ///     Best:    O(1)
    ///     Worst:   O(2n) => In case max items at current size if full
    ///     Average: O(1)
    /// </summary>
    /// <param name="key">The key of the item being added</param>
    /// <param name="value">The value of the item being added</param>
    public void Add(TKey key, TValue value)
    {
        // If we are at capacity, the array needs to grow
        if (_count >= _maxItemsAtCurrentSize)
        {
            // Allocate a larger array (growth factor is x2)
            var largerArray = new HashTableArray<TKey, TValue>(_array.Capacity * 2);

            // And re-add each item to the new array
            foreach (HashTableNodePair<TKey, TValue> node in _array.Items)
            {
                largerArray.Add(node.Key, node.Value);
            }

            // The larger array is now the hash table storage
            _array = largerArray;

            // Update the new max items cached value
            _maxItemsAtCurrentSize = (int)(_array.Capacity * _fillFactor) + 1;
        }

        _array.Add(key, value);

        _count++;
    }

    /// <summary>
    /// Remove the item from the hash table whose key matches
    /// the specified key
    /// </summary>
    /// <param name="key">The key of the item to remove</param>
    /// <returns>true if the item was removed, false otherwise</returns>
    public bool Remove(TKey key)
    {
        bool removed = _array.Remove(key);
        if (removed)
        {
            _count--;
        }
        return removed;
    }

    /// <summary>
    /// Find and return the value for the specified key
    /// </summary>
    /// <param name="key">The key whose value is sought</param>
    /// <param name="value">The value associated with the specified key</param>
    /// <returns>True if the value was found, false otherwise</returns>
    public bool TryGetValue(TKey key, out TValue value)
    {
        return _array.TryGetValue(key, out value);
    }

    /// <summary>
    /// Return a boolean indicating if the hash table contains the specified key
    /// </summary>
    /// <param name="key">The key whose existence is being tested</param>
    /// <returns>true if the value exists in the hash table, false otherwise</returns>
    public bool ContainsKey(TKey key)
    {
        TValue value;
        return _array.TryGetValue(key, out value);
    }

    /// <summary>
    /// Return a boolean indicating if the hash table contains the specified value
    /// </summary>
    /// <param name="value">The value whose existence is being tested</param>
    /// <returns>True if the value exists in the hash table, false otherwise</returns>
    public bool ContainsValue(TValue value)
    {
        foreach (TValue foundValue in _array.Values)
        {
            if (value.Equals(foundValue))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Remove all item from the hash table
    /// </summary>
    public void Clear()
    {
        _array.Clear();
        _count = 0;
    }
}