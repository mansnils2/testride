using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TestRide.Data;
using TestRide.Models;
using TestRide.Services.PusherHandler;

namespace TestRide.Graph.Repositories.Customers
{
    public class CustomerRepository : BaseRepository<Customer, int>, ICustomerRepository
    {
        private readonly ApplicationDbContext _db;

        private readonly IHttpContextAccessor _http;

        private readonly IPusherHandler _pusher;

        public CustomerRepository(
            ApplicationDbContext db,
            IHttpContextAccessor http,
            IPusherHandler pusher) : base(db)
        {
            _db = db;
            _http = http;
            _pusher = pusher;
        }

        public async Task<bool> AddCustomerAsync(string name, string ssn)
        {
            var customer = new Customer(name, ssn);
            await _db.Customers.AddAsync(customer);

            var save = await _db.SaveChangesAsync();
            await _pusher.UpdateCustomerAsync(customer.Id);

            return save > 0;
        }
    }
}
