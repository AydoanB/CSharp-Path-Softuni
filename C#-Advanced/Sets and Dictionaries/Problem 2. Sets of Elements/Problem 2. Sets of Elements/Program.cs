using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sum = input[0] + input[1];
            HashSet<int> n = new HashSet<int>();
            HashSet<int> m = new HashSet<int>();
            List<int> a = new List<int>();

            for (int j = 0; j < input[0]; j++)
            {
                n.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < input[1]; i++)
            {
                m.Add(int.Parse(Console.ReadLine()));
            }

            foreach (var ns in n)

            {
                foreach (var ms in m)
                {
                    if (ns == ms)
                    {

                        a.Add(ns);
                    }
                }
            }

            foreach (var ass in a)
            {
                n.Remove(ass);
            }

            foreach (var num in a)
            {
                Console.Write($"{num} ");
            }

        }
    }
}
