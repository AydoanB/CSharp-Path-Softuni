namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private class Node
        {
            public T Element { get; set; }
            public Node Next { get; set; }

            public Node(T element, Node next)
            {
                Element = element;
                Next = next;
            }
            public Node(T element)
            {
                Element = element;
            }

        }

        private Node head;


        public int Count { get; private set; }

        public void Enqueue(T item)
        {
            var newNode = new Node(item);
            if (head == null)
            {
                head = newNode;
            }
            else
            {

                var node = head;

                while (node.Next != null)
                {
                    node = node.Next;
                }

                node.Next = newNode;
            }

            Count++;

        }

        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            var oldHead = head;
            head = oldHead.Next;
            Count--;
            return oldHead.Element;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            return head.Element;
        }

        public bool Contains(T item)
        {
            bool result = false;
            var node = head;
            while (node != null)
            {
                var element = Dequeue();
                if (element.Equals(item))
                {
                    result = true;
                    break;
                }

                node = node.Next;

            }

            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = head;


            while (node != null)
            {
                yield return node.Element;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}