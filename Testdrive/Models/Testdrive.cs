using TestRide.Graph.Models;

namespace TestRide.Models
{
    public class Testdrive : IEntity<int>
    {
        public int Id { get; set; }

        public virtual Car Car { get; set; }

        public virtual User User { get; set; }
    }
}
