using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    [XmlType("Purchase")]
    public class ImportPurchasesDto
    {
        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlElement("Type")]
        [Required]
        public string Type { get; set; }

        [XmlElement("Key")]
        [RegularExpression(@"^([A-Za-z0-9]{4})(-[A-Za-z0-9]{4}){2}")]
        public string Key { get; set; }

        [XmlElement("Card")]
        [Required]
        [RegularExpression(@"(^\d{4})( \d{4}){3}")]
        public string Card { get; set; }

        [XmlElement("Date")] 
        [Required]
        public string Date { get; set; }
    }
}