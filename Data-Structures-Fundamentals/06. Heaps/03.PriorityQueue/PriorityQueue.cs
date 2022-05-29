using System.Collections.Generic;

namespace _03.PriorityQueue
{
    using System;

    public class PriorityQueue<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> heap = new List<T>();
        public int Size => heap.Count;

        public T Dequeue()
        {
            T top = heap[0];
            heap[0] = heap[heap.Count - 1];

            heap.RemoveAt(heap.Count-1);
            HeapifyDown(0);
            return top;
        }

        public void Add(T element)
        {
            heap.Add(element);
            HeapifyDown(heap.Count - 1);
        }

        private void HeapifyDown(int index)
        {
            int leftIndex = index * 2 + 1;
            int rightIndex = index * 2 + 2;
            int maxIndex = leftIndex;

            if (leftIndex >= Size) return;

            if (rightIndex < Size && heap[leftIndex].CompareTo(heap[rightIndex]) < 0)
            {
                maxIndex = rightIndex;
            }

            if (heap[index].CompareTo(heap[maxIndex]) < 0)
            {
                (heap[maxIndex], heap[index]) = (heap[index], heap[maxIndex]);
                HeapifyDown(maxIndex);
            }


        }

        public T Peek()
        {
            return heap[0];
        }
    }
}
