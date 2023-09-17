namespace Company3.Api.Infrastructure
{
    using Microsoft.AspNetCore.Mvc.Formatters;
    using System.Xml;
    using System.Xml.Serialization;

    public class XmlSerializerOutputFormatterNamespace : XmlSerializerOutputFormatter
    {
        protected override void Serialize(XmlSerializer xmlSerializer, XmlWriter xmlWriter, object value)
        {
            //applying "empty" namespace will produce no namespaces
            var emptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(xmlWriter, value, emptyNamespaces);
        }
    }
}