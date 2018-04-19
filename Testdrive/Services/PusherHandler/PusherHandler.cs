using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PusherServer;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TestRide.Data;

namespace TestRide.Services.PusherHandler
{
    public class PusherHandler : IPusherHandler
    {
        private readonly IConfiguration _config;

        private readonly ApplicationDbContext _db;

        public PusherHandler(IConfiguration config, ApplicationDbContext db)
        {
            _config = config;
            _db = db;
        }

        private Pusher GetClient()
        {
            var options = new PusherOptions
            {
                Cluster = _config.GetConnectionString("PusherCluster"),
                Encrypted = true
            };

            var client = new Pusher(
                _config.GetConnectionString("PusherId"),
                _config.GetConnectionString("PusherKey"),
                _config.GetConnectionString("PusherSecret"),
                options);

            return client;
        }

        public async Task<HttpStatusCode> UpdateTestdrivesAsync()
        {
            // initiate the client
            var pusher = GetClient();
            var result = await pusher.TriggerAsync("testdrives", "new-testdrive", null);
            return result.StatusCode;
        }

        public async Task<HttpStatusCode> UpdateCustomersAsync()
        {
            // initiate the client
            var pusher = GetClient();
            var result = await pusher.TriggerAsync("customers", "new-customer", null);
            return result.StatusCode;
        }
    }
}