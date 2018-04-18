using GraphQL.Types;
using TestRide.Graph.Helpers;
using TestRide.Models;

namespace TestRide.Graph.Types
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType()
        {
            Field(c => c.Id);

            Field(c => c.Name);

            Field(c => c.SocialSecurityNumber);

            Field("countOfTestdrives", c => c.Testdrives.Count);

            Field<ListGraphType<TestdriveType>>("testdrives",
                arguments: GraphExtensions.GraphSubQueryArguments,
                resolve: context => context.Source.Testdrives.ResolveFields(context.GetStandardSubQueryArguments()));
        }
    }
}