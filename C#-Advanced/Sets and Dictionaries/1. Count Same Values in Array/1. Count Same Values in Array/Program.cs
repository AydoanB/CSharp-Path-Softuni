using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Dictionary<double, int> occurencesDict = new Dictionary<double, int>();
            int elCounter = 0;
            foreach (var el in input)
            {
                if (!occurencesDict.ContainsKey(el))
                {
                    occurencesDict[el] = 1;
                }
                else
                {
                    occurencesDict[el]++;
                }
            }

            foreach (var dob in occurencesDict)
            {
                Console.WriteLine($"{dob.Key} - {dob.Value} times");
            }



        }
    }
}
