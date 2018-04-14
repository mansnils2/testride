using TestRide.Data;
using TestRide.Models;

namespace TestRide.Graph.Repositories.Users
{
    public class UserRepository : BaseRepository<User, int>, IUserRepository
    {
        public UserRepository(ApplicationDbContext db) : base(db) { }
    }
}