namespace Algorithm.Lib
{
    public class DoublyLinkedListNode<T>
    {
        /// <summary>
        /// The node value
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// The next node in the list (null if last node)
        /// </summary>
        public DoublyLinkedListNode<T> Next { get; set; }

        /// <summary>
        /// The previous node in the list (null if first node)
        /// </summary>
        public DoublyLinkedListNode<T> Previous { get; set; }

        /// <summary>
        /// Construct a new node with the specified value
        /// </summary>
        /// <param name="value"></param>
        public DoublyLinkedListNode(T value)
        {
            Value = value;
        }
    }
}