namespace Company1.Api.Infrastructure.FilterAttributes
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Configuration;

    public class ApiKeyActionFilterAttribute : ActionFilterAttribute
    {
        private readonly string _apiKey;

        public ApiKeyActionFilterAttribute(IConfiguration configuration)
        {
            _apiKey = configuration["ApiKey"]; // Assuming you store the API key in appsettings.json
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.HttpContext.Request;
            var providedApiKey = request.Headers["ApiKey"].ToString();

            if (!string.Equals(providedApiKey, _apiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}