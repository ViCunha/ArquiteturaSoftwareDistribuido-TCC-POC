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
using System.Threading.Tasks;

namespace Identity.Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        //
        private bool disposed = false;

        private readonly ApplicationDbContextCommands _applicationDbContext;

        private Repository<Customer> _repositoryCustomer = null;

        private Repository<EventSourcingHistory> _repositoryEventSourcingHistory = null;

        private Repository<TransactionProcessingControlHistory> _transactionProcessingControlHistory = null;

        //
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

        public IRepository<TransactionProcessingControlHistory> TransactionProcessingControlHistory
        {
            get
            {
                if (_transactionProcessingControlHistory == null)
                {
                    _transactionProcessingControlHistory = new Repository<TransactionProcessingControlHistory>(_applicationDbContext);
                }
                return _transactionProcessingControlHistory;
            }
            private set { }
        }

        //
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


        public async Task<int> SaveAndGenerateEventSourcingGenerateTransactionProcessingControlAsync<T>(IRepository<T> repository, T entity, EventSourcingHistoryType EventSourcingHistoryType, Guid TPCId) where T : Entity
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

                            await EventSourcingHistoryRepository.AddAsync(await GenerateEventSourcingAsync<T>(entity, (byte)EventSourcingHistoryType));
                            resultOfSave.Add(await SaveAsync());

                            await TransactionProcessingControlHistory.AddAsync(await GenerateTransactionProcessingControlAsync<T>(TPCId));
                            resultOfSave.Add(await SaveAsync());

                            await transaction.CommitAsync();
                        }
                    }
                );

            return (resultOfSave.Count() == resultOfSave.Where(x => x == 1).Count()) ? 1 : 0;
        }

        private async Task<EventSourcingHistory> GenerateEventSourcingAsync<T>(T entity, Byte eventSourcingHistoryType) where T : Entity
        {
            return await Task<EventSourcingHistory>.Factory.StartNew
                (
                    () => new EventSourcingHistory
                               (
                                   Guid.NewGuid()
                                   ,
                                   DateTime.UtcNow
                                   ,
                                   eventSourcingHistoryType
                                   ,
                                   entity.Id
                                   ,
                                   entity.GetType().ToString()
                                   ,
                                   JsonConvert.SerializeObject(entity)
                               )
                );
        }

        private async Task<TransactionProcessingControlHistory> GenerateTransactionProcessingControlAsync<T>(Guid TPCId) where T : Entity
        {
            return await Task<TransactionProcessingControlHistory>.Factory.StartNew
                (
                    () => new TransactionProcessingControlHistory
                               (
                                  TPCId
                                  ,
                                  DateTime.UtcNow
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
