using System.Collections.Immutable;
using System.Linq;

namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;
        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                if (index >= Count || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                return items[Count - 1 - index];
            }
            set
            {
                if (index >= Count || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            Grow();

            items[Count++] = item;
        }

        public bool Contains(T item)
        {
            if (Count == 0)
            {
                return false;
            }
            bool result = false;
            foreach (var element in items)
            {
                if (element.Equals(item))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[Count - 1 - i].Equals(item))
                {
                    return i;

                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {

           
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            };
            for (int i = this.Count; i >= this.Count - index; i--)
            {
                this.items[i] = this.items[i - 1];
            }

            this.items[this.Count - index] = item;
            //for (int i = Count - 1; i >= index; i--)
            //{
            //    items[i + 1] = items[i];

            //}
            //items[index] = item;

            Count++;

            /*if (this.Count == this.items.Length)
            {
                this.items = Grow(this.items);
            }

            for (int i = this.Count; i >= this.Count - index; i--)
            {
                this.items[i] = this.items[i - 1];
            }

            this.items[this.Count - index] = item;

            this.Count++;*/

        }

        public bool Remove(T item)
        {
            if (IndexOf(item) < 0 || IndexOf(item) >= Count)
            {
                return false;
            }
            var index = IndexOf(item);
            RemoveAt(index);

            return true;
        }

        public void RemoveAt(int index)
        {

            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }


            index = Count - 1 - index;
            for (int i = index; i < Count; i++)
            {
                items[i] = items[i + 1];
            }

            items[Count - 1] = default;
            Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            // Array.Reverse(items);
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return items[i];
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

        private void Grow()
        {
            var copyArray = new T[items.Length * 2];
            Array.Copy(items, copyArray, Count);
            items = copyArray;
        }


    }
}