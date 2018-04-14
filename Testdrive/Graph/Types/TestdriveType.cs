using GraphQL.Types;

namespace Testdrive.Graph.Types
{
    public class TestdriveType : ObjectGraphType<Testdrive.Models.Testdrive>
    {
        public TestdriveType()
        {
            Field(td => td.Id);

            Field(u => u.Car, type: typeof(CarType));

            Field(u => u.User, type: typeof(UserType));
        }
    }
}