using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestRide.Graph.Repositories
{
    public interface IBaseRepository<TEntity, in TKey> where TEntity : class
    {
        Task<List<TEntity>> GetAll(
            int offset = 0, 
            int items = 25,
            string clause = "",
            string search = "", 
            string order = "");

        Task<List<TEntity>> GetAll(
            IEnumerable<string> includes, 
            int offset = 0,
            int items = 25,
            string clause = "",
            string search = "",
            string order = "");

        Task<TEntity> Get(TKey id);

        Task<TEntity> Get(TKey id, string include);

        Task<TEntity> Get(TKey id, IEnumerable<string> includes);

        TEntity Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        void Delete(TKey id);

        void Update(TEntity entity);

        Task<bool> SaveChangesAsync();

        Task<int> CountAll(
            string clause = "",
            string search = "");

        Task<int> CountAll(
            IEnumerable<string> includes,
            string clause = "",
            string search = "");
    }
}
