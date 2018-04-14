using System.Collections.Generic;
using Testdrive.Graph.Models;

namespace Testdrive.Models
{
    public class Facility : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
