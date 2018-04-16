using System.Collections.Generic;
using System.Threading.Tasks;
using TestRide.Models;

namespace TestRide.Graph.Repositories.MenuItems
{
    public interface IMenuItemRepository : IBaseRepository<MenuItem, int>
    {
        Task<List<MenuItem>> MyMenuItems();
    }
}
