namespace Problem01.CircularQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CircularQueue<T> : IAbstractQueue<T>
    {
       

        private Node<T> head;
        public int Count { get; private set; }

        public T Dequeue()
        {
            EnsureEmpty();

            var oldNode = head;
            head = oldNode.Next;

            Count--;
            return oldNode.Item;
        }

        public void Enqueue(T item)
        {

            var node = new Node<T>(item);
            if (head == null)
            {
                head = node;
            }
            else
            {
                var currNode = head;

                while (currNode.Next != null)
                {
                    currNode = currNode.Next;

                }

                currNode.Next = node;
            }

            Count++;
        }



        public T Peek()
        {
            EnsureEmpty();
            return this.head.Item;

        }

        public T[] ToArray()
        {
            T[] arr = new T[Count];
            var node = head;

            for (int i = 0; i < Count; i++)
            {
                arr[i] = node.Item;
                node = node.Next;
            }

            return arr;
        }
        public IEnumerator<T> GetEnumerator()
        {
            var node = head;

            while (node.Next != null)
            {
                yield return node.Item;

                node = node.Next;
            }

            yield return node.Item;
        }
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void EnsureEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }

}
