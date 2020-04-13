using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Motel.Utilities.Exceptions
{
    public class ExceptionsHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionsHandlingMiddleware> _logger;
        public ExceptionsHandlingMiddleware(RequestDelegate next, ILogger<ExceptionsHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (MotelExceptions ex)
            {
                await HandleUnhandledExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleUnhandledExceptionAsync(HttpContext context, MotelExceptions ex)
        {
            _logger.LogError(ex, ex.Message);
            if (!context.Response.HasStarted)
            {
                int statuscode = (int)HttpStatusCode.InternalServerError;
                string message = string.Empty;

                message = ex.Message;

                message = "An Unhandle exception has occurred";

                //context.Response.r
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = statuscode;

                var result = new MessageExceptions(message).ToString();
                await context.Response.WriteAsync(result);
            }
        }
    }
}
