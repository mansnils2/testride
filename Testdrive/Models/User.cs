using System.Collections.Generic;
using Testdrive.Graph.Models;

namespace Testdrive.Models
{
    public class User : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int FacilityId { get; set; }

        public virtual Facility Facility { get; set; }

        public virtual ICollection<Testdrive> Testdrives { get; set; }
    }
}
