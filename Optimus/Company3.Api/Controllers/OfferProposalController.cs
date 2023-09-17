using Company3.Api.DataStore;
using Company3.Api.Dto;
using Company3.Api.Infrastructure.FilterAttributes;
using Company3.Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace Company3.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ServiceFilter(typeof(ClientCredentialsAuthActionFilterAttribute))]
    public class OfferProposalController : ControllerBase
    {
        private readonly List<Order> orderData;

        public OfferProposalController()
        {
            orderData = new MockOrderData().GetOrderDetails();
        }

        [HttpPost]
        [Produces("application/xml")]
        public ActionResult<ProposedOffer> GetProposedOffer([FromBody] OrderDto order)
        {
            var offerProposal = orderData.FirstOrDefault(o =>
            {
                var isMatch = o.Source == order.Source && o.Destination == order.Destination;

                for (var i = 0; i < order.Packages.Count; i++)
                {
                    isMatch = isMatch
                    && order.Packages[i].Length == o.Packages[i].Length
                    && order.Packages[i].Width == o.Packages[i].Width
                    && order.Packages[i].Height == o.Packages[i].Height;
                }

                return isMatch;
            });

            ProposedOffer proposedOffer = new()
            {
                Quote = offerProposal?.Quote
            };

            return Ok(proposedOffer);
        }
    }
}