using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Play")]
    public class ImportPlaysDto
    {
        [XmlElement("Title")]
        [StringLength(50), MinLength(4)]
        [Required]
        public string Title { get; set; }

        [XmlElement("Duration")]
        [Required]
        public string Duration { get; set; }

        [XmlElement("Rating")]
        [Range(0.00, 10.00)]
        [Required]
        public float Rating { get; set; }

        [XmlElement("Genre")]
        public string Genre { get; set; }

        [XmlElement("Description")]
        [StringLength(700)]
        [Required]
        public string Description { get; set; }

        [XmlElement("Screenwriter")]
        [StringLength(30), MinLength(4)]
        [Required]
        public string Screenwriter { get; set; }
    }
}