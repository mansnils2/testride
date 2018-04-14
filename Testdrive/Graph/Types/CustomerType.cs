using GraphQL.Types;
using Testdrive.Graph.Helpers;
using Testdrive.Models;

namespace Testdrive.Graph.Types
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType()
        {
            Field(c => c.Id);

            Field(c => c.SocialSecurityNumber);

            Field(c => c.Name);

            Field<ListGraphType<TestdriveType>>("testdrives",
                arguments: GraphExtensions.GraphSubQueryArguments,
                resolve: context => context.Source.Testdrives.ResolveFields(context.GetStandardSubQueryArguments()));
        }
    }
}