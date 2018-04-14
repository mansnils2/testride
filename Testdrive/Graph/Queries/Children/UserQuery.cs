using TestRide.Graph.Repositories.Users;
using TestRide.Graph.Types;
using TestRide.Models;

namespace TestRide.Graph.Queries.Children
{
    public class UserQuery : BaseQuery<UserType, User, int>
    {
        public UserQuery(IUserRepository repo) : base("user", "users", repo) { }
    }
}
