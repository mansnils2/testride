using GraphQL.Types;
using Testdrive.Models;

namespace Testdrive.Graph.Types
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Field(u => u.Id);

            Field(u => u.Name);

            Field(u => u.FacilityId);

            Field(u => u.Facility, type: typeof(FacilityType));
        }
    }
}
