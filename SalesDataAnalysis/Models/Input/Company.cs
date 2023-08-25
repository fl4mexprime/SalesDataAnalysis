using System.Xml.Serialization;

namespace SalesDataAnalysis.Models.Input
{
    [XmlRoot(ElementName = "company"), XmlType("company")]
    public class Company
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("employees")]
        public int Employees { get; set; }

        [XmlElement("outposts")]
        public int Outposts { get; set; }

        [XmlElement("salesVolume")]
        public decimal SalesVolume { get; set; }

        [XmlElement("profit")]
        public decimal Profit { get; set; }
    }
}