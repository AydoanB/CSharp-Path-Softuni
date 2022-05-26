namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private class Node
        {
            public T Element { get; set; }
            public Node Next { get; set; }


            public Node(T element)
            {
                Element = element;
            }

            public Node(T element, Node next)
            {
                Element = element;
                Next = next;
            }
        }
        private Node head;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newNode = new Node(item, this.head);
            head = newNode;
            Count++;

            /*
             *  var newNode = new Node(item);
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
             */
        }

        public void AddLast(T item)
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
                head = node.Next;
            }

            Count++;

        }



        public T GetFirst()
        {
            EnsureNotEmpty();
            return this.head.Element;
        }

        public T GetLast()
        {
            EnsureNotEmpty();
            throw new NotImplementedException();
        }

        public T RemoveFirst()
        {
            EnsureNotEmpty();
            var oldTop = head;

            head = oldTop.Next;
            Count--;
            return oldTop.Element;

        }

        public T RemoveLast()
        {
            EnsureNotEmpty();
            Count--;

            throw new NotImplementedException();
        }
        public IEnumerator<T> GetEnumerator()
        {
            var node = head;
            while (node.Next != null)
            {
                yield return node.Element;
                node = node.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void EnsureNotEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}