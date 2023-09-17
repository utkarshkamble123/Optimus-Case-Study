using Company2.Api.DataStore;
using Company2.Api.Dto;
using Company2.Api.Infrastructure.FilterAttributes;
using Company2.Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace Company2.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ServiceFilter(typeof(CustomAuthorizeActionFilterAttribute))]
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
                var isMatch = o.Consignee == order.Consignee && o.Consignor == order.Consignor;

                for (var i = 0; i < order.Cartons.Count; i++)
                {
                    isMatch = isMatch
                    && order.Cartons[i].Length == o.Cartons[i].Length
                    && order.Cartons[i].Width == o.Cartons[i].Width
                    && order.Cartons[i].Height == o.Cartons[i].Height;
                }

                return isMatch;
            });

            ProposedOffer proposedOffer = new()
            {
                Amount = offerProposal?.Amount
            };

            return Ok(proposedOffer);
        }
    }
}