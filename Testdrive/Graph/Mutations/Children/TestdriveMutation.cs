using GraphQL.Types;
using TestRide.Graph.Repositories.Testdrives;
using TestRide.Graph.Types;
using TestRide.Models;

namespace TestRide.Graph.Mutations.Children
{
    public class TestdriveMutation : ObjectGraphType<TestdriveType>
    {
        public TestdriveMutation(ITestdriveRepository repo)
        {
            Field<BooleanGraphType>(
                "addTestdrive",
                resolve: context =>
                {
                    repo.Add(new Testdrive());
                    return repo.SaveChangesAsync();
                });
        }
    }
}
