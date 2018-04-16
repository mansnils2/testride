using System.Collections.Generic;
using GraphQL.Types;
using TestRide.Graph.Queries.Children;

namespace TestRide.Graph.Queries
{
    public class ParentQuery : ObjectGraphType
    {
        public ParentQuery(
            FacilityQuery facilities,
            CarQuery cars,
            CustomerQuery customers,
            UserQuery users,
            TestdriveQuery testdrives,
            MenuItemQuery menuItems)
        {
            var children = new List<dynamic>
            {
                facilities,
                cars,
                customers,
                users,
                testdrives,
                menuItems
            };

            foreach (var child in children)
                foreach (var field in child.Fields)
                    AddField(field);
        }
    }
}
