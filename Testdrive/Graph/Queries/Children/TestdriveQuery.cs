using Testdrive.Graph.Repositories.Testdrives;
using Testdrive.Graph.Types;

namespace Testdrive.Graph.Queries.Children
{
    public class TestdriveQuery : BaseQuery<TestdriveType, Testdrive.Models.Testdrive, int>
    {
        public TestdriveQuery(ITestdriveRepository repo) : base("testdrive", "testdrives", repo) { }
    }
}
