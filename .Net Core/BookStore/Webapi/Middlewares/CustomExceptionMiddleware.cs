using System.Diagnostics;
using System.Net;
using Webapi.Services;
using Newtonsoft.Json;

namespace Webapi.MiddleWares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _loggerService;

        public CustomExceptionMiddleware(RequestDelegate next, ILoggerService loggerService)
        {
            _next = next;
            _loggerService = loggerService;
        }

        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            string message = "[Request]  HTTP " + context.Request.Method + " - " + context.Request.Path;
            _loggerService.Write(message);
            try
            {
                await _next(context);
                watch.Stop();
                message = "[Response] HTTP " + context.Request.Method + " - " + context.Request.Path
                    + " responded " + context.Response.StatusCode + " in " + watch.Elapsed.TotalMilliseconds.ToString() + " ms";
                _loggerService.Write(message);
            }
            catch (Exception e)
            {
                watch.Stop();
                await HandleException(context, watch, e);
            }
        }

        public Task HandleException(HttpContext context, Stopwatch watch, Exception e)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "[Error]   HTTP" + context.Request.Method + " - "
                + context.Response.StatusCode + " Error Message: " + e.Message
                + " in " + watch.Elapsed.TotalMilliseconds.ToString() + " ms";
            _loggerService.Write(message);

            var result = JsonConvert.SerializeObject(new { error = e.Message }, Formatting.None);
            return context.Response.WriteAsync(result);
        }
    }

    public static class CustomExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}