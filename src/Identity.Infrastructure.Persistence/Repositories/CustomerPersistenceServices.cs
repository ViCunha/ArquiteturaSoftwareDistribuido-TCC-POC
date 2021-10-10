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

        public async Task<int> CreateNewCustomerAsync(Customer customer)
        {
            return await SaveAndGenerateEventSourcingAsync(customer, EventSourcingRecordType.Create);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _unitOfWork.CustomerRepository.GetAllAsync();
        }

        // TODO: How manage possible exceptions during the persistences
        private async Task<int> SaveAndGenerateEventSourcingAsync(Customer customer, EventSourcingRecordType eventSourcingRecordType)
        {
            List<int> resultOfSave = new List<int>();

            
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await _unitOfWork.CustomerRepository.AddAsync(customer);
                resultOfSave.Add(await _unitOfWork.SaveAsync());


                await _unitOfWork.EventSourcingRecordRepository.AddAsync(await GenerateEventSourcingAsync(customer, eventSourcingRecordType));
                resultOfSave.Add(await _unitOfWork.SaveAsync());
                scope.Complete();
            }

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

    }
}
