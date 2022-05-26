using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, List<decimal>>();
            double totalGrade = 0;
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                decimal grade = decimal.Parse(input[1]);


                if (!dict.ContainsKey(name))
                {
                    dict.Add(name, new List<decimal>());
                }
                dict[name].Add(grade);

            }

            foreach (var person in dict)
            {
                Console.WriteLine($"{person.Key} -> {string.Join(" ", person.Value)} (avg: {(person.Value.Average()):f2})");
            }
        }
    }
}
