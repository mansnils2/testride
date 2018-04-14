using Testdrive.Data;

namespace Testdrive.Graph.Repositories.Testdrives
{
    public class TestdriveRepository : BaseRepository<Testdrive.Models.Testdrive, int>, ITestdriveRepository
    {
        public TestdriveRepository(ApplicationDbContext db) : base(db) { }
    }
}
