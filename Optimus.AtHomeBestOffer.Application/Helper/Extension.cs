using System.Xml;
using System.Xml.Serialization;

namespace Optimus.AtHomeBestOffer.Application.Helper
{
    public static class Extension
    {
        public static string SerializeToXML<T>(this T value)
        {
            var emptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(value.GetType());
            var settings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = true
            };

            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, value, emptyNamespaces);
                var txt = stream.ToString();
                return txt;
            }
        }

        public static T DeserializeFromXML<T>(this string xmlText)
        {
            using var stringReader = new StringReader(xmlText);
            var serializer = new XmlSerializer(typeof(T));
            var obj = ((T)serializer.Deserialize(stringReader));
            return obj;
        }
    }
}