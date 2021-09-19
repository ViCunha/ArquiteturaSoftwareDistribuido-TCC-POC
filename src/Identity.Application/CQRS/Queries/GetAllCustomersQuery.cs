using Identity.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.CQRS.Queries
{
    public class GetAllCustomersQuery : IGetAllCustomersQuery
    {
        public IEnumerable<Customer> GetAllCustomers()
        {
            return new List<Customer>()
            {
                new Customer() { Id = System.Guid.NewGuid(), isActive = true, Name = "a" }
                        ,
                new Customer() { Id = System.Guid.NewGuid(), isActive = true, Name = "b" }
                        ,
                new Customer() { Id = System.Guid.NewGuid(), isActive = true, Name = "c" }
            };
        }
    }
}
