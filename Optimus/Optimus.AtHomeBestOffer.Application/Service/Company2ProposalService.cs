using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Optimus.AtHomeBestOffer.Application.Dto;
using Optimus.AtHomeBestOffer.Application.Helper;
using System.Net.Mime;

namespace Optimus.AtHomeBestOffer.Application.Service
{
    public class Company2ProposalService : IProposalService<Company2OrderDto, Company2ProposedOffer>
    {
        public readonly IConfiguration configuration;
        private readonly ILogger<Company2ProposalService> logger;

        public Company2ProposalService(IConfiguration configuration, ILogger<Company2ProposalService> logger)
        {
            this.configuration = configuration;
            this.logger = logger;
        }

        public async Task<Company2ProposedOffer> GetProposedOffer(Company2OrderDto order)
        {
            Company2ProposedOffer company2ProposedOffer = new();
            try
            {
                string c1Url = configuration["Company2Endpoint"];
                Dictionary<string, string> requestHeaders = new()
                {
                    { "Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c" }
                };
                string response = await OfferRequest.PostAsync(c1Url, JsonConvert.SerializeObject(order), MediaTypeNames.Application.Json, requestHeaders);
                var result = JsonConvert.DeserializeObject<Company2ProposedOffer>(response);
                return result ?? company2ProposedOffer;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("401 (Unauthorized)"))
                {
                    logger.LogError("401 Not Authorized. Unable to authenticate for Company 1 API");
                }
                return company2ProposedOffer;
            }
        }
    }
}