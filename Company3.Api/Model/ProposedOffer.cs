using System.Xml.Serialization;

namespace Company3.Api.Model
{
    [XmlRoot(ElementName = "xml", Namespace = "")]
    public class ProposedOffer
    {
        [XmlElement(ElementName = "quote")]
        public float? Quote { get; set; }
    }
}