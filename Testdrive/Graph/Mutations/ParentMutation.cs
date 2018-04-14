using GraphQL.Types;
using System.Collections.Generic;

namespace Testdrive.Graph.Mutations
{
    public class ParentMutation : ObjectGraphType
    {
        public ParentMutation()
        {
            var children = new List<dynamic>
            {
                
            };

            foreach (var child in children)
                foreach (var field in child.Fields)
                    AddField(field);
        }
    }
}
