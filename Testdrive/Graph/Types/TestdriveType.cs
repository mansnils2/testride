using GraphQL.Types;
using TestRide.Models;

namespace TestRide.Graph.Types
{
    public class TestdriveType : ObjectGraphType<Testdrive>
    {
        public TestdriveType()
        {
            Field(t => t.Id);

            Field(t => t.Timestamp);

            Field(t => t.Customer, type: typeof(CustomerType));

            Field(t => t.Car, type: typeof(CarType));

            Field(t => t.User, type: typeof(UserType));
        }
    }
}