using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType ("Country")]
    public class ImportCountriesDto
    {
        [XmlElement ("CountryName")]
        [MinLength(4)]
        [MaxLength(60)]
        [Required]
        public string CountryName { get; set; }

        [XmlElement ("ArmySize")]
        [Range(50_000,10_000_000)]
        [Required]
        public int ArmySize { get; set; }
    }
}