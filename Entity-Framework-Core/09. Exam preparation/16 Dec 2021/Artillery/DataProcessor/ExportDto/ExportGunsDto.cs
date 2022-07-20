using System.Collections.Generic;
using System.Xml.Serialization;
using Artillery.Data.Models.Enums;

namespace Artillery.DataProcessor.ExportDto
{
    [XmlType("Gun")]
    public class ExportGunsDto
    {
        [XmlAttribute ("Manufacturer")]
        public string Manufacturer { get; set; }

        [XmlAttribute("GunType")] 
        public string GunType { get; set; }

        [XmlAttribute("GunWeight")]
        public int GunWeight { get; set; }

        [XmlAttribute("BarrelLength")] 
        public double BarrelLength { get; set; }

        [XmlAttribute("Range")] 
        public int Range{ get; set; }

        [XmlArray("Countries")]
        public ExportCountriesXml[] Countries { get; set; }

    }
    [XmlType("Country")]
    public class ExportCountriesXml
    {
        [XmlAttribute("Country")]
        public string Country { get; set; }

        [XmlAttribute("ArmySize")] 
        public int ArmySize { get; set; }
    }
}