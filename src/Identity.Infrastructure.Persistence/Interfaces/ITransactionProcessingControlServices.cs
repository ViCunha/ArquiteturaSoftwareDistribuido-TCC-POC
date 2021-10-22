using Identity.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Persistence.Interfaces
{
    public interface ITransactionProcessingControlServices
    {
        Task CreateNewTransactionProcessingControlAsync(TransactionProcessingControlHistory transactionProcessingControlHistory);

        Task<TransactionProcessingControlHistory> GetTransactionProcessingControlByIdAsync(Guid id);
    }
}