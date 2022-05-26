using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> geo = new Dictionary<string, Dictionary<string, List<string>>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inp = Console.ReadLine().Split();
                string continent = inp[0];
                string country = inp[1];
                string city = inp[2];

                if (!geo.ContainsKey(continent))
                {
                    geo.Add(continent, new Dictionary<string, List<string>>());
                    geo[continent].Add(country, new List<string>());
                    geo[continent][country].Add(city);
                }

               else if (!geo[continent].ContainsKey(country))
                {
                    geo[continent].Add(country, new List<string>());
                    geo[continent][country].Add(city);

                }

                else
                {
                    geo[continent][country].Add(city);
                }


            }
            foreach (var shop in geo)
            {
                Console.WriteLine($"{shop.Key}:");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"{product.Key} -> {string.Join(", ", product.Value)}");
                }
            }
        }
    }
}
