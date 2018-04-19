using System.Collections.Generic;
using TestRide.Graph.Models;

namespace TestRide.Models
{
    public class Customer : IEntity<int>
    {
        public Customer() { }

        public Customer(string name, string socialSecurityNumber)
        {
            Name = name;
            SocialSecurityNumber = socialSecurityNumber;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string SocialSecurityNumber { get; set; }

        public virtual ICollection<Testdrive> Testdrives { get; set; }
    }
}
