using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Models;
// ReSharper disable All

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            var db = new ProductShopContext();
            db.Database.EnsureDeleted();

            db.Database.EnsureCreated();

            var users = ImportUsers(db,
                "users.json");

            var products = ImportProducts(db,
                "products.json");

            var categories = ImportCategories(db,
                "categories.json");

            var categoriesProducts = ImportCategoryProducts(db,
                "categories-products.json");
            //Console.WriteLine(users);
            //Console.WriteLine(products);
            //Console.WriteLine(categories);
            //Console.WriteLine(categoriesProducts);

            Console.WriteLine(GetUsersWithProducts(db));

        }
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(inputJson));
            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(inputJson));
            context.Products.AddRange(products);
            context.SaveChanges();
            return $"Successfully imported {products.Count}";
        }
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<List<Category>>(File.ReadAllText(inputJson));
            context.Categories.AddRange(categories);
            context.SaveChanges();
            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(File.ReadAllText(inputJson));
            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var productForExport = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(product => new
                {
                    product.Name,
                    product.Price,
                    SellerFullName = $"{product.Seller.FirstName} {product.Seller.LastName}"
                })
                .OrderBy(p => p.Price)
                .ToList();
            var serialized = JsonConvert.SerializeObject(productForExport, Formatting.Indented);
            File.WriteAllText("products-in-range.json", serialized);


            return null;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var soldProducts = context.Users
                .Where(u => u.ProductsSold.Count > 0)
                .OrderBy(u => u.LastName).ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    soldProducts = u.ProductsSold
                        .Where(p => p.Buyer != null)
                        .Select(p => new
                        {
                            p.Name,
                            p.Price,
                            buyerFirstName = p.Buyer.FirstName,
                            buyerLastName = p.Buyer.LastName
                        })
                }).ToList();
            var setting = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };


            var serialized = JsonConvert.SerializeObject(soldProducts, setting);

            File.WriteAllText("user-sold-products.json", serialized);

            return serialized;
        }
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var grouped = context.CategoryProducts.GroupBy(x => x.Category)
                .Select(c => new
                {
                    c.Key.Name,
                    productsCount = c.Key.CategoryProducts.Count,
                    averagePrice = c.Key.CategoryProducts.Average(x => x.Product.Price).ToString("f2"),
                    totalRevenue = c.Key.CategoryProducts.Sum(x => x.Product.Price).ToString("f2")
                })
                .OrderByDescending(x => x.productsCount)
                .ToList();


            var setting = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };


            var serialized = JsonConvert.SerializeObject(grouped, setting);

            File.WriteAllText("categories-by-products.json", serialized);

            return serialized;
        }


        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersAndProducts = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .Select(u => new
                {
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold.Count(p => p.Buyer != null),
                        products = u.ProductsSold.Where(p => p.Buyer != null)
                            .Select(p => new
                            {
                                name = p.Name,
                                price = p.Price
                            }).ToList()
                    }
                })
                .OrderByDescending(x => x.soldProducts.products.Count())
                .ToList();

            var setting = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };

            var obj = new
            {
                usersCount = usersAndProducts.Count(),
                users = usersAndProducts
            };

            var serialized = JsonConvert.SerializeObject(obj, setting);

            File.WriteAllText("users-and-products.json", serialized);

            return serialized;
        }
    }
}