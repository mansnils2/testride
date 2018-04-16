using GraphQL.Types;
using TestRide.Models;

namespace TestRide.Graph.Types
{
    public class MenuItemType : ObjectGraphType<MenuItem>
    {
        public MenuItemType()
        {
            Field(c => c.Id);

            Field(c => c.Order);

            Field(c => c.Title);

            Field(c => c.Link);

            Field(c => c.Icon);

            Field(c => c.Color);
        }
    }
}