using System;
using RealProductShop.Data;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RealProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new ProductShopContext();
            ImportUsers(db, "input.json");
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var v = JsonSerializer.Serialize(inputJson);

            return v.ToString();
        }
    }
}
