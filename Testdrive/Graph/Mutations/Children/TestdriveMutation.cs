using GraphQL.Types;
using TestRide.Graph.Repositories.Testdrives;
using TestRide.Graph.Types;

namespace TestRide.Graph.Mutations.Children
{
    public class TestdriveMutation : ObjectGraphType<TestdriveType>
    {
        public TestdriveMutation(ITestdriveRepository repo)
        {
            Field<BooleanGraphType>(
                "addTestdrive",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> {Name = "licenseplate"},
                    new QueryArgument<StringGraphType> {Name = "carName"}),
                resolve: context => repo.AddTestdriveAsync(
                    context.GetArgument<string>("licenseplate"),
                    context.GetArgument<string>("carName")));
        }
    }
}
