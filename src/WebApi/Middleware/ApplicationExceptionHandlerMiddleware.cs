using System.Net;
using System.Security;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;

namespace WebApi.Middleware
{
    public static class ApplicationExceptionHandlerMiddleware
    {
        public static IApplicationBuilder UseApplicationExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseExceptionHandler(
                builder =>
                {
                    builder.Run(context =>
                    {
                        context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "text/plain";
                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if (error != null)
                        {
                            if (error.Error is SecurityException)
                            {
                                context.Response.StatusCode = (int) HttpStatusCode.Forbidden;
                            }
                            else
                            {
                                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                            }
                        }

                        return Task.CompletedTask;
                    });
                });
        }
    }
}