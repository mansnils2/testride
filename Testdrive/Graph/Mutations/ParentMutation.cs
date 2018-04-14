using System.Collections.Generic;
using GraphQL.Types;
using TestRide.Graph.Mutations.Children;

namespace TestRide.Graph.Mutations
{
    public class ParentMutation : ObjectGraphType
    {
        public ParentMutation(
            TestdriveMutation testdrive)
        {
            var children = new List<dynamic>
            {
                testdrive
            };

            foreach (var child in children)
                foreach (var field in child.Fields)
                    AddField(field);
        }
    }
}
