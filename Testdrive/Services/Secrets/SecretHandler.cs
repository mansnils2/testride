using Microsoft.Extensions.Configuration;

namespace TestRide.Services.Secrets
{
    public class SecretHandler : ISecretHandler
    {
        private readonly IConfiguration _configuration;

        public SecretHandler(IConfiguration configuration) { }
    }
}