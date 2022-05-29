using Problem01.CircularQueue;

namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        public int Count { get; private set; }
        private Node<T> head;
        private Node<T> tail;
        public void AddFirst(T item)
        {
            var node = new Node<T>(item);
            if (this.head == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                this.head.Previous = node;
                node.Next = this.head;
                this.head = node;
            }

            Count++;
        }

        public void AddLast(T item)
        {
            var node = new Node<T>(item);
            if (Count == 0)
            {
                head = node;
                tail = node;
            }
            else
            {
                while (node.Next != null)
                {
                    node = node.Next;
                }

                tail.Next = node;
                node.Previous = tail;
                tail = node;
            }

            Count++;
        }

        public T GetFirst()
        {
            IsEmpty();

            return this.head.Item;

        }

        public T GetLast()
        {
            IsEmpty();

            return this.tail.Item;
        }

        public T RemoveFirst()
        {
            IsEmpty();
            var oldNode = head;
            head = oldNode.Next;
            Count--;
            return oldNode.Item;
        }

        public T RemoveLast()
        {
            IsEmpty();
            var oldNode = tail;

            if (Count == 1)
            {
                tail = oldNode.Previous;
                head = oldNode.Previous;
            }
            else
            {
                tail = oldNode.Previous;
                tail.Next = default;
            }
           
            Count--;
            return oldNode.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = head;

            while (node != null)
            {
                yield return node.Item;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void IsEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            
        }
    }
}