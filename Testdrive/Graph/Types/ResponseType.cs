using GraphQL.Types;
using TestRide.Models;

namespace TestRide.Graph.Types
{
    public class ResponseType : ObjectGraphType<Response>
    {
        public ResponseType()
        {
            Field(r => r.Message);

            Field(r => r.HasError);
        }
    }
}
