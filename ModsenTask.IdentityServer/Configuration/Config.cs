using IdentityServer4.Models;
using IdentityServer4.Test;

namespace ModsenTask.IdentityServer.Configuration
{
    public class Config
    {
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "modsenTaskClient",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("Secret".Sha256())
                    },
                    AllowedScopes = { "ModsenTask" }
                }
            };
        public static IEnumerable<ApiScope> ApiScopes =>
           new ApiScope[]
           {
               new ApiScope("ModsenTask", "ModsenTask-API")
           };
        public static IEnumerable<ApiResource> ApiResources =>
           new ApiResource[]
           {

           };
        public static IEnumerable<IdentityResource> IdentityResources =>
           new IdentityResource[]
           {

           };
        public static List<TestUser> TestUsers =>
           new List<TestUser>
           {

           };
    }
}
