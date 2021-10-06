using Identity.Domain.Interfaces;
using Identity.Domain.Models;
using Identity.Infrastructure.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            await _unitOfWork.CustomerRepository.AddAsync(customer);
            var result = await _unitOfWork.SaveAsync();

            return result;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _unitOfWork.CustomerRepository.GetAllAsync();
        }
    }
}
