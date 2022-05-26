using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            int newGunSize = gunBarrelSize;
            int bulletCounter = 0;

            int[] bulletsArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locksArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int valueOfIntelligenceArray = int.Parse(Console.ReadLine());

            Stack<int> bulletStack = new Stack<int>(bulletsArray);
            Queue<int> locksQueue = new Queue<int>(locksArray);

            while (locksQueue.Any()&&bulletStack.Any())
            {
                if (bulletStack.Peek() <= locksQueue.Peek())
                {
                    Console.WriteLine("Bang!");
                    bulletStack.Pop();
                    locksQueue.Dequeue();

                    newGunSize--;
                    bulletCounter++;
                }
                else
                {
                    Console.WriteLine("Ping!");
                    bulletStack.Pop();

                    newGunSize--;
                    bulletCounter++;
                }

                if (newGunSize == 0 && bulletStack.Any())
                {
                    Console.WriteLine("Reloading!");
                    newGunSize = gunBarrelSize;
                }

               
            }

            int bulletCost = bulletPrice * bulletCounter;
            int moneyEarned = valueOfIntelligenceArray - bulletCost;
            if (!locksQueue.Any())
            {
                Console.WriteLine($"{bulletStack.Count} bullets left. Earned ${moneyEarned}");
            }

            if (locksQueue.Any() && !bulletStack.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");


            }

        }
    }
}
