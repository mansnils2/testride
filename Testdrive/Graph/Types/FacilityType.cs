using GraphQL.Types;
using Testdrive.Graph.Helpers;
using Testdrive.Models;

namespace Testdrive.Graph.Types
{
    public class FacilityType : ObjectGraphType<Facility>
    {
        public FacilityType()
        {
            Field(f => f.Id);

            Field(f => f.Name);

            Field<ListGraphType<UserType>>("users",
                arguments: GraphExtensions.GraphSubQueryArguments,
                resolve: context => context.Source.Users.ResolveFields(context.GetStandardSubQueryArguments()));
        }
    }
}