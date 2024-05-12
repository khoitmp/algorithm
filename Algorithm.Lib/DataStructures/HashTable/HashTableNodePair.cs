
namespace Algorithm.Lib
{
    /// <summary>
    /// A node in the hash table array
    /// </summary>
    internal class HashTableNodePair<TKey, TValue>
    {
        /// <summary>
        /// The key cannot be changed because it would affect the 
        /// indexing in the hash table
        /// </summary>
        public TKey Key { get; private set; }

        /// <summary>
        /// The value
        /// </summary>
        public TValue Value { get; set; }

        /// <summary>
        /// Construct a key/value pair for storage in the hash table
        /// </summary>
        public HashTableNodePair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }
}