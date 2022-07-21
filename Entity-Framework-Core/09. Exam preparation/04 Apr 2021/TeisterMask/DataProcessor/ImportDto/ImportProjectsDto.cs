using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Project")]
    public class ImportProjectsDto
    {
        [XmlElement("Name")]
        [Required]
        [StringLength(40), MinLength(2)]
        public string Name { get; set; }

        [XmlElement("OpenDate")]
        [Required]
        public string OpenDate { get; set; }

        [XmlElement("DueDate")]
        public string DueDate { get; set; }

        [XmlArray("Tasks")]
        public ImportTasksDto[] Tasks { get; set; }
    }

    [XmlType("Task")]
    public class ImportTasksDto
    {
        [XmlElement("Name")]
        [Required]
        [StringLength(40), MinLength(2)]
        public string Name { get; set; }

        [XmlElement("OpenDate")]
        [Required]
        public string OpenDate { get; set; }

        [XmlElement("DueDate")]
        [Required]
        public string DueDate { get; set; }

        [XmlElement("ExecutionType")]
        [Required]
        public string ExecutionType { get; set; }

        [XmlElement("LabelType")]
        [Required]
        public string LabelType { get; set; }
    }
}