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

        private Repository<EventSourcingRecord> _repositoryEventSourcingRecords = null;

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

        public IRepository<EventSourcingRecord> EventSourcingRecordRepository
        {
            get
            {
                if (_repositoryEventSourcingRecords == null)
                {
                    _repositoryEventSourcingRecords = new Repository<EventSourcingRecord>(_applicationDbContext);
                }
                return _repositoryEventSourcingRecords;
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


        private async Task<int> SaveTransactionsAndGenerateEventSourcingAsync<T>(IRepository<T> repository, T entity, EventSourcingRecordType eventSourcingRecordType) where T : Entity
        {
            List<int> resultOfSave = new List<int>();

            var strategy = _applicationDbContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync
                (
                    async () =>
                    {
                        using (var transaction = _applicationDbContext.Database.BeginTransaction())
                        {
                            await repository.AddAsync(entity);
                            resultOfSave.Add(await SaveAsync());

                            await EventSourcingRecordRepository.AddAsync(await GenerateEventSourcingAsync(entity, eventSourcingRecordType));
                            resultOfSave.Add(await SaveAsync());

                            await transaction.CommitAsync();
                        }
                    }
                );

            return resultOfSave.Where(x => x != 0).Count();

        }

        private async Task<EventSourcingRecord> GenerateEventSourcingAsync(Entity entity, EventSourcingRecordType eventSourcingRecordType)
        {
            return await Task<EventSourcingRecord>.Factory.StartNew
                (
                    () => new EventSourcingRecord
                               (
                                   Guid.NewGuid()
                                   ,
                                   DateTime.UtcNow
                                   ,
                                   eventSourcingRecordType
                                   ,
                                   Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(entity)).ToString()
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
