using Identity.Domain.Interfaces;
using Identity.Domain.Models;
using Identity.Infrastructure.Persistence.DBContext;
using Identity.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool disposed = false;

        private readonly ApplicationDbContextCommands _applicationDbContext;

        private Repository<Customer> _repositoryCustomer = null;

        public IRepository<Customer> CustomerRepository
        {
            get
            {
                if (_repositoryCustomer == null)
                {
                    _repositoryCustomer = new Repository<Customer>(_applicationDbContext);
                }
                return _repositoryCustomer;
            }
            private set { }
        }

        public UnitOfWork(ApplicationDbContextCommands applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        public int Save()
        {
            return _applicationDbContext.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _applicationDbContext.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _applicationDbContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
