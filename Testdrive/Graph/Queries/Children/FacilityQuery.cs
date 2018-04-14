using TestRide.Graph.Repositories.Facilities;
using TestRide.Graph.Types;
using TestRide.Models;

namespace TestRide.Graph.Queries.Children
{
    public class FacilityQuery : BaseQuery<FacilityType, Facility, int>
    {
        public FacilityQuery(IFacilityRepository repo) : base("facility", "facilities", repo) { }
    }
}
