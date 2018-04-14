using GraphQL.Types;
using TestRide.Models;

namespace TestRide.Graph.Types
{
    public class TestdriveType : ObjectGraphType<Testdrive>
    {
        public TestdriveType()
        {
            Field(td => td.Id);

            Field(u => u.Car, type: typeof(CarType));

            Field(u => u.User, type: typeof(UserType));
        }
    }
}