namespace Algorithm.Lib
{
    public class LinkedListNode<T>
    {
        /// <summary>
        /// The node value
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// The next node in the linked list (null if last node)
        /// </summary>
        public LinkedListNode<T> Next { get; set; }

        /// <summary>
        /// Construct a new node with the specified value
        /// </summary>
        public LinkedListNode(T value)
        {
            Value = value;
        }
    }
}