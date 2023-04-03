using Microsoft.Extensions.DependencyInjection;
using ModsenTask.IdentityServer.Configuration;

namespace ModsenTask.IdentityServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddIdentityServer()
                .AddInMemoryClients(Config.Clients)
                .AddInMemoryApiScopes(Config.ApiScopes)
                .AddDeveloperSigningCredential();

            var app = builder.Build();

            app.UseRouting();
            app.UseIdentityServer();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}