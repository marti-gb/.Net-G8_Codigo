using Microsoft.AspNetCore.Authentication;

namespace Gateway.MiddleWares
{
    public class TokenCheckedMiddleWare(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            string requestPath = context.Request.Path.Value;
            if(requestPath.Contains("Account/Login", StringComparison.InvariantCultureIgnoreCase)
            || requestPath.Contains("Account/register", StringComparison.InvariantCultureIgnoreCase)
            || requestPath.Equals("/"))
            {
                await next(context);
            }
            else
            {
                var authHeader = context.Request.Headers.Authorization;
                if(authHeader.FirstOrDefault() == null)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Lo sentimos, acceso denegado");
                }
                else
                {
                    await next(context);
                }
            }
        }
    }
}
