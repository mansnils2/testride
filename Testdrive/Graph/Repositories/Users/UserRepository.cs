using Testdrive.Data;
using Testdrive.Models;

namespace Testdrive.Graph.Repositories.Users
{
    public class UserRepository : BaseRepository<User, int>, IUserRepository
    {
        public UserRepository(ApplicationDbContext db) : base(db) { }
    }
}