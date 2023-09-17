using AutoMapper;
using Optimus.AtHomeBestOffer.Application.Dto;
using Optimus.AtHomeBestOffer.Application.Model;
using System.Collections.Concurrent;

namespace Optimus.AtHomeBestOffer.Application.Service
{
    public class OfferProcessService : IOfferProcessService
    {
        private readonly IProposalService<Company1OrderDto, Company1ProposedOffer> _c1ProposalService;
        private readonly IProposalService<Company2OrderDto, Company2ProposedOffer> _c2ProposalService;
        private readonly IProposalService<Company3OrderDto, Company3ProposedOffer> _c3ProposalService;
        private readonly IMapper _mapper;

        public OfferProcessService(IMapper _mapper,
            IProposalService<Company1OrderDto, Company1ProposedOffer> _c1ProposalService,
            IProposalService<Company2OrderDto, Company2ProposedOffer> _c2ProposalService,
            IProposalService<Company3OrderDto, Company3ProposedOffer> _c3ProposalService
        )
        {
            this._c1ProposalService = _c1ProposalService;
            this._c2ProposalService = _c2ProposalService;
            this._c3ProposalService = _c3ProposalService;
            this._mapper = _mapper;
        }

        public IEnumerable<ProposedOffer> Process(Order order)
        {
            ConcurrentBag<ProposedOffer> values = new();

            Parallel.Invoke(() =>
            {
                var c1Order = _mapper.Map<Company1OrderDto>(order);
                var c1ProposedOffer = _c1ProposalService.GetProposedOffer(c1Order).Result;
                var proposedOffer = _mapper.Map<ProposedOffer>(c1ProposedOffer);
                proposedOffer.CompanyName = "Company 1";
                values.Add(proposedOffer);
            },
            () =>
            {
                var c2Order = _mapper.Map<Company2OrderDto>(order);
                var c2ProposedOffer = _c2ProposalService.GetProposedOffer(c2Order).Result;
                var proposedOffer = _mapper.Map<ProposedOffer>(c2ProposedOffer);
                proposedOffer.CompanyName = "Company 2";
                values.Add(proposedOffer);
            },
            () =>
            {
                var c3Order = _mapper.Map<Company3OrderDto>(order);
                var c3ProposedOffer = _c3ProposalService.GetProposedOffer(c3Order).Result;
                var proposedOffer = _mapper.Map<ProposedOffer>(c3ProposedOffer);
                proposedOffer.CompanyName = "Company 3";
                values.Add(proposedOffer);
            });

            var bestOffer = values.ToList()
                .Where(offer => offer.Total != null)
                .GroupBy(x => x.Total)
                .OrderBy(group => group.Key)
                .First()
                .Select(item => item); ;

            return bestOffer;
        }
    }
}