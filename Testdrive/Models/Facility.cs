using System.Collections.Generic;
using TestRide.Graph.Models;

namespace TestRide.Models
{
    public class Facility : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
