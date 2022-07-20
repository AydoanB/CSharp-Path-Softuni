
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Artillery.Data.Models.Enums;
using Artillery.DataProcessor.ExportDto;
using Newtonsoft.Json;

namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using System;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var shellsForExport = context.Shells
                .Where(s => s.ShellWeight > shellWeight)
                .Select(s => new ExportShellsDto()
                {
                    ShellWeight = s.ShellWeight,
                    Caliber = s.Caliber,
                    Guns = s.Guns.Where(g => g.GunType == GunType.AntiAircraftGun)
                    .Select(g => new GunsExportDto()
                    {
                        GunType = g.GunType.ToString(),
                        GunWeight = g.GunWeight,
                        BarrelLength = g.BarrelLength,
                        Range = g.Range > 3000 ? "Long-range" : "Regular range"

                    }).OrderByDescending(g => g.GunWeight).ToList()

                }).OrderBy(s => s.ShellWeight).ToList();

            return JsonConvert.SerializeObject(shellsForExport, Formatting.Indented);
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            var data = context.Guns
                .Where(g => g.Manufacturer.ManufacturerName == manufacturer)
                .Select(g => new ExportGunsDto()
                {
                    Manufacturer = g.Manufacturer.ManufacturerName,
                    GunType = g.GunType.ToString(),
                    GunWeight = g.GunWeight,
                    BarrelLength = g.BarrelLength,
                    Range = g.Range,
                    Countries = g.CountriesGuns.Where(c => c.Country.ArmySize > 4500000)
                        .Select(c => new ExportCountriesXml()
                        {
                            Country = c.Country.CountryName,
                            ArmySize = c.Country.ArmySize
                        }).OrderBy(c => c.ArmySize).ToArray()

                })
                .OrderBy(g => g.BarrelLength)
                .ToList();

            return XmlConverter.Serialize(data, "Guns");
        }
    }
}
