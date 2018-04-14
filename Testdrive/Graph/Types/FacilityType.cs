using GraphQL.Types;
using TestRide.Graph.Helpers;
using TestRide.Models;

namespace TestRide.Graph.Types
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