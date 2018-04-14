using System.Collections.Generic;
using TestRide.Graph.Models;

namespace TestRide.Models
{
    public class Car : IEntity<int>
    {
        public int Id { get; set; }

        public string Licenseplate { get; set; }

        public string CarName { get; set; }

        public virtual ICollection<Testdrive> Testdrives { get; set; }
    }
}
