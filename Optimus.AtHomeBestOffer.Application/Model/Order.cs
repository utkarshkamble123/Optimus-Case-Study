namespace Optimus.AtHomeBestOffer.Application.Model
{
    public class Order
    {
        public string SourceAddress { get; set; } = string.Empty;
        public string DestinationAddress { get; set; } = string.Empty;
        public List<Dimensions> CartonDimensions { get; set; } = new();
    }
}