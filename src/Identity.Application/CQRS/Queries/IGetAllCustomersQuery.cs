using Identity.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Application.CQRS.Queries
{
    public interface IGetAllCustomersQuery
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
    }
}