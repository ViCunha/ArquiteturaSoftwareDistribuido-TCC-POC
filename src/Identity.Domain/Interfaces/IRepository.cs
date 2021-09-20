using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        int Count();
        Task<int> CountAsync();

        TEntity GetById(Guid id);
        Task<TEntity> GetByIdAsync(Guid id);

        IEnumerable<TEntity> GetByLambda(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetByLambdaAsync(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();

        void Add(TEntity entity);
        Task AddAsync(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);
        Task AddRangeAsync(IEnumerable<TEntity> entity);

        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity);

        void Delete(TEntity entity);
        Task DeleteAsync(TEntity entity);

        void DeleteRange(IEnumerable<TEntity> entity);
        Task DeleteRangeAsync(IEnumerable<TEntity> entity);
    }
}
