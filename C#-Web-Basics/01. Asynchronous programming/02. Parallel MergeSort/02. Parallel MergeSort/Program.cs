using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace _02._Parallel_MergeSort
{
    internal class Program
    {
        static object obj1 = new object();
        static object obj2 = new object();
        static void Main(string[] args)
        {
            Random random = new Random();
            var list = new LinkedList<int>();

            for (int i = 0; i < 50; i++)
            {
                list.AddFirst(random.Next(50000));
            }

            MergeSort(list);

        }
        public static async Task<LinkedList<int>> MergeSort(LinkedList<int> elements)
        {

            var left = new LinkedList<int>();
            var right = new LinkedList<int>();

            foreach (var element in elements)
            {
                if (element % 2 == 0)
                {
                    right.AddFirst(element);
                }
                else
                {
                    left.AddFirst(element);
                }
            }

            left = await MergeSort(left);
            right = await MergeSort(right);

            return Merge(left, right);
        }

        public static LinkedList<int> Merge(LinkedList<int> left, LinkedList<int> right)
        {
            var result = new LinkedList<int>();

            while (left.Any() && right.Any())
            {
                if (left.FirstOrDefault() <= right.FirstOrDefault())
                {
                    result.AddFirst(left.FirstOrDefault());
                    left.RemoveFirst();
                }
                else
                {
                    result.AddFirst(right.FirstOrDefault());
                    right.RemoveFirst();
                }
            }

            while (left.Any())
            {
                result.AddFirst(left.FirstOrDefault());
                left.RemoveFirst();
            }

            while (right.Any())
            {
                result.AddFirst(right.FirstOrDefault());
                right.RemoveFirst();
            }
            return result;
        }
    }

}
