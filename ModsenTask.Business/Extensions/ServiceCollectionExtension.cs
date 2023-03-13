using Microsoft.Extensions.DependencyInjection;
using ModsenTask.Business.Services.Interfaces;
using ModsenTask.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsenTask.Business.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<IBookService, BookService>();
        }
    }
}
