namespace Company3.Api.Model
{
    public class Order : ProposedOffer
    {
        public string Source { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public List<Package> Packages { get; set; } = new();
    }
}