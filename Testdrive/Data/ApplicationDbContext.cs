using Microsoft.EntityFrameworkCore;
using Testdrive.Models;

namespace Testdrive.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Facility> Facilities { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Models.Testdrive> Testdrives { get; set; }
    }
}
