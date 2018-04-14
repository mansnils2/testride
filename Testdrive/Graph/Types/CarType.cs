using GraphQL.Types;
using Testdrive.Graph.Helpers;
using Testdrive.Models;

namespace Testdrive.Graph.Types
{
    public class CarType : ObjectGraphType<Car>
    {
        public CarType()
        {
            Field(c => c.Id);

            Field(c => c.Licenseplate);

            Field(c => c.CarName);

            Field<ListGraphType<TestdriveType>>("testdrives",
                arguments: GraphExtensions.GraphSubQueryArguments,
                resolve: context => context.Source.Testdrives.ResolveFields(context.GetStandardSubQueryArguments()));
        }
    }
}