using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _1._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            var stack = new Stack<int>();

            int N = input[0];
            int S = input[1];
            int X = input[2];

            var arr = new int[N];

            arr = Console.ReadLine().Split().Select(int.Parse).ToArray();


            for (int i = 0; i < N; i++)
            {
                stack.Push(arr[i]);
            }

            for (int i = 0; i < S; i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                if (stack.Contains(X))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    stack.ToArray();
                    Console.WriteLine(stack.Min());
                }
            }
           

           
        }


    }
}
