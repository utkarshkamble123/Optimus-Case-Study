using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Optimus.AtHomeBestOffer.Application.Dto;
using Optimus.AtHomeBestOffer.Application.Helper;
using System.Net.Mime;

namespace Optimus.AtHomeBestOffer.Application.Service
{
    public class Company3ProposalService : IProposalService<Company3OrderDto, Company3ProposedOffer>
    {
        public readonly IConfiguration configuration;
        private readonly ILogger<Company2ProposalService> logger;

        public Company3ProposalService(IConfiguration configuration, ILogger<Company2ProposalService> logger)
        {
            this.configuration = configuration;
            this.logger = logger;
        }

        public async Task<Company3ProposedOffer> GetProposedOffer(Company3OrderDto order)
        {
            Company3ProposedOffer company3ProposedOffer = new();
            try
            {
                string c1Url = configuration["Company3Endpoint"];
                Dictionary<string, string> requestHeaders = new()
                {
                    { "TenentId", "7E8E90A4-5F84-41A9-AE6B-F80E49B2C491" },
                    { "ClientId", "client-id" },
                    { "ClientSecret", "client-secret" }
                };

                string response = await OfferRequest.PostAsync(c1Url, order.SerializeToXML(), MediaTypeNames.Application.Xml, requestHeaders);
                var result = response.DeserializeFromXML<Company3ProposedOffer>();
                return result ?? company3ProposedOffer;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("401 (Unauthorized)"))
                {
                    logger.LogError("401 Not Authorized. Unable to authenticate for Company 1 API");
                }
                return company3ProposedOffer;
            }
        }
    }
}