using TestRide.Data;
using TestRide.Models;

namespace TestRide.Graph.Repositories.Testdrives
{
    public class TestdriveRepository : BaseRepository<Testdrive, int>, ITestdriveRepository
    {
        public TestdriveRepository(ApplicationDbContext db) : base(db) { }
    }
}
