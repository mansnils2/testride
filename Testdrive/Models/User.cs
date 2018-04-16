using System.Collections.Generic;
using TestRide.Graph.Models;

namespace TestRide.Models
{
    public class User : IEntity<int>
    {
        public int Id { get; set; }

        public string ExternalId { get; set; }

        public string Name { get; set; }

        public Roles Roles { get; set; }

        public int FacilityId { get; set; }

        public virtual Facility Facility { get; set; }

        public virtual ICollection<Testdrive> Testdrives { get; set; }
    }
}
