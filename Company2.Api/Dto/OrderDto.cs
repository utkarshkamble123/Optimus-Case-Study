using Company2.Api.Model;

namespace Company2.Api.Dto
{
    public class OrderDto
    {
        public string Consignee { get; set; } = string.Empty;
        public string Consignor { get; set; } = string.Empty;
        public List<Dimensions> Cartons { get; set; } = new();
    }
}