using ModsenTask.API.Middlewares;

namespace ModsenTask.API.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static void UseCustomExceptionMiddleware(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
