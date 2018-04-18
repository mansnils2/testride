using System.Collections.Generic;
using TestRide.Graph.Models;

namespace TestRide.Models
{
    public class Car : IEntity<int>
    {
        public Car() { }

        public Car(string licenseplate, string carName)
        {
            Licenseplate = licenseplate;
            CarName = carName;
        }

        public int Id { get; set; }

        public string Licenseplate { get; set; }

        public string CarName { get; set; }

        public virtual ICollection<Testdrive> Testdrives { get; set; }
    }
}
