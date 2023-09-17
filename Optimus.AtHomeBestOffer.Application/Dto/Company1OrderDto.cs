using Optimus.AtHomeBestOffer.Application.Model;

namespace Optimus.AtHomeBestOffer.Application.Dto
{
    public class Company1OrderDto
    {
        public string ContactAddress { get; set; } = string.Empty;
        public string WarehouseAddress { get; set; } = string.Empty;
        public List<Dimensions> PackageDimensions { get; set; } = new();
    }
}