namespace ups.delivey.portal.Middleware
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AccountMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public AccountMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var path = httpContext.Request.Path;

            if (path.HasValue && path.Value.StartsWith("/Home/Index"))
            {
                if (httpContext.Session.GetString("Manager") == null)
                {
                    httpContext.Response.Redirect("/");
                }
            }

            return _requestDelegate(httpContext);
        }
            
    }

    public static class AccounMiddlewareExtensions
    {
        public static IApplicationBuilder UseAccountMilddware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AccountMiddleware>();
        }
    }
}
