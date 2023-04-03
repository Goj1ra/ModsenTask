using Microsoft.AspNetCore.Diagnostics;
using ModsenTask.API.Logging;
using ModsenTask.API.ViewModels;
using ModsenTask.Business.Models;
using System.Net;
using System.Text.Json;

namespace ModsenTask.API.Middlewares
{
    public sealed class ExceptionMiddleware : IMiddleware
    {
        private readonly ILoggerManager _loggerManager;

        public ExceptionMiddleware()
        {

        }
        public ExceptionMiddleware(ILoggerManager loggerManager)
        {
            _loggerManager = loggerManager;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Something went wrong: {e}");
                await HandleExceptionAsync(context);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var response = GetResponse(context);

            await context.Response.WriteAsync(new ErrorDetailsViewModel
            {
                Message = JsonSerializer.Serialize(response),
                StatusCode = context.Response.StatusCode
            }.ToString());

        }

        private static ApiResult<string> GetResponse(HttpContext context)
        {
            var exception = context.Features.Get<IExceptionHandlerFeature>();

            var errorMessage = exception != null
                ? exception.Error.Message
                : "Internal server error";

            var respose = ApiResult<string>.Failure(new[] { errorMessage });
            return respose;



        }
    }
}
