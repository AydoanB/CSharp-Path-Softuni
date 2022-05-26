using System;
using System.Collections.Generic;
using _03.PriorityQueue;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new PriorityQueue<int>();
            var elements = new List<int>() { 15, 25, 6, 9, 5, 8, 17, 16 };
            foreach (var element in elements)
            {
                queue.Add(element);
            }

            while (queue.Size > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}
