using GraphQL;
using System.Threading.Tasks;
using Testdrive.Graph.Models;

namespace Testdrive.Graph.GraphContext
{
    public interface IGraphContext
    {
        Task<ExecutionResult> QueryAsync(GraphQlQuery query);
    }
}
