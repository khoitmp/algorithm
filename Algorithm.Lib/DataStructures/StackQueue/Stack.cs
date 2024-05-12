using System;

namespace Algorithm.Lib
{
    public class Stack<T>
    {
        private readonly Deque<T> _store = new Deque<T>();
        public int Count => _store.Count;

        public void Push(T item)
        {
            _store.EnqueueHead(item);
        }

        public T Pop()
        {
            return _store.DequeueHead();
        }

        public T Peek()
        {
            T value;
            if (_store.PeekHead(out value))
            {
                return value;
            }

            throw new InvalidOperationException();
        }
    }
}