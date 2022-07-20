using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using ProductShop.XmlConverter;

namespace ProductShop
{
    public class StartUp
    {
        static IMapper mapper;
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
            db.Database.EnsureCreated();
            // Console.WriteLine(ImportUsers(db, "users.xml"));
            //Console.WriteLine(ImportProducts(db, "products.xml"));
            // Console.WriteLine(ImportCategories(db, "categories.xml"));
            // Console.WriteLine(ImportCategoryProducts(db, "categories-products.xml"));
            Console.WriteLine(GetSoldProducts(db));

        }
        private static void InitliazeMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
            mapper = config.CreateMapper();
        }
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            InitliazeMapper();

            var serialized =
                XmlConvert.Deserializer<ImportUsersDto>(File.ReadAllText("../../../Datasets/" + inputXml), "Users");


            var users = mapper.Map<IEnumerable<User>>(serialized);

            context.Users.AddRange(users);
            context.SaveChanges();
            return $"Succesfully imported {users.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            InitliazeMapper();

            var serialized =
                XmlConvert.Deserializer<ImportProductsDto>(File.ReadAllText("../../../Datasets/" + inputXml),
                    "Products").Where(x => context.Users.Any(u => u.Id == x.BuyerId) || context.Users.Any(u => u.Id == x.SellerId));
            var products = mapper.Map<IEnumerable<Product>>(serialized);


            context.Products.AddRange(products);
            context.SaveChanges();
            return $"Succesfully imported {products.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            InitliazeMapper();

            var serialized =
                XmlConvert.Deserializer<ImportCategoryDto>(File.ReadAllText("../../../Datasets/" + inputXml), "Categories").Where(c => c.Name != null);
            var categories = mapper.Map<IEnumerable<Category>>(serialized);


            context.Categories.AddRange(categories);
            context.SaveChanges();
            return $"Succesfully imported {categories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            InitliazeMapper();

            var serialized =
                XmlConvert.Deserializer<ImportCategoriesAndProductsDto>(
                        File.ReadAllText("../../../Datasets/" + inputXml), "CategoryProducts")
                    .Where(cp =>
                        context.Categories.Any(c => c.Id == cp.CategoryId) &&
                        context.Products.Any(p => p.Id == cp.ProductId));

            var categories = mapper.Map<IEnumerable<CategoryProduct>>(serialized);


            context.CategoryProducts.AddRange(categories);
            context.SaveChanges();
            return $"Succesfully imported {categories.Count()}";
        }

        //Export
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(x => x.Price)
                .Take(10)
                .Select(p => new ExportProductsInRangeDto()
                {
                    Name = p.Name,
                    Price = p.Price,
                    BuyerFullName = p.Buyer.FirstName + " " + p.Buyer.LastName
                }).ToList();
            var serialized = XmlConvert.Serialize(products, "Products");
            File.WriteAllText("products-in-range.xml", serialized);
            return serialized;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var products = context.Users
                .Where(u => u.ProductsSold.Count > 0)
                .OrderBy(u => u.LastName).ThenBy(u => u.FirstName)
                .Take(5)
                .Select(u => new ExportSoldProductsDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold.Select(p => new ExportProductDto()
                    {
                        Name = p.Name,
                        Price = p.Price
                    }).ToArray()

                }).ToList();


            var serialized = XmlConvert.Serialize(products, "Users");
            File.WriteAllText("users-sold-products.xml", serialized);
            return serialized;
        }
    }
}