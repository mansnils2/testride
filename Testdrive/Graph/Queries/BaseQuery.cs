using GraphQL;
using GraphQL.Types;
using Testdrive.Extensions;
using Testdrive.Graph.Repositories;

namespace Testdrive.Graph.Queries
{
    public class BaseQuery<T, TEntity, TKey> : ObjectGraphType where T : ObjectGraphType<TEntity> where TEntity : class
    {
        protected BaseQuery(string single, string multiple, IBaseRepository<TEntity, TKey> repo)
        {
            Field<T>(
                single,
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id" },
                    new QueryArgument<StringGraphType> { Name = "include" }),
                resolve: context =>
                {
                    var id = context.GetArgument<TKey>("id");
                    var include = context.GetArgument<string>("include");

                    if (include.IsEmpty()) return repo.Get(id);

                    var includes = include.Split(",");
                    return includes.Length > 1
                        ? repo.Get(id, includes)
                        : repo.Get(id, include);
                });

            Field<ListGraphType<T>>(
                multiple,
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "offset" },
                    new QueryArgument<IntGraphType> { Name = "items" },
                    new QueryArgument<StringGraphType> { Name = "where" },
                    new QueryArgument<StringGraphType> { Name = "search" },
                    new QueryArgument<StringGraphType> { Name = "order" },
                    new QueryArgument<StringGraphType> { Name = "include" }),
                resolve: context =>
                {
                    var offset = context.GetArgument<int?>("offset");
                    var items = context.GetArgument<int?>("items");

                    var where = context.GetArgument<string>("where");
                    var search = context.GetArgument<string>("search");

                    var order = context.GetArgument<string>("order");
                    var include = context.GetArgument<string>("include");

                    return include.IsEmpty()
                        ? repo.GetAll(offset ?? 0, items ?? 25, where, search, order)
                        : repo.GetAll(include.Split(","), offset ?? 0, items ?? 25, where, search, order);
                });

            Field<IntGraphType>(
                "countOf" + multiple.ToTitleCase(),
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "where" },
                    new QueryArgument<StringGraphType> { Name = "search" },
                    new QueryArgument<StringGraphType> { Name = "include" }),
                resolve: context =>
                {
                    var where = context.GetArgument<string>("where");
                    var search = context.GetArgument<string>("search");
                    var include = context.GetArgument<string>("include");

                    return include.IsEmpty()
                        ? repo.CountAll(where, search)
                        : repo.CountAll(include.Split(","), where, search);
                });
        } 
    }
}
