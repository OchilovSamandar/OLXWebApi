using OLXWebApi.Models;
using OLXWebApi.Services.Exceptions;

namespace OLXWebApi.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly  RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(OlxWebApiException exception)
            {
                httpContext.Response.StatusCode = exception.Status;
                await httpContext.Response.WriteAsJsonAsync(new Response
                {
                    Status = exception.Status,
                    Message = exception.Message
                });
            }
            catch (Exception exception)
            {
                _logger.LogError($"{exception}\n\n");
                httpContext.Response.StatusCode = 500;
                await httpContext.Response.WriteAsJsonAsync(new Response
                {
                    Status = 500,
                    Message = exception.Message
                });
            }
        }
    }
}
