using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Teaq;

namespace CarDealer
{

    public class StartUp
    {
        private static IMapper mapper;
        public static void Main(string[] args)
        {
            var contex = new CarDealerContext();
            contex.Database.EnsureCreated();
            //Console.WriteLine(ImportSuppliers(contex, "suppliers.json"));
            //Console.WriteLine(ImportParts(contex, "parts.json"));
            //Console.WriteLine(ImportCars(contex, "cars.json"));
            //Console.WriteLine(ImporCustomers(contex, "customers.json"));
            // Console.WriteLine(ImporSales(contex, "sales.json"));

            Console.WriteLine(GetSalesWithAppliedDiscount(contex));
        }

        private static void InitializeMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());
            mapper = config.CreateMapper();
        }
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            InitializeMapper();
            var file = File.ReadAllText(@"../../../Datasets/" + inputJson);
            var data = JsonConvert.DeserializeObject<IEnumerable<SupplierInputModel>>(file);
            var suppliers = mapper.Map<IEnumerable<Supplier>>(data);
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {data.Count()}";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            InitializeMapper();

            var file = File.ReadAllText(@"../../../Datasets/" + inputJson);

            var data = JsonConvert.DeserializeObject<IEnumerable<PartInputModel>>(file)
                .Where(x => context.Suppliers.Any(y => y.Id == x.SupplierId));
            var parts = mapper.Map<IEnumerable<Part>>(data);

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            InitializeMapper();

            var file = File.ReadAllText(@"../../../Datasets/" + inputJson);

            var carsDTOs = JsonConvert.DeserializeObject<IEnumerable<CarInputModel>>(file);

            foreach (var carDto in carsDTOs)
            {
                var car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                context.Cars.Add(car);

                foreach (var partId in carDto.partsId)
                {
                    var partCar = new PartCar
                    {
                        CarId = car.Id,
                        PartId = partId
                    };

                    if (car.PartCars.FirstOrDefault(pc => pc.PartId == partId) == null)
                    {
                        context.PartCars.Add(partCar);
                    }
                }
            }

            context.SaveChanges();

            return $"Successfully imported {carsDTOs.Count()}.";
        }
        public static string ImporCustomers(CarDealerContext context, string inputJson)
        {
            InitializeMapper();

            var file = File.ReadAllText(@"../../../Datasets/" + inputJson);

            var data = JsonConvert.DeserializeObject<IEnumerable<CustomerInputModel>>(file);
            var customers = mapper.Map<IEnumerable<Customer>>(data);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}";
        }
        public static string ImporSales(CarDealerContext context, string inputJson)
        {
            InitializeMapper();

            var file = File.ReadAllText(@"../../../Datasets/" + inputJson);

            var data = JsonConvert.DeserializeObject<IEnumerable<SaleInputModel>>(file);
            var sales = mapper.Map<IEnumerable<Sale>>(data);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate).ThenByDescending(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();

            var serialized = JsonConvert.SerializeObject(customers, Injector.settings);
            File.WriteAllText("ordered-customers.json", serialized);
            return serialized;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var toyotaCars = context.Cars
                 .Where(c => c.Make == "Toyota")
                 .OrderBy(c => c.Model).ThenByDescending(c => c.TravelledDistance)
                 .Select(c => new
                 {
                     c.Id,
                     c.Make,
                     c.Model,
                     c.TravelledDistance
                 }).ToList();

            var serialized = JsonConvert.SerializeObject(toyotaCars, Injector.settings);
            File.WriteAllText("ordered-customers.json", serialized);
            return serialized;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var salesWithDiscount = context.Sales
                .Take(10)
                .Select(s => new
                {
                    car = new
                    {
                        s.Car.Make,
                        s.Car.Model,
                        s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    s.Discount,
                    price = s.Car.PartCars.Sum(x => x.Part.Price),
                    priceWithDiscount = s.Car.PartCars.Sum(x => x.Part.Price) - (s.Car.PartCars.Sum(x => x.Part.Price)*s.Discount / 100)
                }).ToList();

            var serialized = JsonConvert.SerializeObject(salesWithDiscount, Injector.settings);
            File.WriteAllText("sales-discount.json", serialized);
            return serialized;
        }
    }
}