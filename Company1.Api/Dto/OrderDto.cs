using Company1.Api.Model;

namespace Company1.Api.Dto
{
    public class OrderDto
    {
        public string ContactAddress { get; set; } = string.Empty;
        public string WarehouseAddress { get; set; } = string.Empty;
        public List<Dimensions> PackageDimensions { get; set; } = new();
    }
}