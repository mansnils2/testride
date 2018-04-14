using TestRide.Data;
using TestRide.Models;

namespace TestRide.Graph.Repositories.Facilities
{
    public class FacilityRepository : BaseRepository<Facility, int>, IFacilityRepository
    {
        public FacilityRepository(ApplicationDbContext db) : base(db) { }
    }
}
