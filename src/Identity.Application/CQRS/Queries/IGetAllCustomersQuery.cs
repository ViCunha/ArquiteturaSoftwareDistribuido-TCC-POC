using Identity.Domain.Model;
using System.Collections.Generic;

namespace Identity.Application.CQRS.Queries
{
    public interface IGetAllCustomersQuery
    {
        IEnumerable<Customer> GetAllCustomers();
    }
}