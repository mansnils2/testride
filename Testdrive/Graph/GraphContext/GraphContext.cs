using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQL.Validation;
using Testdrive.Graph.Models;
using Testdrive.Graph.Mutations;
using Testdrive.Graph.Queries;

namespace Testdrive.Graph.GraphContext
{
    public class GraphContext : IGraphContext
    {
        private readonly Schema _schema;
        private readonly IValidationRule _authorization;

        public GraphContext(
            ParentQuery queries,
            ParentMutation mutations,
            IValidationRule authorization)
        {
            _schema = new Schema { Query = queries, Mutation = mutations };
            _authorization = authorization;
        }

        public Task<ExecutionResult> QueryAsync(GraphQlQuery query)
        {
            var rules = new List<IValidationRule> { _authorization };
            return new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = _schema;
                _.Query = query.Query;
                _.ValidationRules = rules;
            });
        }
    }
}
