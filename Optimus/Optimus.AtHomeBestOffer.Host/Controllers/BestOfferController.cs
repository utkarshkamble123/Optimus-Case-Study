using Microsoft.AspNetCore.Mvc;
using Optimus.AtHomeBestOffer.Application.Model;
using Optimus.AtHomeBestOffer.Application.Service;

namespace Optimus.AtHomeBestOffer.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BestOfferController : ControllerBase
    {
        private readonly IOfferProcessService _offerProcessService;

        public BestOfferController(IOfferProcessService _offerProcessService)
        {
            this._offerProcessService = _offerProcessService;
        }

        [HttpPost]
        public ActionResult<IEnumerable<ProposedOffer>> GetOffer([FromBody] Order order)
        {
            var bestOffer = _offerProcessService.Process(order);
            return Ok(bestOffer);
        }
    }
}   