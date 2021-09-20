using Identity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.CQRS.Queries
{
    public class GetAllCustomersQuery : IGetAllCustomersQuery
    {
        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await Task.Factory.StartNew
                (
                    () => new List<Customer>()
                    {
                        new Customer() { Id = Guid.NewGuid(), isActive = true, Name = "a" }
                        ,
                        new Customer() { Id = Guid.NewGuid(), isActive = true, Name = "b" }
                        ,
                        new Customer() { Id = Guid.NewGuid(), isActive = true, Name = "c" }
                    }
                );
        }
    }
}
