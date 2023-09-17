using System.Xml.Serialization;

namespace Company3.Api.Model
{
    public class Package
    {
        [XmlElement(ElementName = "length")]
        public float Length { get; set; }

        [XmlElement(ElementName = "width")]
        public float Width { get; set; }

        [XmlElement(ElementName = "height")]
        public float Height { get; set; }
    }
}