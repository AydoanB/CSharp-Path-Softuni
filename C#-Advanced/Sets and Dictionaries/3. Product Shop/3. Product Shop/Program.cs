using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shopDictionary =
                new Dictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string[] cmd = Console.ReadLine().Split(", ");
                string shop = cmd[0];
                

                if (shop == "Revision")
                {
                    break;
                }
                string product = cmd[1];
                double price = double.Parse(cmd[2]);
                if (!shopDictionary.ContainsKey(shop))
                {
                    shopDictionary.Add(shop,new Dictionary<string, double>());
                    shopDictionary[shop].Add(product, price);
                }
                else
                {
                    shopDictionary[shop].Add(product,price);
                }
            }
            foreach (var shop in shopDictionary.OrderBy(shop => shop.Key))
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }

        }
    }
}
