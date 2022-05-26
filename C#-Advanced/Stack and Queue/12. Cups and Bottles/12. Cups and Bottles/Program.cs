using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] in1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] in2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int wastedWater = 0;

            Queue<int> cups = new Queue<int>(in1);
            Stack<int> bottles = new Stack<int>(in2);


            bool flag = false;
            bool noBottles = false;
            var currCup = 0;

            while (true)
            {
                if (!cups.Any())
                {
                    flag = true;
                    break;
                }
                else if (!bottles.Any())
                {
                    noBottles = true;
                    break;
                }

                int currBottle = bottles.Peek();
               
                if (currCup <= 0)
                {
                    currCup = cups.Peek();
                }

                if (currBottle >= currCup)
                {
                    wastedWater += (currBottle - currCup);
                    currCup = 0;
                    bottles.Pop();
                    cups.Dequeue();
                }
                else
                {
                    currCup -= currBottle;
                    bottles.Pop();

                }
            }

            if (flag == true)
            {
                Console.WriteLine($"Bottles: {0}", String.Join(" ", bottles.Count));
            }

            else if (noBottles == true)
            {
                Console.WriteLine($"Cups: {0}", String.Join(" ", cups.Count));
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");


        }
    }
}
