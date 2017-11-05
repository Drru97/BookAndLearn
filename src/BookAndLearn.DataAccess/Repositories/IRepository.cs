using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookAndLearn.DataAccess.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(int id);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter);
        Task AddAsync(TEntity item);
        Task UpdateAsync(TEntity item);
        Task DeleteAsync(TEntity item);
        Task DeleteAsync<T>(int id) where T : class, new();
        Task SaveAsync();
    }
}
