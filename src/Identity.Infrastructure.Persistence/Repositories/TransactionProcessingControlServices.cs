using Identity.Domain.Interfaces;
using Identity.Domain.Models;
using Identity.Infrastructure.Persistence.Interfaces;
using System;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Persistence.Repositories
{
    public class TransactionProcessingControlServices : ITransactionProcessingControlServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionProcessingControlServices(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task CreateNewTransactionProcessingControlAsync(TransactionProcessingControlHistory transactionProcessingControlHistory)
        {
            await _unitOfWork.TransactionProcessingControlHistory.AddAsync(transactionProcessingControlHistory);
        }

        public async Task<TransactionProcessingControlHistory> GetTransactionProcessingControlByIdAsync(Guid id)
        {
            return await _unitOfWork.TransactionProcessingControlHistory.GetByIdAsync(id);
        }


    }
}
