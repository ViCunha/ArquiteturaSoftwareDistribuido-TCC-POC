using Identity.Domain.Interfaces;
using Identity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Persistence.Interfaces
{
    public interface ICustomerPersistenceServices 
    {
        Task<IEnumerable<Customer>> GetAllCustomers();

        Task<Customer> CreateNewCustomer();
    }
}
