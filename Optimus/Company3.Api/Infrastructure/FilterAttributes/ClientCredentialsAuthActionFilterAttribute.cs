namespace Company3.Api.Infrastructure.FilterAttributes
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Configuration;

    public class ClientCredentialsAuthActionFilterAttribute : ActionFilterAttribute
    {
        private readonly string tenentId;
        private readonly string clientId;
        private readonly string clientSecret;

        public ClientCredentialsAuthActionFilterAttribute(IConfiguration configuration)
        {
            tenentId = configuration["TenentId"]; // Assuming you store the API key in appsettings.json
            clientId = configuration["ClientId"]; // Assuming you store the API key in appsettings.json
            clientSecret = configuration["ClientSecret"]; // Assuming you store the API key in appsettings.json
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.HttpContext.Request;
            var providedTenentId = request.Headers["TenentId"].ToString();
            var providedClientSecret = request.Headers["ClientSecret"].ToString();
            var providedClientId = request.Headers["ClientId"].ToString();

            if (!(string.Equals(providedTenentId, tenentId) && string.Equals(providedClientId, clientId) && string.Equals(providedClientSecret, clientSecret)))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}