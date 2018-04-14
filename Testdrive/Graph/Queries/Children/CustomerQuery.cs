using TestRide.Graph.Repositories.Customers;
using TestRide.Graph.Types;
using TestRide.Models;

namespace TestRide.Graph.Queries.Children
{
    public class CustomerQuery : BaseQuery<CustomerType, Customer, int>
    {
        public CustomerQuery(ICustomerRepository repo) : base("customer", "customers", repo) { }
    }
}
