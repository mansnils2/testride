using Testdrive.Graph.Repositories.Facilities;
using Testdrive.Graph.Types;
using Testdrive.Models;

namespace Testdrive.Graph.Queries.Children
{
    public class FacilityQuery : BaseQuery<FacilityType, Facility, int>
    {
        public FacilityQuery(IFacilityRepository repo) : base("facility", "facilities", repo) { }
    }
}
