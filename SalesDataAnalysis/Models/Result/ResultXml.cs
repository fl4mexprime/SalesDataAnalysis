using System.Collections.Generic;
using System.Xml.Serialization;

namespace SalesDataAnalysis.Models.Result
{
    [XmlRoot(ElementName = "results"), XmlType("results")]
    public class ResultXml
    {
        [XmlElement("result")]
        public List<ResultModel> Result { get; set; }
    }
}