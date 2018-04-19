using Microsoft.EntityFrameworkCore;
using TestRide.Models;

namespace TestRide.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Testdrive> Testdrives { get; set; }

        public DbSet<MenuItem> MenuItems { get; set; }
    }
}
