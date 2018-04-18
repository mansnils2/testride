using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Key]
        public int Id { get; set; }

        public long Timestamp { get; set; }


        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public int CarId { get; set; }

        [ForeignKey("CarId")]
        public virtual Car Car { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
