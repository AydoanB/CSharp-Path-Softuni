using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Manufacturer")]
    public class ImportManufacturersDto
    {
        [XmlElement("ManufacturerName")]
        [StringLength(40),MinLength(4)]
        [Required]
        public string ManufacturerName { get; set; }

        [XmlElement("Founded")]
        [StringLength(100), MinLength(10)]
        [Required]
        public string Founded { get; set; }
    }
}