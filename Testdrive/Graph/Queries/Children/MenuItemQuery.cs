using GraphQL.Types;
using TestRide.Graph.Repositories.MenuItems;
using TestRide.Graph.Types;
using TestRide.Models;

namespace TestRide.Graph.Queries.Children
{
    public class MenuItemQuery : BaseQuery<MenuItemType, MenuItem, int>
    {
        public MenuItemQuery(IMenuItemRepository repo) : base("menuItem", "menuItems", repo)
        {
            Field<ListGraphType<MenuItemType>>(
                "myMenuItems",
                resolve: context => repo.MyMenuItems());
        }
    }
}
