using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export
{
    [XmlType("User")]
    public class ExportUserAndPurchasesDto
    {
        [XmlAttribute("username")]
        public string Username { get; set; }

        public ExportPurchasesForUserDto[] Purchases { get; set; }

        [XmlElement("TotalSpent")]
        public decimal TotalSpent { get; set; }
    }
    [XmlType("Purchase")]
    public class ExportPurchasesForUserDto
    {
        [XmlElement("Card")]
        public string Card { get; set; }

        [XmlElement("Cvc")]
        public string Cvc { get; set; }

        [XmlElement("Date")]
        public string Date { get; set; }


        [XmlArray("Purchases")]
        public ExportGamesInPurchasesDto Game { get; set; }

       
    }

    public class ExportGamesInPurchasesDto
    {
        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlElement("Genre")]
        public string Genre { get; set; }

        [XmlElement("Price")]
        public decimal Price { get; set; }
    }
}