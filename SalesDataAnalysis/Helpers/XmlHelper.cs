using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SalesDataAnalysis.Helpers
{
    public static class XmlHelper
    {
        public static string Serialize<T>(T entity) where T : class
        {
            // Removes version
            var settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true
            };

            var xmlSerializer = new XmlSerializer(typeof(T));
            using var stringWriter = new StringWriter();
            using var xmlWriter = XmlWriter.Create(stringWriter, settings);
            
            // Removes namespace
            var xmlns = new XmlSerializerNamespaces();
            xmlns.Add(string.Empty, string.Empty);
            xmlSerializer.Serialize(xmlWriter, entity, xmlns);

            // Parse string as XDocument, so we get the correct file formatting and indentation in the resulting file
            var doc = XDocument.Parse(stringWriter.ToString());
            return doc.ToString();
        }
    }
}