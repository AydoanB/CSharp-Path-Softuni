using System;
using System.Collections.Generic;
using System.Linq;

namespace Fast_Foods___new
{
    class Program
    {
        static void Main(string[] args)
        {
            var ordersQueue = new Queue<int>();
            int foodQuantity = int.Parse(Console.ReadLine());
            var orders = Console.ReadLine().Split().Select(int.Parse).ToList();




            for (int i = 0; i < orders.Count; i++)
            {
                ordersQueue.Enqueue(orders[i]);
            }

            Console.WriteLine(ordersQueue.Max());

            while(ordersQueue.Peek() <= foodQuantity)
            {
                var temp = ordersQueue.Peek();
                foodQuantity -= temp;
                ordersQueue.Dequeue();
                if (foodQuantity < temp)
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", ordersQueue)}");
                    break;
                }
            }

            if (ordersQueue.Count == 0)
            {
                Console.WriteLine("Orders complete.");
            }




        }
    }
}
