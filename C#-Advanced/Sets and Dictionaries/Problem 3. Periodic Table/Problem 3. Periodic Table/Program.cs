using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> table = new HashSet<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                foreach (var inp in input)
                {
                    table.Add(inp);
                }


            }

            foreach (var element in table.OrderBy(x => x))
            {
                Console.Write($"{element} ");
            }
        }
    }
}
