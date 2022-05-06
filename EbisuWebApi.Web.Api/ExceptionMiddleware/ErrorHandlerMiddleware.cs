using EbisuWebApi.Crosscutting.Exceptions;
using System.Net;
using System.Text;
using System.Text.Json;

namespace EbisuWebApi.Web.Api.ExceptionMiddleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                
                
                if (error is EbisuException)
                {
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
               
                var result = JsonSerializer.Serialize(new { message = error?.Message });
                await response.WriteAsync(result);

                LogException(error);
            }
        }

        private void LogException(Exception? error)
        {
            var logMessageBuilder = new StringBuilder();
            logMessageBuilder.AppendLine("Exception: ");
            logMessageBuilder.AppendLine($"{error?.Message}");
            logMessageBuilder.AppendLine("Stack:");
            logMessageBuilder.AppendLine($"{error?.StackTrace}");
            logMessageBuilder.AppendLine();

            _logger.LogError(logMessageBuilder.ToString());
        }
    }
}
