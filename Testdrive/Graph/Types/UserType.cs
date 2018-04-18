using GraphQL.Types;
using TestRide.Graph.Helpers;
using TestRide.Models;

namespace TestRide.Graph.Types
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Field(u => u.Id);

            Field(u => u.ExternalId);

            Field(u => u.Name);

            Field<ListGraphType<TestdriveType>>("testdrives",
                arguments: GraphExtensions.GraphSubQueryArguments,
                resolve: context => context.Source.Testdrives.ResolveFields(context.GetStandardSubQueryArguments()));
        }
    }
}
