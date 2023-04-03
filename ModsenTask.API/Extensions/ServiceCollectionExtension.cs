using Microsoft.AspNetCore.Mvc;
using ModsenTask.API.Attributes;
using ModsenTask.API.Logging;
using ModsenTask.API.Middlewares;

namespace ModsenTask.API.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static void AddCustomExceptionHandler(this IServiceCollection services)
        {
            services.AddScoped<ExceptionMiddleware>();
        }

        public static void ConfigureFluentValidation(this IServiceCollection services)
        {
            services.AddMvcCore();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(ValidateViewModelStareAttribute));
            });
        }
    }
}
