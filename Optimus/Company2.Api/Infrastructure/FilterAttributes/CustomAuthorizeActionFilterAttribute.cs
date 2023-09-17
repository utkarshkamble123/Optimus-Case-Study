namespace Company2.Api.Infrastructure.FilterAttributes
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Configuration;

    public class CustomAuthorizeActionFilterAttribute : ActionFilterAttribute
    {
        private readonly string tokenCredentials;

        public CustomAuthorizeActionFilterAttribute(IConfiguration configuration)
        {
            tokenCredentials = configuration["Authorization-Header-Bearer-Token-Mock"]; // Assuming you store the API key in appsettings.json
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.HttpContext.Request;
            var providedApiKey = request.Headers["Authorization"].ToString();

            if (!string.Equals(providedApiKey, tokenCredentials))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}