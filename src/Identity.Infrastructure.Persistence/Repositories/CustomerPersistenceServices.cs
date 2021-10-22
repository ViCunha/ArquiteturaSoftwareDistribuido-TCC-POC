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
    public class CustomerPersistenceServices : ICustomerPersistenceServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerPersistenceServices(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<int> CreateNewCustomerAsync(Customer customer, Guid TPCId)
        {
            return await _unitOfWork.SaveAndGenerateEventSourcingAsync<Customer>(_unitOfWork.CustomerRepository, customer, EventSourcingHistoryType.Create, TPCId);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _unitOfWork.CustomerRepository.GetAllAsync();
        }

        public async Task<Customer> GetCustomersByIdAsync(Guid id)
        {
            return await _unitOfWork.CustomerRepository.GetByIdAsync(id);
        }

        public async Task<TransactionProcessingControlHistory> GetTransactionProcessingControlByIdAsync(Guid id)
        {
            return await _unitOfWork.TransactionProcessingControlHistory.GetByIdAsync(id);
        }


    }
}
