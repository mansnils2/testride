using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using TestRide.Graph.Models;
using TestRide.Graph.Mutations;
using TestRide.Graph.Queries;

namespace TestRide.Graph.GraphContext
{
    public class GraphContext : IGraphContext
    {
        private readonly Schema _schema;

        public GraphContext(
            ParentQuery queries,
            ParentMutation mutations)
        {
            _schema = new Schema {Query = queries, Mutation = mutations};
        }

        public Task<ExecutionResult> QueryAsync(GraphQlQuery query)
        {
            return new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = _schema;
                _.Query = query.Query;
            });
        }
    }
}
