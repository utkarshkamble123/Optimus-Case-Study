using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Optimus.AtHomeBestOffer.Application.Dto;
using Optimus.AtHomeBestOffer.Application.Helper;
using System.Net.Mime;

namespace Optimus.AtHomeBestOffer.Application.Service
{
    public class Company1ProposalService : IProposalService<Company1OrderDto, Company1ProposedOffer>
    {
        public readonly IConfiguration configuration;
        private readonly ILogger<Company1ProposalService> logger;

        public Company1ProposalService(IConfiguration configuration, ILogger<Company1ProposalService> logger)
        {
            this.configuration = configuration;
            this.logger = logger;
        }

        public async Task<Company1ProposedOffer> GetProposedOffer(Company1OrderDto order)
        {
            Company1ProposedOffer company1ProposedOffer = new();
            try
            {
                string c1Url = configuration["Company1Endpoint"];
                Dictionary<string, string> requestHeaders = new()
                {
                    { "ApiKey", "This-is-secret-api-key-for-Company-1" }
                };
                string response = await OfferRequest.PostAsync(c1Url, JsonConvert.SerializeObject(order), MediaTypeNames.Application.Json, requestHeaders);
                var result = JsonConvert.DeserializeObject<Company1ProposedOffer>(response);
                return result ?? company1ProposedOffer;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("401 (Unauthorized)"))
                {
                    logger.LogError("401 Not Authorized. Unable to authenticate for Company 1 API");
                }

                return company1ProposedOffer;
            }
        }
    }
}