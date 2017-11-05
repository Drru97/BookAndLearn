using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookAndLearn.DataAccess.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly BookAndLearnContext Context;

        public Repository(BookAndLearnContext context)
        {
            Context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await Context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task AddAsync(TEntity item)
        {
            Context.Set<TEntity>().Add(item);
            await SaveAsync();
        }

        public async Task UpdateAsync(TEntity item)
        {
            Context.Entry(item).State = EntityState.Modified;
            await SaveAsync();
        }

        public async Task DeleteAsync(TEntity item)
        {
            Context.Entry(item).State = EntityState.Deleted;
            await SaveAsync();
        }

        public async Task DeleteAsync<T>(int id) where T : class, new()
        {
            var entity = Context.Set<T>().Find(id);

            if (entity != null)
            {
                Context.Set<T>().Remove(entity);
            }

            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
