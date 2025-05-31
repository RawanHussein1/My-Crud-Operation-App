
using Application.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MyCrudOperation.API.Models;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyCrudOperation.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception caught by middleware.");

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                var response = new ApisResponse(new ServiceResult
                {
                    Succeeded = false,
                    ResultObject = null,
                    Errors = new List<ServiceError>
            {
                new ServiceError ("500", ex.Message )
            }
                });

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }
}


