using Identity.Domain.Models;
using Identity.Domain.Models.EventSourcing;
using System;
using System.Threading.Tasks;

namespace Identity.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<Customer> CustomerRepository { get; }

        public IRepository<EventSourcingHistory> EventSourcingHistoryRepository { get; }

        public IRepository<TransactionProcessingControlHistory> TransactionProcessingControlHistory { get; }

        Task<int> SaveAndGenerateEventSourcingGenerateTransactionProcessingControlAsync<T>(IRepository<T> repository, T entity, EventSourcingHistoryType EventSourcingHistoryType, Guid TPCId) where T : Entity;

        int Save();

        Task<int> SaveAsync();
    }
}
