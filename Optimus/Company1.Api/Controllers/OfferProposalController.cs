using Company1.Api.DataStore;
using Company1.Api.Dto;
using Company1.Api.Infrastructure.FilterAttributes;
using Company1.Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace Company1.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ServiceFilter(typeof(ApiKeyActionFilterAttribute))]
    public class OfferProposalController : ControllerBase
    {
        private readonly List<Order> orderData;

        public OfferProposalController()
        {
            orderData = new MockOrderData().GetOrderDetails();
        }

        [HttpPost]
        public ActionResult<ProposedOffer> GetProposedOffer([FromBody] OrderDto order)
        {
            var offerProposal = orderData.FirstOrDefault(o =>
            {
                var isMatch = o.ContactAddress == order.ContactAddress && o.WarehouseAddress == order.WarehouseAddress;

                for (var i = 0; i < order.PackageDimensions.Count; i++)
                {
                    isMatch = isMatch
                    && order.PackageDimensions[i].Length == o.PackageDimensions[i].Length
                    && order.PackageDimensions[i].Width == o.PackageDimensions[i].Width
                    && order.PackageDimensions[i].Height == o.PackageDimensions[i].Height;
                }

                return isMatch;
            });

            ProposedOffer proposedOffer = new()
            {
                Total = offerProposal?.Total
            };

            return Ok(proposedOffer);
        }
    }
}