namespace Company1.Api.Model
{
    public class Order : ProposedOffer
    {
        public string ContactAddress { get; set; } = string.Empty;
        public string WarehouseAddress { get; set; } = string.Empty;
        public List<Dimensions> PackageDimensions { get; set; } = new();
    }
}