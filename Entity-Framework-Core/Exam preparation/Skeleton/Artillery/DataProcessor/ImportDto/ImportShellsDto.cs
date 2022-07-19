using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Shell")]
    public class ImportShellsDto
    {
        [XmlElement("ShellWeight")]
        [Range(2,1_680)]
        [Required]
        public double ShellWeight { get; set; }

        [XmlElement("Caliber")]
        [StringLength(30),MinLength(4)]
        [Required]
        public string Caliber { get; set; }

    }
}