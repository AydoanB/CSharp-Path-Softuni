using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int rackCounter = 1;
            var racks = new Stack<int>();

            var clothesInBox = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            int rackCapacity = int.Parse(Console.ReadLine());


            for (int i = 0; i < clothesInBox.Count; i++)
            {
                racks.Push(clothesInBox[i]);
            }

            while (racks.Count > 0)
            {

                sum += racks.Peek();

                if (sum <= rackCapacity)
                {
                    racks.Pop();
                }
                else
                {
                    rackCounter++;
                    sum = 0;
                }
            }
            Console.WriteLine(rackCounter);
        }

    }
}



