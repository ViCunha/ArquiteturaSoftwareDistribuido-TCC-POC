using Identity.Domain.Models;
using Identity.Domain.Models.EventSourcing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<Customer> CustomerRepository { get; }

        public IRepository<EventSourcingHistory> EventSourcingHistoryRepository { get; }

        Task<int> SaveAndGenerateEventSourcingAsync<T>(IRepository<T> repository, T entity, EventSourcingHistoryType EventSourcingHistoryType, Guid TPCId) where T : Entity;

        int Save();

        Task<int> SaveAsync();
    }
}
