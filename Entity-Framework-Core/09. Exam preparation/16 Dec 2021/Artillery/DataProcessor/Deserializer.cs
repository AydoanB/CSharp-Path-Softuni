using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Artillery.Data.Models;
using Artillery.Data.Models.Enums;
using Artillery.DataProcessor.ImportDto;
using AutoMapper;
using Newtonsoft.Json;

namespace Artillery.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Artillery.Data;

    public class Deserializer
    {
        public static IMapper mapper;
        private static void InitliazeMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ArtilleryProfile>();
            });
            mapper = config.CreateMapper();
        }

        private const string ErrorMessage =
                "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            var sb = new StringBuilder();
            InitliazeMapper();
            var xmlDeserializer = XmlConverter.Deserializer<ImportCountriesDto>(xmlString, "Countries");

            foreach (var country in xmlDeserializer)
            {
                if (!IsValid(country))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                context.Countries.Add(new Country()
                {
                    CountryName = country.CountryName,
                    ArmySize = country.ArmySize
                });
                context.SaveChanges();
                sb.AppendLine(string.Format(SuccessfulImportCountry, country.CountryName, country.ArmySize));

            }

            return sb.ToString().TrimEnd();

        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var xmlDeserializer = XmlConverter.Deserializer<ImportManufacturersDto>(xmlString, "Manufacturers");
            foreach (var jsonManufacturer in xmlDeserializer)
            {
                bool isExist = context.Manufacturers.Any(m => m.ManufacturerName == jsonManufacturer.ManufacturerName);
                if (!IsValid(jsonManufacturer) || isExist)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var foundedSplit = jsonManufacturer.Founded.Split(", ");
                string country = foundedSplit[foundedSplit.Length - 1];
                string town = foundedSplit[foundedSplit.Length - 2];
                var manufacturer = new Manufacturer()
                {
                    ManufacturerName = jsonManufacturer.ManufacturerName,
                    Founded = jsonManufacturer.Founded
                };
                context.Manufacturers.Add(manufacturer);
                context.SaveChanges();
                sb.AppendLine(string.Format(SuccessfulImportManufacturer, manufacturer.ManufacturerName,
                    $"{town}, {country}"));
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            var xmlDeserialized = XmlConverter.Deserializer<ImportShellsDto>(xmlString, "Shells");
            var sb = new StringBuilder();
            foreach (var jsonShell in xmlDeserialized)
            {
                if (!IsValid(jsonShell))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var shell = new Shell()
                {
                    Caliber = jsonShell.Caliber,
                    ShellWeight = jsonShell.ShellWeight
                };
                context.Shells.Add(shell);
                context.SaveChanges();
                sb.AppendLine(string.Format(SuccessfulImportShell, shell.Caliber, shell.ShellWeight));

            }
            return sb.ToString().TrimEnd();

        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var jsonDeserialized = JsonConvert.DeserializeObject<List<ImportGunsDto>>(jsonString);
            foreach (var jsonGun in jsonDeserialized)
            {
                bool guntypeString = Enum.TryParse<GunType>(jsonGun.GunType, out GunType gunType);
                if (!IsValid(jsonGun) || !guntypeString)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var gun = new Gun()
                {
                    ManufacturerId = jsonGun.ManufacturerId,
                    GunWeight = jsonGun.GunWeight,
                    BarrelLength = jsonGun.BarrelLength,
                    NumberBuild = jsonGun.NumberBuild,
                    Range = jsonGun.Range,
                    GunType = gunType,
                    ShellId = jsonGun.ShellId,
                    CountriesGuns = jsonGun.Countries.Select(c => new CountryGun()
                    {
                        CountryId = c.Id,
                    }).ToList()
                };
                context.Guns.Add(gun);
                context.SaveChanges();
                sb.AppendLine(string.Format(SuccessfulImportGun, gunType.ToString(), gun.GunWeight, gun.BarrelLength));
            }

            return sb.ToString().TrimEnd();

        }
        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
