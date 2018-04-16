using System.Collections.Generic;
using GraphQL.Types;
using TestRide.Graph.Mutations.Children;

namespace TestRide.Graph.Mutations
{
    public class ParentMutation : ObjectGraphType
    {
        public ParentMutation(
            TestdriveMutation testdrive,
            CustomerMutation customer,
            CarMutation car)
        {
            var children = new List<dynamic>
            {
                testdrive,
                customer,
                car
            };

            foreach (var child in children)
                foreach (var field in child.Fields)
                    AddField(field);
        }
    }
}
