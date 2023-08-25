using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SalesDataAnalysis.Helpers
{
    /// <summary>
    /// Helper for working with xml files
    /// </summary>
    public static class XmlHelper
    {
        /// <summary>
        /// Serializes a xml document
        /// </summary>
        /// <param name="entity">The xml file</param>
        /// <typeparam name="T">Model, which the file should be Serialized from</typeparam>
        /// <returns>string</returns>
        public static string Serialize<T>(T entity) where T : class
        {
            try
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
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Deserializes a Xml file
        /// </summary>
        /// <param name="filePath">path to the xml file</param>
        /// <typeparam name="T">Model, which the file should be deserialize to</typeparam>
        /// <returns>T</returns>
        public static T Deserialize<T>(string filePath) where T : class
        {
            try
            {
                using var reader = new StreamReader(filePath);
                return (T) new XmlSerializer(typeof(T)).Deserialize(reader);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}