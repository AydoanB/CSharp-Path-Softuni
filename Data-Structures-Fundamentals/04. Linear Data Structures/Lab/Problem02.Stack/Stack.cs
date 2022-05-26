namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
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

        private Node top;

        public int Count { get; private set; }

        public void Push(T item)
        {
            var newNode = new Node(item);
            newNode.Next = top;
            top = newNode;
            Count++;

        }

        public T Pop()
        {
            if (top == null)
            {
                throw new InvalidOperationException();
            }
            var oldTop = top;
            top = oldTop.Next;
            Count--;
            return oldTop.Element;
        }

        public T Peek()
        {
            if (top == null)
            {
                throw new InvalidOperationException();
            }
            return this.top.Element;

        }

        public bool Contains(T item)
        {
            //var List = new List<T>();
            //var node = top;
            //while (node != null)
            //{
            //    List.Add(node.Element);
            //}

            //return List.Contains(item);

            var node = top;
            bool result = false;
            while (node != null)
            {
                if (node.Element.Equals(item))
                {
                    result = true;
                }

                node = node.Next;
            }

            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = top;

            while (node != null)
            {
                yield return node.Element;
                node = top.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}