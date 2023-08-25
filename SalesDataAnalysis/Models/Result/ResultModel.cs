using System.Xml.Serialization;

namespace SalesDataAnalysis.Models.Result
{
    public class ResultModel
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("result")]
        public decimal Result { get; set; }
    }
}