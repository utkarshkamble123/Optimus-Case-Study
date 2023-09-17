namespace Company2.Api.Model
{
    public class Order : ProposedOffer
    {
        public string Consignee { get; set; } = string.Empty;
        public string Consignor { get; set; } = string.Empty;
        public List<Dimensions> Cartons { get; set; } = new();
    }
}