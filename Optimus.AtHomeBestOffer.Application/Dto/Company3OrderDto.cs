using Optimus.AtHomeBestOffer.Application.Model;
using System.Xml.Serialization;

namespace Optimus.AtHomeBestOffer.Application.Dto
{
    [XmlRoot(ElementName = "xml", Namespace = "")]
    public class Company3OrderDto
    {
        [XmlElement(ElementName = "source")]
        public string Source { get; set; } = string.Empty;

        [XmlElement(ElementName = "destination")]
        public string Destination { get; set; } = string.Empty;

        [XmlArray(ElementName = "packages"), XmlArrayItem("package")]
        public List<Package> Packages { get; set; } = new();
    }
}