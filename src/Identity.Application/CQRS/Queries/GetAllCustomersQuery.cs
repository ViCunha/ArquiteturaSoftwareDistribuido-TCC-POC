using Identity.Domain.Models;
using Identity.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.CQRS.Queries
{
    public class GetAllCustomersQuery : IGetAllCustomersQuery
    {
        private readonly IRepositoryCustomer _repositoryCustomer;

        public GetAllCustomersQuery(IRepositoryCustomer repositoryCustomer)
        {
            this._repositoryCustomer = repositoryCustomer;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _repositoryCustomer.GetAllCustomers();
        }
    }
}
