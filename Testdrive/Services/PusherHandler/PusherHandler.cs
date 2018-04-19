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

        public async Task<HttpStatusCode> UpdateCustomerAsync(int id)
        {
            // initiate the client
            var pusher = GetClient();
            var customer = await _db.Customers
                .AsNoTracking()
                .Include(c => c.Testdrives)
                .Where(c => c.Id == id)
                .Select(c => new
                {
                    id = c.Id,
                    name = c.Name,
                    socialSecurityNumber = c.SocialSecurityNumber,
                    countOfTestdrives = c.Testdrives.Count
                }).FirstOrDefaultAsync();

            var result = await pusher.TriggerAsync("customers", "new-customer", customer);
            return result.StatusCode;
        }
    }
}