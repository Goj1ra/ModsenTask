using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ModsenTask.Data.Data;
using ModsenTask.Data.Repositories;
using ModsenTask.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsenTask.Data.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplicationDbContext(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(s => s.UseSqlServer(connectionString));
        }

        public static void AddRepositories(this  IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<IBookRepository, BookRepository>();
        }
    }
}
