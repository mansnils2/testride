using Testdrive.Graph.Repositories.Customers;
using Testdrive.Graph.Types;
using Testdrive.Models;

namespace Testdrive.Graph.Queries.Children
{
    public class CustomerQuery : BaseQuery<CustomerType, Customer, int>
    {
        public CustomerQuery(ICustomerRepository repo) : base("customer", "customers", repo) { }
    }
}
