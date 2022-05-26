using System.Linq;

namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] items;

        public List()
            : this(DEFAULT_CAPACITY)
        {
        }

        public List(int capacity)
        {
            items = new T[capacity];
        }

        public T this[int index]
        {

            get
            {
                CheckForRange(index);

                return items[index];
            }
            set
            {
                CheckForRange(index);
                items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            Increasor();
            
            items[Count++] = item;

        }

        public bool Contains(T item)
        {

            foreach (var el in items.Take(Count))
            {
                if (el.Equals(item))
                {
                    return true;
                }

            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return items[i];
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            CheckForRange(index);
            Increasor();

            for (int i = Count; i > index; i--)
            {
                items[i] = items[i - 1];
            }

            items[index] = item;
            Count++;

        }

        public bool Remove(T item)
        {
            if (Contains(item))
            {
                var index = IndexOf(item);
                RemoveAt(index);
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            CheckForRange(index);
            for (int i = index; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }

            Count--;
            
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
        private void CheckForRange(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void Increasor()
        {
            if (Count == items.Length)
            {
                T[] copy = new T[items.Length * 2];
                //for (int i = 0; i < this.items.Length; i++)
                //{
                //    copy[i] = items[i];
                //}
                Array.Copy(items, copy, Count);
                items = copy;
            }
        }
    }

}