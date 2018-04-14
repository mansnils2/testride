using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Testdrive
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) => WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(ConfigConfiguration)
                .UseStartup<Startup>()
                .Build();

        private static void ConfigConfiguration(WebHostBuilderContext webHostBuilderContext,
            IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables();

            var config = builder.Build();

            builder.AddAzureKeyVault(
                $"https://{config["AzureKeyVault:Vault"]}.vault.azure.net/",
                config["AzureKeyVault:ClientId"],
                config["AzureKeyVault:ClientSecret"]
            );
        }
    }
}
