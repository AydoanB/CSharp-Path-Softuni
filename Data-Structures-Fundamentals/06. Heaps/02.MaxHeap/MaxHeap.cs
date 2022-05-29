using System.Collections.Generic;

namespace _02.MaxHeap
{
    using System;

    public class MaxHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        public int Size => this.elements.Count;
        private List<T> elements = new List<T>();


        public void Add(T element)
        {
            elements.Add(element);
            Heapify(elements.IndexOf(element));
        }

        private void Heapify(int index)
        {
            if (index == 0)
            {
                return;
            }
            int parentIndex = (index - 1) / 2;


            if (elements[index].CompareTo(elements[parentIndex]) > 0)
            {
                (elements[index], elements[parentIndex]) = (elements[parentIndex], elements[index]);
                Heapify(parentIndex);
            }
        }
        public T Peek()
        {
            return elements[0];
        }
    }
}
