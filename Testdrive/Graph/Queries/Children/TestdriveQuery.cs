using TestRide.Graph.Repositories.Testdrives;
using TestRide.Graph.Types;
using TestRide.Models;

namespace TestRide.Graph.Queries.Children
{
    public class TestdriveQuery : BaseQuery<TestdriveType, Testdrive, int>
    {
        public TestdriveQuery(ITestdriveRepository repo) : base("testdrive", "testdrives", repo) { }
    }
}
