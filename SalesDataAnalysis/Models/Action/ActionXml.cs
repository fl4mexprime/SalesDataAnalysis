using System.Xml.Serialization;

namespace SalesDataAnalysis.Models.action
{
    [XmlRoot(ElementName = "actions"), XmlType("actions")]
    public class ActionXml
    {
        [XmlElement("action")]
        public Action[] Actions { get; set; }
    }
}