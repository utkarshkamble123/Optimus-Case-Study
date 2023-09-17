using Optimus.AtHomeBestOffer.Application.Model;

namespace Optimus.AtHomeBestOffer.Application.Dto
{
    public class Company2OrderDto
    {
        public string Consignee { get; set; } = string.Empty;
        public string Consignor { get; set; } = string.Empty;
        public List<Dimensions> Cartons { get; set; } = new();
    }
}