using Testdrive.Graph.Repositories.Users;
using Testdrive.Graph.Types;
using Testdrive.Models;

namespace Testdrive.Graph.Queries.Children
{
    public class UserQuery : BaseQuery<UserType, User, int>
    {
        public UserQuery(IUserRepository repo) : base("user", "users", repo) { }
    }
}
