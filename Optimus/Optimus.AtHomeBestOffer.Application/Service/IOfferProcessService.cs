using Optimus.AtHomeBestOffer.Application.Model;

namespace Optimus.AtHomeBestOffer.Application.Service
{
    public interface IOfferProcessService
    {
        IEnumerable<ProposedOffer> Process(Order order);
    }
}