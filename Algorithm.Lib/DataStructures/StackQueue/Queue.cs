using System;

namespace Algorithm.Lib
{
    public class Queue<T>
    {
        private readonly Deque<T> _store = new Deque<T>();
        public int Count => _store.Count;

        public void Enqueue(T value)
        {
            _store.EnqueueTail(value);
        }

        public T Dequeue()
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