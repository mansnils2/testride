using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace TestRide
{
    public class Program
    {
        public static void Main(string[] args) => WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(ConfigConfiguration)
            .UseStartup<Startup>()
            .Build()
            .Run();

        private static void ConfigConfiguration(
            WebHostBuilderContext context,
            IConfigurationBuilder builder)
        {
            if (context.HostingEnvironment.IsDevelopment())
                builder.SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("localsettings.json", false, true)
                    .AddEnvironmentVariables();
        }
    }
}
