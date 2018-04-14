using Testdrive.Data;
using Testdrive.Models;

namespace Testdrive.Graph.Repositories.Customers
{
    public class CustomerRepository : BaseRepository<Customer, int>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext db) : base(db) { }
    }
}
