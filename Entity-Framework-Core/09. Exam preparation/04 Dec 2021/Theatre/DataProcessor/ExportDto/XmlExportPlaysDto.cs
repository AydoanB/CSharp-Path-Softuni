using System.Xml.Serialization;

namespace Theatre.DataProcessor.ExportDto
{
    [XmlType("Play")]
    public class XmlExportPlaysDto
    {
        [XmlAttribute("Title")]
        public string Title { get; set; }

        [XmlAttribute("Duration")]
        public string Duration { get; set; }

        [XmlAttribute("Rating")]
        public string Rating { get; set; }

        [XmlAttribute("Genre")]
        public string Genre { get; set; }

        [XmlArray]
        public ExportActorsDto[] Actors { get; set; }
    }

    [XmlType("Actor")]
    public class ExportActorsDto
    {
        [XmlAttribute("FullName")] 
        public string FullName { get; set; }

        [XmlAttribute("MainCharacter")] 
        public string MainCharacter { get; set; }
    }
}