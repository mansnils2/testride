using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using GraphQL;
using Microsoft.EntityFrameworkCore;
using TestRide.Data;
using TestRide.Graph.Models;

namespace TestRide.Graph.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>, new()
    {
        private readonly ApplicationDbContext _db;

        protected BaseRepository(ApplicationDbContext db) => _db = db;

        private IQueryable<TEntity> GetEntities(string clause = "", string search = "", string order = "")
        {
            var entities = _db.Set<TEntity>().AsNoTracking();
            if ((clause + search + order).IsEmpty()) return entities;

            if (!clause.IsEmpty()) entities = entities.Where(clause);
            if (!order.IsEmpty()) entities = entities.OrderBy(order);

            return entities;
        }

        public virtual Task<List<TEntity>> GetAll(
            int offset = 0, 
            int items = 25,
            string where = "",
            string search = "", 
            string order = "")
        {
            return GetEntities(where, search, order)
                .Skip(offset * items)
                .Take(items)
                .ToListAsync();
        }

        public Task<List<TEntity>> GetAll(
            IEnumerable<string> includes, 
            int offset = 0, 
            int items = 25,
            string where = "",
            string search = "",
            string order = "")
        {
            var entities = GetEntities(where, search, order);
            entities = includes.Aggregate(entities, (current, include) => current.Include(include));

            return entities
                .Skip(offset * items)
                .Take(items)
                .ToListAsync();
        }

        public virtual Task<TEntity> Get(TKey id)
        {
            return _db.Set<TEntity>().SingleOrDefaultAsync(c => c.Id.Equals(id));
        }

        public Task<TEntity> Get(TKey id, string include)
        {
            return _db.Set<TEntity>().Include(include).SingleOrDefaultAsync(c => c.Id.Equals(id));
        }

        public Task<TEntity> Get(TKey id, IEnumerable<string> includes)
        {
            var query = _db.Set<TEntity>().AsQueryable();
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return query.SingleOrDefaultAsync(c => c.Id.Equals(id));
        }

        public TEntity Add(TEntity entity)
        {
            _db.Set<TEntity>().Add(entity);
            return entity;
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _db.Set<TEntity>().AddRange(entities);
        }

        public virtual void Delete(TKey id)
        {
            var entity = new TEntity { Id = id };
            _db.Set<TEntity>().Attach(entity);
            _db.Set<TEntity>().Remove(entity);
        }

        public virtual async Task<bool> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync() > 0;
        }

        public virtual void Update(TEntity entity)
        {
            _db.Set<TEntity>().Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }

        public virtual Task<int> CountAll(
            string where = "",
            string search = "")
        {
            return GetEntities(where, search).CountAsync();
        }

        public Task<int> CountAll(
            IEnumerable<string> includes,
            string where = "",
            string search = "")
        {
            var entities = GetEntities(where, search);
            entities = includes.Aggregate(entities, (current, include) => current.Include(include));

            return entities.CountAsync();
        }
    }
}
