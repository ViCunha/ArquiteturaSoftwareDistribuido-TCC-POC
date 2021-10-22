using Identity.Domain.Interfaces;
using Identity.Domain.Models;
using Identity.Domain.Models.EventSourcing;
using Identity.Infrastructure.Persistence.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

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
