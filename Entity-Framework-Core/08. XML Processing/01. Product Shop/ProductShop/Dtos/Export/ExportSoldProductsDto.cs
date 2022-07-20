using System.Collections.Generic;
using System.Xml.Serialization;
using ProductShop.Models;

namespace ProductShop.Dtos.Export
{
    [XmlType ("User")]
    public class ExportSoldProductsDto
    {
        [XmlElement ("firstName")] 
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("soldProducts")]
       public ExportProductDto[] SoldProducts { get; set; }
    }

    [XmlType("Product")]
    public class ExportProductDto
    {
        [XmlElement ("name")] 
        public string Name { get; set; }

        [XmlElement ("price")] 
        public decimal Price { get; set; }
    }
}