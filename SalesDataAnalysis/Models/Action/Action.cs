using System.Xml.Serialization;

namespace SalesDataAnalysis.Models.action
{
    [XmlRoot(ElementName = "action"), XmlType("action")]
    public class Action
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlAttribute("function")]
        public string Function { get; set; }

        [XmlAttribute("source")]
        public string Source { get; set; }

        [XmlAttribute("filter")]
        public string Filter { get; set; }
    }
}