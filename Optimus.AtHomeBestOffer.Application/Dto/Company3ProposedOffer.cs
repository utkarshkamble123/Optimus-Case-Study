using System.Xml.Serialization;

namespace Optimus.AtHomeBestOffer.Application.Dto
{
    [XmlRoot(ElementName = "xml", Namespace = "")]
    public class Company3ProposedOffer
    {
        [XmlElement(ElementName = "quote")]
        public float? Quote { get; set; }
    }
}