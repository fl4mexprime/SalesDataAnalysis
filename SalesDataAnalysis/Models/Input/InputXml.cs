using System.Xml.Serialization;

namespace SalesDataAnalysis.Models.Input
{
    [XmlRoot(ElementName = "input"), XmlType("input")]
    public class InputXml
    {
        [XmlElement("company")]
        public Company[] Company { get; set; }
    }
}