using System.Collections.Generic;
using TestRide.Graph.Models;

namespace TestRide.Models
{
    public class Customer : IEntity<int>
    {
        public int Id { get; set; }

        public string SocialSecurityNumber { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Testdrive> Testdrives { get; set; }
    }
}
