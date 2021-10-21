using Identity.Domain.Interfaces;
using Identity.Domain.Models;
using Identity.Domain.Models.EventSourcing;
using Identity.Infrastructure.Persistence.DBContext;
using Identity.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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

        private Repository<EventSourcingHistory> _repositoryEventSourcingHistory = null;

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

        public IRepository<EventSourcingHistory> EventSourcingHistoryRepository
        {
            get
            {
                if (_repositoryEventSourcingHistory == null)
                {
                    _repositoryEventSourcingHistory = new Repository<EventSourcingHistory>(_applicationDbContext);
                }
                return _repositoryEventSourcingHistory;
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


        public async Task<int> SaveAndGenerateEventSourcingAsync<T>(IRepository<T> repository, T entity, EventSourcingHistoryType EventSourcingHistoryType) where T : Entity
        {
            var resultOfSave = new List<int>();
            var strategy = _applicationDbContext.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync
                (
                    async () =>
                    {
                        using (var transaction = _applicationDbContext.Database.BeginTransaction())
                        {
                            await repository.AddAsync(entity);
                            resultOfSave.Add(await SaveAsync());

                            await EventSourcingHistoryRepository.AddAsync(await GenerateEventSourcingAsync<T>(entity, EventSourcingHistoryType));
                            resultOfSave.Add(await SaveAsync());

                            await transaction.CommitAsync();
                        }
                    }
                );

            return (resultOfSave.Count() == resultOfSave.Where(x => x == 1).Count()) ? 1 : 0;
        }

        private async Task<EventSourcingHistory> GenerateEventSourcingAsync<T>(T entity, EventSourcingHistoryType eventSourcingHistoryType) where T : Entity
        {
            return await Task<EventSourcingHistory>.Factory.StartNew
                (
                    () => new EventSourcingHistory
                               (
                                   id: Guid.NewGuid()
                                   ,
                                   DateTime.UtcNow
                                   ,
                                   eventSourcingHistoryType
                                   ,
                                   entity.GetType().ToString()
                                   ,
                                   JsonConvert.SerializeObject(entity)
                               )
                );
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
