using GraphQL.Types;
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

            Field(u => u.Facility, type: typeof(FacilityType));
        }
    }
}
