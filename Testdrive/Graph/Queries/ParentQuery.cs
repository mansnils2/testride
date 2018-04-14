using GraphQL.Types;
using System.Collections.Generic;
using Testdrive.Graph.Queries.Children;

namespace Testdrive.Graph.Queries
{
    public class ParentQuery : ObjectGraphType
    {
        public ParentQuery(
            FacilityQuery facilities,
            CarQuery cars,
            CustomerQuery customers,
            UserQuery users,
            TestdriveQuery testdrives)
        {
            var children = new List<dynamic>
            {
                facilities,
                cars,
                customers,
                users,
                testdrives
            };

            foreach (var child in children)
                foreach (var field in child.Fields)
                    AddField(field);
        }
    }
}
