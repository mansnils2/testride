using TestRide.Data;
using TestRide.Models;

namespace TestRide.Graph.Repositories.Customers
{
    public class CustomerRepository : BaseRepository<Customer, int>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext db) : base(db) { }
    }
}
