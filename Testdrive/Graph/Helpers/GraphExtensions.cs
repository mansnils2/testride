using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using GraphQL;
using GraphQL.Types;
using TestRide.Graph.Helpers.Models;

namespace TestRide.Graph.Helpers
{
    public static class GraphExtensions
    {
        public static IEnumerable<T> ResolveFields<T>(
            this IEnumerable<T> source,
            StandardSubQueryArguments arguments)
        {
            if (arguments.Offset.HasValue && arguments.Offset > 0 && arguments.Take.HasValue && arguments.Take > 0)
                source = source.Skip((int)arguments.Offset * (int)arguments.Take);

            if (arguments.Take.HasValue && arguments.Take > 0) source = source.Take((int)arguments.Take);

            if (!arguments.Where.IsEmpty()) source = source.AsQueryable().Where(arguments.Where);
            if (!arguments.Order.IsEmpty()) source = source.AsQueryable().OrderBy(arguments.Order);

            return source;
        }

        public static StandardSubQueryArguments GetStandardSubQueryArguments<T>(this ResolveFieldContext<T> context)
        {
            var offset = context.GetArgument<int?>("offset");
            var take = context.GetArgument<int?>("take");

            var where = context.GetArgument<string>("where");
            var order = context.GetArgument<string>("order");

            return new StandardSubQueryArguments(offset, take, where, order);
        }

        public static QueryArguments GraphSubQueryArguments => new QueryArguments(
            new QueryArgument<IntGraphType> { Name = "offset" },
            new QueryArgument<IntGraphType> { Name = "take" },
            new QueryArgument<StringGraphType> { Name = "where" },
            new QueryArgument<StringGraphType> { Name = "order" });
    }
}
