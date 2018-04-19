using GraphQL.Types;
using TestRide.Graph.Repositories.Customers;
using TestRide.Graph.Types;
using TestRide.Services.PusherHandler;

namespace TestRide.Graph.Mutations.Children
{
    public class CustomerMutation : ObjectGraphType<CustomerType>
    {

        public CustomerMutation(
            ICustomerRepository repo,
            IPusherHandler pusher)
        {
            Field<BooleanGraphType>(
                "addCustomer",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "name" },
                    new QueryArgument<StringGraphType> { Name = "socialSecurityNumber" }),
                resolve: context => repo.AddCustomerAsync(
                    context.GetArgument<string>("name"),
                    context.GetArgument<string>("socialSecurityNumber")));
        }
    }
}
