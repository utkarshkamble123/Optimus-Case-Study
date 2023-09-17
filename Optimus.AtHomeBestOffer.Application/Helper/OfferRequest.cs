using System.Text;

namespace Optimus.AtHomeBestOffer.Application.Helper
{
    public class OfferRequest
    {
        public static async Task<string> PostAsync(string url, string postBody, string contentType, Dictionary<string, string> requestHeaders = null)
        {
            try
            {
                using HttpClient httpClient = new();

                if (requestHeaders != null && requestHeaders.Any())
                {
                    foreach (var header in requestHeaders)
                    {
                        httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }

                using StringContent jsonContent = new(
                    postBody,
                    new UTF8Encoding(false),
                    contentType);

                using HttpResponseMessage response = await httpClient.PostAsync(
                    url,
                    jsonContent);

                response.EnsureSuccessStatusCode();

                var proposalResponse = await response.Content.ReadAsStringAsync();

                return proposalResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}