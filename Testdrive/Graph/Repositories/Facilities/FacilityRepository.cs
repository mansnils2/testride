using Testdrive.Data;
using Testdrive.Models;

namespace Testdrive.Graph.Repositories.Facilities
{
    public class FacilityRepository : BaseRepository<Facility, int>, IFacilityRepository
    {
        public FacilityRepository(ApplicationDbContext db) : base(db) { }
    }
}
