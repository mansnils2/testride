using TestRide.Extensions;
using TestRide.Graph.Models;

namespace TestRide.Models
{
    public class Testdrive : IEntity<int>
    {
        public Testdrive()
        {
            Timestamp = UnixTime.Now();
        }

        public void AddData(Customer customer, User user, Car car)
        {
            Customer = customer;
            Car = car;
            User = user;
        }

        public int Id { get; set; }

        public long Timestamp { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Car Car { get; set; }

        public virtual User User { get; set; }
    }
}
