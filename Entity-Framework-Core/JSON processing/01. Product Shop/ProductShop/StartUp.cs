using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Stopwatch s = new Stopwatch();
            var db = new ProductShopContext();

            s.Start();
            var users =  ImportUsers(db,
                "users.json");

            var products =  ImportUsers(db,
                "products.json");

            var categories =  ImportUsers(db,
                "categories.json");
            
            var categoriesProducts =  ImportUsers(db,
                "categories-products.json");
            
            
            //Console.WriteLine(users);
            //Console.WriteLine(products);
            //Console.WriteLine(categories);
            //Console.WriteLine(categoriesProducts);

            db.SaveChanges();
            s.Stop();
            Console.WriteLine(s.Elapsed.Milliseconds);
        }
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(@"C:\Users\Aiduan\Desktop\Softuni\github\CSharp-Path-Softuni\Entity-Framework-Core\JSON processing\01. Product Shop\ProductShop\Datasets\" + inputJson));

            return $"Successfully imported {users.Count}";
        }
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(@"C: \Users\Aiduan\Desktop\Softuni\github\CSharp - Path - Softuni\Entity - Framework - Core\JSON processing\01.Product Shop\ProductShop\Datasets\" + inputJson));

            return $"Successfully imported {products.Count}";
        }
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<List<Category>>(File.ReadAllText(@"C: \Users\Aiduan\Desktop\Softuni\github\CSharp - Path - Softuni\Entity - Framework - Core\JSON processing\01.Product Shop\ProductShop\Datasets\"+inputJson));

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts =  JsonConvert.DeserializeObject<List<CategoryProduct>>(File.ReadAllText(@"C: \Users\Aiduan\Desktop\Softuni\github\CSharp - Path - Softuni\Entity - Framework - Core\JSON processing\01.Product Shop\ProductShop\Datasets\" + inputJson));

            return $"Successfully imported {categoryProducts.Count}";
        }
    }
}