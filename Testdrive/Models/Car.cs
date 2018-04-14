using System.Collections.Generic;
using Testdrive.Graph.Models;

namespace Testdrive.Models
{
    public class Car : IEntity<int>
    {
        public int Id { get; set; }

        public string Licenseplate { get; set; }

        public string CarName { get; set; }

        public virtual ICollection<Testdrive> Testdrives { get; set; }
    }
}
