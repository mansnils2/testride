using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using TestRide.Graph.Repositories.Customers;
using TestRide.Graph.Repositories.Testdrives;
using TestRide.Graph.Types;
using TestRide.Models;

namespace TestRide.Graph.Mutations.Children
{
    public class CustomerMutation : ObjectGraphType<CustomerType>
    {
        public CustomerMutation(ICustomerRepository repo)
        {
            Field<BooleanGraphType>(
                "addCustomer",
                resolve: context =>
                {
                    repo.Add(new Customer());
                    return repo.SaveChangesAsync();
                });
        }
    }
}
