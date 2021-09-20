using Identity.Domain.Interfaces;
using Identity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Persistence.Repositories
{
    public class RepositoryCustomer : IRepositoryCustomer
    {
        private readonly IUnitOfWork _unitOfWork;

        public RepositoryCustomer(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _unitOfWork.CustomerRepository.GetAllAsync();
        }
    }
}
