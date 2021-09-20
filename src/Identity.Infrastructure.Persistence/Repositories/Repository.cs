using Identity.Domain.Interfaces;
using Identity.Domain.Models;
using Identity.Infrastructure.Persistence.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity, IAggregateRoot
    {
        private readonly ApplicationDBContextQueries _context = null;

        private readonly DbSet<T> _dbSet;
        public Repository(ApplicationDBContextQueries context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public int Count()
        {
            return _dbSet.Count();
        }

        public async Task<int> CountAsync()
        {
            return await _dbSet.CountAsync();
        }

        public T GetById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IEnumerable<T> GetByLambda(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).AsEnumerable();
        }

        public async Task<IEnumerable<T>> GetByLambdaAsync(Expression<Func<T, bool>> predicate)
        {
            return await Task.Factory.StartNew(() => (IEnumerable<T>)_dbSet.Where(predicate));
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsEnumerable();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return (await _dbSet.ToListAsync()).AsEnumerable();
        }


        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public async Task AddRangeAsync(IEnumerable<T> entity)
        {
            await _dbSet.AddRangeAsync(entity);
        }


        public void Delete(T entity)
        {
            entity.isActive = false;
            Update(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            entity.isActive = false;
            await UpdateAsync(entity);

        }

        public void DeleteRange(IEnumerable<T> entity)
        {
            foreach (var item in entity)
            {
                Delete(item);
            }
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entity)
        {
            foreach (var item in entity)
            {
                await DeleteAsync(item);
            }
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);

        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Factory.StartNew
                    (
                        () =>
                        {
                            _dbSet.Attach(entity);
                            _context.Entry<T>(entity).State = EntityState.Modified;
                        }
                    );

        }
    }
}
