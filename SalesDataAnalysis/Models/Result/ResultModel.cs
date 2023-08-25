using System.Xml.Serialization;

namespace SalesDataAnalysis.Models.Result
{
    public class ResultModel
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        
        [XmlText]
        public decimal Value { get; set; }
    }
}