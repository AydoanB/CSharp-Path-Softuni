using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Birthday_CelebrationNewOne
{
    class Program
    {
        static void Main(string[] args)
        {
            int wastedFood = 0;
            Queue<int> eatingCapacity = new Queue<int>(Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            Stack<int> plates = new Stack<int>(Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            while (eatingCapacity.Any() || plates.Any())
            {
                int guest = eatingCapacity.Peek();
                int plate = plates.Peek();
                if (guest <= 0)
                {
                    eatingCapacity.Dequeue();
                }

                if (guest > plate)
                {
                    plates.Pop();
                }
                else if (plate >= guest)
                {
                    eatingCapacity.Dequeue();
                    wastedFood += plate - guest;
                }

                if (eatingCapacity.Count <= 0 || plates.Count <= 0) break;
            }

            if (eatingCapacity.Any())
            {
                Console.WriteLine($"Guests: {0}", string.Join(" ", eatingCapacity));
            }
            else
            {
                Console.WriteLine($"Plates: {0}", string.Join(" ", plates));
            }

            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
