using Domain.Exeptions;
using Shared.ErrorModels;
using System.Net;

namespace E_Commerce.API.MiddelWares
{
    public class GlobalErrorHandlingMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalErrorHandlingMiddleWare> _logger;

        public GlobalErrorHandlingMiddleWare(RequestDelegate next, ILogger<GlobalErrorHandlingMiddleWare> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
                if(httpContext.Response.StatusCode == (int)HttpStatusCode.NotFound) 
                    await HandleNotFoundEndPointAsync(httpContext);
            }
            catch (Exception ex) {
                _logger.LogError("");
                await HandelExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleNotFoundEndPointAsync(HttpContext httpContext)
        {
            httpContext.Request.ContentType = "application/json";
            var response = new ErrorDetails
            {
                StatusCode = (int)HttpStatusCode.NotFound,
                ErrorMessage = $"The end Point {httpContext.Request.Path} not Found.",
            }.ToString();
            await httpContext.Response.WriteAsync(response);
        }

        private async Task HandelExceptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            httpContext.Response.ContentType = "application/json";


            httpContext.Response.StatusCode = ex switch
            {
                NotFoundException => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError
            };
           var response = new ErrorDetails
            {
                StatusCode = httpContext.Response.StatusCode,
                ErrorMessage = ex.Message,
            }.ToString();
            await httpContext.Response.WriteAsync(response);
        }
    }
}
