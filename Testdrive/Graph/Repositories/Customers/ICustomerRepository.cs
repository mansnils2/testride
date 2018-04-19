using System.Threading.Tasks;
using TestRide.Models;

namespace TestRide.Graph.Repositories.Customers
{
    public interface ICustomerRepository : IBaseRepository<Customer, int>
    {
        Task<bool> AddCustomerAsync(string name, string ssn);
    }
}
