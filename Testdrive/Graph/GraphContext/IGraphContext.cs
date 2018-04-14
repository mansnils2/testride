using System.Threading.Tasks;
using GraphQL;
using TestRide.Graph.Models;

namespace TestRide.Graph.GraphContext
{
    public interface IGraphContext
    {
        Task<ExecutionResult> QueryAsync(GraphQlQuery query);
    }
}
